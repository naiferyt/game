using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Localize : SingletonScript<Localize>
{
	public static Action OnLanguageLoaded;

	public TextAsset defaultLanguageFile;

	public string defaultLanguageURL;

	public LanguageAsset[] languageAssets;

	private static Hashtable strings;

	private static Hashtable dynamicKeys;

	private static bool simulateLongLanguage;

	private void Awake()
	{
		RecoveryPending.Hit("Localize.Awake");
	}

	[DebuggerHidden]
	private IEnumerator WebLoadingHelper()
	{
		RecoveryPending.Hit("Localize.WebLoadingHelper");
		yield break;
	}

	public void LoadDefaultLanguage()
	{
		RecoveryPending.Hit("Localize.LoadDefaultLanguage");
	}

	public void LoadLanguageAsset(LanguageAsset asset)
	{
		RecoveryPending.Hit("Localize.LoadLanguageAsset");
	}

	public void UseLocalizedLanguage(string url)
	{
		RecoveryPending.Hit("Localize.UseLocalizedLanguage");
	}

	[DebuggerHidden]
	public IEnumerator UseLocalizedLanguageHelper(string url)
	{
		RecoveryPending.Hit("Localize.UseLocalizedLanguageHelper");
		yield break;
	}

	public void LoadLanguage(string languageData)
	{
		RecoveryPending.Hit("Localize.LoadLanguage");
	}

	public void LoadKeys(string languageData)
	{
		RecoveryPending.Hit("Localize.LoadKeys");
	}

	public static string Get(string key)
	{
		RecoveryPending.Hit("Localize.Get");
		return default(string);
	}

	public static KeyCode[] GetDynamicKeys(string keyEvent)
	{
		RecoveryPending.Hit("Localize.GetDynamicKeys");
		return default(KeyCode[]);
	}

	public static string GetBaseURL()
	{
		RecoveryPending.Hit("Localize.GetBaseURL");
		return default(string);
	}

	public static string GetURL(string key)
	{
		RecoveryPending.Hit("Localize.GetURL");
		return default(string);
	}
}
