using UnityEngine;

public class TerrainEffectTrigger : MonoBehaviour
{
	public BaseEffect.EffectTypes effectType;

	public int power;

	public float time;

	public bool removeOnExit;

	public bool oilSlick;

	private BaseEffect spawnedEffect;

	private void Start()
	{
		RecoveryPending.Hit("TerrainEffectTrigger.Start");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("TerrainEffectTrigger.OnTriggerEnter");
	}

	private void OnTriggerExit(Collider other)
	{
		RecoveryPending.Hit("TerrainEffectTrigger.OnTriggerExit");
	}
}
