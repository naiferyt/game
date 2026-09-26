using System.Collections;
using UnityEngine;

public class LocalizedAssetSwapper : MonoBehaviour
{
	private Texture2D localizedTexture;

	public LocalizedString englishImagePath;

	public LocalizedString webEnglishImagePath;

	private bool web;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Start()
	{
		return default(IEnumerator);
	}
}
