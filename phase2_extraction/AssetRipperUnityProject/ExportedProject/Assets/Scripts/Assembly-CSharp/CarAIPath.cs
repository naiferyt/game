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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
