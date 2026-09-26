using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BubbleJet : MonoBehaviour
{
	public float jetPower;

	private void Start()
	{
		RecoveryPending.Hit("BubbleJet.Start");
	}

	private void OnTriggerStay(Collider other)
	{
		RecoveryPending.Hit("BubbleJet.OnTriggerStay");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("BubbleJet.OnDrawGizmos");
	}
}
