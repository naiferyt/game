// Stage 1 recovery infrastructure (ADAPTADO-U6: compatibility layer, not game logic).
// Unity 4 APIs the original code called that Unity 6 deprecated or removed, re-expressed with the Unity 6 API
// while keeping the Unity 4 semantics (active objects only). The #else branch keeps the file compiling against
// the original Unity 4.3 UnityEngine.dll used by forensics/scripts/mcs_check.
using System;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_2023_1_OR_NEWER
using UnityEngine.SceneManagement;
#endif

// Stage 4 (ADAPTADO-U6): Unity 4's iPhoneGeneration values, kept as a local enum because UnityEngine.iOS only
// exists in the editor and in iOS players (Windows/Android builds failed with CS0234). Same integer values, so
// serialized fields keep their data.
public enum U4iPhoneGeneration
{
	Unknown = 0, iPhone = 1, iPhone3G = 2, iPhone3GS = 3, iPodTouch1Gen = 4, iPodTouch2Gen = 5, iPodTouch3Gen = 6,
	iPad1Gen = 7, iPhone4 = 8, iPodTouch4Gen = 9, iPad2Gen = 10, iPhone4S = 11, iPad3Gen = 12, iPhone5 = 13,
	iPodTouch5Gen = 14, iPadMini1Gen = 15, iPad4Gen = 16
}

public static class U4Compat
{
	// iPhone.generation: the device generation on iOS, Unknown elsewhere.
	public static U4iPhoneGeneration IPhoneGeneration
	{
		get
		{
#if UNITY_IOS
			return (U4iPhoneGeneration)(int)UnityEngine.iOS.Device.generation;
#else
			return U4iPhoneGeneration.Unknown;
#endif
		}
	}
	// Object.FindObjectsOfType(Type): all loaded, active objects of a type.
	public static Object[] FindObjectsOfType(Type type)
	{
#if UNITY_2023_1_OR_NEWER
		return Object.FindObjectsByType(type, FindObjectsSortMode.None);
#else
		return Object.FindObjectsOfType(type);
#endif
	}

	public static T[] FindObjectsOfType<T>() where T : Object
	{
#if UNITY_2023_1_OR_NEWER
		return Object.FindObjectsByType<T>(FindObjectsSortMode.None);
#else
		return Object.FindObjectsOfType<T>();
#endif
	}

	// Object.FindObjectOfType(Type): the first active object of a type (Unity 4 made no ordering promise).
	public static Object FindObjectOfType(Type type)
	{
#if UNITY_2023_1_OR_NEWER
		return Object.FindAnyObjectByType(type);
#else
		return Object.FindObjectOfType(type);
#endif
	}

	public static T FindObjectOfType<T>() where T : Object
	{
#if UNITY_2023_1_OR_NEWER
		return Object.FindAnyObjectByType<T>();
#else
		return Object.FindObjectOfType<T>();
#endif
	}

	// UnityEngine.WWW (removed): the few original download loops only need isDone / error / text.
	public sealed class WebRequest
	{
#if UNITY_2023_1_OR_NEWER
		readonly UnityEngine.Networking.UnityWebRequest m_Request;
		public WebRequest(string url)
		{
			m_Request = UnityEngine.Networking.UnityWebRequest.Get(url);
			m_Request.SendWebRequest();
		}
		public bool isDone { get { return m_Request.isDone; } }
		public string error { get { return m_Request.error; } }
		public string text { get { return m_Request.downloadHandler.text; } }
#else
		readonly WWW m_Request;
		public WebRequest(string url) { m_Request = new WWW(url); }
		public bool isDone { get { return m_Request.isDone; } }
		public string error { get { return m_Request.error; } }
		public string text { get { return m_Request.text; } }
#endif
	}

#if UNITY_2023_1_OR_NEWER
	// MonoBehaviour.OnLevelWasLoaded is no longer sent by Unity 6. The three original receivers (SingletonScript,
	// ScreenFader, UghCamera) were renamed OnLevelWasLoadedU6 so they are never invoked twice, and this bridge sends
	// that message to every active GameObject (DontDestroyOnLoad ones included) after each non-additive load:
	// the same point Unity 4 used (after Awake/OnEnable of the new scene, before its Start).
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void InstallLevelWasLoadedBridge()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private static bool s_FirstScene = true;

	private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		// Unity 4 did not send OnLevelWasLoaded for the first scene of the player, nor for additive loads.
		if (s_FirstScene) { s_FirstScene = false; return; }
		if (mode != LoadSceneMode.Single) return;
		foreach (GameObject go in Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
		{
			if (go != null) go.SendMessage("OnLevelWasLoadedU6", scene.buildIndex, SendMessageOptions.DontRequireReceiver);
		}
	}
#endif
}
