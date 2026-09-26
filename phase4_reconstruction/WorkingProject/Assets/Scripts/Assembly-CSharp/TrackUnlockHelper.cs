using System;
using System.Collections;
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
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public bool CanPranksgiving
	{
		get
		{
			return default(bool);
		}
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Start()
	{
		return default(IEnumerator);
	}

	public bool GetHasEnoughMedals(string circuitName, int medals)
	{
		return default(bool);
	}

	public int GetCircuitMedalCount(string circuitName)
	{
		return default(int);
	}

	public bool IsCircuitUnlocked(string circuitName)
	{
		return default(bool);
	}

	public bool CheckForPreraceSetupUnlock(string circuitName)
	{
		return default(bool);
	}

	private void UnlockAllEverything()
	{
	}

	public void RelockEverything()
	{
	}

	public int GetHighestTrackPlace(string trackName)
	{
		return default(int);
	}

	public bool TestForUltraHard()
	{
		return default(bool);
	}

	public int GetTrackMedalCount(string trackName)
	{
		return default(int);
	}

	public GameObject[] GetCircuitTracks(string circuitName)
	{
		return default(GameObject[]);
	}
}
