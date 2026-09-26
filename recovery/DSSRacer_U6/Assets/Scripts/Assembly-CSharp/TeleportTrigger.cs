using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
	public Transform target;

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("TeleportTrigger.OnTriggerEnter");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("TeleportTrigger.OnDrawGizmos");
	}
}
