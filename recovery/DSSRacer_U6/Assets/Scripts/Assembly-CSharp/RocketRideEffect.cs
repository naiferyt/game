using UnityEngine;

// Rocket ride (Booster + Rocket combo): the kart is parented to a big RocketAI and carried to the car
// ahead; detaching restores control at full speed.
// Source listing: recovery/aot_listings/Assembly-CSharp/RocketRideEffect.txt
public class RocketRideEffect : BaseEffect
{
	private const float MAX_TARGET_DISTANCE = 150f;

	public GameObject parentObject;

	private CarCollider cc;

	private GameObject target;

	private bool reverse;

	private GameObject rocket;

	private float oldDist;

	// RECUPERADO-AOT RocketRideEffect::.ctor token 0x060003b2 @0x000f6e34
	// time = float.MinValue: the ride lasts until the rocket detaches (Update removes the effect).
	public RocketRideEffect(GameObject owner)
	{
		effectType = EffectTypes.RocketRideEffect;
		parentObject = owner;
		time = float.MinValue;
		cc = parentObject.GetComponent<CarCollider>();
	}

	// RECUPERADO-AOT RocketRideEffect::Init token 0x060003b3 @0x000f6eb8
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	public override void Init()
	{
		if (!(parentObject != null))
		{
			return;
		}
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component != null)
		{
			component.AddEffect(new BoosterEffect(parentObject));
		}
		int num = RaceManager.GetCarPosition(parentObject) - 1;
		if (num >= 0 && num < RaceManager.allCars.Length)
		{
			target = RaceManager.GetCarInPosition(num);
		}
		LaunchRocket(target);
		FollowCamera followCamera = (FollowCamera)U4Compat.FindObjectOfType(typeof(FollowCamera));
		if (parentObject == RaceManager.GetPlayerCar())
		{
			CameraShake component2 = followCamera.GetComponent<CameraShake>();
			if (component2 != null)
			{
				component2.TurnOnShake(0f, 0f);
			}
		}
	}

	// RECUPERADO-AOT RocketRideEffect::Update token 0x060003b4 @0x000f70a4
	public override void Update()
	{
		if (parentObject.transform.parent == null)
		{
			EffectManager component = parentObject.GetComponent<EffectManager>();
			if (component != null)
			{
				component.RemoveEffect(this);
			}
			if (cc != null)
			{
				DetachFromRocket();
			}
		}
	}

	// RECUPERADO-AOT RocketRideEffect::Shutdown token 0x060003b5 @0x000f7158
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	public override void Shutdown()
	{
		if (cc != null)
		{
			DetachFromRocket();
		}
		FollowCamera followCamera = (FollowCamera)U4Compat.FindObjectOfType(typeof(FollowCamera));
		CameraShake component = followCamera.GetComponent<CameraShake>();
		if (component != null)
		{
			component.TurnOffShake();
		}
	}

	// RECUPERADO-AOT RocketRideEffect::Stack token 0x060003b6 @0x000f7240
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT RocketRideEffect::GetEffectSnapShot token 0x060003b7 @0x000f7274
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}

	// RECUPERADO-AOT RocketRideEffect::LaunchRocket token 0x060003b8 @0x000f72a4
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	// The rider/owner stores are RocketAI.SetRiderEffect and SetOwner inlined; the camera pulls back to
	// a minimum follow distance of 10 for the ride.
	protected void LaunchRocket(GameObject target)
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		rocket = (GameObject)Object.Instantiate(component.rocketEffectPrefab, parentObject.transform.position + Vector3.up * 2f, parentObject.transform.rotation);
		RocketAI component2 = rocket.GetComponent<RocketAI>();
		rocket.transform.localScale = Vector3.one * 2f;
		component2.isReverse = reverse;
		component2.SetRiderEffect(this);
		component2.SetOwner(parentObject);
		component2.SetTarget(target);
		cc.PauseSounds(true);
		cc.enabled = false;
		cc.ignoreGravity = true;
		cc.IncrementInputBlock();
		parentObject.transform.parent = rocket.transform;
		parentObject.transform.localPosition = new Vector3(0f, 0.75f, -0.05f);
		if (RaceManager.IsPlayerCar(parentObject))
		{
			FollowCamera followCamera = (FollowCamera)U4Compat.FindObjectOfType(typeof(FollowCamera));
			if (followCamera != null)
			{
				oldDist = followCamera.followDistance.min;
				followCamera.followDistance.min = 10f;
			}
		}
	}

	// RECUPERADO-AOT RocketRideEffect::DetachFromRocket token 0x060003b9 @0x000f76cc
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	// The input block decrement is CarCollider.DecrementInputBlock inlined.
	public void DetachFromRocket()
	{
		if (cc == null)
		{
			return;
		}
		parentObject.transform.parent = null;
		cc.lastClosestWP = null;
		cc.enabled = true;
		cc.PauseSounds(false);
		cc.ignoreGravity = false;
		cc.DecrementInputBlock();
		cc.TransformVelocity(-cc.GetVelocity() + cc.transform.forward * cc.GetActualMaxSpeed());
		cc = null;
		if (RaceManager.IsPlayerCar(parentObject))
		{
			FollowCamera followCamera = (FollowCamera)U4Compat.FindObjectOfType(typeof(FollowCamera));
			if (followCamera != null)
			{
				followCamera.followDistance.min = oldDist;
			}
		}
	}
}
