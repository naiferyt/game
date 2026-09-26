using UnityEngine;

public class BoosterEffect : BaseEffect
{
	private GameObject parentObject;

	public BoosterEffect(GameObject parent)
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
