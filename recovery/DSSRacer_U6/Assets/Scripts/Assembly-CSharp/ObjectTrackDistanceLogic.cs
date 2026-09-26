using UnityEngine;

public class ObjectTrackDistanceLogic : MonoBehaviour
{
	public float trackDistance;

	private void Start()
	{
		RecoveryPending.Hit("ObjectTrackDistanceLogic.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("ObjectTrackDistanceLogic.Update");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("ObjectTrackDistanceLogic.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("ObjectTrackDistanceLogic.OnDisable");
	}

	private void CalculateTrackDistance()
	{
		RecoveryPending.Hit("ObjectTrackDistanceLogic.CalculateTrackDistance");
	}
}
