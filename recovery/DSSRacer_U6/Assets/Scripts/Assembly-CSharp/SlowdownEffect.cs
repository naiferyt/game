using UnityEngine;

public class SlowdownEffect : BaseEffect
{
	private GameObject parentObject;

	public SlowdownEffect(GameObject parent)
	{
		RecoveryPending.Hit("SlowdownEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("SlowdownEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("SlowdownEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("SlowdownEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("SlowdownEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("SlowdownEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
