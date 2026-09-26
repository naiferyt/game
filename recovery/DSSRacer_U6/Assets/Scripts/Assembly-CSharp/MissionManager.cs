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
			RecoveryPending.Hit("MissionManager.get_CurrentMissionComplete");
			return default(bool);
		}
	}

	public bool AllMissionsComplete
	{
		get
		{
			RecoveryPending.Hit("MissionManager.get_AllMissionsComplete");
			return default(bool);
		}
	}

	// RECUPERADO-AOT MissionManager::GetHasStartedFirstMission token 0x060002ce @0x000ebc4c
	public bool GetHasStartedFirstMission()
	{
		return hasStartedFirstMission;
	}

	[DebuggerHidden]
	public IEnumerator WaitForNextMission(BaseMission mission)
	{
		RecoveryPending.Hit("MissionManager.WaitForNextMission");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("MissionManager.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("MissionManager.Update");
	}

	public void AddMission(BaseMission mission)
	{
		RecoveryPending.Hit("MissionManager.AddMission");
	}

	public void CompleteMission(BaseMission mission)
	{
		RecoveryPending.Hit("MissionManager.CompleteMission");
	}

	public void Signal(string signal)
	{
		RecoveryPending.Hit("MissionManager.Signal");
	}

	public void Signal(string signal, object value)
	{
		RecoveryPending.Hit("MissionManager.Signal");
	}

	public BaseMission GetCurrentMission()
	{
		RecoveryPending.Hit("MissionManager.GetCurrentMission");
		return default(BaseMission);
	}
}
