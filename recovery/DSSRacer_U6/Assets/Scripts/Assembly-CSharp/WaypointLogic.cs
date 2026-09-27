using System;
using System.Collections.Generic;
using UnityEngine;

// Track spine: a linked chain of waypoints (with branch shortcuts) giving distance along the track, the
// nearest track point and the drivable width (walls) used by karts, AI and progress.
// Source listing: recovery/aot_listings/Assembly-CSharp/WaypointLogic.txt
public class WaypointLogic : MonoBehaviour
{
	// RECUPERADO-AOT WaypointLogic::.ctor token 0x06000578 @0x00115c68 (field initializers)
	public float waypointWallDist = 9f;

	public float waypointWallOffset;

	public WaypointLogic forwardPoint;

	public WaypointLogic backwardPoint;

	public bool projectsWalls = true;

	public bool isFirst;

	public WaypointLogic[] branchHints;

	public WaypointLogic forwardHint;

	[NonSerialized]
	public bool isBranch;

	public float distanceToNext;

	public float totalTrackDistance;

	public float distanceToPrev
	{
		// RECUPERADO-AOT WaypointLogic::get_distanceToPrev token 0x06000579 @0x00115cbc
		get
		{
			if (backwardPoint == null)
			{
				return 0f;
			}
			return backwardPoint.distanceToNext;
		}
	}

	// RECUPERADO-AOT WaypointLogic::ProjectOnWPLine token 0x0600057a @0x00115d34
	// Projects pos on the segment towards otherPoint (with a 0.001 tolerance at both ends).
	private bool ProjectOnWPLine(WaypointLogic otherPoint, Vector3 pos, out Vector3 projPoint)
	{
		Vector3 vector = otherPoint.transform.position - base.transform.position;
		Vector3 rhs = pos - base.transform.position;
		float num = Vector3.Dot(vector.normalized, rhs);
		if (num + 0.001f < 0f || !(vector.magnitude >= num - 0.001f))
		{
			projPoint = Vector3.zero;
			return false;
		}
		projPoint = base.transform.position + vector.normalized * num;
		return true;
	}

	// ADAPTADO-U6 (2026-09-27): the original divides by the segment length; a few waypoints of the original data share
	// the same position (Kick Butt Track 2 "Waypoint 92"/"93", Kick Butt Track 3 two "Waypoint 3", Fish Hooks Track 2
	// "Waypoint 2nxtra2"/"3", 1 cm) and gave 0/0 = NaN: a kart near them got a NaN position from the road walls, spread it
	// to the others through the kart-to-kart checks and Unity 6 crashed (Bus Jumper). Segments under 5 cm use ratio 0.
	private static float SegmentRatio(Vector3 part, Vector3 segment)
	{
		float length = segment.magnitude;
		if (length < 0.05f)
		{
			return 0f;
		}
		return part.magnitude / length;
	}

	// RECUPERADO-AOT WaypointLogic::GetTrackPoint token 0x0600057b @0x00115fc4
	// Closest of: this waypoint, the projection on the next segment, the projection on the previous one.
	public Vector3 GetTrackPoint(Vector3 pos)
	{
		Vector3 result = base.transform.position;
		float num = (base.transform.position - pos).sqrMagnitude;
		Vector3 projPoint;
		if (forwardPoint != null && ProjectOnWPLine(forwardPoint, pos, out projPoint))
		{
			float sqrMagnitude = (projPoint - pos).sqrMagnitude;
			if (!(num < sqrMagnitude))
			{
				result = projPoint;
				num = sqrMagnitude;
			}
		}
		Vector3 projPoint2;
		if (backwardPoint != null && ProjectOnWPLine(backwardPoint, pos, out projPoint2))
		{
			float sqrMagnitude2 = (projPoint2 - pos).sqrMagnitude;
			if (!(num < sqrMagnitude2))
			{
				result = projPoint2;
			}
		}
		return result;
	}

