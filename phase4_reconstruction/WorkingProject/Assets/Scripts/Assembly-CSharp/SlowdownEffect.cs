using UnityEngine;

public class SlowdownEffect : BaseEffect
{
	private GameObject parentObject;

	public SlowdownEffect(GameObject parent)
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
