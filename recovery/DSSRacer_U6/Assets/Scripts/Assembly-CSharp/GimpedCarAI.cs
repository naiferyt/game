using System.Collections;
using System.Diagnostics;
using UnityEngine;

// The rival driver the game actually uses (CarAI swaps itself for this one): the kart replays a recorded driving
// line (CarAIPathManager), steered by a PID toward the next recorded point, with its own speed model (the kart's
// acceleration and max speed), road-wall and kart-to-kart collisions, ground following on the shadow blob, and two
// timers that fire power-ups at random and hand it free rockets.
// Source listing: recovery/aot_listings/Assembly-CSharp/GimpedCarAI.txt
public class GimpedCarAI : MonoBehaviour
{
	private const float WRECK_FLIP_TIME = 0.25f;

	private const float USE_POWERUP_INTERVAL = 3f;

	private const float USE_POWERUP_CHANCE = 0.5f;

	private const float GAIN_AGGRESSION_POWERUP = 0.05f;

	private CarCollider carCollider;

	private AnimationDriver animDriver;

	private CarAIPath currentPath;

	private int currentPathIndex;

	// RECUPERADO-AOT GimpedCarAI::.ctor token 0x06000052 @0x000c7014 (field initializers)
	private Vector3 targetPos = Vector3.zero;

	private Vector3 lastPos = Vector3.zero;

	private Quaternion targetRot = Quaternion.identity;

	private Quaternion lastRot = Quaternion.identity;

	private float targetDist;

	private float linearVelocity;

	private Vector3 bumpVelocity = Vector3.zero;

	private ShadowBlob shadowBlob;

	private float wreckedFlipTimer = 0.25f;

	private PIDVectorController pid = new PIDVectorController(1f, 0f, 0f, Vector3.zero, Vector3.zero);

	public float aggressionIndex = 1f;

	public float LinearVelocity
	{
		// RECUPERADO-AOT GimpedCarAI::get_LinearVelocity token 0x06000053 @0x000c720c
		get
		{
			return linearVelocity;
		}
		// RECUPERADO-AOT GimpedCarAI::set_LinearVelocity token 0x06000054 @0x000c724c
		set
		{
			linearVelocity = value;
		}
	}

	public float Velocity
	{
		// RECUPERADO-AOT GimpedCarAI::get_Velocity token 0x06000055 @0x000c7290
		get
		{
			return linearVelocity;
		}
	}

	public Vector3 Direction
	{
		// RECUPERADO-AOT GimpedCarAI::get_Direction token 0x06000056 @0x000c72d0
		get
		{
			return (targetPos - lastPos).normalized;
		}
	}

	public bool IsInAir
	{
		// RECUPERADO-AOT GimpedCarAI::get_IsInAir token 0x06000057 @0x000c73a8
		get
		{
			return shadowBlob.ShadowPosition.y + carCollider.attributes.groundHeight < base.transform.position.y;
		}
	}

	// RECUPERADO-AOT GimpedCarAI::SetNewPath token 0x06000058 @0x000c7470
	// Picks a random recorded line and skips ahead (at most 6 points) until the next point is within 15 degrees
	// of the kart's heading.
	private void SetNewPath()
	{
		currentPath = CarAIPathManager.GetRandomPath();
		currentPathIndex = -1;
		SetNextPoint();
		Vector3 forward = base.transform.forward;
		Vector3 vector = currentPath.pathPoints[currentPathIndex].point - base.transform.position;
		int num = 0;
		while (15f < Mathf.Abs(Vector3.Angle(forward, vector.normalized)))
		{
			SetNextPoint();
			vector = currentPath.pathPoints[currentPathIndex].point - base.transform.position;
			num++;
			if (num > 5)
			{
				break;
			}
		}
	}

	// RECUPERADO-AOT GimpedCarAI::SetNextPoint token 0x06000059 @0x000c769c
	private void SetNextPoint()
	{
		lastPos = base.transform.position;
		lastRot = base.transform.rotation;
		currentPathIndex++;
		if (currentPathIndex >= currentPath.pathPoints.Length)
		{
			SetNewPath();
			return;
		}
		targetPos = currentPath.pathPoints[currentPathIndex].point;
		targetRot = currentPath.pathPoints[currentPathIndex].rotation;
		targetDist = (targetPos - lastPos).magnitude;
	}

