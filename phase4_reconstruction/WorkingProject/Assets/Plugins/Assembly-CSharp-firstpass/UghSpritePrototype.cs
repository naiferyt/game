using System;
using UnityEngine;

public class UghSpritePrototype : ScriptableObject
{
	[Serializable]
	public enum InsetScaling
	{
		None = 0,
		XAxis = 1,
		YAxis = 2
	}

	public Vector3 nativePixelSize;

	public Rect nativeUVRect;

	public Material material;

	public Vector3 size;

	public Vector3 pixelSize;

	public int pixelWidth;

	public int pixelHeight;

	public Rect sourceUVRect;

	public EdgePixels edgePixelInsets;

	[HideInInspector]
	public EdgePixels edgeInsets;

	public EdgePixels edgePixelCrops;

	public InsetScaling insetScaling;

	private EdgePixels previousEdgePixelInsets;

	private EdgePixels previousEdgeInsets;

	private EdgePixels previousEdgePixelCrops;

	public GameObject CreateSprite(Type type)
	{
		return default(GameObject);
	}

	private void OnEnable()
	{
	}

	public void UpdatePrototype()
	{
	}
}
