using System;
using UnityEngine;

public class WaypointLogic : MonoBehaviour
{
	public float waypointWallDist;

	public float waypointWallOffset;

	public WaypointLogic forwardPoint;

	public WaypointLogic backwardPoint;

	public bool projectsWalls;

	public bool isFirst;

	public WaypointLogic[] branchHints;

	public WaypointLogic forwardHint;

	[NonSerialized]
	public bool isBranch;

	public float distanceToNext;

	public float totalTrackDistance;

	public float distanceToPrev
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private bool ProjectOnWPLine(WaypointLogic otherPoint, Vector3 pos, out Vector3 projPoint)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Vector3 GetTrackPoint(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public float GetWallDistanceAtPoint(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Vector3 GetWallOffsetForPoint(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static float GetTrackDistanceForPoint(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static WaypointLogic FindClosestWaypoint(Vector3 pos, bool ignoreBranches)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static WaypointLogic FindNextWaypoint(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static float FindWallDistance(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void WaypointPrecalculations(WaypointLogic first)
	{
	}

	private void OnDrawGizmos()
	{
	}
}
