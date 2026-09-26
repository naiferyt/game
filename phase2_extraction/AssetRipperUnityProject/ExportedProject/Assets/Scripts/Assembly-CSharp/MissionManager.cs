using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool AllMissionsComplete
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool GetHasStartedFirstMission()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public IEnumerator WaitForNextMission(BaseMission mission)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
