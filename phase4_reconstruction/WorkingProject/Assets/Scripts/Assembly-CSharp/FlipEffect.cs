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
