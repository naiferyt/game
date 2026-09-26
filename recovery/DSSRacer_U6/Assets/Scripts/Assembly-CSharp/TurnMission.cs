public class TurnMission : BaseMission
{
	public override void Init()
	{
		RecoveryPending.Hit("TurnMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("TurnMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("TurnMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("TurnMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("TurnMission.Signal");
	}
}
