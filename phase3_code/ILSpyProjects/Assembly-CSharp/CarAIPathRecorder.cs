using System.Collections.Generic;
using UnityEngine;

public class CarAIPathRecorder : MonoBehaviour
{
	private const float deltaCompressThreshold = 35f;

	private bool isRecording;

	private List<CarAIPath.PathPoint> path;

	private void DeltaCompressPath()
	{
	}

	private void DistanceCompressPath(List<CarAIPath.PathPoint> subpath)
	{
	}

	private void DistanceCompressPathWithGroundChecking(List<CarAIPath.PathPoint> subpath)
	{
	}

	private void Update()
	{
	}

	public void StartRecording()
	{
	}

	public void FinishRecording()
	{
	}
}
