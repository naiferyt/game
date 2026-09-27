using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Kart physics without rigidbodies: own velocity/acceleration integration, gravity (CAR_GRAVITY), ground
// following through the TriFoot (or a raycast to "Ground"), sphere-cast collisions against karts and
// props, track walls from the waypoint chain, drift / power-slide, stall and wrong-way checks.
// Source listing: recovery/aot_listings/Assembly-CSharp/CarCollider.txt
[RequireComponent(typeof(AudioSource), typeof(SoundSequencer))]
public class CarCollider : MonoBehaviour
{
	private enum EngineSoundState
	{
		NONE = 0,
		IDLE = 1,
		ACCEL = 2
	}

	private const float COLLISION_RESTITUTION = 0.3f;

	private const bool COLLISION_NOSE_JERK = false;

	public const float CAR_GRAVITY = 10f;

	public const float STALL_TIME = 3f;

	public const float STALL_DIST_EPSILON = 0.1f;

	private const int groundLayerMask = 256;

	private const int carLayerMask = 512;

	private const int collideLayerMask = 1024;

	// RECUPERADO-AOT CarCollider::.ctor token 0x060001b1 @0x000d88f4 (field initializers)
	private Vector3 lastPosition = Vector3.zero;

	private float stallTimer;

	public CartAttributes attributes = new CartAttributes();

	public bool ignoreFixedUpdate;

	private Vector3 velocity = Vector3.zero;

	private Vector3 accel = Vector3.zero;

	private bool drifting;

	public Vector3 driftVector = Vector3.zero;

	public bool ignoreGravity;

	private bool carLocked;

	private int inhibitBlockLevel;

	private bool playingTireSqueal;

	private bool initFinished;

	private bool sparks;

	private bool soundPaused;

	public WaypointLogic lastClosestWP;

	private GimpedCarAI gimpedAI;

	private float powerSlideTimer;

	private bool powerSlideQueued;

	private EffectManager carEffectMgr;

	private TriFoot triFoot;

	private SoundSequencer sequencer;

	private EngineSoundState engineSoundState;

	private AudioSource engineAudioSource;

	private GameObject lastRoadContact;

	private Vector3 lastRoadContactPos = Vector3.zero;

	private CameraShake cameraShake;

	// RECUPERADO-AOT CarCollider::get_EngineAudioSource token 0x060001b2 @0x000d8a00
	public AudioSource EngineAudioSource
	{
		get
		{
			return engineAudioSource;
		}
	}

	// RECUPERADO-AOT CarCollider::get_isCarLocked token 0x060001b3 @0x000d8a34
	// RECUPERADO-AOT CarCollider::set_isCarLocked token 0x060001b4 @0x000d8a98
	// Locked before the start (elapsedTime == -1), while paused, or when explicitly locked.
	public bool isCarLocked
	{
		get
		{
			return RaceManager.elapsedTime == -1 || RaceManager.isPaused || carLocked;
		}
		set
		{
			carLocked = value;
		}
	}

	// RECUPERADO-AOT CarCollider::get_EffectMgr token 0x060001b5 @0x000d8ad4
	public EffectManager EffectMgr
	{
		get
		{
			return carEffectMgr;
		}
	}

	// RECUPERADO-AOT CarCollider::get_isDrifting token 0x060001b6 @0x000d8b08
	public bool isDrifting
	{
		get
		{
			return drifting;
		}
	}

	// RECUPERADO-AOT CarCollider::get_PowerSlideTimer token 0x060001b7 @0x000d8b3c
	public float PowerSlideTimer
	{
		get
		{
			return powerSlideTimer;
		}
	}

	// RECUPERADO-AOT CarCollider::get_isPowerSlideQueued token 0x060001b8 @0x000d8b7c
	public bool isPowerSlideQueued
	{
		get
		{
			return powerSlideQueued;
		}
	}

	// RECUPERADO-AOT CarCollider::get_isInAir token 0x060001b9 @0x000d8bb0
	public bool isInAir
	{
		get
		{
			return lastRoadContact == null || carEffectMgr.HasEffect(typeof(GuidedJumpEffect));
		}
	}

	// RECUPERADO-AOT CarCollider::OnEnable token 0x060001ba @0x000d8c28
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	private void OnEnable()
	{
		initFinished = false;
		RaceManager.raceInitFinishedEvent += RaceInitFinished;
		if (cameraShake == null)
		{
			cameraShake = U4Compat.FindObjectOfType(typeof(CameraShake)) as CameraShake;
		}
	}

	// RECUPERADO-AOT CarCollider::OnDisable token 0x060001bb @0x000d8d24
	private void OnDisable()
	{
		initFinished = false;
		RaceManager.raceInitFinishedEvent -= RaceInitFinished;
	}

