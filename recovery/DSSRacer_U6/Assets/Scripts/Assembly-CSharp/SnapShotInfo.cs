using System.Collections.Generic;
using UnityEngine;

// All karts' snapshots for one lap plus the race clock at that moment.
// Source listing: recovery/aot_listings/Assembly-CSharp/SnapShotInfo.txt
public class SnapShotInfo
{
	// RECUPERADO-AOT SnapShotInfo::.ctor token 0x0600024f @0x000e5d34 (field initializer)
	public List<CarSnapShot> carSnaps = new List<CarSnapShot>();

	public float raceTime;

	// RECUPERADO-AOT SnapShotInfo::AddCarSnap token 0x06000250 @0x000e5d98
	public void AddCarSnap(CarSnapShot carSnap)
	{
		carSnaps.Add(carSnap);
	}

	// RECUPERADO-AOT SnapShotInfo::DebugDump token 0x06000251 @0x000e5de0
	public void DebugDump()
	{
		string text = string.Empty;
		foreach (CarSnapShot carSnap in carSnaps)
		{
			text = text + "Carsnap: " + carSnap.name + "\tProg: " + carSnap.prog + "\n";
		}
		Debug.Log(text + "RaceTime: " + raceTime.ToString());
	}
}
