public class FinishTheLapMission : BaseMission
{
	public override void Init()
	{
		RecoveryPending.Hit("FinishTheLapMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("FinishTheLapMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("FinishTheLapMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("FinishTheLapMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("FinishTheLapMission.Signal");
	}
}
