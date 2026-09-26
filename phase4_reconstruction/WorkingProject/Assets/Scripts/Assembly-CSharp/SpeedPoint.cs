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
		projPoint = default(Vector3);
		return default(bool);
	}

	public Vector3 GetSPLinePoint(Vector3 pos)
	{
		return default(Vector3);
	}

	public Vector3 GetSPLine()
	{
		return default(Vector3);
	}

	public bool IsPointForward(Vector3 point)
	{
		return default(bool);
	}

	public static SpeedPoint FindClosestSpeedPoint(Vector3 pos)
	{
		return default(SpeedPoint);
	}

	private void OnDrawGizmos()
	{
	}
}
