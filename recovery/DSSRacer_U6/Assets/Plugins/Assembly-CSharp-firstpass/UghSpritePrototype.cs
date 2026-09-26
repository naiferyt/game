using System;
using UnityEngine;

// Sprite definition asset: material, source rectangle in the atlas, size and nine-slice insets/crops.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghSpritePrototype.txt
public class UghSpritePrototype : ScriptableObject
{
	[Serializable]
	public enum InsetScaling
	{
		None = 0,
		XAxis = 1,
		YAxis = 2
	}

	// RECUPERADO-AOT UghSpritePrototype..ctor token 0x0600046e @0x0004a4dc (field initializers)
	public Vector3 nativePixelSize = Vector3.zero;

	public Rect nativeUVRect = new Rect(0f, 0f, 0f, 0f);

	public Material material;

	public Vector3 size;

	public Vector3 pixelSize;

	public int pixelWidth;

	public int pixelHeight;

	public Rect sourceUVRect;

	public EdgePixels edgePixelInsets = new EdgePixels();

	[HideInInspector]
	public EdgePixels edgeInsets = new EdgePixels();

	public EdgePixels edgePixelCrops = new EdgePixels();

	public InsetScaling insetScaling;

	private EdgePixels previousEdgePixelInsets = new EdgePixels();

	private EdgePixels previousEdgeInsets = new EdgePixels();

	private EdgePixels previousEdgePixelCrops = new EdgePixels();

	// RECUPERADO-AOT UghSpritePrototype.CreateSprite token 0x0600046f @0x0004a618
	public GameObject CreateSprite(Type type)
	{
		GameObject go = new GameObject(name, type);
		UghSprite sprite = go.GetComponent<UghSprite>();
		sprite.Prototype = this;
		sprite.transform.position = UghCamera.Instance.ScreenSize * 0.5f;
		UghButton button = go.GetComponent<UghButton>();
		if ((bool)button)
		{
			button.AutoSizeCollider();
		}
		return go;
	}

	// RECUPERADO-AOT UghSpritePrototype.OnEnable token 0x06000470 @0x0004a794
	private void OnEnable()
	{
		UpdatePrototype();
	}

	// RECUPERADO-AOT UghSpritePrototype.UpdatePrototype token 0x06000471 @0x0004a7c8
	public void UpdatePrototype()
	{
		// (reference comparison, as compiled: after the first update the copies always differ, so it recomputes)
		if (previousEdgeInsets == edgeInsets && previousEdgePixelCrops == edgePixelCrops && previousEdgePixelInsets == edgePixelInsets)
		{
			return;
		}
		previousEdgePixelInsets = edgePixelInsets.DeepCopy();
		previousEdgeInsets = edgeInsets.DeepCopy();
		previousEdgePixelCrops = edgePixelCrops.DeepCopy();
		pixelSize = new Vector3(nativePixelSize.x - edgePixelCrops.xSum, nativePixelSize.y - edgePixelCrops.ySum, 0f);
		size = pixelSize / UghCamera.PixelsPerUnit;
		pixelWidth = (int)pixelSize.x;
		pixelHeight = (int)pixelSize.y;
		edgeInsets.top = edgePixelInsets.top / pixelSize.y;
		edgeInsets.bottom = edgePixelInsets.bottom / pixelSize.y;
		edgeInsets.right = edgePixelInsets.right / pixelSize.x;
		edgeInsets.left = edgePixelInsets.left / pixelSize.x;
		sourceUVRect.width = nativeUVRect.width * (pixelSize.x - edgePixelCrops.right - edgePixelCrops.left) / pixelSize.x;
		sourceUVRect.x = nativeUVRect.x + edgePixelCrops.left * (nativeUVRect.width / pixelSize.x);
		sourceUVRect.height = nativeUVRect.height * (pixelSize.y - edgePixelCrops.top - edgePixelCrops.bottom) / pixelSize.y;
		sourceUVRect.y = nativeUVRect.y + edgePixelCrops.bottom * (nativeUVRect.height / pixelSize.y);
	}
}
