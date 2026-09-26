using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

// Reference-counted loader for kart/character assets. iOS used the RESOURCE route (Resources/cart assets);
// the ASSET_BUNDLE route (WWW download of a bundle) is kept but nothing in the shipped data requests it.
// Source listing: recovery/aot_listings/Assembly-CSharp/StreamManager.txt
public class StreamManager : MonoBehaviour
{
	public enum StreamType
	{
		UNKNOWN = 0,
		ASSET_BUNDLE = 1,
		RESOURCE = 2
	}

	public class Asset
	{
		public string name;

		public string path;

		public WWW payload;

		public AssetBundle bundle;

		public Object resource;

		public int instanceCount;

		public int size;

		public StreamType streamType;

		// RECUPERADO-AOT StreamManager/Asset::get_isDone token 0x060004a1 @0x001060ec
		public bool isDone
		{
			get
			{
				if (streamType == StreamType.ASSET_BUNDLE)
				{
					return bundle != null;
				}
				if (streamType == StreamType.RESOURCE)
				{
					return resource != null;
				}
				return false;
			}
		}

		// RECUPERADO-AOT StreamManager/Asset::get_progress token 0x060004a2 @0x00106154
		public float progress
		{
			get
			{
				float result = 0f;
				if (streamType == StreamType.ASSET_BUNDLE && payload != null)
				{
					result = payload.progress;
				}
				else if (streamType == StreamType.RESOURCE && resource != null)
				{
					result = 1f;
				}
				return result;
			}
		}

		// RECUPERADO-AOT StreamManager/Asset::get_isInUse token 0x060004a3 @0x0010621c
		public bool isInUse
		{
			get
			{
				return instanceCount > 0;
			}
		}

		// RECUPERADO-AOT StreamManager/Asset::get_mainAsset token 0x060004a4 @0x0010625c
		// ADAPTADO-U6: AssetBundle.mainAsset was removed in Unity 5; the first asset of the bundle stands in for it.
		public Object mainAsset
		{
			get
			{
				if (streamType == StreamType.ASSET_BUNDLE)
				{
					if (bundle == null)
					{
						return null;
					}
					Object[] array = bundle.LoadAllAssets();
					return (array.Length <= 0) ? null : array[0];
				}
				if (streamType == StreamType.RESOURCE)
				{
					return resource;
				}
				return null;
			}
		}

		// RECUPERADO-AOT StreamManager/Asset::Unload token 0x060004a5 @0x001062dc
		public void Unload()
		{
			if (streamType == StreamType.ASSET_BUNDLE)
			{
				bundle.Unload(true);
				return;
			}
			if (streamType == StreamType.RESOURCE)
			{
				System.Type type = resource.GetType();
				if (type == typeof(GameObject) || type == typeof(MonoBehaviour) || type == typeof(AssetBundle))
				{
					Resources.UnloadUnusedAssets();
				}
				else
				{
					Resources.UnloadAsset(resource);
				}
				return;
			}
			UnityEngine.Debug.LogError("StreamManager trying to unload an asset with an unknown streamType!");
		}
	}

	public class AssetCluster
	{
		// RECUPERADO-AOT StreamManager/AssetCluster::.ctor token 0x060004a6 @0x001063b4 (field initializer)
		public List<Asset> assetList = new List<Asset>();

		// RECUPERADO-AOT StreamManager/AssetCluster::get_progress token 0x060004a7 @0x00106418
		public float progress
		{
			get
			{
				float num = 0f;
				foreach (Asset asset in assetList)
				{
					num += asset.progress;
				}
				return num / (float)assetList.Count;
			}
		}

		// RECUPERADO-AOT StreamManager/AssetCluster::get_isDone token 0x060004a8 @0x001065d4
		public bool isDone
		{
			get
			{
				foreach (Asset asset in assetList)
				{
					if (!asset.isDone)
					{
						return false;
					}
				}
				return true;
			}
		}

		// RECUPERADO-AOT StreamManager/AssetCluster::AddAsset token 0x060004a9 @0x00106738
		public void AddAsset(string _name, string _path, StreamType type)
		{
			Asset asset = new Asset();
			asset.name = _name;
			asset.path = _path;
			asset.streamType = type;
			assetList.Add(asset);
		}

		// RECUPERADO-AOT StreamManager/AssetCluster::GetAsset token 0x060004aa @0x001067b4
		public Asset GetAsset(string _name)
		{
			foreach (Asset asset in assetList)
			{
				if (asset.name == _name)
				{
					return asset;
				}
			}
			return null;
		}

