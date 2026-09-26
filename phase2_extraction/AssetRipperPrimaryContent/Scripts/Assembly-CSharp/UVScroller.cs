using System;
using UnityEngine;

public class UVScroller : MonoBehaviour
{
	[Serializable]
	public class UVScroll
	{
		public bool useRendererMaterial;

		public Material material;

		public string textureName;

		public Vector2 speed;
	}

	public UVScroll[] scrollers;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
