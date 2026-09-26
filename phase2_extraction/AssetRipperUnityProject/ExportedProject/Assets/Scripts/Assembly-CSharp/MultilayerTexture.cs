using System;
using UnityEngine;

[Serializable]
public class MultilayerTexture
{
	[Serializable]
	public class Layer
	{
		public string name;

		public Texture2D texture;

		public Color32 colorMultiplier;
	}

	public Layer[] layers;

	private Layer FindLayerByName(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Texture2D ComposeTexture()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void SetLayerTexture(string name, Texture2D texture)
	{
	}

	public void SetLayerColor(string name, Color32 color)
	{
	}
}
