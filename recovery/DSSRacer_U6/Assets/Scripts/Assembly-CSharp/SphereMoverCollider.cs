using UnityEngine;

// Trigger on a SphereMoverAI's surroundings: anything with a SphereMoverAI that enters bounces off this object.
// Source listing: recovery/aot_listings/Assembly-CSharp/SphereMoverCollider.txt
// RECUPERADO-AOT SphereMoverCollider::.ctor token 0x060000a8 @0x000cf61c (trivial constructor)
public class SphereMoverCollider : MonoBehaviour
{
	// RECUPERADO-AOT SphereMoverCollider::Start token 0x060000a9 @0x000cf650
	private void Start()
	{
	}

	// RECUPERADO-AOT SphereMoverCollider::Update token 0x060000aa @0x000cf67c
	private void Update()
	{
	}

	// RECUPERADO-AOT SphereMoverCollider::OnTriggerEnter token 0x060000ab @0x000cf6a8
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter!!");
		SphereMoverAI component = other.GetComponent<SphereMoverAI>();
		if (component != null)
		{
			component.CollisionReflect(base.transform);
		}
	}
}
