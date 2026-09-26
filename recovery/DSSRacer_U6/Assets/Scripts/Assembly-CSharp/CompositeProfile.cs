using System;
using UnityEngine;

// Layout of the kart's shared texture atlas: named slots, each filled with a rectangle of a source texture.
// Source listing: recovery/aot_listings/Assembly-CSharp/CompositeProfile.txt
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

	// RECUPERADO-AOT CompositeProfile::FindSlotByName token 0x060001f0 @0x000df3c8
	public CompositeSlot FindSlotByName(string slotName)
	{
		CompositeSlot[] array = compositeSlots;
		foreach (CompositeSlot compositeSlot in array)
		{
			if (compositeSlot.name == slotName)
			{
				return compositeSlot;
			}
		}
		Debug.LogWarning("Couldn't find the slot name in this composite profile");
		return null;
	}

	// RECUPERADO-AOT CompositeProfile::SetSlotSource token 0x060001f1 @0x000df474
	public void SetSlotSource(string slotName, Texture2D sourceTexture, Rect sourceRect)
	{
		CompositeSlot compositeSlot = FindSlotByName(slotName);
		if (compositeSlot != null)
		{
			compositeSlot.sourceInSlot = new CompositeSource();
			compositeSlot.sourceInSlot.sourceRect = sourceRect;
			compositeSlot.sourceInSlot.sourceTexture = sourceTexture;
		}
	}
}
