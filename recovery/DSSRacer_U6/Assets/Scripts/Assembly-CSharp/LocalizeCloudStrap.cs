using UnityEngine;

public class LocalizeCloudStrap : MonoBehaviour
{
	public LanguageAsset[] languageImages;

	private void Awake()
	{
		RecoveryPending.Hit("LocalizeCloudStrap.Awake");
	}

	private void Start()
	{
		RecoveryPending.Hit("LocalizeCloudStrap.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("LocalizeCloudStrap.Update");
	}
}
