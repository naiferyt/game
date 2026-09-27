using UnityEngine;

// Teleport pad: sends karts entering the trigger to target (TeleportEffect).
// Source listing: recovery/aot_listings/Assembly-CSharp/TeleportTrigger.txt
// RECUPERADO-AOT TeleportTrigger::.ctor token 0x060004fb @0x0010c354 (trivial constructor)
public class TeleportTrigger : MonoBehaviour
{
	public Transform target;

	// RECUPERADO-AOT TeleportTrigger::OnTriggerEnter token 0x060004fc @0x0010c388
	private void OnTriggerEnter(Collider other)
	{
		if (target == null)
		{
			Debug.Log("This Trigger has no Target!!");
		}
		else if (!(other.gameObject.GetComponent<CarCollider>() == null))
		{
			EffectManager component = other.gameObject.GetComponent<EffectManager>();
			if (!(component == null))
			{
				component.AddEffect(new TeleportEffect(other.gameObject, target.position, false));
			}
		}
	}

	// RECUPERADO-AOT TeleportTrigger::OnDrawGizmos token 0x060004fd @0x0010c4d8
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	private void OnDrawGizmos()
	{
		if (target != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(base.transform.position, target.position);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(target.position, 1f);
		}
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.size);
	}
}
