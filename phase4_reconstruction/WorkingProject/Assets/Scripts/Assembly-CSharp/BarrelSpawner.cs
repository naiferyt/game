using System.Collections;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
	private const int groundLayerMask = 256;

	public float spawnTime;

	public GameObject barrelPrefab;

	private GameObject barrel;

	private bool spawnCounting;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator SpawnCheck()
	{
		return default(IEnumerator);
	}

	private void SpawnBarrel()
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
