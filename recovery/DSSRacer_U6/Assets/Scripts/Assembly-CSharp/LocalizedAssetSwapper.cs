using System.Collections;
using UnityEngine;

// Replaces this renderer's texture with a localized image loaded from Resources.
// Source listing: recovery/aot_listings/Assembly-CSharp/LocalizedAssetSwapper.txt
public class LocalizedAssetSwapper : MonoBehaviour
{
	private Texture2D localizedTexture;

	public LocalizedString englishImagePath;

	public LocalizedString webEnglishImagePath;

	private bool web;

	// RECUPERADO-AOT LocalizedAssetSwapper.Start token 0x0600051b @0x0010de5c
	// (body: <Start>c__Iterator3F.MoveNext token 0x0600094e @0x0014e3a4)
	private IEnumerator Start()
	{
		// ADAPTADO-U6: web = Application.isWebPlayer || DataUtility.Instance.forceWebPlayer. The web player is gone and
		// forceWebPlayer is [NonSerialized] and never assigned, so web is always false; the WWW branch that downloaded
		// webEnglishImagePath (StreamManager.PrependRootFileLocation) is therefore omitted.
		if (DataUtility.Instance && DataUtility.Instance.forceWebPlayer)
		{
			web = true;
		}
		if (web)
		{
			Debug.LogError("This object does not have a web path for localized asset!!!!");
			yield break;
		}
		if (englishImagePath.Text == string.Empty)
		{
			Debug.LogError("This object does not have a Resource path for localized asset!!!!");
		}
		localizedTexture = Resources.Load(englishImagePath.Text, typeof(Texture2D)) as Texture2D;
		Renderer rend = gameObject.GetComponent<Renderer>();
		if (rend != null && localizedTexture != null)
		{
			rend.material.mainTexture = localizedTexture;
		}
	}
}
