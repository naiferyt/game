using UnityEngine;

// AI state: drive to a visible power-up box ahead of the kart (not a coin), until it is taken or left behind.
// Source listing: recovery/aot_listings/Assembly-CSharp/DrivePickupAIState.txt
// RECUPERADO-AOT DrivePickupAIState::.ctor token 0x0600003d @0x000c5b4c (trivial constructor)
public class DrivePickupAIState : BaseCarAIState
{
	public const float MIN_DIST = 40f;

	public GameObject desiredPickup;

	// RECUPERADO-AOT DrivePickupAIState::GetAIStateEnum token 0x0600003e @0x000c5b78
	public override CarAI.AIStates GetAIStateEnum()
	{
		return CarAI.AIStates.getPickup;
	}

	// RECUPERADO-AOT DrivePickupAIState::Init token 0x0600003f @0x000c5ba8
	public override void Init()
	{
		Collider[] array = Physics.OverlapSphere(parentAI.gameObject.transform.position, parentAI.personality.awarenessRadius);
		foreach (Collider collider in array)
		{
			Vector3 vector = collider.transform.position - parentAI.transform.position;
			Ray ray = new Ray(parentAI.transform.position, vector.normalized);
			if (!Physics.Raycast(ray, vector.magnitude, 2048) && collider.tag == "Pickup" && collider.gameObject.GetComponent<Coin>() == null
				&& !(0f >= Vector3.Dot(parentAI.transform.forward, vector)) && !(vector.sqrMagnitude < 1600f))
			{
				desiredPickup = collider.gameObject;
				break;
			}
		}
	}

	// RECUPERADO-AOT DrivePickupAIState::Update token 0x06000040 @0x000c5ef8
	public override void Update()
	{
		if (desiredPickup == null)
		{
			parentAI.StateDone(this);
			return;
		}
		Vector3 vector = desiredPickup.transform.position - parentAI.transform.position;
		float num = Vector3.Dot(parentAI.transform.forward, vector);
		if (!(num >= 0f))
		{
			parentAI.StateDone(this);
		}
		if (!(vector.magnitude >= parentAI.DistEpsilon))
		{
			desiredPickup = null;
		}
	}

	// RECUPERADO-AOT DrivePickupAIState::FixedUpdate token 0x06000041 @0x000c60bc
	public override void FixedUpdate()
	{
		if (!(desiredPickup == null))
		{
			parentAI.DriveTowardPoint(desiredPickup.transform.position);
		}
	}

	// RECUPERADO-AOT DrivePickupAIState::Shutdown token 0x06000042 @0x000c6144
	public override void Shutdown()
	{
	}
}
