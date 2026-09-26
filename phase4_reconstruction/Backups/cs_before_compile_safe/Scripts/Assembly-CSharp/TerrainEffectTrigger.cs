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
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
