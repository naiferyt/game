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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