		// RECUPERADO-AOT StreamManager/AssetCluster::GetMainObjectOfAsset token 0x060004ab @0x00106918
		public Object GetMainObjectOfAsset(string _name)
		{
			Asset asset = GetAsset(_name);
			if (asset == null)
			{
				return null;
			}
			if (asset.streamType == StreamType.ASSET_BUNDLE)
			{
				return asset.mainAsset;
			}
			if (asset.streamType == StreamType.RESOURCE)
			{
				return asset.resource;
			}
			return null;
		}

		// RECUPERADO-AOT StreamManager/AssetCluster::Preload token 0x060004ac @0x0010699c
		// Shares assets already known to the manager; starts loading the others without taking a reference.
		public void Preload()
		{
			StreamManager instance = Instance;
			for (int i = 0; i < assetList.Count; i++)
			{
				Asset asset = assetList[i];
				if (instance.assetDictionary.ContainsKey(asset.name))
				{
					assetList[i] = instance.assetDictionary[asset.name];
					continue;
				}
				instance.assetDictionary.Add(asset.name, asset);
				instance.StartCoroutine(instance.LoadAsset(asset));
			}
		}

		// RECUPERADO-AOT StreamManager/AssetCluster::Load token 0x060004ad @0x00106a98
		// Like Preload, but takes one reference on every asset of the cluster.
		public void Load()
		{
			StreamManager instance = Instance;
			for (int i = 0; i < assetList.Count; i++)
			{
				Asset asset = assetList[i];
				if (instance.assetDictionary.ContainsKey(asset.name))
				{
					assetList[i] = instance.assetDictionary[asset.name];
					assetList[i].instanceCount++;
					continue;
				}
				instance.assetDictionary.Add(asset.name, asset);
				asset.instanceCount++;
				instance.StartCoroutine(instance.LoadAsset(asset));
			}
		}

		// RECUPERADO-AOT StreamManager/AssetCluster::Release token 0x060004ae @0x00106bc0
		public void Release()
		{
			foreach (Asset asset in assetList)
			{
				ReleaseAsset(asset.name);
			}
		}
	}

	// RECUPERADO-AOT StreamManager::.ctor token 0x06000492 @0x00104f4c (field initializer)
	private Dictionary<string, Asset> assetDictionary = new Dictionary<string, Asset>();

	private static StreamManager s_Instance;

