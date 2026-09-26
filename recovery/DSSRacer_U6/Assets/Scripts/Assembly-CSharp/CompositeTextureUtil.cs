using System.Collections;
using System.Diagnostics;
using UnityEngine;

// CPU texture compositing for the kart: tinted layer merge (paint jobs) and slot blits into the shared atlas.
// Every texture read here has to be imported as readable, as in the original build.
// Source listing: recovery/aot_listings/Assembly-CSharp/CompositeTextureUtil.txt
public static class CompositeTextureUtil
{
	public class AsyncTextureProcessor
	{
		public Texture2D newTexture;

		// RECUPERADO-AOT CompositeTextureUtil/AsyncTextureProcessor::GenerateCompositeTextureAsync token 0x060001fb @0x000e043c
		// (iterator <GenerateCompositeTextureAsync>c__Iterator1E MoveNext token 0x06000884 @0x00145838)
		// Same result as GenerateCompositeTexture, spread over several frames.
		[DebuggerHidden]
		public IEnumerator GenerateCompositeTextureAsync(CompositeProfile profile)
		{
			newTexture = new Texture2D(profile.defaultTexture.width, profile.defaultTexture.height);
			if (profile.defaultTexture != null)
			{
				newTexture.SetPixels32(profile.defaultTexture.GetPixels32());
			}
			yield return null;
			CompositeProfile.CompositeSlot[] compositeSlots = profile.compositeSlots;
			foreach (CompositeProfile.CompositeSlot slot in compositeSlots)
			{
				if (slot.sourceInSlot == null || !(slot.sourceInSlot.sourceTexture != null))
				{
					continue;
				}
				Color32[] pixelBuffer = BlitPixels(newTexture, slot.topLeftPoint, slot.sourceInSlot.sourceTexture, slot.sourceInSlot.sourceRect, false);
				if (pixelBuffer == null)
				{
					UnityEngine.Debug.LogWarning("There was an issue with a composite blit with slot name " + slot.name);
					continue;
				}
				yield return null;
				newTexture.SetPixels32(pixelBuffer);
				yield return null;
			}
			newTexture.Apply();
		}
	}

	// RECUPERADO-AOT CompositeTextureUtil::ColorMultiply token 0x060001f4 @0x000df57c
	public static Color32[] ColorMultiply(Texture2D source, Color32 color)
	{
		Color32[] pixels = source.GetPixels32();
		for (int i = 0; i < pixels.Length; i++)
		{
			Color32 color2 = pixels[i];
			color2.r = (byte)Mathf.Clamp(color2.r * color.r / 255, 0, 255);
			color2.g = (byte)Mathf.Clamp(color2.g * color.g / 255, 0, 255);
			color2.b = (byte)Mathf.Clamp(color2.b * color.b / 255, 0, 255);
			color2.a = (byte)Mathf.Clamp(color2.a * color.a / 255, 0, 255);
			pixels[i] = color2;
		}
		return pixels;
	}

	// RECUPERADO-AOT CompositeTextureUtil::AlphaBlendColor32 token 0x060001f5 @0x000df6c4
	// color1 is drawn over color2 ("over" operator).
	public static Color32 AlphaBlendColor32(Color32 color1, Color32 color2)
	{
		Color32 result = color1;
		float num = (float)(int)color1.a / 255f;
		float num2 = 1f - num;
		float num3 = (float)(int)color2.a / 255f;
		result.r = (byte)(uint)((float)(int)color1.r * num + (float)(int)color2.r * num3 * num2);
		result.g = (byte)(uint)((float)(int)color1.g * num + (float)(int)color2.g * num3 * num2);
		result.b = (byte)(uint)((float)(int)color1.b * num + (float)(int)color2.b * num3 * num2);
		result.a = (byte)(uint)((num + num3 * num2) * 255f);
		return result;
	}

