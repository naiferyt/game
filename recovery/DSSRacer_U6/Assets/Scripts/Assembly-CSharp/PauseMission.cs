public class PauseMission : BaseMission
{
	public override void Init()
	{
		RecoveryPending.Hit("PauseMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("PauseMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("PauseMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("PauseMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("PauseMission.Signal");
	}
}
