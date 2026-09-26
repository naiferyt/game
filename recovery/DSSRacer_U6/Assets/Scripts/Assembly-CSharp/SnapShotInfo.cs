using System.Collections.Generic;

public class SnapShotInfo
{
	public List<CarSnapShot> carSnaps;

	public float raceTime;

	public void AddCarSnap(CarSnapShot carSnap)
	{
		RecoveryPending.Hit("SnapShotInfo.AddCarSnap");
	}

	public void DebugDump()
	{
		RecoveryPending.Hit("SnapShotInfo.DebugDump");
	}
}
