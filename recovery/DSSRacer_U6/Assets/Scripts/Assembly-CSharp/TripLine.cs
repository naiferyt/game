using UnityEngine;

// Trip-wire dragged behind a kart by TripLineEffect: wipes out any other kart that touches it.
// Source listing: recovery/aot_listings/Assembly-CSharp/TripLine.txt
// RECUPERADO-AOT TripLine::.ctor token 0x060003e7 @0x000f94c8 (trivial constructor)
public class TripLine : MonoBehaviour
{
	// RECUPERADO-AOT TripLine::Start token 0x060003e8 @0x000f94fc
	private void Start()
	{
	}

	// RECUPERADO-AOT TripLine::Update token 0x060003e9 @0x000f9528
	private void Update()
	{
	}

	// RECUPERADO-AOT TripLine::OnTriggerEnter token 0x060003ea @0x000f9554
	private void OnTriggerEnter(Collider other)
	{
		if (!(other.transform.parent == base.transform.parent))
		{
			EffectManager component = other.gameObject.GetComponent<EffectManager>();
			if (component != null)
			{
				component.AddEffect(new WipeoutEffect(other.gameObject));
			}
		}
	}
}
