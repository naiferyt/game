using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
	private const int groundLayerMask = 256;

	public float pickupInterval;

	public bool toRoadSurface;

	public BasePickup[] pickupPrefabList;

	private GameObject pickup;

	private bool spawnCounting;

	[DebuggerHidden]
	private IEnumerator SpawnCheck()
	{
		RecoveryPending.Hit("PickupSpawner.SpawnCheck");
		yield break;
	}

	private void SpawnPickup()
	{
		RecoveryPending.Hit("PickupSpawner.SpawnPickup");
	}

	private void Start()
	{
		RecoveryPending.Hit("PickupSpawner.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("PickupSpawner.Update");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("PickupSpawner.OnDrawGizmos");
	}
}
