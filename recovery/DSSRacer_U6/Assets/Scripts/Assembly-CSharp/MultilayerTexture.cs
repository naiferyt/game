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
		RecoveryPending.Hit("MultilayerTexture.FindLayerByName");
		return default(Layer);
	}

	public Texture2D ComposeTexture()
	{
		RecoveryPending.Hit("MultilayerTexture.ComposeTexture");
		return default(Texture2D);
	}

	public void SetLayerTexture(string name, Texture2D texture)
	{
		RecoveryPending.Hit("MultilayerTexture.SetLayerTexture");
	}

	public void SetLayerColor(string name, Color32 color)
	{
		RecoveryPending.Hit("MultilayerTexture.SetLayerColor");
	}
}
