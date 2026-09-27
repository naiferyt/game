using UnityEngine;

// Power-up box on the track: gives its effect to the kart that drives through it (if its reserve has room),
// with sound, mission signal and a pickup particle burst on the player's kart, then disappears.
// Source listing: recovery/aot_listings/Assembly-CSharp/BasePickup.txt
// RECUPERADO-AOT BasePickup::.ctor token 0x06000441 @0x00100088 (trivial constructor)
public abstract class BasePickup : MonoBehaviour
{
	private const int carLayerMask = 512;

	public GameObject pickupPUPEffectPrefab;

	private ParticleSystem[] particles; // ADAPTADO-U6: ParticleEmitter (legacy, eliminado en Unity 2018.3) -> ParticleSystem

	private bool isPaused;

	// RECUPERADO-AOT BasePickup::OnTriggerEnter token 0x06000442 @0x001000bc
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.DestroyObject -> Destroy.
	private void OnTriggerEnter(Collider other)
	{
		PowerupHolder component = other.gameObject.GetComponent<PowerupHolder>();
		SoundSequencer component2 = other.gameObject.GetComponent<SoundSequencer>();
		if (component2 != null)
		{
			component2.RequestPlay("powerupPickup");
		}
		if (RaceManager.IsPlayerCar(other.gameObject))
		{
			MissionManager component3 = other.gameObject.GetComponent<MissionManager>();
			if (component3 != null)
			{
				component3.Signal("Collected Powerup");
			}
			if (other.transform.Find("PUP Pickup Particles") == null)
			{
				Vector3 position = other.transform.forward * 3f + other.transform.position;
				GameObject gameObject = Object.Instantiate(pickupPUPEffectPrefab, position, Quaternion.identity) as GameObject;
				gameObject.transform.parent = other.transform;
				gameObject.name = "PUP Pickup Particles";
			}
		}
		if ((bool)component)
		{
			if (component.CanTakePowerup)
			{
				component.AddEffect(GetTriggeredEffect(other.gameObject));
			}
			Object.Destroy(base.gameObject);
		}
	}

	public abstract BaseEffect GetTriggeredEffect(GameObject obj);

	// RECUPERADO-AOT BasePickup::Start token 0x06000444 @0x00100438
	public void Start()
	{
		particles = GetComponentsInChildren<ParticleSystem>();
	}

	// RECUPERADO-AOT BasePickup::Update token 0x06000445 @0x00100488
	// Stops the box's particles while the race is paused. ADAPTADO-U6: ParticleEmitter.enabled -> emission.enabled.
	public void Update()
	{
		if (RaceManager.isPaused && !isPaused)
		{
			ParticleSystem[] array = particles;
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem.EmissionModule emission = array[i].emission;
				emission.enabled = false;
			}
			isPaused = true;
		}
		else if (!RaceManager.isPaused && isPaused)
		{
			ParticleSystem[] array2 = particles;
			for (int j = 0; j < array2.Length; j++)
			{
				ParticleSystem.EmissionModule emission2 = array2[j].emission;
				emission2.enabled = true;
			}
			isPaused = false;
		}
	}
}