	// RECUPERADO-AOT CarCollider::CarUpdatePump token 0x060001bc @0x000d8db4
	// RECUPERADO-AOT CarCollider/<CarUpdatePump>c__Iterator1C::MoveNext token 0x06000878 @0x00145370
	// Slow update (every 0.25 s, staggered): wrong-way check for the player, stall and catch-up checks.
	[DebuggerHidden]
	private IEnumerator CarUpdatePump()
	{
		yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
		while (true)
		{
			yield return new WaitForSeconds(0.25f);
			if (RaceManager.IsPlayerCar(base.gameObject))
			{
				DoWrongWayCheck();
			}
			if (!isCarLocked)
			{
				CheckForStall(0.25f);
				CheckForCatchUp();
			}
		}
	}

	// RECUPERADO-AOT CarCollider::Start token 0x060001bd @0x000d8dfc
	// Sets up the one-shot audio source plus a looping engine source, the TriFoot (cast mask 1280 =
	// Ground | Collide) and the "Cars" layer, then starts the slow update pump.
	// ADAPTADO-U6: Component.audio -> GetComponent<AudioSource>(); AddComponent(Type) -> AddComponent<T>().
	private void Start()
	{
		gimpedAI = base.gameObject.GetComponent<GimpedCarAI>();
		sequencer = base.gameObject.GetComponent<SoundSequencer>();
		AudioSource component = GetComponent<AudioSource>();
		if ((bool)component)
		{
			component.playOnAwake = false;
			component.rolloffMode = AudioRolloffMode.Linear;
			component.maxDistance = 40f;
			component.volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
			component.enabled = true;
		}
		engineAudioSource = base.gameObject.AddComponent<AudioSource>();
		engineAudioSource.playOnAwake = false;
		engineAudioSource.rolloffMode = AudioRolloffMode.Linear;
		engineAudioSource.maxDistance = 40f;
		engineAudioSource.loop = true;
		engineAudioSource.volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
		engineAudioSource.enabled = true;
		engineAudioSource.priority = 127;
		GetComponent<AudioSource>().priority = 128;
		sequencer.SetPriority(128);
		stallTimer = 3f;
		carEffectMgr = GetComponent<EffectManager>();
		triFoot = GetComponent<TriFoot>();
		if (triFoot == null)
		{
			triFoot = base.gameObject.AddComponent<TriFoot>();
		}
		triFoot.castMask = 1280;
		base.gameObject.layer = LayerMask.NameToLayer("Cars");
		StartCoroutine(CarUpdatePump());
	}

	// RECUPERADO-AOT CarCollider::PauseSounds token 0x060001be @0x000d91f4
	// ADAPTADO-U6: Component.audio -> GetComponent<AudioSource>().
	public void PauseSounds(bool pause)
	{
		if (pause)
		{
			engineAudioSource.Pause();
			GetComponent<AudioSource>().Pause();
			soundPaused = true;
		}
		else
		{
			engineAudioSource.Play();
			GetComponent<AudioSource>().Play();
			soundPaused = false;
		}
	}

	// RECUPERADO-AOT CarCollider::Update token 0x060001bf @0x000d928c
	// Follows the pause state, fires a queued power-slide boost once the drift ends, and drives the engine
	// sound (idle at <= 2 u/s, otherwise pitch = max(1, speed * 5 / maxSpeed)).
	private void Update()
	{
		lastClosestWP = null;
		if (RaceManager.isPaused && !soundPaused)
		{
			PauseSounds(true);
		}
		else if (!RaceManager.isPaused && soundPaused)
		{
			PauseSounds(false);
		}
		if (RaceManager.isPaused)
		{
			return;
		}
		if (carEffectMgr != null && !drifting && powerSlideQueued)
		{
			powerSlideQueued = false;
			BoosterEffect boosterEffect = new BoosterEffect(base.gameObject);
			boosterEffect.power = Mathf.FloorToInt(attributes.powerSlidePower);
			boosterEffect.time = attributes.powerSlideDuration;
			carEffectMgr.AddEffect(boosterEffect);
			powerSlideTimer = 0f;
			CarMetrics component = GetComponent<CarMetrics>();
			if (component != null)
			{
				component.Signal("PowerSlide Boost");
			}
		}
		if (!RaceManager.IsPlayerCar(base.gameObject))
		{
			gimpedAI = base.gameObject.GetComponent<GimpedCarAI>();
		}
		float num = ((!(gimpedAI == null)) ? gimpedAI.LinearVelocity : velocity.magnitude);
		if (num <= 2f)
		{
			SetEngineSoundState(EngineSoundState.IDLE);
			engineAudioSource.pitch = 1f;
			return;
		}
		SetEngineSoundState(EngineSoundState.ACCEL);
		float num2 = num * 5f / attributes.maxSpeed;
		engineAudioSource.pitch = ((!(num2 < 1f)) ? num2 : 1f);
	}

