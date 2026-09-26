using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
	private bool loadingLevel;

	private bool fadeComplete;

	private string levelToLoad;

	private int levelIndexToLoad;

	private UghSprite spriteToUse;

	[HideInInspector]
	public bool debugStrap;

	private static ScreenFader s_Instance;

	public static ScreenFader Instance
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static void CreateScreenFader()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void LoadLevel(string levelName)
	{
	}

	public void LoadLevel(int levelIndex)
	{
	}

	[DebuggerHidden]
	private IEnumerator FadeInHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator FadeOutHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void FadeIn()
	{
	}

	public void FadeOut()
	{
	}

	private void OnLevelWasLoaded()
	{
	}
}
