using System.Collections.Generic;
using UnityEngine;

// Development tool of the original team: records the kart's pose every frame and, when finished, thins the
// recording (points at least 35 apart; on the ground only where the straight line keeps close to the terrain)
// and hands it to CarAIPathManager as a new rival driving line.
// Source listing: recovery/aot_listings/Assembly-CSharp/CarAIPathRecorder.txt
public class CarAIPathRecorder : MonoBehaviour
{
	private const float deltaCompressThreshold = 35f;

	private bool isRecording;

	// RECUPERADO-AOT CarAIPathRecorder::.ctor token 0x0600000f @0x000c1150 (field initializer)
	private List<CarAIPath.PathPoint> path = new List<CarAIPath.PathPoint>();

	// RECUPERADO-AOT CarAIPathRecorder::DeltaCompressPath token 0x06000010 @0x000c11b8
	// Splits the recording into runs of airborne / grounded points and compresses each run.
	private void DeltaCompressPath()
	{
		Debug.Log("Pre-compress points: " + path.Count);
		List<CarAIPath.PathPoint> list = new List<CarAIPath.PathPoint>();
		List<CarAIPath.PathPoint> list2 = new List<CarAIPath.PathPoint>();
		bool inAir = path[0].inAir;
		foreach (CarAIPath.PathPoint item in path)
		{
			if (item.inAir == inAir)
			{
				list2.Add(item);
				continue;
			}
			if (inAir)
			{
				DistanceCompressPath(list2);
			}
			else
			{
				DistanceCompressPathWithGroundChecking(list2);
			}
			list.AddRange(list2);
			list2.Clear();
			list2.Add(item);
			inAir = item.inAir;
		}
		if (list2.Count > 0)
		{
			if (inAir)
			{
				DistanceCompressPath(list2);
			}
			else
			{
				DistanceCompressPathWithGroundChecking(list2);
			}
			list.AddRange(list2);
		}
		path = list;
		Debug.Log("Post-compress points: " + path.Count);
	}

	// RECUPERADO-AOT CarAIPathRecorder::DistanceCompressPath token 0x06000011 @0x000c14d8
	private void DistanceCompressPath(List<CarAIPath.PathPoint> subpath)
	{
		Debug.Log("Standard decompress started with " + subpath.Count);
		for (int i = 1; i < subpath.Count; i++)
		{
			if (!(35f < (subpath[i].point - subpath[i - 1].point).magnitude))
			{
				subpath.RemoveAt(i);
				i--;
			}
		}
		Debug.Log("Standard compress ended with " + subpath.Count);
	}

	// RECUPERADO-AOT CarAIPathRecorder::DistanceCompressPathWithGroundChecking token 0x06000012 @0x000c16cc
	// From each kept point, jump to the first point more than 35 away, then halve the jump while the straight
	// segment hits geometry or, sampled every 0.2, floats 0.65 or more above the ground; the skipped points go.
	private void DistanceCompressPathWithGroundChecking(List<CarAIPath.PathPoint> subpath)
	{
		Debug.Log("Ground compress started with " + subpath.Count);
		for (int i = 0; i < subpath.Count; i++)
		{
			CarAIPath.PathPoint pathPoint = subpath[i];
			CarAIPath.PathPoint pathPoint2 = null;
			List<CarAIPath.PathPoint> list = new List<CarAIPath.PathPoint>();
			for (int j = i + 1; j < subpath.Count; j++)
			{
				CarAIPath.PathPoint pathPoint3 = subpath[j];
				if (35f < (pathPoint3.point - pathPoint.point).magnitude)
				{
					pathPoint2 = pathPoint3;
					break;
				}
				list.Add(pathPoint3);
			}
			if (pathPoint2 == null)
			{
				pathPoint2 = subpath[subpath.Count - 1];
			}
			Vector3 vector = pathPoint2.point - pathPoint.point;
			while (Physics.Raycast(pathPoint.point, vector.normalized, vector.magnitude))
			{
				int num = list.Count / 2;
				if (num == 0 || list.Count == 0)
				{
					pathPoint2 = null;
					break;
				}
				pathPoint2 = list[num];
				list.RemoveRange(num, list.Count - num);
				vector = pathPoint2.point - pathPoint.point;
			}
			if (pathPoint2 == null)
			{
				continue;
			}
			bool flag = false;
			do
			{
				flag = true;
				Vector3 vector2 = pathPoint2.point - pathPoint.point;
				for (float num2 = 0.2f; num2 < 1f; num2 += 0.2f)
				{
					Vector3 vector3 = pathPoint.point + vector2 * num2;
					RaycastHit hitInfo;
					if (Physics.Raycast(new Ray(vector3, Vector3.down), out hitInfo) && !((hitInfo.point - vector3).magnitude < 0.65f))
					{
						flag = false;
						int num3 = list.Count / 2;
						if (num3 == 0 || list.Count == 0)
						{
							pathPoint2 = null;
							break;
						}
						pathPoint2 = list[num3];
						list.RemoveRange(num3, list.Count - num3);
					}
				}
			}
			while (pathPoint2 != null && list.Count != 0 && !flag);
			if (pathPoint2 == null)
			{
				continue;
			}
			foreach (CarAIPath.PathPoint item in list)
			{
				subpath.Remove(item);
			}
		}
		Debug.Log("Ground compress ended with " + subpath.Count);
	}

	// RECUPERADO-AOT CarAIPathRecorder::Update token 0x06000013 @0x000c1f84
	private void Update()
	{
		if (isRecording)
		{
			CarAIPath.PathPoint pathPoint = new CarAIPath.PathPoint();
			pathPoint.point = base.transform.position;
			pathPoint.rotation = base.transform.rotation;
			if (GetComponent<CarCollider>() != null)
			{
				pathPoint.inAir = GetComponent<CarCollider>().isInAir;
			}
			else
			{
				pathPoint.inAir = false;
			}
			path.Add(pathPoint);
		}
	}

	// RECUPERADO-AOT CarAIPathRecorder::StartRecording token 0x06000014 @0x000c20b0
	public void StartRecording()
	{
		if (!isRecording)
		{
			path = new List<CarAIPath.PathPoint>();
			isRecording = true;
		}
	}

	// RECUPERADO-AOT CarAIPathRecorder::FinishRecording token 0x06000015 @0x000c2120
	public void FinishRecording()
	{
		if (isRecording)
		{
			Debug.Log("Applying AI path recording");
			isRecording = false;
			DeltaCompressPath();
			CarAIPath carAIPath = new CarAIPath();
			carAIPath.pathPoints = path.ToArray();
			CarAIPathManager.ProduceInstance();
			CarAIPathManager.AddPath(carAIPath);
		}
	}
}
