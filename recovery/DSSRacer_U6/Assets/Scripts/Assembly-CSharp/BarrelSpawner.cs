using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
	private const int groundLayerMask = 256;

	public float spawnTime;

	public GameObject barrelPrefab;

	private GameObject barrel;

	private bool spawnCounting;

	[DebuggerHidden]
	private IEnumerator SpawnCheck()
	{
		RecoveryPending.Hit("BarrelSpawner.SpawnCheck");
		yield break;
	}

	private void SpawnBarrel()
	{
		RecoveryPending.Hit("BarrelSpawner.SpawnBarrel");
	}

	private void Start()
	{
		RecoveryPending.Hit("BarrelSpawner.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("BarrelSpawner.Update");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("BarrelSpawner.OnDrawGizmos");
	}
}
