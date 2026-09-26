using System.Collections;
using System.Collections.Generic;
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
				return default(bool);
			}
		}

		public float progress
		{
			get
			{
				return default(float);
			}
		}

		public bool isInUse
		{
			get
			{
				return default(bool);
			}
		}

		public Object mainAsset
		{
			get
			{
				return default(Object);
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
				return default(float);
			}
		}

		public bool isDone
		{
			get
			{
				return default(bool);
			}
		}

		public void AddAsset(string _name, string _path, StreamType type)
		{
		}

		public Asset GetAsset(string _name)
		{
			return default(Asset);
		}

		public Object GetMainObjectOfAsset(string _name)
		{
			return default(Object);
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
			return default(StreamManager);
		}
	}

	public static bool isAvailable
	{
		get
		{
			return default(bool);
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadAsset(Asset a)
	{
		return default(IEnumerator);
	}

	public static Asset PreloadAsset(string name, string path, StreamType type)
	{
		return default(Asset);
	}

	public static Asset RequestAsset(string name, string path, StreamType type)
	{
		return default(Asset);
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
		return default(string);
	}

	public static void DebugDump()
	{
	}
}
