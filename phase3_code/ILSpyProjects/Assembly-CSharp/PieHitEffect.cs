using UnityEngine;

public class PieHitEffect : BaseEffect
{
	public enum HitDirection
	{
		Left,
		Right
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public override BaseEffect GetEffectSnapShot()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
