using UnityEngine;

// Bouncing basketball hazard (child of a rigidbody): hops randomly while grounded, knocks karts back
// and is pushed away by them; frozen while the race is paused.
// Source listing: recovery/aot_listings/Assembly-CSharp/BasketBall.txt
public class BasketBall : MonoBehaviour
{
	// RECUPERADO-AOT BasketBall::.ctor token 0x060004bc @0x00107538 (field initializers)
	private float bounceTimer = 1f;

	private bool bounceBack;

	private Vector3 lastBounce = Vector3.zero;

	// RECUPERADO-AOT BasketBall::Update token 0x060004bd @0x001075a8
	// ADAPTADO-U6: Component.rigidbody -> GetComponent<Rigidbody>(); Rigidbody.velocity is linearVelocity in Unity 6.
	// Alternates a random hop with the mirrored hop back, so the ball stays around its spot.
	private void Update()
	{
		if (RaceManager.isPaused)
		{
			base.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			return;
		}
		base.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		if (bounceTimer > 0f)
		{
			bounceTimer -= Time.deltaTime;
			return;
		}
#if UNITY_6000_0_OR_NEWER
		float y = base.transform.parent.GetComponent<Rigidbody>().linearVelocity.y;
#else
		float y = base.transform.parent.GetComponent<Rigidbody>().velocity.y;
#endif
		if (!(Mathf.Abs(y) < 0.001f))
		{
			return;
		}
		bounceTimer = 1f;
		if (bounceBack)
		{
			lastBounce.x *= -1f;
			lastBounce.z *= -1f;
			base.transform.parent.GetComponent<Rigidbody>().AddForce(lastBounce);
		}
		else
		{
			Vector2 insideUnitCircle = Random.insideUnitCircle;
			Vector3 vector = Vector3.up * 50f;
			vector.x += insideUnitCircle.x * 100f * Random.value;
			vector.z += insideUnitCircle.y * 100f * Random.value;
			lastBounce = vector;
			base.transform.parent.GetComponent<Rigidbody>().AddForce(lastBounce);
		}
		bounceBack = !bounceBack;
		PlayBounceSound();
	}

	// RECUPERADO-AOT BasketBall::PlayBounceSound token 0x060004be @0x0010799c
	private void PlayBounceSound()
	{
		SoundSequencer component = GetComponent<SoundSequencer>();
		if (component != null)
		{
			component.RequestPlay("Basketball");
		}
	}

	// RECUPERADO-AOT BasketBall::OnTriggerEnter token 0x060004bf @0x00107a10
	// ADAPTADO-U6: Component.rigidbody -> GetComponent<Rigidbody>().
	// Rivals get a GimpedCarAI bump; the player's kart loses its velocity component towards the ball.
	private void OnTriggerEnter(Collider other)
	{
		CarCollider component = other.GetComponent<CarCollider>();
		if (component != null)
		{
			Vector3 vector = base.transform.position - other.transform.position;
			Vector3 force = vector.normalized * 1000f;
			force.y = 100f;
			base.transform.parent.GetComponent<Rigidbody>().AddForce(force);
			GimpedCarAI component2 = other.GetComponent<GimpedCarAI>();
			if (component2 != null)
			{
				component2.Bump(vector.normalized * -10f);
			}
			else
			{
				component.TransformVelocity(-vector.normalized * Vector3.Dot(component.GetVelocity(), vector.normalized));
			}
		}
		PlayBounceSound();
	}
}
