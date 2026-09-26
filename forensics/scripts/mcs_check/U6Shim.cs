// Compile-check only (never copied into the Unity project): declares the few Unity 6 APIs the recovered code
// uses that the original Unity 4.3 UnityEngine.dll lacks, so mcs can type-check the game scripts in the cloud.
// Real signatures: Unity 6000.6 scripting reference. Add members here only as the recovered code needs them.
namespace UnityEngine.iOS
{
	public enum DeviceGeneration { Unknown = 0, iPhone = 1, iPhone3G = 2, iPhone3GS = 3, iPodTouch1Gen = 4, iPodTouch2Gen = 5, iPodTouch3Gen = 6, iPad1Gen = 7, iPhone4 = 8, iPodTouch4Gen = 9, iPad2Gen = 10, iPhone4S = 11, iPad3Gen = 12, iPhone5 = 13, iPodTouch5Gen = 14, iPadMini1Gen = 15, iPad4Gen = 16, iPhone5C = 17, iPhone5S = 18, iPadAir1 = 19, iPadMini2Gen = 20, iPhoneUnknown = 10001, iPadUnknown = 10002, iPodTouchUnknown = 10003 }
}

namespace UnityEngine.SceneManagement
{
	public enum LoadSceneMode { Single = 0, Additive = 1 }

	public struct Scene
	{
		public string name { get { return null; } }
		public int buildIndex { get { return 0; } }
		public bool IsValid() { return false; }
	}

	public static class SceneManager
	{
		public static int sceneCount { get { return 0; } }
		public static event UnityEngine.Events.UnityAction<Scene, LoadSceneMode> sceneLoaded { add { } remove { } }
		public static Scene GetActiveScene() { return default(Scene); }
		public static void LoadScene(string sceneName) { }
		public static void LoadScene(int sceneBuildIndex) { }
		public static void LoadScene(string sceneName, LoadSceneMode mode) { }
		public static UnityEngine.AsyncOperation LoadSceneAsync(string sceneName) { return null; }
		public static UnityEngine.AsyncOperation LoadSceneAsync(int sceneBuildIndex) { return null; }
		public static UnityEngine.AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode mode) { return null; }
	}
}

namespace UnityEngine.Events
{
	public delegate void UnityAction<T0, T1>(T0 arg0, T1 arg1);
}
