using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
	private const int carLayerMask = 512;

	public GameObject pickupPUPEffectPrefab;

	private ParticleEmitter[] particles;

	private bool isPaused;

	private void OnTriggerEnter(Collider other)
	{
	}

	public abstract BaseEffect GetTriggeredEffect(GameObject obj);

	public void Start()
	{
	}

	public void Update()
	{
	}
}
