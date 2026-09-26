using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Circuit/track progression: medals (achievements per track), best places ("Highest Place <track>" metrics),
// race-option ("Prerace Setup") unlocks, and the Pranksgiving availability switch.
// Source listing: recovery/aot_listings/Assembly-CSharp/TrackUnlockHelper.txt
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

	// RECUPERADO-AOT TrackUnlockHelper::Start token 0x06000587 @0x00118bb8
	// (iterator <Start>c__Iterator49 MoveNext token 0x0600098a @0x001508d4)
	// ELIMINADO (contenido remoto muerto): the original downloaded http://datg-apps.com/ss/pranksgiving.txt and set
	//     canPranksgiving = flag.ToLower() != "locked" && flag.ToLower() != "lock"
	// from its JSON field "Pranksgiving". RECONSTRUIDO: local switch, enabled by default (decision D2).
	[DebuggerHidden]
	private IEnumerator Start()
	{
		canPranksgiving = RecoverySwitches.PranksgivingEnabled;
		yield break;
	}

	// RECUPERADO-AOT TrackUnlockHelper::GetHasEnoughMedals token 0x06000589 @0x00118c34
	public bool GetHasEnoughMedals(string circuitName, int medals)
	{
		return GetCircuitMedalCount(circuitName) >= medals;
	}

	// RECUPERADO-AOT TrackUnlockHelper::GetCircuitMedalCount token 0x0600058a @0x00118c90
	// (predicate <GetCircuitMedalCount>c__AnonStorey98::<>m__19 token 0x06000b44)
	public int GetCircuitMedalCount(string circuitName)
	{
		CircuitTracks circuitTracks = Array.Find(circuitList, (CircuitTracks x) => x.circuitName.Equals(circuitName));
		if (circuitTracks == null)
		{
			return -1;
		}
		int num = 0;
		TrackMedals[] trackList = circuitTracks.trackList;
		foreach (TrackMedals trackMedals in trackList)
		{
			AchievementListener[] achievementList = trackMedals.achievementList;
			foreach (AchievementListener achievementListener in achievementList)
			{
				if (achievementListener.HasAchieved())
				{
					num++;
				}
			}
		}
		return num;
	}

	// RECUPERADO-AOT TrackUnlockHelper::IsCircuitUnlocked token 0x0600058b @0x00118e50
	// True when every track of the circuit has been finished in the top three (places are 0-based).
	public bool IsCircuitUnlocked(string circuitName)
	{
		CheckForPreraceSetupUnlock(circuitName);
		int num = 0;
		CircuitTracks[] array = circuitList;
		foreach (CircuitTracks circuitTracks in array)
		{
			if (!(circuitTracks.circuitName == circuitName))
			{
				continue;
			}
			TrackMedals[] trackList = circuitTracks.trackList;
			foreach (TrackMedals trackMedals in trackList)
			{
				int highestTrackPlace = GetHighestTrackPlace(trackMedals.track.UIName.baseText);
				if (highestTrackPlace > 2 || highestTrackPlace < 0)
				{
					return false;
				}
				num++;
			}
			if (num >= 3)
			{
				return true;
			}
		}
		return false;
	}

	// RECUPERADO-AOT TrackUnlockHelper::CheckForPreraceSetupUnlock token 0x0600058c @0x00118f9c
	// First place on the three tracks of a circuit unlocks its race options.
	public bool CheckForPreraceSetupUnlock(string circuitName)
	{
		int num = 0;
		CircuitTracks[] array = circuitList;
		foreach (CircuitTracks circuitTracks in array)
		{
			if (circuitTracks.circuitName == circuitName)
			{
				TrackMedals[] trackList = circuitTracks.trackList;
				foreach (TrackMedals trackMedals in trackList)
				{
					if (GetHighestTrackPlace(trackMedals.track.UIName.baseText) == 0)
					{
						num++;
					}
				}
			}
		}
		if (num == 3)
		{
			DataUtility.Instance.Unlock(circuitName + " Prerace Setup");
			return true;
		}
		return false;
	}

	// RECUPERADO-AOT TrackUnlockHelper::UnlockAllEverything token 0x0600058d @0x001190ec
	private void UnlockAllEverything()
	{
		CircuitTracks[] array = circuitList;
		foreach (CircuitTracks circuitTracks in array)
		{
			DataUtility.Instance.Unlock(circuitTracks.circuitName + " Prerace Setup");
			TrackMedals[] trackList = circuitTracks.trackList;
			foreach (TrackMedals trackMedals in trackList)
			{
				LifetimeMetrics.SetMetric("Highest Place " + trackMedals.track.UIName.baseText, 0f);
			}
		}
	}

	// RECUPERADO-AOT TrackUnlockHelper::RelockEverything token 0x0600058e @0x0011923c
	public void RelockEverything()
	{
		CircuitTracks[] array = circuitList;
		foreach (CircuitTracks circuitTracks in array)
		{
			DataUtility.Instance.Relock(circuitTracks.circuitName + " Prerace Setup");
			TrackMedals[] trackList = circuitTracks.trackList;
			foreach (TrackMedals trackMedals in trackList)
			{
				LifetimeMetrics.SetMetric("Highest Place " + trackMedals.track.UIName.baseText, -1f);
			}
		}
	}

	// RECUPERADO-AOT TrackUnlockHelper::GetHighestTrackPlace token 0x0600058f @0x0011938c
	// Best finishing place (0 = 1st) or -1 when never raced. (The original compares against float.NaN with ==,
	// which is never true; a missing metric is NaN and still yields -1 through the "> -1" test.)
	public int GetHighestTrackPlace(string trackName)
	{
		CircuitTracks[] array = circuitList;
		foreach (CircuitTracks circuitTracks in array)
		{
			TrackMedals[] trackList = circuitTracks.trackList;
			foreach (TrackMedals trackMedals in trackList)
			{
				if (trackMedals.track.UIName.baseText == trackName)
				{
					float num = DataUtility.Instance.lifeTimeMetrics["Highest Place " + trackName];
					if (!(num > -1f))
					{
						return -1;
					}
					return (int)num;
				}
			}
		}
		return -1;
	}

	// RECUPERADO-AOT TrackUnlockHelper::TestForUltraHard token 0x06000590 @0x00119518
	public bool TestForUltraHard()
	{
		int num = 0;
		CircuitTracks[] array = circuitList;
		foreach (CircuitTracks circuitTracks in array)
		{
			if (CheckForPreraceSetupUnlock(circuitTracks.circuitName))
			{
				num++;
			}
		}
		return num >= circuitList.Length;
	}

	// RECUPERADO-AOT TrackUnlockHelper::GetTrackMedalCount token 0x06000591 @0x001195d4
	// (predicate <GetTrackMedalCount>c__AnonStorey99::<>m__1A token 0x06000b46)
	public int GetTrackMedalCount(string trackName)
	{
		CircuitTracks[] array = circuitList;
		foreach (CircuitTracks circuitTracks in array)
		{
			TrackMedals trackMedals = Array.Find(circuitTracks.trackList, (TrackMedals x) => x.track.UIName.baseText.Equals(trackName));
			if (trackMedals != null)
			{
				int num = 0;
				AchievementListener[] achievementList = trackMedals.achievementList;
				foreach (AchievementListener achievementListener in achievementList)
				{
					if (achievementListener.HasAchieved())
					{
						num++;
					}
				}
				return num;
			}
		}
		return -1;
	}

	// RECUPERADO-AOT TrackUnlockHelper::GetCircuitTracks token 0x06000592 @0x00119778
	// (predicate <GetCircuitTracks>c__AnonStorey9A::<>m__1B token 0x06000b48)
	public GameObject[] GetCircuitTracks(string circuitName)
	{
		CircuitTracks circuitTracks = Array.Find(circuitList, (CircuitTracks x) => x.circuitName.Equals(circuitName));
		if (circuitTracks == null)
		{
			return null;
		}
		GameObject[] array = new GameObject[circuitTracks.trackList.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = circuitTracks.trackList[i].track.gameObject;
		}
		return array;
	}
}
