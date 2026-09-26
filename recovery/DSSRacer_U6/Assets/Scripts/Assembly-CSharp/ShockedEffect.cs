using UnityEngine;

public class ShockedEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject shockParticle;

	public ShockedEffect(GameObject owner)
	{
		RecoveryPending.Hit("ShockedEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("ShockedEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("ShockedEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("ShockedEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("ShockedEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("ShockedEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
