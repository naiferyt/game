using System;
using System.Collections;
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
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator WebLoadingHelper()
	{
		return default(IEnumerator);
	}

	public void LoadDefaultLanguage()
	{
	}

	public void LoadLanguageAsset(LanguageAsset asset)
	{
	}

	public void UseLocalizedLanguage(string url)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator UseLocalizedLanguageHelper(string url)
	{
		return default(IEnumerator);
	}

	public void LoadLanguage(string languageData)
	{
	}

	public void LoadKeys(string languageData)
	{
	}

	public static string Get(string key)
	{
		return default(string);
	}

	public static KeyCode[] GetDynamicKeys(string keyEvent)
	{
		return default(KeyCode[]);
	}

	public static string GetBaseURL()
	{
		return default(string);
	}

	public static string GetURL(string key)
	{
		return default(string);
	}
}
