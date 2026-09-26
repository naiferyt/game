using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TrackUnlockHelper : MonoBehaviour
{
	[Serializable]
	public class TrackMedals
	{
		public RaceSettings track;

		public AchievementListener[] achievementList;
	}

	[Serializable]
	public class CircuitTracks
	{
		public string circuitName;

		public TrackMedals[] trackList;
	}

	public CircuitTracks[] circuitList;

	private bool canPranksgiving;

	private bool debugUnlock;

	public bool DebugUnlock
	{
		// RECUPERADO-AOT TrackUnlockHelper::get_DebugUnlock token 0x06000585 @0x00118b38
		get
		{
			return debugUnlock;
		}
		// RECUPERADO-AOT TrackUnlockHelper::set_DebugUnlock token 0x06000586 @0x00118b6c
		set
		{
			debugUnlock = value;
			if (debugUnlock)
			{
				UnlockAllEverything();
			}
		}
	}

	public bool CanPranksgiving
	{
		// RECUPERADO-AOT TrackUnlockHelper::get_CanPranksgiving token 0x06000588 @0x00118c00
		get
		{
			return canPranksgiving;
		}
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("TrackUnlockHelper.Start");
		yield break;
	}

	public bool GetHasEnoughMedals(string circuitName, int medals)
	{
		RecoveryPending.Hit("TrackUnlockHelper.GetHasEnoughMedals");
		return default(bool);
	}

	public int GetCircuitMedalCount(string circuitName)
	{
		RecoveryPending.Hit("TrackUnlockHelper.GetCircuitMedalCount");
		return default(int);
	}

	public bool IsCircuitUnlocked(string circuitName)
	{
		RecoveryPending.Hit("TrackUnlockHelper.IsCircuitUnlocked");
		return default(bool);
	}

	public bool CheckForPreraceSetupUnlock(string circuitName)
	{
		RecoveryPending.Hit("TrackUnlockHelper.CheckForPreraceSetupUnlock");
		return default(bool);
	}

	private void UnlockAllEverything()
	{
		RecoveryPending.Hit("TrackUnlockHelper.UnlockAllEverything");
	}

	public void RelockEverything()
	{
		RecoveryPending.Hit("TrackUnlockHelper.RelockEverything");
	}

	public int GetHighestTrackPlace(string trackName)
	{
		RecoveryPending.Hit("TrackUnlockHelper.GetHighestTrackPlace");
		return default(int);
	}

	public bool TestForUltraHard()
	{
		RecoveryPending.Hit("TrackUnlockHelper.TestForUltraHard");
		return default(bool);
	}

	public int GetTrackMedalCount(string trackName)
	{
		RecoveryPending.Hit("TrackUnlockHelper.GetTrackMedalCount");
		return default(int);
	}

	public GameObject[] GetCircuitTracks(string circuitName)
	{
		RecoveryPending.Hit("TrackUnlockHelper.GetCircuitTracks");
		return default(GameObject[]);
	}
}
