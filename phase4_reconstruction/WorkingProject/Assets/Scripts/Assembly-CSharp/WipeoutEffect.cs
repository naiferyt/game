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
