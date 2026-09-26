using UnityEngine;

public class SkidEffect : BaseEffect
{
	private const float SKID_EQUALIZE_ANGLE = 10f;

	private GameObject parentObject;

	private CarCollider carCollider;

	public SkidEffect(GameObject owner)
	{
		RecoveryPending.Hit("SkidEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("SkidEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("SkidEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("SkidEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("SkidEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("SkidEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
