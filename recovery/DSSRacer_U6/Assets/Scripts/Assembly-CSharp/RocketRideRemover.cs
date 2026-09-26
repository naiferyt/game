using UnityEngine;

public class RocketRideRemover : MonoBehaviour
{
	private void Start()
	{
		RecoveryPending.Hit("RocketRideRemover.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("RocketRideRemover.Update");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("RocketRideRemover.OnTriggerEnter");
	}
}
