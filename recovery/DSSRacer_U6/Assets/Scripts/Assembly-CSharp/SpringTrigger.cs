using UnityEngine;

// Spring pad: adds springPower to the velocity of a kart entering the trigger.
// Source listing: recovery/aot_listings/Assembly-CSharp/SpringTrigger.txt
// RECUPERADO-AOT SpringTrigger::.ctor token 0x060004f8 @0x0010c190 (trivial constructor)
public class SpringTrigger : MonoBehaviour
{
	public Vector3 springPower;

	// RECUPERADO-AOT SpringTrigger::OnTriggerEnter token 0x060004f9 @0x0010c1c4
	private void OnTriggerEnter(Collider other)
	{
		CarCollider component = other.gameObject.GetComponent<CarCollider>();
		if (!(component == null))
		{
			component.TransformVelocity(springPower);
		}
	}

	// RECUPERADO-AOT SpringTrigger::OnDrawGizmos token 0x060004fa @0x0010c268
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.size);
	}
}
