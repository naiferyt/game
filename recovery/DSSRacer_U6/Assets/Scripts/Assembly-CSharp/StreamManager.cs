using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

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

		public bool isDone
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public float progress
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool isInUse
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Object mainAsset
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public void Unload()
		{
		}
	}

	public class AssetCluster
	{
		public List<Asset> assetList;

		public float progress
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool isDone
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public void AddAsset(string _name, string _path, StreamType type)
		{
		}

		public Asset GetAsset(string _name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Object GetMainObjectOfAsset(string _name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Preload()
		{
		}

		public void Load()
		{
		}

		public void Release()
		{
		}
	}

	private Dictionary<string, Asset> assetDictionary;

	private static StreamManager s_Instance;

	public static StreamManager Instance
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool isAvailable
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[DebuggerHidden]
	private IEnumerator LoadAsset(Asset a)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static Asset PreloadAsset(string name, string path, StreamType type)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static Asset RequestAsset(string name, string path, StreamType type)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void ReleaseAsset(string name)
	{
	}

	public static void Cleanup()
	{
	}

	public static void FlushAll()
	{
	}

	public static string PrependRootFileLocation(string path)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void DebugDump()
	{
	}
}
