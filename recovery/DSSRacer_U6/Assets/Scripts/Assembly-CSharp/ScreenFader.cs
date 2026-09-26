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
			RecoveryPending.Hit("ScreenFader.get_Instance");
			return default(ScreenFader);
		}
	}

	public static void CreateScreenFader()
	{
		RecoveryPending.Hit("ScreenFader.CreateScreenFader");
	}

	private void Start()
	{
		RecoveryPending.Hit("ScreenFader.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("ScreenFader.Update");
	}

	public void LoadLevel(string levelName)
	{
		RecoveryPending.Hit("ScreenFader.LoadLevel");
	}

	public void LoadLevel(int levelIndex)
	{
		RecoveryPending.Hit("ScreenFader.LoadLevel");
	}

	[DebuggerHidden]
	private IEnumerator FadeInHelper()
	{
		RecoveryPending.Hit("ScreenFader.FadeInHelper");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator FadeOutHelper()
	{
		RecoveryPending.Hit("ScreenFader.FadeOutHelper");
		yield break;
	}

	public void FadeIn()
	{
		RecoveryPending.Hit("ScreenFader.FadeIn");
	}

	public void FadeOut()
	{
		RecoveryPending.Hit("ScreenFader.FadeOut");
	}

	private void OnLevelWasLoaded()
	{
		RecoveryPending.Hit("ScreenFader.OnLevelWasLoaded");
	}
}
