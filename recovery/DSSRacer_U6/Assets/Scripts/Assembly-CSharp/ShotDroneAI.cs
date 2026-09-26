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
		RecoveryPending.Hit("ShotDroneAI.Start");
	}

	public void SetParent(GameObject parent)
	{
		RecoveryPending.Hit("ShotDroneAI.SetParent");
	}

	private void Update()
	{
		RecoveryPending.Hit("ShotDroneAI.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("ShotDroneAI.FixedUpdate");
	}

	private void Shoot(GameObject target)
	{
		RecoveryPending.Hit("ShotDroneAI.Shoot");
	}
}