	// RECUPERADO-AOT CarCollider::FixedUpdate token 0x060001c0 @0x000d95d8
	private void FixedUpdate()
	{
		if (ignoreFixedUpdate || RaceManager.isPaused)
		{
			return;
		}
		bool flag = isCarLocked;
		DoPowerSlideCheck();
		DoTireDrag();
		if (!ignoreGravity)
		{
			DoGroundCollision();
		}
		if (!flag)
		{
			DoAcceleration();
			if (QualityControl.DoPerFrameCollision)
			{
				DoMovement();
			}
			else
			{
				DoGimpedMovement();
			}
		}
		DoRoadBoundaries();
	}

	// RECUPERADO-AOT CarCollider::CheckForCatchUp token 0x060001c1 @0x000d9688
	// When the car ahead is further than HUDLogic.catchupDistance along the track, the player gets the
	// catch-up notice and an AI kart gets a free booster.
	private void CheckForCatchUp()
	{
		int num = RaceManager.GetCarPosition(base.gameObject) - 1;
		if (num > 0)
		{
			GameObject carInPosition = RaceManager.GetCarInPosition(num);
			if (carInPosition != null)
			{
				float num2 = WaypointLogic.GetTrackDistanceForPoint(carInPosition.transform.position) - WaypointLogic.GetTrackDistanceForPoint(base.gameObject.transform.position);
				if (HUDLogic.Instance.catchupDistance < num2)
				{
					if (RaceManager.IsPlayerCar(base.gameObject))
					{
						HUDLogic.Instance.CatchUpNeeded = true;
						return;
					}
					BoosterEffect newEffect = (BoosterEffect)BaseEffect.GetEffectInstance(BaseEffect.EffectTypes.BoosterEffect, base.gameObject);
					EffectManager component = base.gameObject.GetComponent<EffectManager>();
					if (component != null)
					{
						component.AddEffect(newEffect);
					}
					return;
				}
			}
		}
		HUDLogic.Instance.CatchUpNeeded = false;
	}

	// RECUPERADO-AOT CarCollider::ApplyAcceleration token 0x060001c2 @0x000d9884
	public void ApplyAcceleration(float value)
	{
		if (!(lastRoadContact == null) && !isCarLocked)
		{
			if (!drifting)
			{
				accel = base.transform.forward * value * GetActualAcceleration();
			}
			else
			{
				accel = driftVector * value * GetActualAcceleration();
			}
		}
	}

	// RECUPERADO-AOT CarCollider::ApplyTurning token 0x060001c3 @0x000d99f8
	public void ApplyTurning(float value)
	{
		if (lastRoadContact == null || isCarLocked || InputBlocked())
		{
			return;
		}
		float num = value * attributes.turnRate;
		if (drifting && !isInAir)
		{
			num *= attributes.driftTurnMult;
		}
		num *= Time.deltaTime;
		base.transform.Rotate(0f, num, 0f);
		AnimationDriver component = base.gameObject.GetComponent<AnimationDriver>();
		if (component != null)
		{
			component.turnFactor = Mathf.Clamp(value, -1f, 1f);
		}
		if (Mathf.Abs(value) > 0.5f)
		{
			MissionManager component2 = base.gameObject.GetComponent<MissionManager>();
			if (component2 != null)
			{
				component2.Signal("Turning");
			}
		}
	}

	// RECUPERADO-AOT CarCollider::ApplyDrift token 0x060001c4 @0x000d9c78
	// Entering a drift freezes the heading; leaving it snaps the velocity back onto the kart's forward.
	public void ApplyDrift(bool state)
	{
		if (state)
		{
			if (!drifting)
			{
				driftVector = base.transform.forward;
			}
		}
		else if (drifting)
		{
			velocity = base.transform.forward * velocity.magnitude;
		}
		drifting = state;
	}

	// RECUPERADO-AOT CarCollider::RaceInitFinished token 0x060001c5 @0x000d9d74
	public void RaceInitFinished()
	{
		initFinished = true;
		SetupAudioStuff();
	}

	// RECUPERADO-AOT CarCollider::SetEngineSoundState token 0x060001c6 @0x000d9db0
	private void SetEngineSoundState(EngineSoundState state)
	{
		if (!initFinished || engineSoundState == state)
		{
			return;
		}
		engineAudioSource.Stop();
		engineSoundState = state;
		if (state != EngineSoundState.NONE)
		{
			AudioClip clip = SoundLibrary.GetClip(attributes.engineSoundString + "engineIdle");
			if (clip != null)
			{
				engineAudioSource.clip = clip;
				engineAudioSource.Play();
			}
		}
	}

	// RECUPERADO-AOT CarCollider::GetActualAcceleration token 0x060001c7 @0x000d9e8c
	// Scaled by the strongest booster (+power%) and slowdown (-power%).
	public float GetActualAcceleration()
	{
		float num = attributes.acceleration;
		if (carEffectMgr != null)
		{
			float num2 = 1f + (float)carEffectMgr.GetHighestPoweredEffect(typeof(BoosterEffect)) / 100f;
			float num3 = 1f - (float)carEffectMgr.GetHighestPoweredEffect(typeof(SlowdownEffect)) / 100f;
			if (num2 > 0f)
			{
				num *= num2;
			}
			if (num3 != 1f)
			{
				num *= num3;
			}
		}
		return num;
	}

