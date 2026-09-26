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
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public bool CanPranksgiving
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool GetHasEnoughMedals(string circuitName, int medals)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public int GetCircuitMedalCount(string circuitName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool IsCircuitUnlocked(string circuitName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool CheckForPreraceSetupUnlock(string circuitName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void UnlockAllEverything()
	{
	}

	public void RelockEverything()
	{
	}

	public int GetHighestTrackPlace(string trackName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool TestForUltraHard()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public int GetTrackMedalCount(string trackName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public GameObject[] GetCircuitTracks(string circuitName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
