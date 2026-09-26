using System.Collections;
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
			return default(ScreenFader);
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

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator FadeInHelper()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator FadeOutHelper()
	{
		return default(IEnumerator);
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
