public class BrakeMission : BaseMission
{
	private bool hasStartedMission;

	public override void Init()
	{
		RecoveryPending.Hit("BrakeMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("BrakeMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("BrakeMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("BrakeMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("BrakeMission.Signal");
	}
}
