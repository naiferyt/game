using UnityEngine;

public class BoosterEffect : BaseEffect
{
	private GameObject parentObject;

	public BoosterEffect(GameObject parent)
	{
		RecoveryPending.Hit("BoosterEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("BoosterEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("BoosterEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("BoosterEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("BoosterEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("BoosterEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
