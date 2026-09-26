using UnityEngine;

public class RocketRideEffect : BaseEffect
{
	private const float MAX_TARGET_DISTANCE = 150f;

	public GameObject parentObject;

	private CarCollider cc;

	private GameObject target;

	private bool reverse;

	private GameObject rocket;

	private float oldDist;

	public RocketRideEffect(GameObject owner)
	{
		RecoveryPending.Hit("RocketRideEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("RocketRideEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("RocketRideEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("RocketRideEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("RocketRideEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("RocketRideEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}

	protected void LaunchRocket(GameObject target)
	{
		RecoveryPending.Hit("RocketRideEffect.LaunchRocket");
	}

	public void DetachFromRocket()
	{
		RecoveryPending.Hit("RocketRideEffect.DetachFromRocket");
	}
}
