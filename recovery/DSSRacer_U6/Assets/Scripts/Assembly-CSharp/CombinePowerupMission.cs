public class CombinePowerupMission : BaseMission
{
	private void Start()
	{
		RecoveryPending.Hit("CombinePowerupMission.Start");
	}

	public override void Init()
	{
		RecoveryPending.Hit("CombinePowerupMission.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("CombinePowerupMission.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("CombinePowerupMission.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("CombinePowerupMission.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("CombinePowerupMission.Signal");
	}
}
