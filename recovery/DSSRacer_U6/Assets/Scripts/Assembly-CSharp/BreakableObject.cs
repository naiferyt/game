using UnityEngine;

// Prop that disappears when hit faster than breakSpeed (CarCollider sends CollideBreak).
// Source listing: recovery/aot_listings/Assembly-CSharp/BreakableObject.txt
public class BreakableObject : MonoBehaviour
{
	// RECUPERADO-AOT BreakableObject::.ctor token 0x060004c4 @0x00107e14 (field initializer)
	public float breakSpeed = 50f;

	// RECUPERADO-AOT BreakableObject::CollideBreak token 0x060004c5 @0x00107e60
	private void CollideBreak(float speed)
	{
		if (breakSpeed < speed)
		{
			base.gameObject.SetActive(false);
			Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT BreakableObject::Start token 0x060004c6 @0x00107ed4
	private void Start()
	{
	}

	// RECUPERADO-AOT BreakableObject::Update token 0x060004c7 @0x00107f00
	private void Update()
	{
	}
}
