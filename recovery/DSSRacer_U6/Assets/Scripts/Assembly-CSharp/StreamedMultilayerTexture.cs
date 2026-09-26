using System;
using UnityEngine;

[Serializable]
public class StreamedMultilayerTexture
{
	[Serializable]
	public class Layer
	{
		public string name;

		public string textureName;

		public Color32 color;
	}

	public string name;

	public string bundlePath;

	public string resourcePath;

	public Layer[] layers;

	private StreamManager.Asset asset;

	public MultilayerTexture PrepareMultilayerTexture()
	{
		RecoveryPending.Hit("StreamedMultilayerTexture.PrepareMultilayerTexture");
		return default(MultilayerTexture);
	}

	public void RequestAssets()
	{
		RecoveryPending.Hit("StreamedMultilayerTexture.RequestAssets");
	}

	public void ReleaseAssets()
	{
		RecoveryPending.Hit("StreamedMultilayerTexture.ReleaseAssets");
	}

	public bool IsLoaded()
	{
		RecoveryPending.Hit("StreamedMultilayerTexture.IsLoaded");
		return default(bool);
	}
}
