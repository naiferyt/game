using UnityEngine;

public class MineEffect : BaseEffect
{
	private GameObject parentObject;

	private float dropDelay;

	private float dropCountdown;

	public MineEffect(GameObject parent)
	{
	}

	public override void Init()
	{
	}

	public override void Shutdown()
	{
	}

	public override bool Stack(BaseEffect second)
	{
		return default(bool);
	}

	public override void Update()
	{
	}

	public override BaseEffect GetEffectSnapShot()
	{
		return default(BaseEffect);
	}
}
