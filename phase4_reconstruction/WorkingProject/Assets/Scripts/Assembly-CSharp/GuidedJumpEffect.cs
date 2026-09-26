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
	}

	public override void Init()
	{
	}

	public override void Update()
	{
	}

	public override void FixedUpdate()
	{
	}

	public override void Shutdown()
	{
	}

	public override bool Stack(BaseEffect second)
	{
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		return default(BaseEffect);
	}
}
