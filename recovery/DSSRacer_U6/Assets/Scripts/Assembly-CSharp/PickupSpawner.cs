using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Spawns a random power-up box from its list (dropped 2 units above the road below it) and respawns it
// pickupInterval seconds after it has been taken.
// Source listing: recovery/aot_listings/Assembly-CSharp/PickupSpawner.txt
public class PickupSpawner : MonoBehaviour
{
	private const int groundLayerMask = 256;

	// RECUPERADO-AOT PickupSpawner::.ctor token 0x0600044a @0x00100740 (field initializers)
	public float pickupInterval = 30f;

	public bool toRoadSurface = true;

	public BasePickup[] pickupPrefabList;

	private GameObject pickup;

	private bool spawnCounting;

	// RECUPERADO-AOT PickupSpawner::SpawnCheck token 0x0600044b @0x00100794
	// RECUPERADO-AOT PickupSpawner/<SpawnCheck>c__Iterator30::MoveNext token 0x060008f4 @0x0014bb8c
	[DebuggerHidden]
	private IEnumerator SpawnCheck()
	{
		yield return new WaitForSeconds(pickupInterval);
		while (RaceManager.isPaused)
		{
			yield return 0;
		}
		if (pickup == null)
		{
			SpawnPickup();
		}
		spawnCounting = false;
	}

	// RECUPERADO-AOT PickupSpawner::SpawnPickup token 0x0600044c @0x001007dc
	private void SpawnPickup()
	{
		if (toRoadSurface)
		{
			RaycastHit hitInfo;
			if (Physics.Raycast(base.transform.position, Vector3.down, out hitInfo, float.PositiveInfinity, 256))
			{
				Vector3 position = hitInfo.point + Vector3.up * 2f;
				BasePickup original = pickupPrefabList[Random.Range(0, pickupPrefabList.Length)];
				BasePickup basePickup = (BasePickup)Object.Instantiate(original, position, base.transform.rotation);
				if (basePickup != null)
				{
					pickup = basePickup.gameObject;
				}
			}
			else
			{
				UnityEngine.Debug.LogError("Could not drop powerup because there is no ground beneath '" + base.gameObject.name + "'");
			}
		}
		else
		{
			BasePickup original2 = pickupPrefabList[Random.Range(0, pickupPrefabList.Length)];
			BasePickup basePickup2 = (BasePickup)Object.Instantiate(original2, base.transform.position, base.transform.rotation);
			if (basePickup2 != null)
			{
				pickup = basePickup2.gameObject;
			}
		}
	}

	// RECUPERADO-AOT PickupSpawner::Start token 0x0600044d @0x00100ba4
	private void Start()
	{
		SpawnPickup();
	}

	// RECUPERADO-AOT PickupSpawner::Update token 0x0600044e @0x00100bd8
	private void Update()
	{
		if (!RaceManager.isPaused && pickup == null && !spawnCounting)
		{
			spawnCounting = true;
			StartCoroutine(SpawnCheck());
		}
	}

	// RECUPERADO-AOT PickupSpawner::OnDrawGizmos token 0x0600044f @0x00100c5c
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(base.transform.position, new Vector3(1f, 1f, 1f));
	}
}
