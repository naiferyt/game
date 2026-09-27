using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Runs the missions of a Mission-mode race on the player kart: updates the active ones, forwards signals,
// shows the HUD start/complete banners and ends the race when no mission is left.
// Source listing: recovery/aot_listings/Assembly-CSharp/MissionManager.txt
public class MissionManager : MonoBehaviour
{
	// RECUPERADO-AOT MissionManager::.ctor token 0x060002cd @0x000ebb88 (field initializers)
	public List<BaseMission> missionList = new List<BaseMission>();

	public List<BaseMission> missionsPendingCompletion = new List<BaseMission>();

	public List<BaseMission> missionsPendingAdd = new List<BaseMission>();

	private bool hasStartedFirstMission;

	private bool curMissionComplete;

	private bool raceEnd;

	public bool CurrentMissionComplete
	{
		// RECUPERADO-AOT MissionManager::get_CurrentMissionComplete token 0x060002d1 @0x000ebd10
		get
		{
			return curMissionComplete;
		}
	}

	public bool AllMissionsComplete
	{
		// RECUPERADO-AOT MissionManager::get_AllMissionsComplete token 0x060002d2 @0x000ebd44
		get
		{
			return missionList.Count == 0;
		}
	}

	// RECUPERADO-AOT MissionManager::GetHasStartedFirstMission token 0x060002ce @0x000ebc4c
	public bool GetHasStartedFirstMission()
	{
		return hasStartedFirstMission;
	}

	// RECUPERADO-AOT MissionManager::WaitForNextMission token 0x060002cf @0x000ebc80
	// RECUPERADO-AOT MissionManager/<WaitForNextMission>c__Iterator23::MoveNext token 0x060008a2 @0x001480b4
	[DebuggerHidden]
	public IEnumerator WaitForNextMission(BaseMission mission)
	{
		if (mission.missionCollection != null)
		{
			float timer = 0f;
			mission.missionCollection.setCheckCurrentMission(false);
			yield return 0;
			do
			{
				timer += Time.deltaTime;
				yield return 0;
			}
			while (timer < 3.4f);
			mission.missionCollection.setCheckCurrentMission(true);
			curMissionComplete = false;
			yield return 0;
		}
	}

	// RECUPERADO-AOT MissionManager::Start token 0x060002d0 @0x000ebcd8
	private void Start()
	{
		hasStartedFirstMission = false;
	}

	// RECUPERADO-AOT MissionManager::Update token 0x060002d3 @0x000ebd90
	private void Update()
	{
		foreach (BaseMission item in missionsPendingAdd)
		{
			missionList.Add(item);
		}
		missionsPendingAdd.Clear();
		foreach (BaseMission mission in missionList)
		{
			if (!hasStartedFirstMission)
			{
				hasStartedFirstMission = true;
				StartCoroutine(HUDLogic.Instance.SignalMissionStart(false));
			}
			mission.Update();
		}
		foreach (BaseMission item2 in missionsPendingCompletion)
		{
			item2.Shutdown();
			missionList.Remove(item2);
		}
		missionsPendingCompletion.Clear();
		if (missionList.Count == 0 && !raceEnd)
		{
			StartCoroutine(RaceManager.Instance.PostRaceCountdown(false));
			raceEnd = true;
		}
	}

	// RECUPERADO-AOT MissionManager::AddMission token 0x060002d4 @0x000ec1a8
	public void AddMission(BaseMission mission)
	{
		mission.manager = this;
		mission.Init();
		missionsPendingAdd.Add(mission);
	}

	// RECUPERADO-AOT MissionManager::CompleteMission token 0x060002d5 @0x000ec208
	public void CompleteMission(BaseMission mission)
	{
		curMissionComplete = true;
		UnityEngine.Debug.Log("Mission complete: " + mission.missionName);
		if (mission.missionCollection == null)
		{
			missionsPendingCompletion.Add(mission);
			Signal("Mission Complete", mission);
			StartCoroutine(HUDLogic.Instance.SignalMissionComplete(true));
		}
		else
		{
			Signal("Mission Complete", mission);
			StartCoroutine(WaitForNextMission(mission));
		}
	}

	// RECUPERADO-AOT MissionManager::Signal token 0x060002d6 @0x000ec2f4
	public void Signal(string signal)
	{
		foreach (BaseMission mission in missionList)
		{
			mission.Signal(signal);
		}
	}

	// RECUPERADO-AOT MissionManager::Signal token 0x060002d7 @0x000ec440
	public void Signal(string signal, object value)
	{
		foreach (BaseMission mission in missionList)
		{
			mission.Signal(signal, value);
		}
	}

	// RECUPERADO-AOT MissionManager::GetCurrentMission token 0x060002d8 @0x000ec594
	public BaseMission GetCurrentMission()
	{
		return missionList[0];
	}
}
