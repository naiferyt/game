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
