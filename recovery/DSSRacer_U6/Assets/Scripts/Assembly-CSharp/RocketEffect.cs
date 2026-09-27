using System.Collections.Generic;
using UnityEngine;

// Rocket power-up: fires a battery of homing RocketAI rockets at the cars ahead.
// Source listing: recovery/aot_listings/Assembly-CSharp/RocketEffect.txt
public class RocketEffect : BaseEffect
{
	private const float BATTERY_LAUNCH_DELAY = 0.25f;

	private const float MAX_TARGET_DISTANCE = 150f;

	private GameObject parentObject;

	public bool isReflected;

	private List<GameObject> targetList;

	private float batteryTimer;

	private bool reverse;

	// RECUPERADO-AOT RocketEffect::.ctor token 0x060003ab @0x000f65bc
	public RocketEffect(GameObject parent)
	{
		targetList = new List<GameObject>();
		batteryTimer = 0.25f;
		parentObject = parent;
		effectType = EffectTypes.RocketEffect;
		power = 1;
		time = 0.25f;
		isMultiLevel = true;
	}

	// RECUPERADO-AOT RocketEffect::Init token 0x060003ac @0x000f6674
	// Level 1 targets the car just ahead (or just behind when driving against the waypoint
	// direction); level 2 queues every car within 150 m in that direction. The volley fires one
	// rocket every 0.25 s; with no target a single dumb rocket (null target) is launched.
	public override void Init()
	{
		if (!(parentObject != null))
		{
			return;
		}
		int carPosition = RaceManager.GetCarPosition(parentObject);
		float carLastTrackDistance = RaceManager.GetCarLastTrackDistance(parentObject);
		WaypointLogic waypointLogic = WaypointLogic.FindNextWaypoint(parentObject.transform.position);
		Vector3 normalized = (waypointLogic.forwardPoint.transform.position - waypointLogic.transform.position).normalized;
		reverse = Vector3.Dot(normalized, parentObject.transform.forward) < 0f;
		if (powerLevel > 1)
		{
			if (!reverse)
			{
				for (int num = carPosition - 1; num >= 0; num--)
				{
					if (Mathf.Abs(RaceManager.GetCarLastTrackDistance(RaceManager.GetCarInPosition(num)) - carLastTrackDistance) < 150f)
					{
						targetList.Add(RaceManager.GetCarInPosition(num));
					}
				}
			}
			else
			{
				for (int i = carPosition + 1; i < RaceManager.allCars.Length; i++)
				{
					if (Mathf.Abs(RaceManager.GetCarLastTrackDistance(RaceManager.GetCarInPosition(i)) - carLastTrackDistance) < 150f)
					{
						targetList.Add(RaceManager.GetCarInPosition(i));
					}
				}
			}
		}
		else
		{
			int num2 = carPosition + ((!reverse) ? (-1) : 1);
			if (num2 >= 0 && num2 < RaceManager.allCars.Length)
			{
				targetList.Add(RaceManager.GetCarInPosition(num2));
			}
		}
		if (targetList.Count == 0)
		{
			targetList.Add(null);
		}
		time = (float)targetList.Count * 0.25f + 0.1f;
	}

	// RECUPERADO-AOT RocketEffect::Shutdown token 0x060003ad @0x000f6a74
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT RocketEffect::Stack token 0x060003ae @0x000f6aa0
	public override bool Stack(BaseEffect second)
	{
		return true;
	}

	// RECUPERADO-AOT RocketEffect::Update token 0x060003af @0x000f6ad4
	public override void Update()
	{
		if (targetList.Count > 0)
		{
			batteryTimer -= Time.deltaTime;
			if (batteryTimer <= 0f)
			{
				batteryTimer = 0.25f;
				GameObject target = targetList[0];
				targetList.RemoveAt(0);
				LaunchRocket(target);
			}
		}
	}

	// RECUPERADO-AOT RocketEffect::GetEffectSnapShot token 0x060003b0 @0x000f6bb8
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}

	// RECUPERADO-AOT RocketEffect::LaunchRocket token 0x060003b1 @0x000f6be8
	// The owner store is RocketAI.SetOwner inlined (private field launchOwner).
	protected void LaunchRocket(GameObject target)
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		GameObject gameObject = (GameObject)Object.Instantiate(component.rocketEffectPrefab, parentObject.transform.position + parentObject.transform.forward * 5f + Vector3.up * 2f, parentObject.transform.rotation);
		RocketAI component2 = gameObject.GetComponent<RocketAI>();
		component2.SetOwner(parentObject);
		component2.SetTarget(target);
		component2.isReverse = reverse;
	}
}
