public class UsePowerupMission : BaseMission
{
	public override void Init()
	{
		RecoveryPending.Hit("UsePowerupMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("UsePowerupMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("UsePowerupMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("UsePowerupMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("UsePowerupMission.Signal");
	}
}
