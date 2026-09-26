using UnityEngine;

public class SpringTrigger : MonoBehaviour
{
	public Vector3 springPower;

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("SpringTrigger.OnTriggerEnter");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("SpringTrigger.OnDrawGizmos");
	}
}