	// RECUPERADO-AOT GimpedCarAI::DoRoadBoundaries token 0x0600005a @0x000c78e0
	// Keeps the kart inside the walls of the closest waypoint: cancels the bump velocity toward the wall and pushes
	// the kart back to (wall distance - kart width) from the track line.
	private void DoRoadBoundaries()
	{
		WaypointLogic waypointLogic = WaypointLogic.FindClosestWaypoint(base.transform.position, false);
		if (waypointLogic == null)
		{
			return;
		}
		Vector3 trackPoint = waypointLogic.GetTrackPoint(base.transform.position);
		Vector3 wallOffsetForPoint = waypointLogic.GetWallOffsetForPoint(base.transform.position);
		Vector3 vector = trackPoint + wallOffsetForPoint - base.transform.position;
		vector.y = 0f;
		float magnitude = vector.magnitude;
		float wallDistanceAtPoint = waypointLogic.GetWallDistanceAtPoint(base.transform.position);
		if (waypointLogic.projectsWalls && !(magnitude + GetComponent<Collider>().bounds.size.x < wallDistanceAtPoint))
		{
			// MODIFICADO (petición del usuario, 2026-09-27; no está en el original): a rival is not pushed back while in the
			// air, nor when the next point of its own recorded line is beyond the same wall. The closest waypoint is searched
			// in 3D, so it can belong to another stretch: over the Kick Butt 1 jump pit it was the road 15 units below (rival
			// pinned in mid-air up to 13 s) and on the Dirt Devils split road it was the main road (rival pinned for the rest
			// of the race).
			Vector3 toTargetWall = waypointLogic.GetTrackPoint(targetPos) + waypointLogic.GetWallOffsetForPoint(targetPos) - targetPos;
			toTargetWall.y = 0f;
			if (IsInAir || !(toTargetWall.magnitude + GetComponent<Collider>().bounds.size.x < waypointLogic.GetWallDistanceAtPoint(targetPos)))
			{
				return;
			}
			vector.Normalize();
			bumpVelocity -= vector * Vector3.Dot(bumpVelocity, vector);
			Vector3 position = trackPoint + wallOffsetForPoint - vector * (wallDistanceAtPoint - GetComponent<Collider>().bounds.size.x);
			position.y = base.transform.position.y;
			base.transform.position = position;
		}
	}

	// RECUPERADO-AOT GimpedCarAI::DoCarCollisions token 0x0600005b @0x000c7e18
	// Kart-to-kart contact (distance squared under the kart width): bounce away unless shielded; smash and level-2
	// shields flip the loser. Staying in contact flips this kart every WRECK_FLIP_TIME seconds.
	private void DoCarCollisions()
	{
		bool flag = false;
		float x = GetComponent<Collider>().bounds.size.x;
		bool flag2 = carCollider.EffectMgr.HasEffect(typeof(ShieldEffect));
		bool flag3 = carCollider.EffectMgr.HasEffectOfLevel(typeof(ShieldEffect), 2);
		bool flag4 = carCollider.EffectMgr.HasEffect(typeof(SmashEffect));
		GameObject[] allCars = RaceManager.allCars;
		for (int i = 0; i < allCars.Length; i++)
		{
			GameObject gameObject = allCars[i];
			if (gameObject == base.gameObject || gameObject == null)
			{
				continue;
			}
			Vector3 vector = gameObject.transform.position - base.transform.position;
			if (x < vector.sqrMagnitude)
			{
				continue;
			}
			flag = true;
			EffectManager component = gameObject.GetComponent<EffectManager>();
			bool flag5 = component.HasEffect(typeof(ShieldEffect));
			bool flag6 = component.HasEffectOfLevel(typeof(ShieldEffect), 2);
			bool flag7 = component.HasEffect(typeof(SmashEffect));
			if (!flag2)
			{
				Bump(-vector * 2f);
			}
			if ((flag7 && !flag2) || (flag4 && flag6))
			{
				carCollider.EffectMgr.AddEffect(new FlipEffect(base.gameObject));
			}
			if ((flag4 && !flag5) || (flag7 && flag3))
			{
				component.AddEffect(new FlipEffect(gameObject));
			}
		}
		if (flag)
		{
			wreckedFlipTimer -= Time.deltaTime;
			if (!(0f < wreckedFlipTimer))
			{
				wreckedFlipTimer = 0.25f;
				carCollider.EffectMgr.AddEffect(new FlipEffect(base.gameObject));
			}
		}
		else
		{
			wreckedFlipTimer = 0.25f;
		}
	}

