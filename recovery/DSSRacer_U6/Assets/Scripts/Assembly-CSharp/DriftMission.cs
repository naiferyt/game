public class DriftMission : BaseMission
{
	public bool isBoost;

	private bool hasStartedMission;

	public override void Init()
	{
		RecoveryPending.Hit("DriftMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("DriftMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("DriftMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("DriftMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("DriftMission.Signal");
	}
}
