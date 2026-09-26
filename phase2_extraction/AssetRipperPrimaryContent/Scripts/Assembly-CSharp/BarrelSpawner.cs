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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
