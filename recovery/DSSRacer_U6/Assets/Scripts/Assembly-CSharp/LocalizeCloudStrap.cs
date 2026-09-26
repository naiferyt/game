using UnityEngine;

// Swaps the boot-screen logo texture for the one matching the system language.
// Source listing: recovery/aot_listings/Assembly-CSharp/LocalizeCloudStrap.txt
public class LocalizeCloudStrap : MonoBehaviour
{
	public LanguageAsset[] languageImages;

	// RECUPERADO-AOT LocalizeCloudStrap.Awake token 0x060006a3 @0x0012e524
	private void Awake()
	{
		foreach (LanguageAsset asset in languageImages)
		{
			if (asset.language != Application.systemLanguage)
			{
				continue;
			}
			Texture2D texture = Resources.Load(asset.resourceName, typeof(Texture2D)) as Texture2D;
			Renderer r = gameObject.GetComponent<Renderer>();
			if (r != null && texture != null)
			{
				r.material.mainTexture = texture;
			}
			UghSprite sprite = GetComponent<UghSprite>();
			if (sprite)
			{
				sprite.UpdateMesh();
			}
			break;
		}
	}

	// RECUPERADO-AOT LocalizeCloudStrap.Start token 0x060006a4 @0x0012e6b8 (empty in the original)
	private void Start()
	{
	}

	// RECUPERADO-AOT LocalizeCloudStrap.Update token 0x060006a5 @0x0012e6e4 (empty in the original)
	private void Update()
	{
	}
}
