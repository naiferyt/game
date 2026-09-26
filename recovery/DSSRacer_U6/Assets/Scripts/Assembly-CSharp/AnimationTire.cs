using UnityEngine;

// Spins the kart's tire objects around their local X axis at the kart's speed (backwards when reversing).
// Source listing: recovery/aot_listings/Assembly-CSharp/AnimationTire.txt
public class AnimationTire : MonoBehaviour
{
	public GameObject[] tires;

	private CarCollider owner;

	private float velocity;

	private GimpedCarAI gimped;

	// RECUPERADO-AOT AnimationTire::Start token 0x060001a0 @0x000d60d0
	private void Start()
	{
		if (owner == null)
		{
			owner = base.gameObject.GetComponent<CarCollider>();
		}
		gimped = base.gameObject.GetComponent<GimpedCarAI>();
	}

	// RECUPERADO-AOT AnimationTire::Update token 0x060001a1 @0x000d6160
	private void Update()
	{
		if (RaceManager.isPaused)
		{
			return;
		}
		if (gimped != null)
		{
			velocity = gimped.LinearVelocity;
			for (int i = 0; i < tires.Length; i++)
			{
				tires[i].transform.Rotate(Vector3.right, gimped.LinearVelocity * Time.deltaTime);
			}
			return;
		}
		if (owner == null)
		{
			if (base.transform.parent != null)
			{
				owner = base.gameObject.GetComponent<CarCollider>();
			}
			return;
		}
		velocity = owner.GetVelocity().magnitude;
		float num = Vector3.Dot(owner.transform.forward, owner.GetVelocity());
		for (int j = 0; j < tires.Length; j++)
		{
			if (num > 0f)
			{
				tires[j].transform.Rotate(Vector3.right, velocity * Time.deltaTime);
			}
			else
			{
				tires[j].transform.Rotate(-Vector3.right, velocity * Time.deltaTime);
			}
		}
	}
}
