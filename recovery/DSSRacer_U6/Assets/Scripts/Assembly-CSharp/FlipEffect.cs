using UnityEngine;

public class FlipEffect : BaseEffect
{
	private GameObject parentObject;

	private float baseTime;

	private float spinRate;

	private Vector3 startPos;

	private Vector3 peakPos;

	private bool restoreCamFacingFlag;

	public FlipEffect(GameObject parent)
	{
		RecoveryPending.Hit("FlipEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("FlipEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("FlipEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("FlipEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("FlipEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("FlipEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
