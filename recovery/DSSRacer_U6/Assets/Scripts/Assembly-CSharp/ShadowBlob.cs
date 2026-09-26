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
			RecoveryPending.Hit("ShadowBlob.get_ShadowPosition");
			return default(Vector3);
		}
	}

	private void Start()
	{
		RecoveryPending.Hit("ShadowBlob.Start");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("ShadowBlob.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("ShadowBlob.OnDisable");
	}

	private void Update()
	{
		RecoveryPending.Hit("ShadowBlob.Update");
	}
}
