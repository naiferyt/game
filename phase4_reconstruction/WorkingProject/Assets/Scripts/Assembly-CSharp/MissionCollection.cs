public class MissionCollection : BaseMission
{
	private int currentMission;

	public BaseMission[] missionList;

	private bool checkWhetherCurrentMissionIsCompleted;

	public override void Init()
	{
	}

	public new bool GetHasArrow()
	{
		return default(bool);
	}

	public override void Update()
	{
	}

	public override void Shutdown()
	{
	}

	public override void Signal(string signal)
	{
	}

	public override void Signal(string signal, object value)
	{
	}

	public bool getCheckCurrentMission()
	{
		return default(bool);
	}

	public void setCheckCurrentMission(bool newValue)
	{
	}

	public bool GetAreThereAnyMissionsLeft()
	{
		return default(bool);
	}

	public new string GetTaskDisplay()
	{
		return default(string);
	}

	public BaseMission GetCurrentMission()
	{
		return default(BaseMission);
	}
}
