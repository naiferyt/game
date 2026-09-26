using System.Collections;
using UnityEngine;

public static class CompositeTextureUtil
{
	public class AsyncTextureProcessor
	{
		public Texture2D newTexture;

		[System.Diagnostics.DebuggerHidden]
		public IEnumerator GenerateCompositeTextureAsync(CompositeProfile profile)
		{
			return default(IEnumerator);
		}
	}

	public static Color32[] ColorMultiply(Texture2D source, Color32 color)
	{
		return default(Color32[]);
	}

	public static Color32 AlphaBlendColor32(Color32 color1, Color32 color2)
	{
		return default(Color32);
	}

	public static Color32[] BlitPixels(Texture2D destination, Vector2 destinationPosition, Texture2D source, Rect sourceRect, bool alphaBlend)
	{
		return default(Color32[]);
	}

	public static Texture2D MergeLayers(Texture2D[] layers, Color32[] layerColorMultiply)
	{
		return default(Texture2D);
	}

	public static Texture2D BlitToCachedTexture(CompositeProfile profile, PaintJob paint)
	{
		return default(Texture2D);
	}

	public static Texture2D GenerateCompositeTexture(CompositeProfile profile)
	{
		return default(Texture2D);
	}
}
