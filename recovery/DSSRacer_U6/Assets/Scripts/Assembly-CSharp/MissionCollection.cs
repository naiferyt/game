public class MissionCollection : BaseMission
{
	private int currentMission;

	public BaseMission[] missionList;

	private bool checkWhetherCurrentMissionIsCompleted;

	public override void Init()
	{
		RecoveryPending.Hit("MissionCollection.Init");
	}

	public new bool GetHasArrow()
	{
		RecoveryPending.Hit("MissionCollection.GetHasArrow");
		return default(bool);
	}

	public override void Update()
	{
		RecoveryPending.Hit("MissionCollection.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("MissionCollection.Shutdown");
	}

	public override void Signal(string signal)
	{
		RecoveryPending.Hit("MissionCollection.Signal");
	}

	public override void Signal(string signal, object value)
	{
		RecoveryPending.Hit("MissionCollection.Signal");
	}

	public bool getCheckCurrentMission()
	{
		RecoveryPending.Hit("MissionCollection.getCheckCurrentMission");
		return default(bool);
	}

	public void setCheckCurrentMission(bool newValue)
	{
		RecoveryPending.Hit("MissionCollection.setCheckCurrentMission");
	}

	public bool GetAreThereAnyMissionsLeft()
	{
		RecoveryPending.Hit("MissionCollection.GetAreThereAnyMissionsLeft");
		return default(bool);
	}

	public new string GetTaskDisplay()
	{
		RecoveryPending.Hit("MissionCollection.GetTaskDisplay");
		return default(string);
	}

	public BaseMission GetCurrentMission()
	{
		RecoveryPending.Hit("MissionCollection.GetCurrentMission");
		return default(BaseMission);
	}
}
