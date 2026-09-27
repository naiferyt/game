using UnityEngine;

// Homing rocket fired by RocketEffect/RocketRideEffect/BoatAnchorEffect: pops up out of the kart for
// launchTimer seconds, then follows the waypoints until its target is within 30 m and dives on it.
// Source listing: recovery/aot_listings/Assembly-CSharp/RocketAI.txt
[RequireComponent(typeof(SoundSequencer))]
public class RocketAI : MonoBehaviour
{
	private const float MAX_VELOCITY = 100f;

	private const float ACCELERATION = 200f;

	private const float CYCLE_WP_DISTANCE_SQR = 25f;

	private const float HUNT_DISTANCE_SQR = 900f;

	private const float KILL_DISTANCE = 1f;

	// RECUPERADO-AOT RocketAI::.ctor token 0x06000079 @0x000cb408 (field initializers)
	private float launchTimer = 0.5f;

	private float lifeTimer = 10f;

	private WaypointLogic nextWP;

	private GameObject launchOwner;

	public GameObject launchTarget;

	private Vector3 launchVector = Vector3.zero;

	private float velocity;

	private RocketRideEffect riderEffect;

	public bool isReverse;

	public bool isBoatAnchor;

	public bool rideRocket;

	private GameObject explosionEffectPrefab;

	private SoundSequencer seq;

	// RECUPERADO-AOT RocketAI::StrikeTarget token 0x0600007a @0x000cb490
	// A level-2 shield reflects a new rocket volley back at the shooter's position in the race.
	private void StrikeTarget(GameObject target)
	{
		CarCollider component = target.GetComponent<CarCollider>();
		if (component != null)
		{
			EffectManager effectMgr = component.EffectMgr;
			if (component.IsShielded())
			{
				ShieldEffect shieldEffect = effectMgr.GetStrongestEffect(typeof(ShieldEffect)) as ShieldEffect;
				if (shieldEffect.PowerLevel > 1)
				{
					RocketEffect rocketEffect = new RocketEffect(component.gameObject);
					rocketEffect.power = 1;
					rocketEffect.time = lifeTimer;
					effectMgr.AddEffect(rocketEffect);
				}
				SoundSequencer component2 = effectMgr.gameObject.GetComponent<SoundSequencer>();
				if (component2 != null)
				{
					component2.RequestPlay("rocketHit Shield");
				}
			}
			else if ((bool)effectMgr)
			{
				if (!isBoatAnchor)
				{
					WipeoutEffect wipeoutEffect = new WipeoutEffect(component.gameObject);
					wipeoutEffect.power = 50;
					wipeoutEffect.time = 2f;
					effectMgr.AddEffect(wipeoutEffect);
					if (RaceManager.IsPlayerCar(launchOwner))
					{
						CarMetrics component3 = launchOwner.GetComponent<CarMetrics>();
						if (component3 != null)
						{
							component3.Signal("RocketEffect success");
							CarCollider component4 = launchOwner.GetComponent<CarCollider>();
							if (component4 != null && component4.isInAir)
							{
								component3.Signal("Powerup hit in air");
							}
							LifetimeMetrics.Signal("Lifetime RocketEffect success");
						}
						CharacterVOController vOController = launchOwner.GetVOController();
						if (vOController != null)
						{
							vOController.PlayCelebrate();
						}
					}
				}
				else
				{
					effectMgr.AddEffect(new ShockedEffect(component.gameObject));
					CharacterVOController vOController2 = launchOwner.GetVOController();
					if (vOController2 != null)
					{
						vOController2.PlayCelebrate();
					}
				}
			}
		}
		Explode();
	}

	// RECUPERADO-AOT RocketAI::LaunchUpdate token 0x0600007b @0x000cb870
	// Launch phase: flies along launchVector; ends early once the target is within 30 m. The default
	// offset (up * 900 * 2) only makes the no-target case read as far away.
	private void LaunchUpdate()
	{
		Vector3 vector = Vector3.up * 900f * 2f;
		if (launchTarget != null)
		{
			vector = launchTarget.transform.position - base.transform.position;
		}
		if (vector.sqrMagnitude <= 900f)
		{
			launchTimer = 0f;
		}
		base.transform.position = base.transform.position + launchVector * velocity * Time.deltaTime;
	}

