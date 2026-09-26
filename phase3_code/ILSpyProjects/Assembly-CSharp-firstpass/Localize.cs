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
	}

	[DebuggerHidden]
	private IEnumerator WebLoadingHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	public IEnumerator UseLocalizedLanguageHelper(string url)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void LoadLanguage(string languageData)
	{
	}

	public void LoadKeys(string languageData)
	{
	}

	public static string Get(string key)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static KeyCode[] GetDynamicKeys(string keyEvent)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static string GetBaseURL()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static string GetURL(string key)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
