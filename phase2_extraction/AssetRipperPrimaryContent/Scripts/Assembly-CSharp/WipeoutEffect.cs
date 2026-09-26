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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public override BaseEffect GetEffectSnapShot()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
