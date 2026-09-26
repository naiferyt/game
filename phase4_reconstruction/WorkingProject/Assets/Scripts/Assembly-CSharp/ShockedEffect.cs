using UnityEngine;

public class ShockedEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject shockParticle;

	public ShockedEffect(GameObject owner)
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
