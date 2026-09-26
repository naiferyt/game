using UnityEngine;

public class SmashEffect : BaseEffect
{
	private GameObject parentObject;

	public SmashEffect(GameObject parent)
	{
		RecoveryPending.Hit("SmashEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("SmashEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("SmashEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("SmashEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("SmashEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("SmashEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
