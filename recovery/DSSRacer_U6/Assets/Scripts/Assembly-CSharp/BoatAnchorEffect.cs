using UnityEngine;

public class BoatAnchorEffect : BaseEffect
{
	private const float MAX_TARGET_DISTANCE = 150f;

	public GameObject parentObject;

	private GameObject target;

	public BoatAnchorEffect(GameObject owner)
	{
		RecoveryPending.Hit("BoatAnchorEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("BoatAnchorEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("BoatAnchorEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("BoatAnchorEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("BoatAnchorEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("BoatAnchorEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}

	protected void LaunchAnchor(GameObject target)
	{
		RecoveryPending.Hit("BoatAnchorEffect.LaunchAnchor");
	}
}
