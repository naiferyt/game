using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
	private const int carLayerMask = 512;

	public GameObject pickupPUPEffectPrefab;

	private ParticleSystem[] particles; // ADAPTADO-U6: ParticleEmitter (legacy, eliminado en Unity 2018.3) -> ParticleSystem

	private bool isPaused;

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("BasePickup.OnTriggerEnter");
	}

	public abstract BaseEffect GetTriggeredEffect(GameObject obj);

	public void Start()
	{
		RecoveryPending.Hit("BasePickup.Start");
	}

	public void Update()
	{
		RecoveryPending.Hit("BasePickup.Update");
	}
}
