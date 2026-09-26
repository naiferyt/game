using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
	public List<BaseMission> missionList;

	public List<BaseMission> missionsPendingCompletion;

	public List<BaseMission> missionsPendingAdd;

	private bool hasStartedFirstMission;

	private bool curMissionComplete;

	private bool raceEnd;

	public bool CurrentMissionComplete
	{
		get
		{
			return default(bool);
		}
	}

	public bool AllMissionsComplete
	{
		get
		{
			return default(bool);
		}
	}

	public bool GetHasStartedFirstMission()
	{
		return default(bool);
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator WaitForNextMission(BaseMission mission)
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void AddMission(BaseMission mission)
	{
	}

	public void CompleteMission(BaseMission mission)
	{
	}

	public void Signal(string signal)
	{
	}

	public void Signal(string signal, object value)
	{
	}

	public BaseMission GetCurrentMission()
	{
		return default(BaseMission);
	}
}
