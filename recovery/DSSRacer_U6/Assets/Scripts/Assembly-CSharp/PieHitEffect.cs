using UnityEngine;

public class PieHitEffect : BaseEffect
{
	public enum HitDirection
	{
		Left = 0,
		Right = 1
	}

	private HitDirection hitDirection;

	public PieHitEffect(GameObject owner, HitDirection dir = HitDirection.Right)
	{
		RecoveryPending.Hit("PieHitEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("PieHitEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("PieHitEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("PieHitEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("PieHitEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("PieHitEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
