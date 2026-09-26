using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
	public bool underGap;

	public Transform spawnPoint;

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("ResetTrigger.OnTriggerEnter");
	}
}
