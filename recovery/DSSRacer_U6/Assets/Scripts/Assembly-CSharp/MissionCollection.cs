using UnityEngine;

// A mission made of several sub-missions played in order; completes when the last one is done.
// Source listing: recovery/aot_listings/Assembly-CSharp/MissionCollection.txt
public class MissionCollection : BaseMission
{
	private int currentMission;

	public BaseMission[] missionList;

	// RECUPERADO-AOT MissionCollection::.ctor token 0x060002c1 @0x000eb474 (field initializer)
	private bool checkWhetherCurrentMissionIsCompleted = true;

	// RECUPERADO-AOT MissionCollection::Init token 0x060002c2 @0x000eb4b0
	public override void Init()
	{
		currentMission = 0;
		for (int i = 0; i < missionList.Length; i++)
		{
			missionList[i].manager = manager;
			missionList[i].missionCollection = this;
		}
	}

	// RECUPERADO-AOT MissionCollection::GetHasArrow token 0x060002c3 @0x000eb544
	public new bool GetHasArrow()
	{
		return missionList[currentMission].hasArrow;
	}

	// RECUPERADO-AOT MissionCollection::Update token 0x060002c4 @0x000eb5ac
	public override void Update()
	{
		if (!RaceManager.isPaused && currentMission < missionList.Length)
		{
			hasArrow = missionList[currentMission].hasArrow;
			if (hasArrow)
			{
				arrowRotation = missionList[currentMission].arrowRotation;
				arrowXOffset = missionList[currentMission].arrowXOffset;
				arrowYOffset = missionList[currentMission].arrowYOffset;
			}
			if (checkWhetherCurrentMissionIsCompleted)
			{
				missionList[currentMission].Update();
			}
		}
	}

	// RECUPERADO-AOT MissionCollection::Shutdown token 0x060002c5 @0x000eb71c (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT MissionCollection::Signal token 0x060002c6 @0x000eb748
	public override void Signal(string signal)
	{
		if (currentMission < missionList.Length)
		{
			missionList[currentMission].Signal(signal);
		}
	}

	// RECUPERADO-AOT MissionCollection::Signal token 0x060002c7 @0x000eb7d4
	public override void Signal(string signal, object value)
	{
		if (currentMission >= missionList.Length)
		{
			return;
		}
		if (signal == "Mission Complete" && ((BaseMission)value).missionName == missionList[currentMission].missionName)
		{
			currentMission++;
			if (currentMission >= missionList.Length)
			{
				manager.CompleteMission(this);
				return;
			}
			UnityEngine.Debug.Log("Going to the next mission... " + missionList[currentMission].missionName);
			checkWhetherCurrentMissionIsCompleted = false;
			if (HUDLogic.Instance != null)
			{
				HUDLogic.Instance.StartCoroutine(HUDLogic.Instance.SignalMissionComplete(false));
			}
		}
		else if (currentMission < missionList.Length)
		{
			missionList[currentMission].Signal(signal, value);
		}
	}

	// RECUPERADO-AOT MissionCollection::getCheckCurrentMission token 0x060002c8 @0x000eb9d8
	public bool getCheckCurrentMission()
	{
		return checkWhetherCurrentMissionIsCompleted;
	}

	// RECUPERADO-AOT MissionCollection::setCheckCurrentMission token 0x060002c9 @0x000eba0c
	public void setCheckCurrentMission(bool newValue)
	{
		checkWhetherCurrentMissionIsCompleted = newValue;
	}

	// RECUPERADO-AOT MissionCollection::GetAreThereAnyMissionsLeft token 0x060002ca @0x000eba48
	public bool GetAreThereAnyMissionsLeft()
	{
		return currentMission < missionList.Length;
	}

	// RECUPERADO-AOT MissionCollection::GetTaskDisplay token 0x060002cb @0x000eba90
	public new string GetTaskDisplay()
	{
		if (currentMission < missionList.Length)
		{
			return missionList[currentMission].GetTaskDisplay();
		}
		return "The currentMission is too high!";
	}

	// RECUPERADO-AOT MissionCollection::GetCurrentMission token 0x060002cc @0x000ebb24
	public BaseMission GetCurrentMission()
	{
		return missionList[currentMission];
	}
}
