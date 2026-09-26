using UnityEngine;

public class WipeoutEffect : BaseEffect
{
	private GameObject parentObject;

	private float baseTime;

	private float spinRate;

	private Quaternion startingRot;

	private Quaternion lastRot;

	private bool restoreCamFacingFlag;

	public WipeoutEffect(GameObject parent)
	{
		RecoveryPending.Hit("WipeoutEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("WipeoutEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("WipeoutEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("WipeoutEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("WipeoutEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("WipeoutEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