	// RECUPERADO-AOT StreamManager::get_Instance token 0x06000494 @0x00104fc8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static StreamManager Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(StreamManager)) as StreamManager;
				if (s_Instance == null)
				{
					UnityEngine.Debug.LogError("Could not find StreamManager!");
					return null;
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT StreamManager::get_isAvailable token 0x06000495 @0x001050c8
	public static bool isAvailable
	{
		get
		{
			return s_Instance != null;
		}
	}

	// RECUPERADO-AOT StreamManager::Awake token 0x06000496 @0x00105108
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// RECUPERADO-AOT StreamManager::Start token 0x06000497 @0x00105140
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	private void Start()
	{
		if (U4Compat.FindObjectsOfType(typeof(StreamManager)).Length > 1)
		{
			Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT StreamManager::LoadAsset token 0x06000498 @0x00105198
	// (iterator <LoadAsset>c__Iterator32 MoveNext token 0x06000900 @0x0014c1b0)
	[DebuggerHidden]
	private IEnumerator LoadAsset(Asset a)
	{
		if (a.streamType == StreamType.ASSET_BUNDLE)
		{
			a.payload = new WWW(a.path);
			yield return a.payload;
			if (a.payload == null || a.payload.error != null)
			{
				UnityEngine.Debug.LogError("Could not stream in asset at path: " + a.path);
				if (a.payload != null)
				{
					UnityEngine.Debug.LogError(a.payload.error);
				}
			}
			else
			{
				a.bundle = a.payload.assetBundle;
				a.size = a.payload.bytesDownloaded;
				a.payload.Dispose();
				a.payload = null;
			}
		}
		else if (a.streamType == StreamType.RESOURCE)
		{
			a.resource = Resources.Load(a.path);
			if (a.resource == null)
			{
				UnityEngine.Debug.LogError("Could not load resource at path: " + a.path);
			}
		}
		else
		{
			UnityEngine.Debug.LogError("StreamManager trying to load an asset with an unknown streamType!");
		}
	}

	// RECUPERADO-AOT StreamManager::PreloadAsset token 0x06000499 @0x001051e8
	// Registers and starts loading an asset without taking a reference (instanceCount stays as it is).
	public static Asset PreloadAsset(string name, string path, StreamType type)
	{
		StreamManager instance = Instance;
		if (instance.assetDictionary.ContainsKey(name))
		{
			return instance.assetDictionary[name];
		}
		Asset asset = new Asset();
		asset.name = name;
		asset.path = path;
		asset.streamType = type;
		instance.assetDictionary[name] = asset;
		instance.StartCoroutine(instance.LoadAsset(asset));
		return asset;
	}

	// RECUPERADO-AOT StreamManager::RequestAsset token 0x0600049a @0x001052c0
	// Takes one reference. Callers that pass an empty path rely on the asset having been preloaded under that name.
	public static Asset RequestAsset(string name, string path, StreamType type)
	{
		if (name == null || name.Length == 0)
		{
			return null;
		}
		StreamManager instance = Instance;
		if (instance.assetDictionary.ContainsKey(name))
		{
			Asset asset = instance.assetDictionary[name];
			asset.instanceCount++;
			return asset;
		}
		Asset asset2 = new Asset();
		asset2.name = name;
		asset2.path = path;
		asset2.streamType = type;
		asset2.instanceCount++;
		instance.assetDictionary[name] = asset2;
		instance.StartCoroutine(instance.LoadAsset(asset2));
		return asset2;
	}

	// RECUPERADO-AOT StreamManager::ReleaseAsset token 0x0600049b @0x001053e0
	public static void ReleaseAsset(string name)
	{
		StreamManager instance = Instance;
		if (instance.assetDictionary.ContainsKey(name))
		{
			instance.assetDictionary[name].instanceCount--;
		}
		else
		{
			UnityEngine.Debug.LogWarning("Trying to release an asset that doesn't exist. ('" + name + "')");
		}
	}

	// RECUPERADO-AOT StreamManager::Cleanup token 0x0600049c @0x0010547c
	// Unloads and forgets every asset nobody holds a reference to.
	public static void Cleanup()
	{
		StreamManager instance = Instance;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Asset> item in instance.assetDictionary)
		{
			if (item.Value.instanceCount <= 0)
			{
				item.Value.Unload();
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			instance.assetDictionary.Remove(item2);
		}
	}

	// RECUPERADO-AOT StreamManager::FlushAll token 0x0600049d @0x00105788
	public static void FlushAll()
	{
		StreamManager instance = Instance;
		foreach (KeyValuePair<string, Asset> item in instance.assetDictionary)
		{
			item.Value.Unload();
		}
		instance.assetDictionary.Clear();
	}

	// RECUPERADO-AOT StreamManager::PrependRootFileLocation token 0x0600049e @0x00105924
	// ADAPTADO-U6: the Application.isWebPlayer branch (dataPath + "/") is gone with the web player.
	public static string PrependRootFileLocation(string path)
	{
		string text = "file://";
		text = ((Application.platform != RuntimePlatform.IPhonePlayer) ? (text + Application.dataPath) : (text + Application.dataPath + "/../"));
		return text + path;
	}

	// RECUPERADO-AOT StreamManager::DebugDump token 0x0600049f @0x001059e4
	// ADAPTADO-U6: WWW.size no longer exists; WWW.bytesDownloaded is the same byte count.
	public static void DebugDump()
	{
		StreamManager instance = Instance;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Stream Manager Debug Dump:");
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		foreach (KeyValuePair<string, Asset> item in instance.assetDictionary)
		{
			stringBuilder.Append("*  " + item.Key + " (" + item.Value.streamType.ToString() + ") : ");
			if (!item.Value.isDone && item.Value.payload != null)
			{
				num++;
				num2 += item.Value.payload.bytesDownloaded;
				stringBuilder.Append((float)item.Value.payload.bytesDownloaded / 1024f + " K (loading)");
			}
			else
			{
				num3++;
				num4 += item.Value.size;
				stringBuilder.Append((float)item.Value.size / 1024f + " K");
			}
			stringBuilder.AppendLine(",");
		}
		stringBuilder.AppendLine("********************");
		stringBuilder.AppendLine("  Loading Assets:");
		stringBuilder.AppendLine("    Count: " + num);
		stringBuilder.AppendLine("    Size: " + (float)num2 / 1024f + " K");
		stringBuilder.AppendLine(string.Empty);
		stringBuilder.AppendLine("  Loaded Assets:");
		stringBuilder.AppendLine("    Count: " + num3);
		stringBuilder.AppendLine("    Size: " + (float)num4 / 1024f + " K");
		UnityEngine.Debug.Log(stringBuilder.ToString());
	}
}
