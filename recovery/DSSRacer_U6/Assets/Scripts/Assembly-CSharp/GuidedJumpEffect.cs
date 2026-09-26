using UnityEngine;

public class GuidedJumpEffect : BaseEffect
{
	private GameObject parentObject;

	private Vector3 jumpStart;

	private Vector3 targetPosition;

	private Vector3 offset;

	private AnimationCurve jumpCurve;

	private float startTime;

	private Vector3 toTarget;

	public GuidedJumpEffect(GameObject owner, Vector3 startPos, Vector3 targetPos, AnimationCurve curve)
	{
		RecoveryPending.Hit("GuidedJumpEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("GuidedJumpEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("GuidedJumpEffect.Update");
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("GuidedJumpEffect.FixedUpdate");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("GuidedJumpEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("GuidedJumpEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("GuidedJumpEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
