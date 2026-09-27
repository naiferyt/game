using UnityEngine;

// Underwater bubble jet: pushes karts inside the trigger along its forward axis.
// Source listing: recovery/aot_listings/Assembly-CSharp/BubbleJet.txt
[RequireComponent(typeof(Collider))]
public class BubbleJet : MonoBehaviour
{
	// RECUPERADO-AOT BubbleJet::.ctor token 0x060004c8 @0x00107f2c (field initializer)
	public float jetPower = 100f;

	// RECUPERADO-AOT BubbleJet::Start token 0x060004c9 @0x00107f78
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	private void Start()
	{
		if (!GetComponent<Collider>().isTrigger)
		{
			Debug.LogError("A bubble jet has a collider that is not a trigger!");
		}
	}

	// RECUPERADO-AOT BubbleJet::OnTriggerStay token 0x060004ca @0x00107fd4
	private void OnTriggerStay(Collider other)
	{
		CarCollider component = other.GetComponent<CarCollider>();
		if (component != null)
		{
			component.TransformVelocity(base.transform.forward * jetPower * Time.deltaTime);
		}
	}

	// RECUPERADO-AOT BubbleJet::OnDrawGizmos token 0x060004cb @0x001080bc
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 30f);
	}
}