	// RECUPERADO-AOT WaypointLogic::GetWallDistanceAtPoint token 0x0600057c @0x001162ec
	// Half-width of the track at pos, interpolated along the segment (infinite where walls are not projected).
	public float GetWallDistanceAtPoint(Vector3 pos)
	{
		Vector3 projPoint = Vector3.zero;
		if (forwardPoint != null && ProjectOnWPLine(forwardPoint, pos, out projPoint))
		{
			if (!projectsWalls)
			{
				return float.PositiveInfinity;
			}
			Vector3 vector = projPoint - base.transform.position;
			Vector3 vector2 = forwardPoint.transform.position - base.transform.position;
			return (forwardPoint.waypointWallDist - waypointWallDist) * SegmentRatio(vector, vector2) + waypointWallDist;
		}
		if (backwardPoint != null && ProjectOnWPLine(backwardPoint, pos, out projPoint))
		{
			if (!backwardPoint.projectsWalls)
			{
				return float.PositiveInfinity;
			}
			Vector3 vector3 = projPoint - backwardPoint.transform.position;
			Vector3 vector4 = base.transform.position - backwardPoint.transform.position;
			return (waypointWallDist - backwardPoint.waypointWallDist) * SegmentRatio(vector3, vector4) + backwardPoint.waypointWallDist;
		}
		return waypointWallDist;
	}

	// RECUPERADO-AOT WaypointLogic::GetWallOffsetForPoint token 0x0600057d @0x001167c4
	// Sideways shift of the track centre at pos (along the segment's left normal), interpolated.
	public Vector3 GetWallOffsetForPoint(Vector3 pos)
	{
		Vector3 projPoint = Vector3.zero;
		if (forwardPoint != null && ProjectOnWPLine(forwardPoint, pos, out projPoint))
		{
			Vector3 vector = forwardPoint.transform.position - base.transform.position;
			Vector3 vector2 = -Vector3.Cross(Vector3.up, vector.normalized);
			Vector3 vector3 = projPoint - base.transform.position;
			return vector2 * ((forwardPoint.waypointWallOffset - waypointWallOffset) * SegmentRatio(vector3, vector) + waypointWallOffset);
		}
		if (backwardPoint != null && ProjectOnWPLine(backwardPoint, pos, out projPoint))
		{
			Vector3 vector4 = base.transform.position - backwardPoint.transform.position;
			Vector3 vector5 = -Vector3.Cross(Vector3.up, vector4.normalized);
			Vector3 vector6 = projPoint - backwardPoint.transform.position;
			return vector5 * ((waypointWallOffset - backwardPoint.waypointWallOffset) * SegmentRatio(vector6, vector4) + backwardPoint.waypointWallOffset);
		}
		return Vector3.zero;
	}

	// RECUPERADO-AOT WaypointLogic::GetTrackDistanceForPoint token 0x0600057e @0x00116d74
	// Distance along the track: the closest waypoint's total plus the flat (xz) projection on its segment; the
	// previous segment is used when the point lies behind the waypoint.
	public static float GetTrackDistanceForPoint(Vector3 pos)
	{
		WaypointLogic waypointLogic = FindClosestWaypoint(pos, false);
		if (waypointLogic.forwardPoint == null)
		{
			Debug.LogError("Track distance may be skewed. (No forward point on " + waypointLogic.name + ".)");
			return waypointLogic.totalTrackDistance;
		}
		Vector3 vector = waypointLogic.forwardPoint.transform.position - waypointLogic.transform.position;
		vector.y = 0f;
		Vector3 rhs = pos - waypointLogic.transform.position;
		rhs.y = 0f;
		vector.Normalize();
		float num = Vector3.Dot(vector, rhs) + waypointLogic.totalTrackDistance;
		if (num < 0f)
		{
			if (waypointLogic.backwardPoint == null)
			{
				Debug.LogError("Track distance may be skewed. (No backward point on " + waypointLogic.name + ".)");
				return waypointLogic.totalTrackDistance;
			}
			vector = waypointLogic.transform.position - waypointLogic.backwardPoint.transform.position;
			vector.y = 0f;
			rhs = pos - waypointLogic.backwardPoint.transform.position;
			rhs.y = 0f;
			vector.Normalize();
			num = Vector3.Dot(vector, rhs) + waypointLogic.backwardPoint.totalTrackDistance;
		}
		return num;
	}

