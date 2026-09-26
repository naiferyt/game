using UnityEngine;

public class ShotDroneAI : MonoBehaviour
{
	private const int carLayerMask = 512;

	private const float BATTERY_SHOT_DELAY = 1f;

	private const float shotAccuracy = 0.35f;

	private float timer;

	public float shotRange;

	public GameObject projectilePrefab;

	private GameObject parentObject;

	private void Start()
	{
	}

	public void SetParent(GameObject parent)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Shoot(GameObject target)
	{
	}
}
