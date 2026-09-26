using UnityEngine;

public class MineEffect : BaseEffect
{
	private GameObject parentObject;

	private float dropDelay;

	private float dropCountdown;

	public MineEffect(GameObject parent)
	{
		RecoveryPending.Hit("MineEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("MineEffect.Init");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("MineEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("MineEffect.Stack");
		return default(bool);
	}

	public override void Update()
	{
		RecoveryPending.Hit("MineEffect.Update");
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("MineEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
