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
				RecoveryPending.Hit("StreamManager.Asset.get_isDone");
				return default(bool);
			}
		}

		public float progress
		{
			get
			{
				RecoveryPending.Hit("StreamManager.Asset.get_progress");
				return default(float);
			}
		}

		public bool isInUse
		{
			get
			{
				RecoveryPending.Hit("StreamManager.Asset.get_isInUse");
				return default(bool);
			}
		}

		public Object mainAsset
		{
			get
			{
				RecoveryPending.Hit("StreamManager.Asset.get_mainAsset");
				return default(Object);
			}
		}

		public void Unload()
		{
			RecoveryPending.Hit("StreamManager.Asset.Unload");
		}
	}

	public class AssetCluster
	{
		public List<Asset> assetList;

		public float progress
		{
			get
			{
				RecoveryPending.Hit("StreamManager.AssetCluster.get_progress");
				return default(float);
			}
		}

		public bool isDone
		{
			get
			{
				RecoveryPending.Hit("StreamManager.AssetCluster.get_isDone");
				return default(bool);
			}
		}

		public void AddAsset(string _name, string _path, StreamType type)
		{
			RecoveryPending.Hit("StreamManager.AssetCluster.AddAsset");
		}

		public Asset GetAsset(string _name)
		{
			RecoveryPending.Hit("StreamManager.AssetCluster.GetAsset");
			return default(Asset);
		}

		public Object GetMainObjectOfAsset(string _name)
		{
			RecoveryPending.Hit("StreamManager.AssetCluster.GetMainObjectOfAsset");
			return default(Object);
		}

		public void Preload()
		{
			RecoveryPending.Hit("StreamManager.AssetCluster.Preload");
		}

		public void Load()
		{
			RecoveryPending.Hit("StreamManager.AssetCluster.Load");
		}

		public void Release()
		{
			RecoveryPending.Hit("StreamManager.AssetCluster.Release");
		}
	}

	private Dictionary<string, Asset> assetDictionary;

	private static StreamManager s_Instance;

	public static StreamManager Instance
	{
		get
		{
			RecoveryPending.Hit("StreamManager.get_Instance");
			return default(StreamManager);
		}
	}

	public static bool isAvailable
	{
		get
		{
			RecoveryPending.Hit("StreamManager.get_isAvailable");
			return default(bool);
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("StreamManager.Awake");
	}

	private void Start()
	{
		RecoveryPending.Hit("StreamManager.Start");
	}

	[DebuggerHidden]
	private IEnumerator LoadAsset(Asset a)
	{
		RecoveryPending.Hit("StreamManager.LoadAsset");
		yield break;
	}

	public static Asset PreloadAsset(string name, string path, StreamType type)
	{
		RecoveryPending.Hit("StreamManager.PreloadAsset");
		return default(Asset);
	}

	public static Asset RequestAsset(string name, string path, StreamType type)
	{
		RecoveryPending.Hit("StreamManager.RequestAsset");
		return default(Asset);
	}

	public static void ReleaseAsset(string name)
	{
		RecoveryPending.Hit("StreamManager.ReleaseAsset");
	}

	public static void Cleanup()
	{
		RecoveryPending.Hit("StreamManager.Cleanup");
	}

	public static void FlushAll()
	{
		RecoveryPending.Hit("StreamManager.FlushAll");
	}

	public static string PrependRootFileLocation(string path)
	{
		RecoveryPending.Hit("StreamManager.PrependRootFileLocation");
		return default(string);
	}

	public static void DebugDump()
	{
		RecoveryPending.Hit("StreamManager.DebugDump");
	}
}
