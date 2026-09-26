public class CollectPowerupMission : BaseMission
{
	private bool hasStartedMission;

	public override void Init()
	{
		RecoveryPending.Hit("CollectPowerupMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("CollectPowerupMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("CollectPowerupMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("CollectPowerupMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("CollectPowerupMission.Signal");
	}
}
