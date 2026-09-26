using UnityEngine;

public class SphereMoverCollider : MonoBehaviour
{
	private void Start()
	{
		RecoveryPending.Hit("SphereMoverCollider.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("SphereMoverCollider.Update");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("SphereMoverCollider.OnTriggerEnter");
	}
}
