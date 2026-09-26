using UnityEngine;

// Blob shadow under the kart: placed on the TriFoot ground point and aligned to its frame, or (before a
// TriFoot is found) on a raycast hit against Ground | Collide.
// Source listing: recovery/aot_listings/Assembly-CSharp/ShadowBlob.txt
public class ShadowBlob : MonoBehaviour
{
	private const int groundLayerMask = 256;

	private const int collideLayerMask = 1024;

	public GameObject blobPrefab;

	private GameObject blobInstance;

	private TriFoot triFoot;

	// RECUPERADO-AOT ShadowBlob::get_ShadowPosition token 0x0600047b @0x00103504
	public Vector3 ShadowPosition
	{
		get
		{
			if (blobInstance == null)
			{
				return Vector3.zero;
			}
			return blobInstance.transform.position;
		}
	}

	// RECUPERADO-AOT ShadowBlob::Start token 0x0600047c @0x001035b8
	private void Start()
	{
		blobInstance = Object.Instantiate(blobPrefab) as GameObject;
	}

	// RECUPERADO-AOT ShadowBlob::OnEnable token 0x0600047d @0x00103634
	private void OnEnable()
	{
		if ((bool)blobInstance)
		{
			blobInstance.SetActive(true);
		}
	}

	// RECUPERADO-AOT ShadowBlob::OnDisable token 0x0600047e @0x0010368c
	private void OnDisable()
	{
		if ((bool)blobInstance)
		{
			blobInstance.SetActive(false);
		}
	}

	// RECUPERADO-AOT ShadowBlob::Update token 0x0600047f @0x001036e4
	// ADAPTADO-U6: GameObject.renderer -> GetComponent<Renderer>().
	private void Update()
	{
		if (triFoot == null)
		{
			triFoot = GetComponent<TriFoot>();
			RaycastHit hitInfo;
			if (Physics.Raycast(base.transform.position + Vector3.up * 5f, Vector3.down, out hitInfo, float.PositiveInfinity, 1280))
			{
				blobInstance.GetComponent<Renderer>().enabled = true;
				blobInstance.transform.position = hitInfo.point + Vector3.up * 0.1f;
				blobInstance.transform.up = hitInfo.normal;
			}
			else
			{
				blobInstance.GetComponent<Renderer>().enabled = false;
			}
		}
		else
		{
			Vector3 position = base.transform.position;
			position = new Vector3(position.x, triFoot.groundPoint.y, position.z) + base.transform.up * 0.25f;
			blobInstance.GetComponent<Renderer>().enabled = true;
			blobInstance.transform.position = position;
			blobInstance.transform.rotation = Quaternion.LookRotation(triFoot.forward, triFoot.up);
		}
	}
}
