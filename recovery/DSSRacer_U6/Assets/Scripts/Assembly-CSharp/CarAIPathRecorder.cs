using System.Collections.Generic;
using UnityEngine;

public class CarAIPathRecorder : MonoBehaviour
{
	private const float deltaCompressThreshold = 35f;

	private bool isRecording;

	private List<CarAIPath.PathPoint> path;

	private void DeltaCompressPath()
	{
		RecoveryPending.Hit("CarAIPathRecorder.DeltaCompressPath");
	}

	private void DistanceCompressPath(List<CarAIPath.PathPoint> subpath)
	{
		RecoveryPending.Hit("CarAIPathRecorder.DistanceCompressPath");
	}

	private void DistanceCompressPathWithGroundChecking(List<CarAIPath.PathPoint> subpath)
	{
		RecoveryPending.Hit("CarAIPathRecorder.DistanceCompressPathWithGroundChecking");
	}

	private void Update()
	{
		RecoveryPending.Hit("CarAIPathRecorder.Update");
	}

	public void StartRecording()
	{
		RecoveryPending.Hit("CarAIPathRecorder.StartRecording");
	}

	public void FinishRecording()
	{
		RecoveryPending.Hit("CarAIPathRecorder.FinishRecording");
	}
}
