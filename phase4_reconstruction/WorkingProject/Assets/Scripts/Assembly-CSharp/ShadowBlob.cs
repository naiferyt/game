using UnityEngine;

public class ShadowBlob : MonoBehaviour
{
	private const int groundLayerMask = 256;

	private const int collideLayerMask = 1024;

	public GameObject blobPrefab;

	private GameObject blobInstance;

	private TriFoot triFoot;

	public Vector3 ShadowPosition
	{
		get
		{
			return default(Vector3);
		}
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}
}
