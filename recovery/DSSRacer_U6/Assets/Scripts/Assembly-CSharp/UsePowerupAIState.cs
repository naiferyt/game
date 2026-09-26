public class UsePowerupAIState : BaseCarAIState
{
	private const int carLayerMask = 512;

	public float RocketChancePercent;

	public float ShieldChancePercent;

	public float MineChancePercent;

	public override CarAI.AIStates GetAIStateEnum()
	{
		RecoveryPending.Hit("UsePowerupAIState.GetAIStateEnum");
		return default(CarAI.AIStates);
	}

	public override void Init()
	{
		RecoveryPending.Hit("UsePowerupAIState.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("UsePowerupAIState.Update");
	}

	private void DoRocketEffectExecute(PowerupHolder holder)
	{
		RecoveryPending.Hit("UsePowerupAIState.DoRocketEffectExecute");
	}

	private void DoShieldEffectExecute(PowerupHolder holder)
	{
		RecoveryPending.Hit("UsePowerupAIState.DoShieldEffectExecute");
	}

	private void DoMineEffectExecute(PowerupHolder holder)
	{
		RecoveryPending.Hit("UsePowerupAIState.DoMineEffectExecute");
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("UsePowerupAIState.FixedUpdate");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("UsePowerupAIState.Shutdown");
	}
}
