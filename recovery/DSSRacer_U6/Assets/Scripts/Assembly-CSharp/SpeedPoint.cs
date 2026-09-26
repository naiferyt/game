using System;
using UnityEngine;

public class SpeedPoint : MonoBehaviour
{
	[Serializable]
	public class SpeedBranchStruct
	{
		public SpeedPoint target;

		public float weight;
	}

	public SpeedPoint forwardPoint;

	public SpeedPoint backwardPoint;

	public SpeedBranchStruct[] branches;

	private bool ProjectOnSPLine(SpeedPoint otherPoint, Vector3 pos, out Vector3 projPoint)
	{
		RecoveryPending.Hit("SpeedPoint.ProjectOnSPLine");
		projPoint = default(Vector3);
		return default(bool);
	}

	public Vector3 GetSPLinePoint(Vector3 pos)
	{
		RecoveryPending.Hit("SpeedPoint.GetSPLinePoint");
		return default(Vector3);
	}

	public Vector3 GetSPLine()
	{
		RecoveryPending.Hit("SpeedPoint.GetSPLine");
		return default(Vector3);
	}

	public bool IsPointForward(Vector3 point)
	{
		RecoveryPending.Hit("SpeedPoint.IsPointForward");
		return default(bool);
	}

	public static SpeedPoint FindClosestSpeedPoint(Vector3 pos)
	{
		RecoveryPending.Hit("SpeedPoint.FindClosestSpeedPoint");
		return default(SpeedPoint);
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("SpeedPoint.OnDrawGizmos");
	}
}
