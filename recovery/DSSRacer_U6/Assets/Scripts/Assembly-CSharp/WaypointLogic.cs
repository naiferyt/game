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
			RecoveryPending.Hit("WaypointLogic.get_distanceToPrev");
			return default(float);
		}
	}

	private bool ProjectOnWPLine(WaypointLogic otherPoint, Vector3 pos, out Vector3 projPoint)
	{
		RecoveryPending.Hit("WaypointLogic.ProjectOnWPLine");
		projPoint = default(Vector3);
		return default(bool);
	}

	public Vector3 GetTrackPoint(Vector3 pos)
	{
		RecoveryPending.Hit("WaypointLogic.GetTrackPoint");
		return default(Vector3);
	}

	public float GetWallDistanceAtPoint(Vector3 pos)
	{
		RecoveryPending.Hit("WaypointLogic.GetWallDistanceAtPoint");
		return default(float);
	}

	public Vector3 GetWallOffsetForPoint(Vector3 pos)
	{
		RecoveryPending.Hit("WaypointLogic.GetWallOffsetForPoint");
		return default(Vector3);
	}

	public static float GetTrackDistanceForPoint(Vector3 pos)
	{
		RecoveryPending.Hit("WaypointLogic.GetTrackDistanceForPoint");
		return default(float);
	}

	public static WaypointLogic FindClosestWaypoint(Vector3 pos, bool ignoreBranches)
	{
		RecoveryPending.Hit("WaypointLogic.FindClosestWaypoint");
		return default(WaypointLogic);
	}

	public static WaypointLogic FindNextWaypoint(Vector3 pos)
	{
		RecoveryPending.Hit("WaypointLogic.FindNextWaypoint");
		return default(WaypointLogic);
	}

	public static float FindWallDistance(Vector3 pos)
	{
		RecoveryPending.Hit("WaypointLogic.FindWallDistance");
		return default(float);
	}

	public static void WaypointPrecalculations(WaypointLogic first)
	{
		RecoveryPending.Hit("WaypointLogic.WaypointPrecalculations");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("WaypointLogic.OnDrawGizmos");
	}
}
