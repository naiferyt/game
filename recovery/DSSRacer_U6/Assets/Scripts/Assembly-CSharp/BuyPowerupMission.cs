public class BuyPowerupMission : BaseMission
{
	private void Start()
	{
		RecoveryPending.Hit("BuyPowerupMission.Start");
	}

	public override void Init()
	{
		RecoveryPending.Hit("BuyPowerupMission.Init");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("BuyPowerupMission.Shutdown");
	}

	public override void Update()
	{
		RecoveryPending.Hit("BuyPowerupMission.Update");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("BuyPowerupMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("BuyPowerupMission.Signal");
	}
}
