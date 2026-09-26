using UnityEngine;

public class TripLine : MonoBehaviour
{
	private void Start()
	{
		RecoveryPending.Hit("TripLine.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("TripLine.Update");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("TripLine.OnTriggerEnter");
	}
}
