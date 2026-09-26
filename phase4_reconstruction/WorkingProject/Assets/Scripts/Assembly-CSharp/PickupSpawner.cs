using System.Collections;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
	private const int groundLayerMask = 256;

	public float pickupInterval;

	public bool toRoadSurface;

	public BasePickup[] pickupPrefabList;

	private GameObject pickup;

	private bool spawnCounting;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator SpawnCheck()
	{
		return default(IEnumerator);
	}

	private void SpawnPickup()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
