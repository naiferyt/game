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
			RecoveryPending.Hit("ShieldEffect.get_Reflective");
			return default(bool);
		}
	}

	public ShieldEffect(GameObject parent)
	{
		RecoveryPending.Hit("ShieldEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("ShieldEffect.Init");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("ShieldEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("ShieldEffect.Stack");
		return default(bool);
	}

	public override void Update()
	{
		RecoveryPending.Hit("ShieldEffect.Update");
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("ShieldEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
