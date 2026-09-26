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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
