using UnityEngine;

public class BoatAnchorEffect : BaseEffect
{
	private const float MAX_TARGET_DISTANCE = 150f;

	public GameObject parentObject;

	private GameObject target;

	public BoatAnchorEffect(GameObject owner)
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

	protected void LaunchAnchor(GameObject target)
	{
	}
}