	// RECUPERADO-AOT WaypointLogic::FindClosestWaypoint token 0x0600057f @0x001171e8
	public static WaypointLogic FindClosestWaypoint(Vector3 pos, bool ignoreBranches)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Waypoint");
		GameObject gameObject = null;
		float num = 0f;
		foreach (GameObject gameObject2 in array)
		{
			if (!ignoreBranches || !gameObject2.GetComponent<WaypointLogic>().isBranch)
			{
				float sqrMagnitude = (gameObject2.transform.position - pos).sqrMagnitude;
				if (gameObject == null || sqrMagnitude < num)
				{
					gameObject = gameObject2;
					num = sqrMagnitude;
				}
			}
		}
		if (gameObject != null)
		{
			return gameObject.GetComponent<WaypointLogic>();
		}
		return null;
	}

	// RECUPERADO-AOT WaypointLogic::FindNextWaypoint token 0x06000580 @0x001173d0
	public static WaypointLogic FindNextWaypoint(Vector3 pos)
	{
		WaypointLogic waypointLogic = FindClosestWaypoint(pos, false);
		Vector3 projPoint;
		if (waypointLogic.ProjectOnWPLine(waypointLogic.forwardPoint, pos, out projPoint))
		{
			return waypointLogic.forwardPoint;
		}
		return waypointLogic;
	}

	// RECUPERADO-AOT WaypointLogic::FindWallDistance token 0x06000581 @0x00117488
	public static float FindWallDistance(Vector3 pos)
	{
		WaypointLogic waypointLogic = FindClosestWaypoint(pos, true);
		if (waypointLogic == null)
		{
			return 0f;
		}
		return waypointLogic.GetWallDistanceAtPoint(pos);
	}

	// RECUPERADO-AOT WaypointLogic::WaypointPrecalculations token 0x06000582 @0x00117528
	// Walks the waypoint graph from the first waypoint (offset by the lap line) accumulating distances; a
	// waypoint is visited once its predecessor is known (up to 1000 deferrals). Branch runs then get their
	// distances spread evenly between the main-line waypoints they join, and each progress trigger stores its
	// own track distance.
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	public static void WaypointPrecalculations(WaypointLogic first)
	{
		float num = 0f;
		if (RaceManager.Instance.lapLine != null)
		{
			Vector3 trackPoint = first.GetTrackPoint(RaceManager.Instance.lapLine.gameObject.transform.position);
			num = (first.transform.position - trackPoint).magnitude;
		}
		if (first.forwardPoint != null)
		{
			first.distanceToNext = (first.forwardPoint.transform.position - first.transform.position).magnitude;
		}
		else
		{
			first.distanceToNext = 0f;
		}
		first.totalTrackDistance = num;
		List<WaypointLogic> list = new List<WaypointLogic>();
		List<WaypointLogic> list2 = new List<WaypointLogic>();
		list2.Add(first);
		list.Add(first.forwardPoint);
		WaypointLogic[] array = first.branchHints;
		foreach (WaypointLogic item in array)
		{
			list.Add(item);
		}
		int num2 = 0;
		while (list.Count > 0)
		{
			WaypointLogic waypointLogic = list[0];
			list.RemoveAt(0);
			if (list2.Contains(waypointLogic))
			{
				continue;
			}
			if (!list2.Contains(waypointLogic.backwardPoint))
			{
				list.Add(waypointLogic);
				num2++;
				if (num2 > 1000)
				{
					Debug.LogError("Aborting WaypointPrecalculations because there were too many defered calculations.");
					return;
				}
				continue;
			}
			waypointLogic.totalTrackDistance = waypointLogic.backwardPoint.totalTrackDistance + waypointLogic.backwardPoint.distanceToNext;
			if (waypointLogic.forwardPoint != null)
			{
				waypointLogic.distanceToNext = (waypointLogic.forwardPoint.transform.position - waypointLogic.transform.position).magnitude;
			}
			else
			{
				waypointLogic.distanceToNext = 0f;
			}
			if (waypointLogic.backwardPoint.isBranch || waypointLogic.backwardPoint.forwardPoint != waypointLogic)
			{
				waypointLogic.isBranch = true;
			}
			list2.Add(waypointLogic);
			list.Add(waypointLogic.forwardPoint);
			WaypointLogic[] array2 = waypointLogic.branchHints;
			foreach (WaypointLogic item2 in array2)
			{
				list.Add(item2);
			}
		}
		List<List<WaypointLogic>> list3 = new List<List<WaypointLogic>>();
		UnityEngine.Object[] array3 = U4Compat.FindObjectsOfType(typeof(WaypointLogic));
		for (int k = 0; k < array3.Length; k++)
		{
			WaypointLogic waypointLogic2 = (WaypointLogic)array3[k];
			if (!waypointLogic2.isBranch || waypointLogic2.forwardPoint.isBranch)
			{
				continue;
			}
			List<WaypointLogic> list4 = new List<WaypointLogic>();
			list4.Add(waypointLogic2);
			WaypointLogic waypointLogic3 = waypointLogic2;
			while (waypointLogic3.isBranch)
			{
				if (waypointLogic3.backwardPoint.isBranch)
				{
					list4.Add(waypointLogic3.backwardPoint);
				}
				waypointLogic3 = waypointLogic3.backwardPoint;
			}
			list3.Add(list4);
		}
		foreach (List<WaypointLogic> item3 in list3)
		{
			float totalTrackDistance = item3[0].forwardPoint.totalTrackDistance;
			float totalTrackDistance2 = item3[item3.Count - 1].backwardPoint.totalTrackDistance;
			float num3 = (totalTrackDistance - totalTrackDistance2) / (float)(item3.Count + 1);
			for (int num4 = item3.Count - 1; num4 >= 0; num4--)
			{
				WaypointLogic waypointLogic4 = item3[num4];
				waypointLogic4.distanceToNext = num3;
				waypointLogic4.totalTrackDistance = waypointLogic4.backwardPoint.totalTrackDistance + num3;
			}
		}
		UnityEngine.Object[] array4 = U4Compat.FindObjectsOfType(typeof(ProgressTriggerLogic));
		for (int l = 0; l < array4.Length; l++)
		{
			ProgressTriggerLogic progressTriggerLogic = (ProgressTriggerLogic)array4[l];
			progressTriggerLogic.trackDistance = GetTrackDistanceForPoint(progressTriggerLogic.transform.position);
		}
	}

	// RECUPERADO-AOT WaypointLogic::OnDrawGizmos token 0x06000583 @0x00117f78
	// Editor view: waypoint sphere, links, and the wall lines of each projecting segment.
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, 0.5f);
		if (forwardPoint != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(base.transform.position, forwardPoint.transform.position);
			if (projectsWalls)
			{
				Vector3 rhs = forwardPoint.transform.position - base.transform.position;
				rhs.y = 0f;
				rhs.Normalize();
				Vector3 vector = -Vector3.Cross(Vector3.up, rhs);
				float wallDistanceAtPoint = GetWallDistanceAtPoint(base.transform.position);
				Vector3 vector2 = base.transform.position + GetWallOffsetForPoint(base.transform.position);
				float wallDistanceAtPoint2 = GetWallDistanceAtPoint(forwardPoint.transform.position);
				Vector3 vector3 = forwardPoint.transform.position + GetWallOffsetForPoint(forwardPoint.transform.position);
				Gizmos.color = Color.red;
				Gizmos.DrawLine(vector2 + vector * wallDistanceAtPoint, vector3 + vector * wallDistanceAtPoint2);
				Gizmos.DrawLine(vector2 - vector * wallDistanceAtPoint, vector3 - vector * wallDistanceAtPoint2);
			}
		}
		if (backwardPoint != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(base.transform.position, backwardPoint.transform.position);
			if (backwardPoint.projectsWalls)
			{
				Vector3 rhs2 = base.transform.position - backwardPoint.transform.position;
				rhs2.y = 0f;
				rhs2.Normalize();
				Vector3 vector4 = -Vector3.Cross(Vector3.up, rhs2);
				float wallDistanceAtPoint3 = GetWallDistanceAtPoint(base.transform.position);
				Vector3 vector5 = base.transform.position + GetWallOffsetForPoint(base.transform.position);
				float wallDistanceAtPoint4 = GetWallDistanceAtPoint(backwardPoint.transform.position);
				Vector3 vector6 = backwardPoint.transform.position + GetWallOffsetForPoint(backwardPoint.transform.position);
				Gizmos.color = Color.red;
				Gizmos.DrawLine(vector5 + vector4 * wallDistanceAtPoint3, vector6 + vector4 * wallDistanceAtPoint4);
				Gizmos.DrawLine(vector5 - vector4 * wallDistanceAtPoint3, vector6 - vector4 * wallDistanceAtPoint4);
			}
		}
	}
}
