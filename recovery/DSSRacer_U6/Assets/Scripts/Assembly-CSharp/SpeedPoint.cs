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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Vector3 GetSPLinePoint(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Vector3 GetSPLine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool IsPointForward(Vector3 point)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static SpeedPoint FindClosestSpeedPoint(Vector3 pos)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnDrawGizmos()
	{
	}
}