	// RECUPERADO-AOT GimpedCarAI::PowerupUseEvaluationCoroutinue token 0x0600005c @0x000c8354
	// RECUPERADO-AOT GimpedCarAI/<PowerupUseEvaluationCoroutinue>c__Iterator1::MoveNext token 0x060007d6 @0x001411f0
	[DebuggerHidden]
	private IEnumerator PowerupUseEvaluationCoroutinue()
	{
		yield return new WaitForSeconds(Random.Range(0f, 3f) + 4f);
		while (true)
		{
			if (!RaceManager.isPaused && !(0.5f < Random.value))
			{
				PowerupHolder ph = GetComponent<PowerupHolder>();
				if ((bool)ph)
				{
					ph.ExecutePowerups();
				}
			}
			yield return new WaitForSeconds(3f);
		}
	}

	// RECUPERADO-AOT GimpedCarAI::AggressionTherapyCoroutine token 0x0600005d @0x000c839c
	// RECUPERADO-AOT GimpedCarAI/<AggressionTherapyCoroutine>c__Iterator2::MoveNext token 0x060007dc @0x001414d0
	// Every 3 s, with chance 5% x aggressionIndex, a free rocket goes into the kart's reserve.
	[DebuggerHidden]
	private IEnumerator AggressionTherapyCoroutine()
	{
		yield return new WaitForSeconds(Random.Range(0f, 3f) + 10f);
		while (true)
		{
			if (!(0.05f * aggressionIndex < Random.value))
			{
				PowerupHolder ph = GetComponent<PowerupHolder>();
				if (ph != null && ph.CanTakePowerup)
				{
					ph.AddEffect(BaseEffect.GetEffectInstance(BaseEffect.EffectTypes.RocketEffect, base.gameObject));
				}
			}
			yield return new WaitForSeconds(3f);
		}
	}

