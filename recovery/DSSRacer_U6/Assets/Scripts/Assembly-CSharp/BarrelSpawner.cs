using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Drops a barrel on the ground below the spawner and drops a new one spawnTime seconds after the last is gone.
// Source listing: recovery/aot_listings/Assembly-CSharp/BarrelSpawner.txt
public class BarrelSpawner : MonoBehaviour
{
	private const int groundLayerMask = 256;

	// RECUPERADO-AOT BarrelSpawner::.ctor token 0x060004b6 @0x00106fb0 (field initializer)
	public float spawnTime = 5f;

	public GameObject barrelPrefab;

	private GameObject barrel;

	private bool spawnCounting;

	// RECUPERADO-AOT BarrelSpawner::SpawnCheck token 0x060004b7 @0x00106ffc
	// RECUPERADO-AOT BarrelSpawner/<SpawnCheck>c__Iterator34::MoveNext token 0x0600090c @0x0014c758
	[DebuggerHidden]
	private IEnumerator SpawnCheck()
	{
		yield return new WaitForSeconds(spawnTime);
		while (RaceManager.isPaused)
		{
			yield return 0;
		}
		if (barrel == null)
		{
			SpawnBarrel();
		}
		spawnCounting = false;
	}

	// RECUPERADO-AOT BarrelSpawner::SpawnBarrel token 0x060004b8 @0x00107044
	private void SpawnBarrel()
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(base.transform.position, Vector3.down, out hitInfo, float.PositiveInfinity, 256))
		{
			Vector3 point = hitInfo.point;
			GameObject gameObject = Object.Instantiate(barrelPrefab, point, barrelPrefab.transform.rotation) as GameObject;
			if (gameObject != null)
			{
				barrel = gameObject;
				float y = gameObject.GetComponent<Collider>().bounds.extents.y;
				barrel.transform.position = point + Vector3.up * y;
			}
		}
		else
		{
			UnityEngine.Debug.LogError("Could not drop barrel because there is no ground beneath '" + base.gameObject.name + "'");
		}
	}

	// RECUPERADO-AOT BarrelSpawner::Start token 0x060004b9 @0x00107340
	private void Start()
	{
		if (barrelPrefab == null)
		{
			UnityEngine.Debug.LogWarning("We have no barrel to spawn in this spawner!!");
		}
		SpawnBarrel();
	}

	// RECUPERADO-AOT BarrelSpawner::Update token 0x060004ba @0x001073a0
	private void Update()
	{
		if (!RaceManager.isPaused && barrel == null && !spawnCounting)
		{
			StartCoroutine(SpawnCheck());
			spawnCounting = true;
		}
	}

	// RECUPERADO-AOT BarrelSpawner::OnDrawGizmos token 0x060004bb @0x00107424
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, new Vector3(1f, 1f, 1f));
	}
}
