using UnityEngine;

// Boat anchor (Rocket + Shield combo): fires one anchor (RocketAI with isBoatAnchor, shocks instead
// of wiping out) at the car ahead/behind and shields the owner.
// Source listing: recovery/aot_listings/Assembly-CSharp/BoatAnchorEffect.txt
public class BoatAnchorEffect : BaseEffect
{
	private const float MAX_TARGET_DISTANCE = 150f;

	public GameObject parentObject;

	private GameObject target;

	// RECUPERADO-AOT BoatAnchorEffect::.ctor token 0x0600035c @0x000f12f4
	public BoatAnchorEffect(GameObject owner)
	{
		effectType = EffectTypes.BoatAnchorEffect;
		parentObject = owner;
	}

	// RECUPERADO-AOT BoatAnchorEffect::Init token 0x0600035d @0x000f133c
	public override void Init()
	{
		if (!(parentObject != null))
		{
			return;
		}
		int carPosition = RaceManager.GetCarPosition(parentObject);
		WaypointLogic waypointLogic = WaypointLogic.FindNextWaypoint(parentObject.transform.position);
		Vector3 normalized = (waypointLogic.forwardPoint.transform.position - waypointLogic.transform.position).normalized;
		bool flag = Vector3.Angle(parentObject.transform.forward, normalized) > 90f;
		int num = carPosition + ((!flag) ? (-1) : 1);
		if (num >= 0 && num < RaceManager.allCars.Length)
		{
			target = RaceManager.GetCarInPosition(num);
		}
		LaunchAnchor(target);
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component != null)
		{
			component.AddEffect(new ShieldEffect(parentObject));
		}
	}

	// RECUPERADO-AOT BoatAnchorEffect::Update token 0x0600035e @0x000f15a8
	public override void Update()
	{
	}

	// RECUPERADO-AOT BoatAnchorEffect::Shutdown token 0x0600035f @0x000f15d4
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT BoatAnchorEffect::Stack token 0x06000360 @0x000f1600
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT BoatAnchorEffect::GetEffectSnapShot token 0x06000361 @0x000f1634
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}

	// RECUPERADO-AOT BoatAnchorEffect::LaunchAnchor token 0x06000362 @0x000f1664
	protected void LaunchAnchor(GameObject target)
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		GameObject gameObject = (GameObject)Object.Instantiate(component.anchorEffectPrefab, parentObject.transform.position + parentObject.transform.forward * 5f + Vector3.up * 2f, parentObject.transform.rotation);
		RocketAI rocketAI = gameObject.GetComponent<RocketAI>();
		if (rocketAI == null)
		{
			rocketAI = gameObject.AddComponent<RocketAI>();
		}
		rocketAI.SetOwner(parentObject);
		rocketAI.SetTarget(target);
		rocketAI.isBoatAnchor = true;
	}
}
