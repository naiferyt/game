using UnityEngine;

public class ShieldEffect : BaseEffect
{
	private GameObject parentObject;

	private GameObject particles;

	private GameObject camera;

	public bool Reflective
	{
		get
		{
			return default(bool);
		}
	}

	public ShieldEffect(GameObject parent)
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
