using UnityEngine;

// Garage lift: moves linearly to a requested position over a given time.
// Source listing: recovery/aot_listings/Assembly-CSharp/LiftControlAI.txt
public class LiftControlAI : MonoBehaviour
{
	// RECUPERADO-AOT LiftControlAI::.ctor token 0x06000095 @0x000ce480 (field initializers)
	private Vector3 desiredPosition = Vector3.zero;

	private float duration;

	private Vector3 initialPosition = Vector3.zero;

	private float timer;

	// RECUPERADO-AOT LiftControlAI::Start token 0x06000096 @0x000ce4fc
	private void Start()
	{
		initialPosition = base.transform.position;
	}

	// RECUPERADO-AOT LiftControlAI::FixedUpdate token 0x06000097 @0x000ce564
	private void FixedUpdate()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
			if (timer < 0f)
			{
				timer = 0f;
			}
			float t = timer / duration;
			base.transform.position = Vector3.Lerp(desiredPosition, initialPosition, t);
		}
	}

	// RECUPERADO-AOT LiftControlAI::SetTransition token 0x06000098 @0x000ce6d8
	public void SetTransition(Vector3 newPosition, float time)
	{
		duration = (timer = time);
		desiredPosition = newPosition;
		initialPosition = base.transform.position;
	}
}
