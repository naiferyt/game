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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
