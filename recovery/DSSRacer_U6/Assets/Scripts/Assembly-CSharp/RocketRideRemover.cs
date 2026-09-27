using UnityEngine;

// Trigger volume that ends a rocket ride (RocketRideEffect) for karts passing through it.
// Source listing: recovery/aot_listings/Assembly-CSharp/RocketRideRemover.txt
// RECUPERADO-AOT RocketRideRemover::.ctor token 0x0600056c @0x00114db0 (trivial constructor)
public class RocketRideRemover : MonoBehaviour
{
	// RECUPERADO-AOT RocketRideRemover::Start token 0x0600056d @0x00114de4
	private void Start()
	{
	}

	// RECUPERADO-AOT RocketRideRemover::Update token 0x0600056e @0x00114e10
	private void Update()
	{
	}

	// RECUPERADO-AOT RocketRideRemover::OnTriggerEnter token 0x0600056f @0x00114e3c
	private void OnTriggerEnter(Collider other)
	{
		EffectManager component = other.GetComponent<EffectManager>();
		if (component != null && component.HasEffect(typeof(RocketRideEffect)))
		{
			component.RemoveEffect(component.GetStrongestEffect(typeof(RocketRideEffect)));
		}
	}
}
