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
			return default(float);
		}
	}

	private bool ProjectOnWPLine(WaypointLogic otherPoint, Vector3 pos, out Vector3 projPoint)
	{
		projPoint = default(Vector3);
		return default(bool);
	}

	public Vector3 GetTrackPoint(Vector3 pos)
	{
		return default(Vector3);
	}

	public float GetWallDistanceAtPoint(Vector3 pos)
	{
		return default(float);
	}

	public Vector3 GetWallOffsetForPoint(Vector3 pos)
	{
		return default(Vector3);
	}

	public static float GetTrackDistanceForPoint(Vector3 pos)
	{
		return default(float);
	}

	public static WaypointLogic FindClosestWaypoint(Vector3 pos, bool ignoreBranches)
	{
		return default(WaypointLogic);
	}

	public static WaypointLogic FindNextWaypoint(Vector3 pos)
	{
		return default(WaypointLogic);
	}

	public static float FindWallDistance(Vector3 pos)
	{
		return default(float);
	}

	public static void WaypointPrecalculations(WaypointLogic first)
	{
	}

	private void OnDrawGizmos()
	{
	}
}
