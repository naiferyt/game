using UnityEngine;

public class Coin : MonoBehaviour
{
	public const int COIN_VALUE = 10;

	private AudioSource audioSource;

	public GameObject pickupCoinEffectPrefab;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider collider)
	{
	}
}
