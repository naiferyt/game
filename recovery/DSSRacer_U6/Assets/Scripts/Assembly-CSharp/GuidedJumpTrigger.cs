using UnityEngine;

public class GuidedJumpTrigger : MonoBehaviour
{
	public GameObject jumpTarget;

	public AnimationCurve jumpCurve;

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("GuidedJumpTrigger.OnTriggerEnter");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("GuidedJumpTrigger.OnDrawGizmos");
	}
}
