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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void RequestAssets()
	{
	}

	public void ReleaseAssets()
	{
	}

	public bool IsLoaded()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
