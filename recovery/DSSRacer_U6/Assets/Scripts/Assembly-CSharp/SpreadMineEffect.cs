using UnityEngine;

public class SpreadMineEffect : BaseEffect
{
	public GameObject parentObject;

	public SpreadMineEffect(GameObject owner)
	{
		RecoveryPending.Hit("SpreadMineEffect..ctor");
	}

	private void Start()
	{
		RecoveryPending.Hit("SpreadMineEffect.Start");
	}

	public override void Init()
	{
		RecoveryPending.Hit("SpreadMineEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("SpreadMineEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("SpreadMineEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("SpreadMineEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("SpreadMineEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}

	protected void LaunchSpreader()
	{
		RecoveryPending.Hit("SpreadMineEffect.LaunchSpreader");
	}
}
