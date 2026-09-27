using UnityEngine;

// UFO laser beam (ShotDroneAI): stretched from the drone to the target (plus a random miss offset) for
// one second.
// Source listing: recovery/aot_listings/Assembly-CSharp/LaserLogic.txt
public class LaserLogic : MonoBehaviour
{
	private const float maxLife = 1f;

	private GameObject parentObject;

	private GameObject targetObject;

	// RECUPERADO-AOT LaserLogic::.ctor token 0x06000065 @0x000c970c (field initializers)
	private float lifetime = 1f;

	private Vector3 error = Vector3.zero;

	// RECUPERADO-AOT LaserLogic::Update token 0x06000066 @0x000c977c
	private void Update()
	{
		if (parentObject != null && targetObject != null)
		{
			base.transform.position = parentObject.transform.position;
			Vector3 vector = targetObject.transform.position + error - base.transform.position;
			base.transform.forward = vector.normalized;
			base.transform.localScale = new Vector3(1f, 1f, vector.magnitude);
		}
		lifetime -= Time.deltaTime;
		if (lifetime <= 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT LaserLogic::SetParent token 0x06000067 @0x000c9a3c
	private void SetParent(GameObject parent)
	{
		parentObject = parent;
	}

	// RECUPERADO-AOT LaserLogic::SetTarget token 0x06000068 @0x000c9a78
	private void SetTarget(GameObject target)
	{
		targetObject = target;
	}

	// RECUPERADO-AOT LaserLogic::ApplyError token 0x06000069 @0x000c9ab4
	// A missed shot lands 5-6 m ahead of the target.
	private void ApplyError()
	{
		if (targetObject != null)
		{
			error = targetObject.transform.forward * (5f + Random.value * 1f);
		}
	}
}