	// RECUPERADO-AOT RocketAI::BurnUpdate token 0x0600007c @0x000cbaac
	// Note (original): a rocket without target that is not being ridden logs and stops moving; it
	// still explodes when lifeTimer runs out (SetTarget(null) leaves it at 0).
	private void BurnUpdate()
	{
		if (launchTarget == null && !rideRocket)
		{
			Debug.LogWarning("Why don't we have a target?");
			return;
		}
		Vector3 vector = Vector3.zero;
		if (launchTarget != null)
		{
			vector = launchTarget.transform.position - base.transform.position;
		}
		if (launchTarget != null && vector.sqrMagnitude <= 900f)
		{
			if (rideRocket)
			{
				riderEffect.DetachFromRocket();
			}
			base.transform.forward = vector;
			if (vector.magnitude <= 1f)
			{
				StrikeTarget(launchTarget);
			}
		}
		else
		{
			Vector3 vector2 = nextWP.transform.position - base.transform.position + Vector3.up * 2f;
			if (vector2.sqrMagnitude <= 25f)
			{
				if (isReverse)
				{
					nextWP = nextWP.backwardPoint;
				}
				else
				{
					nextWP = nextWP.forwardPoint;
				}
			}
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(vector2), Time.deltaTime * 20f);
		}
		base.transform.position = base.transform.position + base.transform.forward * velocity * Time.deltaTime;
	}

	// RECUPERADO-AOT RocketAI::Explode token 0x0600007d @0x000cbf7c
	private void Explode()
	{
		if (rideRocket)
		{
			riderEffect.DetachFromRocket();
		}
		GameObject gameObject = Object.Instantiate(explosionEffectPrefab, base.transform.position, base.transform.rotation) as GameObject;
		gameObject.transform.parent = null;
		gameObject.name = "Explosion Particle Effect";
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT RocketAI::Start token 0x0600007e @0x000cc0bc
	// The launch direction is a random sideways/forward tilt in the owner's frame; the rocket starts at
	// the owner's speed. Note (original): the explosion prefab is only fetched when there is an owner.
	private void Start()
	{
		System.Random random = new System.Random();
		Vector2 insideUnitCircle = Random.insideUnitCircle;
		insideUnitCircle.x = Mathf.Abs(Mathf.Min(insideUnitCircle.x, 0.6f));
		insideUnitCircle.y = Mathf.Abs(Mathf.Max(insideUnitCircle.y, 0.6f));
		insideUnitCircle.x *= (random.Next() % 2 != 0) ? 1 : (-1);
		launchVector = launchOwner.transform.rotation * new Vector3(insideUnitCircle.x, 0.125f, insideUnitCircle.y).normalized;
		base.transform.forward = launchVector;
		nextWP = WaypointLogic.FindNextWaypoint(base.transform.position);
		if (launchOwner != null)
		{
			CarCollider component = launchOwner.GetComponent<CarCollider>();
			if (component != null)
			{
				velocity = component.GetVelocity().magnitude;
			}
			explosionEffectPrefab = ParticleLibrary.Instance.GetPrefab("Explosion");
		}
		seq = GetComponent<SoundSequencer>();
		if ((bool)seq)
		{
			seq.RequestPlay("rocketLaunch");
			seq.RequestPlayLoop("rocketFlight");
		}
		if (rideRocket)
		{
			lifeTimer = 5f;
			launchTimer = 0f;
		}
	}

	// RECUPERADO-AOT RocketAI::Update token 0x0600007f @0x000cc518
	// Note (original): while paused with the sequencer already paused, the else branch unpauses it,
	// so the rocket sounds toggle every paused frame.
	private void Update()
	{
		if (RaceManager.isPaused && !seq.isPaused)
		{
			seq.PauseSounds();
		}
		else if (seq.isPaused)
		{
			seq.UnpauseSounds();
		}
	}

	// RECUPERADO-AOT RocketAI::FixedUpdate token 0x06000080 @0x000cc5a4
	private void FixedUpdate()
	{
		if (RaceManager.isPaused)
		{
			return;
		}
		if (Physics.Raycast(base.transform.position, base.transform.forward, 10f, 1024))
		{
			Explode();
		}
		if (velocity < 100f)
		{
			velocity += 200f * Time.deltaTime;
			if (velocity > 100f)
			{
				velocity = 100f;
			}
		}
		if (launchTimer > 0f)
		{
			launchTimer -= Time.deltaTime;
			LaunchUpdate();
			return;
		}
		lifeTimer -= Time.deltaTime;
		if (lifeTimer <= 0f)
		{
			Explode();
		}
		else
		{
			BurnUpdate();
		}
	}

	// RECUPERADO-AOT RocketAI::SetOwner token 0x06000081 @0x000cc7d4
	public void SetOwner(GameObject obj)
	{
		launchOwner = obj;
	}

	// RECUPERADO-AOT RocketAI::SetTarget token 0x06000082 @0x000cc810
	// No target: short launch arc, then it explodes on the first burn frame.
	public void SetTarget(GameObject obj)
	{
		launchTarget = obj;
		if (launchTarget == null)
		{
			launchTimer = 0.75f;
			lifeTimer = 0f;
		}
	}

	// RECUPERADO-AOT RocketAI::SetRiderEffect token 0x06000083 @0x000cc888
	public void SetRiderEffect(RocketRideEffect rre)
	{
		riderEffect = rre;
		rideRocket = true;
	}
}
