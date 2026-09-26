using UnityEngine;

public class SkidEffect : BaseEffect
{
	private const float SKID_EQUALIZE_ANGLE = 10f;

	private GameObject parentObject;

	private CarCollider carCollider;

	public SkidEffect(GameObject owner)
	{
	}

	public override void Init()
	{
	}

	public override void Update()
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
