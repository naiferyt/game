public class UsePowerupAIState : BaseCarAIState
{
	private const int carLayerMask = 512;

	public float RocketChancePercent;

	public float ShieldChancePercent;

	public float MineChancePercent;

	public override CarAI.AIStates GetAIStateEnum()
	{
		return default(CarAI.AIStates);
	}

	public override void Init()
	{
	}

	public override void Update()
	{
	}

	private void DoRocketEffectExecute(PowerupHolder holder)
	{
	}

	private void DoShieldEffectExecute(PowerupHolder holder)
	{
	}

	private void DoMineEffectExecute(PowerupHolder holder)
	{
	}

	public override void FixedUpdate()
	{
	}

	public override void Shutdown()
	{
	}
}