	// RECUPERADO-AOT CompositeTextureUtil::BlitPixels token 0x060001f6 @0x000df8e4
	// Copies sourceRect of source into destination at destinationPosition (top-left origin); returns the new pixel array.
	public static Color32[] BlitPixels(Texture2D destination, Vector2 destinationPosition, Texture2D source, Rect sourceRect, bool alphaBlend)
	{
		if (destination == null || source == null)
		{
			UnityEngine.Debug.LogError("Must specify a valid blit destination and source.");
			return null;
		}
		if ((float)destination.width - destinationPosition.x < sourceRect.width + sourceRect.x || !((float)destination.height - destinationPosition.y >= sourceRect.height + sourceRect.y))
		{
			UnityEngine.Debug.LogError("Trying to blit a source rect that exceeds destination texture size.");
			return null;
		}
		destinationPosition.y = (float)destination.height - destinationPosition.y - sourceRect.height;
		Color32[] pixels = destination.GetPixels32();
		Color32[] pixels2 = source.GetPixels32();
		Color32[] array = new Color32[pixels.Length];
		System.Array.Copy(pixels, array, pixels.Length);
		for (int i = 0; (float)i < sourceRect.width; i++)
		{
			for (int j = 0; (float)j < sourceRect.height; j++)
			{
				int num = i + (int)sourceRect.x + (j + (int)sourceRect.y) * source.width;
				int num2 = i + (int)destinationPosition.x + (j + (int)destinationPosition.y) * destination.width;
				if (!alphaBlend)
				{
					array[num2] = pixels2[num];
				}
				else
				{
					array[num2] = AlphaBlendColor32(pixels[num2], pixels2[num]);
				}
			}
		}
		return array;
	}

	// RECUPERADO-AOT CompositeTextureUtil::MergeLayers token 0x060001f7 @0x000dfd60
	// Layer 0 is the base; every following layer is tinted and drawn over the result.
	public static Texture2D MergeLayers(Texture2D[] layers, Color32[] layerColorMultiply)
	{
		Texture2D texture2D = new Texture2D(layers[0].width, layers[0].height);
		for (int i = 0; i < layers.Length; i++)
		{
			Color32[] array = ColorMultiply(layers[i], layerColorMultiply[i]);
			if (i == 0)
			{
				texture2D.SetPixels32(array);
				continue;
			}
			Color32[] pixels = texture2D.GetPixels32();
			for (int j = 0; j < pixels.Length; j++)
			{
				pixels[j] = AlphaBlendColor32(array[j], pixels[j]);
			}
			texture2D.SetPixels32(pixels);
		}
		texture2D.Apply();
		return texture2D;
	}

	// RECUPERADO-AOT CompositeTextureUtil::BlitToCachedTexture token 0x060001f8 @0x000dff78
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static Texture2D BlitToCachedTexture(CompositeProfile profile, PaintJob paint)
	{
		PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
		if (previewCart != null)
		{
			Texture2D cachedPaint = previewCart.CachedPaint;
			if (cachedPaint == null)
			{
				UnityEngine.Debug.LogWarning("CachedPaint came back null in Blit()");
				return null;
			}
			string text = CartSlot.SlotNames[(int)paint.slot];
			CompositeProfile.CompositeSlot compositeSlot = profile.FindSlotByName(text.ToLower());
			if (compositeSlot == null)
			{
				UnityEngine.Debug.LogWarning("Composite Slot came back null in Blit() - slotName: " + text);
				return null;
			}
			if (compositeSlot.sourceInSlot != null && compositeSlot.sourceInSlot.sourceTexture != null)
			{
				Color32[] array = BlitPixels(cachedPaint, compositeSlot.topLeftPoint, compositeSlot.sourceInSlot.sourceTexture, compositeSlot.sourceInSlot.sourceRect, false);
				if (array == null)
				{
					UnityEngine.Debug.LogWarning("There was an issue with a composite blit with slot name " + compositeSlot.name);
					return null;
				}
				cachedPaint.SetPixels32(array);
			}
			cachedPaint.Apply();
			return cachedPaint;
		}
		UnityEngine.Debug.LogWarning("Could not find previewCart object during BlitToCached()!");
		return null;
	}

	// RECUPERADO-AOT CompositeTextureUtil::GenerateCompositeTexture token 0x060001f9 @0x000e0208
	public static Texture2D GenerateCompositeTexture(CompositeProfile profile)
	{
		Texture2D texture2D = new Texture2D(profile.defaultTexture.width, profile.defaultTexture.height);
		if (profile.defaultTexture != null)
		{
			texture2D.SetPixels32(profile.defaultTexture.GetPixels32());
		}
		CompositeProfile.CompositeSlot[] compositeSlots = profile.compositeSlots;
		foreach (CompositeProfile.CompositeSlot compositeSlot in compositeSlots)
		{
			if (compositeSlot.sourceInSlot != null && compositeSlot.sourceInSlot.sourceTexture != null)
			{
				Color32[] array = BlitPixels(texture2D, compositeSlot.topLeftPoint, compositeSlot.sourceInSlot.sourceTexture, compositeSlot.sourceInSlot.sourceRect, false);
				if (array == null)
				{
					UnityEngine.Debug.LogWarning("There was an issue with a composite blit with slot name " + compositeSlot.name);
				}
				else
				{
					texture2D.SetPixels32(array);
				}
			}
		}
		texture2D.Apply();
		return texture2D;
	}
}
