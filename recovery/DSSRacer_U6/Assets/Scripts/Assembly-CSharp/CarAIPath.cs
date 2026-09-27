using System;
using UnityEngine;

// One recorded driving line: positions, orientations and airborne flags sampled along the track.
// RECUPERADO-AOT CarAIPath::.ctor token 0x06000001 @0x000c08f0 (trivial constructor)
[Serializable]
public class CarAIPath
{
	// RECUPERADO-AOT CarAIPath/PathPoint::.ctor token 0x06000003 @0x000c095c (trivial constructor)
	[Serializable]
	public class PathPoint
	{
		public Vector3 point;

		public Quaternion rotation;

		public bool inAir;
	}

	public PathPoint[] pathPoints;

	// RECUPERADO-AOT CarAIPath::GetSizeEstimate token 0x06000002 @0x000c091c
	public int GetSizeEstimate()
	{
		return pathPoints.Length * 28;
	}
}
