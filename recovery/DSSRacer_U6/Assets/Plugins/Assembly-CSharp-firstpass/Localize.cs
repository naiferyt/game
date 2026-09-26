using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

// String table: loads the JSON language file ("Translations" and "Keys") and answers Localize.Get(key).
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/Localize.txt
public class Localize : SingletonScript<Localize>
{
	public static Action OnLanguageLoaded;

	public TextAsset defaultLanguageFile;

	// RECUPERADO-AOT Localize..ctor token 0x06000227 @0x0002af08 (field initializer)
	public string defaultLanguageURL = "Languages/Localize-US.txt";

	public LanguageAsset[] languageAssets;

	private static Hashtable strings;

	private static Hashtable dynamicKeys;

	private static bool simulateLongLanguage;

	// RECUPERADO-AOT Localize.Awake token 0x06000229 @0x0002af74
	// RECUPERADO-AOT Localize.<Awake>m__4 token 0x06000235 @0x0002be84
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		LoadDefaultLanguage();
		// ADAPTADO-U6: the original started WebLoadingHelper() when running as OSXWebPlayer/WindowsWebPlayer
		// (platforms 5 and 3); the web player no longer exists, so only the device-language branch remains.
		LanguageAsset asset = Array.Find(languageAssets, x => x.language == Application.systemLanguage);
		if (asset != null)
		{
			LoadLanguageAsset(asset);
		}
	}

	// RECUPERADO-AOT Localize.WebLoadingHelper token 0x0600022a @0x0002b0b0
	// (body: <WebLoadingHelper>c__Iterator8.MoveNext token 0x06000546 @0x000524e4; web player only)
	private IEnumerator WebLoadingHelper()
	{
		if (defaultLanguageURL != null && defaultLanguageURL.Length > 0)
		{
			yield return StartCoroutine(UseLocalizedLanguageHelper(defaultLanguageURL));
		}
		// ELIMINADO (web player): Application.ExternalCall("QueryLocalizedLanguageURL") asked the hosting web page
		// for a language URL.
	}

	// RECUPERADO-AOT Localize.LoadDefaultLanguage token 0x0600022b @0x0002b0f8
	public void LoadDefaultLanguage()
	{
		if (!defaultLanguageFile)
		{
			Debug.LogError("No Default Language File Set.");
			return;
		}
		LoadLanguage(defaultLanguageFile.text);
		LoadKeys(defaultLanguageFile.text);
	}

	// RECUPERADO-AOT Localize.LoadLanguageAsset token 0x0600022c @0x0002b184
	public void LoadLanguageAsset(LanguageAsset asset)
	{
		if (asset.resourceName != null && asset.resourceName.Length > 0)
		{
			TextAsset text = Resources.Load(asset.resourceName, typeof(TextAsset)) as TextAsset;
			if (text != null)
			{
				LoadLanguage(text.text);
				LoadKeys(text.text);
			}
		}
		if (asset.webAssetURL != null && asset.webAssetURL.Length > 0)
		{
			StartCoroutine(UseLocalizedLanguageHelper(asset.webAssetURL));
		}
	}

	// RECUPERADO-AOT Localize.UseLocalizedLanguage token 0x0600022d @0x0002b2a4
	public void UseLocalizedLanguage(string url)
	{
		StartCoroutine("UseLocalizedLanguageHelper", url);
	}

	// RECUPERADO-AOT Localize.UseLocalizedLanguageHelper token 0x0600022e @0x0002b2f0
	// (body: <UseLocalizedLanguageHelper>c__Iterator9.MoveNext token 0x0600054c @0x000526fc)
	public IEnumerator UseLocalizedLanguageHelper(string url)
	{
		// ADAPTADO-U6: WWW -> U4Compat.WebRequest (UnityWebRequest)
		U4Compat.WebRequest www = new U4Compat.WebRequest(GetBaseURL() + url);
		float timeout = 60f;
		float timer = 0f;
		while (timer < timeout && !www.isDone && string.IsNullOrEmpty(www.error))
		{
			timer += Time.deltaTime;
			yield return 0;
		}
		if (!string.IsNullOrEmpty(www.error))
		{
			Debug.LogError(string.Format("There was the following error loading the localized language at url \"{0}\": {1}", url, www.error));
			yield break;
		}
		if (timer >= timeout)
		{
			Debug.LogError(string.Format("The loading of the localized language url \"{0}\" failed because it timed out at {1} seconds", url, timeout));
			yield break;
		}
		if (www.text.Length < 1)
		{
			Debug.LogError("Localized language at URL " + url + " is blank.  Check to make sure the text format is in UTF-8.");
		}
		LoadLanguage(www.text);
		LoadKeys(www.text);
	}

	// RECUPERADO-AOT Localize.LoadLanguage token 0x0600022f @0x0002b348
	public void LoadLanguage(string languageData)
	{
		Hashtable table = MiniJSON.jsonDecode(languageData) as Hashtable;
		if (table == null || table.Count < 1)
		{
			Debug.LogWarning("Does not appear to be a valid language JSON file.");
			return;
		}
		if (!table.ContainsKey("Translations"))
		{
			Debug.LogWarning("Language file does not contain any translations!");
			return;
		}
		strings = table["Translations"] as Hashtable;
		if (OnLanguageLoaded != null)
		{
			OnLanguageLoaded();
		}
		Debug.Log("language is loaded");
	}

	// RECUPERADO-AOT Localize.LoadKeys token 0x06000230 @0x0002b4fc
	public void LoadKeys(string languageData)
	{
		Hashtable table = MiniJSON.jsonDecode(languageData) as Hashtable;
		if (table == null || table.Count < 1)
		{
			Debug.LogWarning("Does not appear to be a valid language JSON file.");
			return;
		}
		if (!table.ContainsKey("Keys"))
		{
			Debug.LogWarning("Local keys file does not contain any keys!");
			return;
		}
		dynamicKeys = table["Keys"] as Hashtable;
		Debug.Log("local keys are loaded");
	}

	// RECUPERADO-AOT Localize.Get token 0x06000231 @0x0002b674
	public static string Get(string key)
	{
		if (strings == null && Application.isPlaying)
		{
			Debug.LogError("Trying to get a translation, but no language is loaded.");
			return "*MISSING_LANGUAGE*";
		}
		if (key == null)
		{
			return null;
		}
		if (key.Length < 1)
		{
			return string.Empty;
		}
		string result = key;
		if (strings != null && strings.ContainsKey(key))
		{
			result = strings[key] as string;
		}
		if (simulateLongLanguage)
		{
			int length = (int)((double)result.Length * 1.45f) + 1;
			while (result.Length < length)
			{
				result += "abcdefghijklmnopqrstuvwxyz"[UnityEngine.Random.Range(0, 25)];
			}
		}
		return result;
	}

	// RECUPERADO-AOT Localize.GetDynamicKeys token 0x06000232 @0x0002b8b8
	public static KeyCode[] GetDynamicKeys(string keyEvent)
	{
		if (dynamicKeys == null)
		{
			Debug.LogError("Dynamic keys are not loaded!");
			return null;
		}
		if (!dynamicKeys.ContainsKey(keyEvent))
		{
			Debug.LogWarning("Dynamic key not loaded for event: " + keyEvent);
			return null;
		}
		List<KeyCode> keys = new List<KeyCode>();
		ArrayList names = dynamicKeys[keyEvent] as ArrayList;
		foreach (string name in names)
		{
			keys.Add((KeyCode)Enum.Parse(typeof(KeyCode), name));
		}
		return keys.ToArray();
	}

	// RECUPERADO-AOT Localize.GetBaseURL token 0x06000233 @0x0002bcc4
	public static string GetBaseURL()
	{
		string dataPath = Application.dataPath;
		string scheme = Regex.IsMatch(dataPath, "^\\w*://") ? string.Empty : "file://";
		return scheme + dataPath + "/";
	}

	// RECUPERADO-AOT Localize.GetURL token 0x06000234 @0x0002bd50
	public static string GetURL(string key)
	{
		string value = Get(key);
		if (!strings.ContainsKey(key))
		{
			return null;
		}
		if (strings[key] as string == string.Empty)
		{
			return null;
		}
		if (value.StartsWith("http"))
		{
			return value;
		}
		return GetBaseURL() + value;
	}
}
