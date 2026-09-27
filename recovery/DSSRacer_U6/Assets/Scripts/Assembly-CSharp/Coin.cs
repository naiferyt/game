using UnityEngine;

// Track token: spins at a slightly random speed; the player kart picking it up earns COIN_VALUE coins.
// Source listing: recovery/aot_listings/Assembly-CSharp/Coin.txt
public class Coin : MonoBehaviour
{
	public const int COIN_VALUE = 10;

	private AudioSource audioSource;

	public GameObject pickupCoinEffectPrefab;

	// RECUPERADO-AOT Coin::Start token 0x060004cd @0x00108208
	private void Start()
	{
		RotatorAI component = GetComponent<RotatorAI>();
		if (component != null)
		{
			Vector3 rotationSpeed = component.rotationSpeed;
			rotationSpeed.y += Random.Range(-5f, 20f);
			component.rotationSpeed = rotationSpeed;
		}
	}

	// RECUPERADO-AOT Coin::OnTriggerEnter token 0x060004ce @0x00108328
	// ADAPTADO-U6: Transform.FindChild -> Find.
	private void OnTriggerEnter(Collider collider)
	{
		if (!RaceManager.IsPlayerCar(collider.gameObject))
		{
			return;
		}
		DataUtility.Instance.AddPlayerMoney(10);
		CarMetrics component = collider.GetComponent<CarMetrics>();
		if (component != null)
		{
			component.Signal("Tokens Collected");
		}
		SoundSequencer component2 = collider.gameObject.GetComponent<SoundSequencer>();
		if (component2 != null)
		{
			component2.RequestPlay("coinPickup");
		}
		if (collider.transform.Find("Tokens Pickup Particles") == null)
		{
			GameObject gameObject = Object.Instantiate(pickupCoinEffectPrefab, collider.transform.position, collider.transform.rotation) as GameObject;
			gameObject.transform.parent = collider.transform;
			gameObject.name = "Tokens Pickup Particles";
		}
		Object.Destroy(base.gameObject);
	}
}
