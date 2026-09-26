using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class LocalizedAssetSwapper : MonoBehaviour
{
	private Texture2D localizedTexture;

	public LocalizedString englishImagePath;

	public LocalizedString webEnglishImagePath;

	private bool web;

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("LocalizedAssetSwapper.Start");
		yield break;
	}
}
