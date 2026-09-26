using System;
using UnityEngine;

// A stack of tinted texture layers merged into one texture (kart paint jobs).
// Source listing: recovery/aot_listings/Assembly-CSharp/MultilayerTexture.txt
[Serializable]
public class MultilayerTexture
{
	[Serializable]
	public class Layer
	{
		public string name;

		public Texture2D texture;

		// RECUPERADO-AOT MultilayerTexture/Layer::.ctor token 0x06000201 @0x000e0744 (field initializer)
		public Color32 colorMultiplier = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}

	public Layer[] layers;

	// RECUPERADO-AOT MultilayerTexture::FindLayerByName token 0x060001fd @0x000e04c0
	private Layer FindLayerByName(string name)
	{
		Layer[] array = layers;
		foreach (Layer layer in array)
		{
			if (layer.name == name)
			{
				return layer;
			}
		}
		return null;
	}

	// RECUPERADO-AOT MultilayerTexture::ComposeTexture token 0x060001fe @0x000e0558
	public Texture2D ComposeTexture()
	{
		if (layers == null || layers.Length == 0)
		{
			return null;
		}
		Texture2D[] array = new Texture2D[layers.Length];
		Color32[] array2 = new Color32[layers.Length];
		for (int i = 0; i < layers.Length; i++)
		{
			array[i] = layers[i].texture;
			array2[i] = layers[i].colorMultiplier;
		}
		return CompositeTextureUtil.MergeLayers(array, array2);
	}

	// RECUPERADO-AOT MultilayerTexture::SetLayerTexture token 0x060001ff @0x000e0698
	public void SetLayerTexture(string name, Texture2D texture)
	{
		Layer layer = FindLayerByName(name);
		if (layer != null)
		{
			layer.texture = texture;
		}
	}

	// RECUPERADO-AOT MultilayerTexture::SetLayerColor token 0x06000200 @0x000e06ec
	public void SetLayerColor(string name, Color32 color)
	{
		Layer layer = FindLayerByName(name);
		if (layer != null)
		{
			layer.colorMultiplier = color;
		}
	}
}
