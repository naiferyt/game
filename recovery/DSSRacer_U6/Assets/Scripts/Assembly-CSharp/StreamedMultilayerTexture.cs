using System;
using System.Collections.Generic;
using UnityEngine;

// Paint-job description whose layer textures are streamed in (Resources on iOS/PC; a bundle in the web build).
// Source listing: recovery/aot_listings/Assembly-CSharp/StreamedMultilayerTexture.txt
// ADAPTADO-U6: Application.isWebPlayer (always false now) is dropped from every test below; the web route still
// runs when DataUtility.forceWebPlayer is set, as in the original.
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

	// RECUPERADO-AOT StreamedMultilayerTexture::PrepareMultilayerTexture token 0x06000203 @0x000e07d8
	// ADAPTADO-U6: AssetBundle.LoadAll -> LoadAllAssets.
	public MultilayerTexture PrepareMultilayerTexture()
	{
		MultilayerTexture multilayerTexture = new MultilayerTexture();
		if (DataUtility.Instance.forceWebPlayer)
		{
			List<MultilayerTexture.Layer> list = new List<MultilayerTexture.Layer>(layers.Length);
			if (asset == null || asset.bundle == null)
			{
				Debug.LogWarning("Asset bundle appears to be null!");
				return null;
			}
			UnityEngine.Object[] array = asset.bundle.LoadAllAssets();
			Layer[] array2 = layers;
			foreach (Layer layer in array2)
			{
				UnityEngine.Object[] array3 = array;
				foreach (UnityEngine.Object @object in array3)
				{
					if (@object.name == layer.textureName)
					{
						MultilayerTexture.Layer layer2 = new MultilayerTexture.Layer();
						layer2.name = layer.name;
						layer2.texture = (Texture2D)@object;
						layer2.colorMultiplier = layer.color;
						list.Add(layer2);
						break;
					}
				}
			}
			multilayerTexture.layers = list.ToArray();
		}
		else
		{
			List<MultilayerTexture.Layer> list2 = new List<MultilayerTexture.Layer>(layers.Length);
			Layer[] array4 = layers;
			foreach (Layer layer3 in array4)
			{
				asset = StreamManager.RequestAsset(layer3.textureName, resourcePath + layer3.textureName, StreamManager.StreamType.RESOURCE);
				if (!asset.isDone)
				{
					Debug.LogError("Requested resource doesn't appear to be loaded.");
				}
				MultilayerTexture.Layer layer4 = new MultilayerTexture.Layer();
				layer4.name = layer3.name;
				layer4.texture = (Texture2D)asset.mainAsset;
				layer4.colorMultiplier = layer3.color;
				list2.Add(layer4);
			}
			multilayerTexture.layers = list2.ToArray();
		}
		return multilayerTexture;
	}

	// RECUPERADO-AOT StreamedMultilayerTexture::RequestAssets token 0x06000204 @0x000e0c64
	// (the Resources route requests each layer in PrepareMultilayerTexture instead)
	public void RequestAssets()
	{
		if (DataUtility.Instance.forceWebPlayer)
		{
			asset = StreamManager.RequestAsset(name, DataUtility.PrependBundlePath(bundlePath), StreamManager.StreamType.ASSET_BUNDLE);
		}
	}

	// RECUPERADO-AOT StreamedMultilayerTexture::ReleaseAssets token 0x06000205 @0x000e0cd0
	public void ReleaseAssets()
	{
		asset = null;
		if (DataUtility.Instance.forceWebPlayer)
		{
			StreamManager.ReleaseAsset(name);
			return;
		}
		Layer[] array = layers;
		foreach (Layer layer in array)
		{
			StreamManager.ReleaseAsset(layer.textureName);
		}
	}

	// RECUPERADO-AOT StreamedMultilayerTexture::IsLoaded token 0x06000206 @0x000e0d7c
	public bool IsLoaded()
	{
		if (asset == null)
		{
			return false;
		}
		return asset.isDone;
	}
}