	// RECUPERADO-AOT CarCollider::GetActualCollisionMass token 0x060001c8 @0x000da03c
	// (The effect-manager check has no effect on the multiplier in the original.)
	private float GetActualCollisionMass()
	{
		float num = 1f;
		if (carEffectMgr != null)
		{
		}
		return attributes.mass * num;
	}

	// RECUPERADO-AOT CarCollider::GetActualCollisionRestitution token 0x060001c9 @0x000da0b8
	private float GetActualCollisionRestitution()
	{
		float num = 1f;
		if (carEffectMgr != null)
		{
		}
		return 0.3f * num;
	}

	// RECUPERADO-AOT CarCollider::GetActualMaxSpeed token 0x060001ca @0x000da134
	public float GetActualMaxSpeed()
	{
		float num = attributes.maxSpeed;
		if (carEffectMgr != null)
		{
			float num2 = 1f + (float)carEffectMgr.GetHighestPoweredEffect(typeof(BoosterEffect)) / 100f;
			float num3 = 1f - (float)carEffectMgr.GetHighestPoweredEffect(typeof(SlowdownEffect)) / 100f;
			if (num2 > 0f)
			{
				num *= num2;
			}
			if (num3 != 1f)
			{
				num *= num3;
			}
		}
		return num;
	}

	// RECUPERADO-AOT CarCollider::GetActualHandling token 0x060001cb @0x000da2e4
	public float GetActualHandling()
	{
		float num = attributes.handling;
		if (carEffectMgr != null && carEffectMgr.HasEffect(typeof(SkidEffect)))
		{
			num *= 0.5f;
		}
		return num;
	}

