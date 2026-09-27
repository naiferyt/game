using UnityEngine;

// Rigidbody launcher: an initial velocity along the object's rotation, then a constant drag force and a torque.
// Source listing: recovery/aot_listings/Assembly-CSharp/ForwardForceAI.txt
public class ForwardForceAI : MonoBehaviour
{
	// RECUPERADO-AOT ForwardForceAI::.ctor token 0x06000092 @0x000ce228 (field initializers)
	public Vector3 boost = Vector3.zero;

	public Vector3 force = Vector3.zero;

	public Vector3 torque = Vector3.zero;

	// RECUPERADO-AOT ForwardForceAI::Start token 0x06000093 @0x000ce2c8
	// ADAPTADO-U6: Component.rigidbody -> GetComponent<Rigidbody>(); Rigidbody.velocity is linearVelocity in Unity 6.
	private void Start()
	{
#if UNITY_6000_0_OR_NEWER
		GetComponent<Rigidbody>().linearVelocity = base.transform.rotation * boost;
#else
		GetComponent<Rigidbody>().velocity = base.transform.rotation * boost;
#endif
	}

	// RECUPERADO-AOT ForwardForceAI::FixedUpdate token 0x06000094 @0x000ce388
	private void FixedUpdate()
	{
		if (!RaceManager.isPaused)
		{
			GetComponent<Rigidbody>().AddForce(-force * Time.deltaTime);
			GetComponent<Rigidbody>().AddRelativeTorque(torque);
		}
	}
}