	// RECUPERADO-AOT GimpedCarAI::Start token 0x0600005e @0x000c83e4
	private void Start()
	{
		carCollider = base.gameObject.GetComponent<CarCollider>();
		shadowBlob = base.gameObject.GetComponent<ShadowBlob>();
		if (currentPath == null && currentPathIndex <= 0)
		{
			SetNewPath();
		}
		if (carCollider != null)
		{
			carCollider.ignoreFixedUpdate = true;
		}
		TriFoot component = base.gameObject.GetComponent<TriFoot>();
		if (component != null)
		{
			Object.Destroy(component);
		}
		Animation componentInChildren = GetComponentInChildren<Animation>();
		if (componentInChildren != null && !RaceManager.IsPlayerCar(base.gameObject))
		{
			animDriver = GetComponent<AnimationDriver>();
			if (animDriver != null)
			{
				animDriver.SetAnimationTarget(componentInChildren.gameObject);
			}
			else
			{
				UnityEngine.Debug.LogWarning("Could not find an AnimationDriver on " + base.name);
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("Could not find an Animation component on " + base.name);
		}
		StartCoroutine(PowerupUseEvaluationCoroutinue());
		StartCoroutine(AggressionTherapyCoroutine());
	}

	// RECUPERADO-AOT GimpedCarAI::Update token 0x0600005f @0x000c861c
	private void Update()
	{
		DoCarCollisions();
		DoRoadBoundaries();
	}

	// RECUPERADO-AOT GimpedCarAI::FixedUpdate token 0x06000060 @0x000c8658
	private void FixedUpdate()
	{
		bool flag = carCollider.EffectMgr.HasEffect(typeof(WipeoutEffect));
		if (currentPath == null || flag || carCollider.EffectMgr.HasEffect(typeof(FlipEffect)))
		{
			if (!flag || !carCollider.isInAir)
			{
				linearVelocity = 0f;
				return;
			}
			linearVelocity *= 0.5f;
		}
		if (RaceManager.isPaused || carCollider.isCarLocked)
		{
			return;
		}
		while ((targetPos - base.transform.position).magnitude < 5f)
		{
			SetNextPoint();
		}
		bool flag2 = carCollider.EffectMgr.HasEffect(typeof(GuidedJumpEffect));
		bumpVelocity -= bumpVelocity * Time.deltaTime;
		float actualAcceleration = carCollider.GetActualAcceleration();
		float actualMaxSpeed = carCollider.GetActualMaxSpeed();
		if (flag2)
		{
			if (flag)
			{
				linearVelocity = actualMaxSpeed * 0.45f;
			}
			else
			{
				linearVelocity = actualMaxSpeed * 0.75f;
			}
		}
		else if (linearVelocity < actualMaxSpeed && !flag)
		{
			linearVelocity += actualAcceleration * Time.deltaTime;
			if (actualMaxSpeed < linearVelocity)
			{
				linearVelocity = actualMaxSpeed;
			}
		}
		else if (actualMaxSpeed < linearVelocity)
		{
			linearVelocity -= linearVelocity * Time.deltaTime;
		}
		pid.SetPoint(targetPos);
		Vector3 vector = pid.CalculateOutput(Time.deltaTime, base.transform.position);
		vector = vector.normalized * linearVelocity;
		vector += bumpVelocity;
		Vector3 position = base.transform.position + vector * Time.deltaTime;
		if (animDriver != null)
		{
			float num = Vector3.Angle(vector, base.transform.forward);
			num *= Mathf.Sign(Vector3.Dot(base.transform.right, vector));
			animDriver.turnFactor = num / 180f;
		}
		float num2 = shadowBlob.ShadowPosition.y + carCollider.attributes.groundHeight - position.y;
		if (!(0f >= num2))
		{
			position.y = shadowBlob.ShadowPosition.y + carCollider.attributes.groundHeight;
		}
		else if (num2 < 0f && !flag2)
		{
			position.y += Mathf.Max(num2, -9f * Time.deltaTime);
		}
		base.transform.position = position;
		if (!carCollider.EffectMgr.HasEffect(typeof(WipeoutEffect)))
		{
			float t = (targetPos - base.transform.position).magnitude / targetDist;
			base.transform.rotation = Quaternion.Slerp(targetRot, lastRot, t);
		}
	}

	// RECUPERADO-AOT GimpedCarAI::Bump token 0x06000061 @0x000c914c
	public void Bump(Vector3 force)
	{
		force.y = 0f;
		bumpVelocity += force;
		linearVelocity += Vector3.Dot(Direction, force);
	}

	// RECUPERADO-AOT GimpedCarAI::GetGimpedSnapShot token 0x06000062 @0x000c928c
	public void GetGimpedSnapShot(out int pathIndex, out int pointIndex)
	{
		pathIndex = CarAIPathManager.GetPathIndex(currentPath);
		pointIndex = currentPathIndex;
	}

	// RECUPERADO-AOT GimpedCarAI::SetGimpedSnapShot token 0x06000063 @0x000c92e8
	public void SetGimpedSnapShot(int pathIndex, int pointIndex)
	{
		currentPath = CarAIPathManager.GetPathByIndex(pathIndex);
		if (currentPath == null)
		{
			UnityEngine.Debug.LogWarning("Could not set the GimpedSnapShot - pathIndex returned a null path");
			return;
		}
		if (pointIndex < 0 || pointIndex >= currentPath.pathPoints.Length)
		{
			currentPath = null;
			UnityEngine.Debug.LogError("Trying to set pointIndex to an illegal index!");
			return;
		}
		currentPathIndex = pointIndex;
		if (currentPath.pathPoints[pointIndex] == null)
		{
			UnityEngine.Debug.LogWarning("Could not set the GimpedSnapShot - pointIndex was not a valid index");
			return;
		}
		targetPos = currentPath.pathPoints[currentPathIndex].point;
		targetRot = currentPath.pathPoints[currentPathIndex].rotation;
		targetDist = (targetPos - lastPos).magnitude;
	}

	// RECUPERADO-AOT GimpedCarAI::SetToClosestPathHead token 0x06000064 @0x000c9544
	public void SetToClosestPathHead()
	{
		Vector3 position = base.transform.position;
		int num = -1;
		float num2 = 0f;
		for (int i = 0; i < CarAIPathManager.GetPathCount(); i++)
		{
			float sqrMagnitude = (CarAIPathManager.GetPathByIndex(i).pathPoints[0].point - position).sqrMagnitude;
			if (num == -1 || sqrMagnitude < num2)
			{
				num = i;
				num2 = sqrMagnitude;
			}
		}
		if (num == -1)
		{
			UnityEngine.Debug.LogWarning("Could not find an AI path head to transition");
		}
		else
		{
			SetGimpedSnapShot(num, 0);
		}
	}
}