	// RECUPERADO-AOT CarCollider::DoGroundCollision token 0x060001cc @0x000da394
	// Snaps to the TriFoot ground point (or a downward raycast when there is no TriFoot) and aligns to
	// the surface; otherwise falls at CAR_GRAVITY and noses down unless flipping.
	// ADAPTADO-U6: RaycastHit.collider as in U4 (same API).
	private void DoGroundCollision()
	{
		float num = 10f * Time.deltaTime;
		float num2 = velocity.y * Time.deltaTime;
		if (triFoot != null)
		{
			if ((triFoot.groundPoint - base.transform.position).magnitude < num + attributes.groundHeight * 2f - num2)
			{
				if (lastRoadContact == null && cameraShake != null && RaceManager.IsPlayerCar(base.gameObject))
				{
					cameraShake.TurnOnShake(0.5f, 0.1f);
					SoundSequencer component = base.gameObject.GetComponent<SoundSequencer>();
					if (component != null)
					{
						component.RequestPlay("Jump Land");
					}
				}
				lastRoadContact = base.gameObject;
				lastRoadContactPos = base.transform.position;
				Vector3 position = base.transform.position;
				base.transform.position = new Vector3(position.x, triFoot.groundPoint.y + attributes.groundHeight, position.z);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(triFoot.forward, triFoot.up), Time.deltaTime * 10f);
			}
			else
			{
				lastRoadContact = null;
				base.transform.position = base.transform.position + Vector3.down * num;
				if (carEffectMgr != null && !carEffectMgr.HasEffect(typeof(FlipEffect)))
				{
					base.transform.forward = Vector3.Lerp(base.transform.forward, Vector3.down, Time.deltaTime);
				}
			}
			return;
		}
		RaycastHit hitInfo;
		if (Physics.Raycast(base.gameObject.transform.position, Vector3.down, out hitInfo, num - num2 + attributes.groundHeight, 256))
		{
			if (lastRoadContact == null && cameraShake != null && RaceManager.IsPlayerCar(base.gameObject))
			{
				cameraShake.TurnOnShake(0.5f, 0.1f);
			}
			lastRoadContact = hitInfo.collider.gameObject;
			lastRoadContactPos = base.transform.position;
			base.gameObject.transform.position = hitInfo.point + Vector3.up * attributes.groundHeight;
			Vector3 forward = -Vector3.Cross(hitInfo.normal, base.transform.right);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.LookRotation(forward, hitInfo.normal), Time.deltaTime * 10f);
		}
		else
		{
			lastRoadContact = null;
			base.gameObject.transform.position = base.gameObject.transform.position + Vector3.down * num;
			if (carEffectMgr != null && !carEffectMgr.HasEffect(typeof(FlipEffect)))
			{
				base.transform.forward = Vector3.Lerp(base.transform.forward, Vector3.down, Time.deltaTime);
			}
		}
	}

	// RECUPERADO-AOT CarCollider::DoAcceleration token 0x060001cd @0x000daed4
	// Coasts down with no throttle (on the ground) or above top speed; otherwise integrates the
	// acceleration, clamps to the actual max speed and consumes it.
	private void DoAcceleration()
	{
		if (accel.sqrMagnitude == 0f && lastRoadContact != null)
		{
			velocity -= velocity * attributes.coastDown * Time.deltaTime;
			return;
		}
		float actualMaxSpeed = GetActualMaxSpeed();
		if (velocity.magnitude >= actualMaxSpeed)
		{
			if (lastRoadContact != null)
			{
				velocity -= velocity * attributes.coastDown * Time.deltaTime;
			}
			return;
		}
		velocity += accel * Time.deltaTime;
		if (velocity.sqrMagnitude > actualMaxSpeed * actualMaxSpeed)
		{
			velocity = velocity.normalized * actualMaxSpeed;
		}
		accel = Vector3.zero;
	}

	// RECUPERADO-AOT CarCollider::DoMovement token 0x060001ce @0x000db288
	// Sphere-casts the frame's displacement against Cars | Collide (1536). Kart hits: with the (always on)
	// dummied player collision the kart is pushed back and skids unless shielded, the other AI gets bumped;
	// smash/shield combinations flip either kart. Prop hits: CollideBreak message, slide along the surface.
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>(); FindChild -> Find; sweep without triggers or initial overlaps (below).
	private void DoMovement()
	{
		Vector3 vector = velocity * Time.deltaTime;
		float actualCollisionMass = GetActualCollisionMass();
		float actualCollisionRestitution = GetActualCollisionRestitution();
		bool flag = carEffectMgr.HasEffect(typeof(ShieldEffect));
		bool flag2 = carEffectMgr.HasEffectOfLevel(typeof(ShieldEffect), 2);
		bool flag3 = carEffectMgr.HasEffect(typeof(SmashEffect));
		// ADAPTADO-U6: QueryTriggerInteraction.Ignore. PhysX 2.8 sweeps never reported trigger shapes, but Unity 5.2+
		// applies queriesHitTriggers (on in this project, as Unity 4's raycastsHitTriggers) to sweeps too: the kart
		// stopped dead in front of hazard triggers on the Collide layer (Doof's Tower robot laser, 45 -> 5) and
		// brushed the ResetTrigger volumes under the road.
		RaycastHit[] array = Physics.SphereCastAll(base.gameObject.transform.position, GetComponent<Collider>().bounds.size.x, vector.normalized, vector.magnitude, 1536, QueryTriggerInteraction.Ignore);
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit raycastHit = array[i];
			// ADAPTADO-U6: Unity 4's PhysX 2.8 sweeps never reported colliders the sphere already overlapped at the
			// start; Unity 5+ returns them with distance 0 and point (0,0,0). This code takes the contact normal as
			// (position - point), so each overlapped collider would brake the kart every frame in a direction
			// pointing away from the world origin: karts crawled up the Kick Butt 1 ramp (the sweep sphere sits
			// inside the Collide block under the slope) and stuck on kerbs. Initial overlaps are skipped as in U4.
			if (raycastHit.distance == 0f && raycastHit.point == Vector3.zero)
			{
				continue;
			}
			GameObject gameObject = raycastHit.transform.gameObject;
			if (gameObject == base.gameObject)
			{
				continue;
			}
			CarCollider component = gameObject.GetComponent<CarCollider>();
			if ((bool)component)
			{
				EffectManager component2 = component.GetComponent<EffectManager>();
				bool flag4 = component2.HasEffect(typeof(ShieldEffect));
				bool flag5 = component2.HasEffectOfLevel(typeof(ShieldEffect), 2);
				bool flag6 = component2.HasEffect(typeof(SmashEffect));
				if (QualityControl.DoDummiedPlayerCollision)
				{
					if (!flag)
					{
						Vector3 vector2 = component.transform.position - base.transform.position;
						velocity -= vector2;
						carEffectMgr.AddEffect(new SkidEffect(base.gameObject));
						GimpedCarAI component3 = component.GetComponent<GimpedCarAI>();
						if (component3 != null)
						{
							component3.Bump(vector2);
						}
					}
				}
				else
				{
					// Full impulse response (unused: DoDummiedPlayerCollision is always true).
					float actualCollisionMass2 = component.GetActualCollisionMass();
					Vector3 normalized = (gameObject.transform.position - base.transform.position).normalized;
					Vector3 lhs = velocity - component.velocity;
					Vector3 vector3 = (1f + actualCollisionRestitution) * normalized * Vector3.Dot(lhs, normalized) / (1f / actualCollisionMass + 1f / actualCollisionMass2);
					if (!flag4)
					{
						if (!QualityControl.DoFullAI)
						{
							GimpedCarAI component4 = gameObject.GetComponent<GimpedCarAI>();
							if (component4 != null)
							{
								component4.Bump(vector3 * (1f / actualCollisionMass2));
							}
						}
						else
						{
							component.velocity += vector3 * (1f / actualCollisionMass2);
						}
					}
					if (flag)
					{
						velocity -= vector3 * (1f / actualCollisionMass);
						vector -= normalized * GetComponent<Collider>().bounds.size.x * component.GetComponent<Collider>().bounds.size.x * Time.deltaTime;
					}
				}
				if ((flag6 && !flag) || (flag3 && flag5))
				{
					carEffectMgr.AddEffect(new FlipEffect(base.gameObject));
				}
				if ((flag3 && !flag4) || (flag6 && flag2))
				{
					component2.AddEffect(new FlipEffect(component.gameObject));
					CarMetrics component5 = GetComponent<CarMetrics>();
					if (RaceManager.IsPlayerCar(base.gameObject) && component5 != null)
					{
						component5.Signal("SmashEffect success");
						if (isInAir)
						{
							component5.Signal("Powerup hit in air");
						}
					}
					LifetimeMetrics.Signal("Lifetime SmashEffect success");
				}
				if (RaceManager.IsPlayerCar(base.gameObject) && carEffectMgr != null && base.transform.Find("Collision Particle Effect") == null)
				{
					GameObject gameObject2 = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Collision"), base.transform.position, base.transform.rotation) as GameObject;
					gameObject2.transform.parent = base.transform;
					gameObject2.name = "Collision Particle Effect";
				}
			}
			else
			{
				CarMetrics component6 = GetComponent<CarMetrics>();
				if (component6 != null && !isInAir)
				{
					if (component6.otherMetrics.ContainsKey("Max Crash Speed"))
					{
						if (component6.otherMetrics["Max Crash Speed"] < velocity.magnitude)
						{
							component6.otherMetrics["Max Crash Speed"] = velocity.magnitude;
						}
					}
					else
					{
						component6.otherMetrics.Add("Max Crash Speed", velocity.magnitude);
					}
				}
				raycastHit.collider.gameObject.SendMessage("CollideBreak", velocity.magnitude, SendMessageOptions.DontRequireReceiver);
				Vector3 normalized2 = (base.transform.position - raycastHit.point).normalized;
				vector -= normalized2 * Vector3.Dot(velocity, normalized2) * Time.deltaTime;
				velocity -= normalized2 * Vector3.Dot(velocity, normalized2);
				if (cameraShake != null && RaceManager.IsPlayerCar(base.gameObject))
				{
					cameraShake.TurnOnShake(0.5f, 0.1f);
				}
			}
			PlayRandomCollisionSound();
		}
		lastPosition = base.gameObject.transform.position;
		base.gameObject.transform.position = base.gameObject.transform.position + vector;
	}

	// RECUPERADO-AOT CarCollider::PlayRandomCollisionSound token 0x060001cf @0x000dc600
	private void PlayRandomCollisionSound()
	{
		string clipName = "collision " + Random.Range(0, 3).ToString();
		if (sequencer != null)
		{
			sequencer.RequestPlay(clipName);
		}
	}

	// RECUPERADO-AOT CarCollider::DoGimpedMovement token 0x060001d0 @0x000dc6a4
	private void DoGimpedMovement()
	{
		Vector3 vector = velocity * Time.deltaTime;
		lastPosition = base.gameObject.transform.position;
		base.gameObject.transform.position = base.gameObject.transform.position + vector;
	}

	// RECUPERADO-AOT CarCollider::CheckForStall token 0x060001d1 @0x000dc7cc
	// Less than 0.1 units of horizontal progress for STALL_TIME seconds puts the kart back on the track.
	private void CheckForStall(float detla)
	{
		Vector3 position = base.transform.position;
		Vector2 vector = new Vector2(position.x, position.z) - new Vector2(lastPosition.x, lastPosition.z);
		if (vector.magnitude < 0.1f)
		{
			stallTimer -= detla;
			if (stallTimer <= 0f)
			{
				DoResetCarOnTrack(false);
				stallTimer = 3f;
			}
		}
		else
		{
			stallTimer = 3f;
		}
	}

	// RECUPERADO-AOT CarCollider::DoResetCarOnTrack token 0x060001d2 @0x000dca14
	public void DoResetCarOnTrack(bool gap)
	{
		DoResetCarOnTrack(gap, Vector3.zero);
	}

	// RECUPERADO-AOT CarCollider::DoResetCarOnTrack token 0x060001d3 @0x000dca68
	// Puts the kart at spawnPos, or on the closest waypoint's track line facing the next waypoint; AI
	// karts drop their current states. (The closest speed point is looked up but unused, as in the original.)
	public void DoResetCarOnTrack(bool gap, Vector3 spawnPos)
	{
		if (spawnPos != Vector3.zero)
		{
			base.gameObject.transform.position = new Vector3(spawnPos.x, spawnPos.y + attributes.groundHeight, spawnPos.z);
		}
		else
		{
			SpeedPoint.FindClosestSpeedPoint(base.gameObject.transform.position);
			WaypointLogic waypointLogic = WaypointLogic.FindClosestWaypoint(base.transform.position, false);
			Vector3 trackPoint = waypointLogic.GetTrackPoint(base.transform.position);
			trackPoint.y += attributes.groundHeight;
			base.transform.position = trackPoint;
			base.transform.forward = (waypointLogic.forwardPoint.transform.position - waypointLogic.transform.position).normalized;
		}
		if (!RaceManager.IsPlayerCar(base.gameObject))
		{
			CarAI component = base.gameObject.GetComponent<CarAI>();
			if (component != null)
			{
				component.ClearStates();
			}
		}
	}

	// RECUPERADO-AOT CarCollider::DoTireDrag token 0x060001d4 @0x000dcddc
	// Bends the velocity toward the kart's heading; much weaker while drifting on the ground.
	private void DoTireDrag()
	{
		Vector3 b = base.transform.forward * velocity.magnitude;
		float num = Time.deltaTime * GetActualHandling();
		if (drifting && !isInAir)
		{
			num *= attributes.driftTireDragMult;
		}
		velocity = Vector3.Lerp(velocity, b, num);
	}

	// RECUPERADO-AOT CarCollider::DoRoadBoundaries token 0x060001d5 @0x000dcf30
	// Keeps the kart inside the waypoint walls: when its horizontal distance from the track line plus its
	// width reaches the wall distance, the outward velocity is removed and it is pushed back inside. With no
	// waypoint and no ground below, it is moved back to the last road contact and stopped.
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	private void DoRoadBoundaries()
	{
		if (lastClosestWP == null)
		{
			lastClosestWP = WaypointLogic.FindClosestWaypoint(base.transform.position, false);
		}
		WaypointLogic waypointLogic = lastClosestWP;
		if (waypointLogic == null)
		{
			if (lastRoadContact == null && !Physics.Raycast(base.transform.position, Vector3.down, 256f))
			{
				base.transform.position = lastRoadContactPos - velocity.normalized * GetComponent<Collider>().bounds.size.x;
				accel = Vector3.zero;
				velocity = Vector3.zero;
			}
			return;
		}
		Vector3 trackPoint = waypointLogic.GetTrackPoint(base.transform.position);
		Vector3 wallOffsetForPoint = waypointLogic.GetWallOffsetForPoint(base.transform.position);
		Vector3 vector = trackPoint + wallOffsetForPoint - base.transform.position;
		vector.y = 0f;
		float magnitude = vector.magnitude;
		float wallDistanceAtPoint = waypointLogic.GetWallDistanceAtPoint(base.transform.position);
		if (!waypointLogic.projectsWalls || magnitude + GetComponent<Collider>().bounds.size.x < wallDistanceAtPoint)
		{
			return;
		}
		CarMetrics component = GetComponent<CarMetrics>();
		if (component != null)
		{
			if (component.otherMetrics.ContainsKey("Max Crash Speed"))
			{
				if (component.otherMetrics["Max Crash Speed"] < velocity.magnitude)
				{
					component.otherMetrics["Max Crash Speed"] = velocity.magnitude;
				}
			}
			else
			{
				component.otherMetrics.Add("Max Crash Speed", velocity.magnitude);
			}
		}
		vector.Normalize();
		velocity -= vector * Vector3.Dot(velocity, vector);
		Vector3 vector2 = trackPoint + wallOffsetForPoint - vector * (wallDistanceAtPoint - GetComponent<Collider>().bounds.size.x);
		base.transform.position = new Vector3(vector2.x, base.transform.position.y, vector2.z);
		PlayRandomCollisionSound();
		if (cameraShake != null && RaceManager.IsPlayerCar(base.gameObject))
		{
			cameraShake.TurnOnShake(0.45f, 0.1f);
		}
	}

	// RECUPERADO-AOT CarCollider::DoPowerSlideCheck token 0x060001d6 @0x000dd834
	// While drifting at an angle between powerSlideAngle/2 and 90 degrees the power-slide timer charges
	// (x1.5 per second, grounded only) with sparks; reaching secondsToPowerSlide queues a boost for when
	// the drift ends, reaching driftTooLong wipes the kart out. The player's kart shows the
	// "PowerSlide" particles while sparking.
	// ADAPTADO-U6: FindChild -> Find.
	private void DoPowerSlideCheck()
	{
		float num = 0f;
		if (velocity.sqrMagnitude > 0f)
		{
			num = Vector3.Angle(base.transform.forward, velocity);
		}
		if (carEffectMgr.HasEffect(typeof(WipeoutEffect)) || carEffectMgr.HasEffect(typeof(FlipEffect)))
		{
			powerSlideTimer = 0f;
			sparks = false;
			num = 0f;
			powerSlideQueued = false;
		}
		if (drifting && num >= attributes.powerSlideAngle / 2f && num < 90f)
		{
			if (!carEffectMgr.HasEffect(typeof(WipeoutEffect)) && !carEffectMgr.HasEffect(typeof(FlipEffect)) && !isInAir)
			{
				powerSlideTimer += Time.deltaTime * 1.5f;
				sparks = true;
			}
			if (sequencer != null && !playingTireSqueal)
			{
				playingTireSqueal = true;
				sequencer.RequestPlayLoop("brakes");
			}
			if (powerSlideTimer >= attributes.driftTooLong)
			{
				sparks = true;
				if (carEffectMgr != null)
				{
					WipeoutEffect newEffect = (WipeoutEffect)BaseEffect.GetEffectInstance(BaseEffect.EffectTypes.WipeoutEffect, base.gameObject);
					carEffectMgr.AddEffect(newEffect);
					powerSlideTimer = 0f;
				}
			}
			else if (powerSlideTimer >= attributes.secondsToPowerSlide)
			{
				powerSlideQueued = true;
				sparks = false;
			}
		}
		else
		{
			powerSlideTimer = 0f;
			sparks = false;
			if (sequencer != null)
			{
				playingTireSqueal = false;
				sequencer.StopLoopingSound("brakes");
			}
		}
		if (!RaceManager.IsPlayerCar(base.gameObject))
		{
			return;
		}
		EffectManager component = GetComponent<EffectManager>();
		if (sparks)
		{
			if (component.transform.Find("Drift Particle Effect") == null)
			{
				GameObject gameObject = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("PowerSlide"), base.transform.position, base.transform.rotation) as GameObject;
				gameObject.transform.parent = base.transform;
				gameObject.name = "Drift Particle Effect";
			}
		}
		else
		{
			Transform transform = component.transform.Find("Drift Particle Effect");
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
		}
	}

	// RECUPERADO-AOT CarCollider::DoWrongWayCheck token 0x060001d7 @0x000dde4c
	// Facing more than 105 degrees away from the track direction (and not wiping out) raises the HUD's
	// wrong-way notice once; otherwise it is cleared.
	private void DoWrongWayCheck()
	{
		WaypointLogic waypointLogic = WaypointLogic.FindNextWaypoint(base.gameObject.transform.position);
		if (waypointLogic == null || waypointLogic.backwardPoint == null)
		{
			return;
		}
		Vector3 to = waypointLogic.transform.position - waypointLogic.backwardPoint.transform.position;
		if (Vector3.Angle(base.transform.forward, to) > 105f && !carEffectMgr.HasEffect(typeof(WipeoutEffect)))
		{
			if (!HUDLogic.Instance.WrongWay)
			{
				HUDLogic.Instance.WrongWay = true;
				StartCoroutine(HUDLogic.Instance.DoWrongWayNotice());
			}
		}
		else
		{
			HUDLogic.Instance.WrongWay = false;
		}
	}

	// RECUPERADO-AOT CarCollider::GetVelocity token 0x060001d8 @0x000de070
	public Vector3 GetVelocity()
	{
		return velocity;
	}

	// RECUPERADO-AOT CarCollider::TransformVelocity token 0x060001d9 @0x000de0dc
	public void TransformVelocity(Vector3 trans)
	{
		velocity += trans;
	}

	// RECUPERADO-AOT CarCollider::GetAccel token 0x060001da @0x000de180
	public Vector3 GetAccel()
	{
		return accel;
	}

	// RECUPERADO-AOT CarCollider::DecrementInputBlock token 0x060001db @0x000de1ec
	public void DecrementInputBlock()
	{
		inhibitBlockLevel--;
	}

	// RECUPERADO-AOT CarCollider::IncrementInputBlock token 0x060001dc @0x000de228
	public void IncrementInputBlock()
	{
		inhibitBlockLevel++;
	}

	// RECUPERADO-AOT CarCollider::InputBlocked token 0x060001dd @0x000de264
	public bool InputBlocked()
	{
		return inhibitBlockLevel > 0;
	}

	// RECUPERADO-AOT CarCollider::IsShielded token 0x060001de @0x000de2a4
	public bool IsShielded()
	{
		if ((bool)carEffectMgr)
		{
			return carEffectMgr.HasEffect(typeof(ShieldEffect));
		}
		return false;
	}

	// RECUPERADO-AOT CarCollider::OnDrawGizmos token 0x060001df @0x000de310
	// Velocity in blue, power-slide angle limits in yellow.
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(base.transform.position, base.transform.position + velocity);
		Gizmos.color = Color.yellow;
		Quaternion quaternion = Quaternion.Euler(0f, attributes.powerSlideAngle, 0f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + quaternion * base.transform.forward);
		quaternion = Quaternion.Euler(0f, 0f - attributes.powerSlideAngle, 0f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + quaternion * base.transform.forward);
	}

	// RECUPERADO-AOT CarCollider::SetupAudioStuff token 0x060001e0 @0x000de680
	// The player's kart gets top audio priority.
	// ADAPTADO-U6: Component.audio -> GetComponent<AudioSource>().
	private void SetupAudioStuff()
	{
		if (engineAudioSource != null && RaceManager.IsPlayerCar(base.gameObject))
		{
			GetComponent<AudioSource>().priority = 0;
			engineAudioSource.priority = 1;
			if (sequencer != null)
			{
				sequencer.SetPriority(0);
			}
		}
	}
}
