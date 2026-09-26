using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BubbleJet : MonoBehaviour
{
	public float jetPower;

	private void Start()
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}

	private void OnDrawGizmos()
	{
	}
}
