using System;
using UnityEngine;

[Serializable]
public class CarAIPath
{
	[Serializable]
	public class PathPoint
	{
		public Vector3 point;

		public Quaternion rotation;

		public bool inAir;
	}

	public PathPoint[] pathPoints;

	public int GetSizeEstimate()
	{
		RecoveryPending.Hit("CarAIPath.GetSizeEstimate");
		return default(int);
	}
}
