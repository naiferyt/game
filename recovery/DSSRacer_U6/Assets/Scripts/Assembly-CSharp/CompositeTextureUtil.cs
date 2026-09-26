using System.Collections;
using System.Diagnostics;
using UnityEngine;

public static class CompositeTextureUtil
{
	public class AsyncTextureProcessor
	{
		public Texture2D newTexture;

		[DebuggerHidden]
		public IEnumerator GenerateCompositeTextureAsync(CompositeProfile profile)
		{
			RecoveryPending.Hit("CompositeTextureUtil.AsyncTextureProcessor.GenerateCompositeTextureAsync");
			yield break;
		}
	}

	public static Color32[] ColorMultiply(Texture2D source, Color32 color)
	{
		RecoveryPending.Hit("CompositeTextureUtil.ColorMultiply");
		return default(Color32[]);
	}

	public static Color32 AlphaBlendColor32(Color32 color1, Color32 color2)
	{
		RecoveryPending.Hit("CompositeTextureUtil.AlphaBlendColor32");
		return default(Color32);
	}

	public static Color32[] BlitPixels(Texture2D destination, Vector2 destinationPosition, Texture2D source, Rect sourceRect, bool alphaBlend)
	{
		RecoveryPending.Hit("CompositeTextureUtil.BlitPixels");
		return default(Color32[]);
	}

	public static Texture2D MergeLayers(Texture2D[] layers, Color32[] layerColorMultiply)
	{
		RecoveryPending.Hit("CompositeTextureUtil.MergeLayers");
		return default(Texture2D);
	}

	public static Texture2D BlitToCachedTexture(CompositeProfile profile, PaintJob paint)
	{
		RecoveryPending.Hit("CompositeTextureUtil.BlitToCachedTexture");
		return default(Texture2D);
	}

	public static Texture2D GenerateCompositeTexture(CompositeProfile profile)
	{
		RecoveryPending.Hit("CompositeTextureUtil.GenerateCompositeTexture");
		return default(Texture2D);
	}
}
