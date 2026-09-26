using System;
using UnityEngine;

public class CompositeProfile : MonoBehaviour
{
	[Serializable]
	public class CompositeSource
	{
		public Texture2D sourceTexture;

		public Rect sourceRect;
	}

	[Serializable]
	public class CompositeSlot
	{
		public string name;

		public Vector2 topLeftPoint;

		public CompositeSource sourceInSlot;
	}

	public Texture2D defaultTexture;

	public CompositeSlot[] compositeSlots;

	public CompositeSlot FindSlotByName(string slotName)
	{
		return default(CompositeSlot);
	}

	public void SetSlotSource(string slotName, Texture2D sourceTexture, Rect sourceRect)
	{
	}
}
