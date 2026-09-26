using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// The player's kart: one CartSlot per slot (part + paint), filled from the defaults and the save; builds the race kart.
// Source listing: recovery/aot_listings/Assembly-CSharp/PlayerInstance.txt
public class PlayerInstance : MonoBehaviour
{
	public CartSlot[] cartSlots;

	private Material multilayerMaterial;

	private bool hasBootstrapped;

	private static PlayerInstance s_Instance;

	private static GameObject constructedCart;

	// RECUPERADO-AOT PlayerInstance::get_Instance token 0x06000243 @0x000e4f50
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static PlayerInstance Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(PlayerInstance)) as PlayerInstance;
				if (s_Instance == null)
				{
					UnityEngine.Debug.LogError("Could not find PlayerInstance!");
					return null;
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT PlayerInstance::.ctor token 0x06000241 @0x000e4e20
	private PlayerInstance()
	{
		Array values = Enum.GetValues(typeof(CartSlot.Slots));
		cartSlots = new CartSlot[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			cartSlots[i] = new CartSlot((CartSlot.Slots)(int)values.GetValue(i));
		}
	}

	// RECUPERADO-AOT PlayerInstance::Awake token 0x06000244 @0x000e5050
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// RECUPERADO-AOT PlayerInstance::Start token 0x06000245 @0x000e5088
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	private void Start()
	{
		if (U4Compat.FindObjectsOfType(typeof(PlayerInstance)).Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT PlayerInstance::Bootstrap token 0x06000246 @0x000e50e0
	public static void Bootstrap()
	{
		PlayerInstance instance = Instance;
		if (instance.hasBootstrapped)
		{
			UnityEngine.Debug.Log("Skipping PlayerInstance.Bootstrap()");
			return;
		}
		instance.hasBootstrapped = true;
		if (CartPartList.CartPartListExists())
		{
			CartPart[] defaultParts = CartPartList.GetDefaultParts();
			for (int i = 0; i < defaultParts.Length; i++)
			{
				CartPart cartPart = defaultParts[i];
				instance.cartSlots[(int)cartPart.cartSlot].partInSlot = cartPart;
			}
		}
		DataUtility dataUtility = DataUtility.Instance;
		if (dataUtility.cloudData.playerCartParts == null)
		{
			dataUtility.cloudData.playerCartParts = new Dictionary<string, string>();
			CartPart[] defaultParts2 = CartPartList.GetDefaultParts();
			foreach (CartPart cartPart2 in defaultParts2)
			{
				dataUtility.SetCartPart(cartPart2.cartSlot, cartPart2.UIName.baseText);
			}
			dataUtility.Save();
		}
		else
		{
			foreach (KeyValuePair<string, string> playerCartPart in dataUtility.cloudData.playerCartParts)
			{
				CartSlot.Slots slots = (CartSlot.Slots)(int)Enum.Parse(typeof(CartSlot.Slots), playerCartPart.Key);
				instance.cartSlots[(int)slots].partInSlot = CartPartList.GetPart(playerCartPart.Value);
			}
		}
		if (dataUtility.cloudData.playerPaintJob == null)
		{
			dataUtility.cloudData.playerPaintJob = new Dictionary<string, string>();
			CartPart[] defaultParts3 = CartPartList.GetDefaultParts();
			foreach (CartPart cartPart3 in defaultParts3)
			{
				if (cartPart3.validPaintJobs.Length > 0)
				{
					dataUtility.SetCartPaint(cartPart3.cartSlot, cartPart3.validPaintJobs[0].name);
					instance.cartSlots[(int)cartPart3.cartSlot].slotPaint = CartPartList.GetPaintJob(cartPart3.validPaintJobs[0].name);
				}
			}
			dataUtility.Save();
			return;
		}
		foreach (KeyValuePair<string, string> item in dataUtility.cloudData.playerPaintJob)
		{
			CartSlot.Slots slots2 = (CartSlot.Slots)(int)Enum.Parse(typeof(CartSlot.Slots), item.Key);
			instance.cartSlots[(int)slots2].slotPaint = CartPartList.GetPaintJob(item.Value);
		}
	}

	// RECUPERADO-AOT PlayerInstance::GetCartSlot token 0x06000247 @0x000e57c4
	public static CartSlot GetCartSlot(CartSlot.Slots slot)
	{
		return Instance.cartSlots[(int)slot];
	}

	// RECUPERADO-AOT PlayerInstance::GetConstructedCart token 0x06000248 @0x000e5828
	public static GameObject GetConstructedCart()
	{
		if (constructedCart == null)
		{
			UnityEngine.Debug.LogError("No constructed cart available.  Call ConstructCart() first!");
		}
		return constructedCart;
	}

	[DebuggerHidden]
	public static IEnumerator ConstructCart()
	{
		RecoveryPending.Hit("PlayerInstance.ConstructCart");
		yield break;
	}

	// RECUPERADO-AOT PlayerInstance::MatchAlternateForms token 0x0600024a @0x000e58d0
	// Moves every slot to the body's form (kart / monster truck / bike), unlocking the matching variant of an owned part.
	public static void MatchAlternateForms()
	{
		CartSlot cartSlot = GetCartSlot(CartSlot.Slots.body);
		if (cartSlot == null || cartSlot.partInSlot == null)
		{
			return;
		}
		AlternateForm.BodyForm bodyForm = cartSlot.partInSlot.alternateForms.GetBodyForm(cartSlot.partInSlot);
		CartSlot[] array = Instance.cartSlots;
		foreach (CartSlot cartSlot2 in array)
		{
			if (cartSlot2.partInSlot == null || cartSlot2.partInSlot.alternateForms == null)
			{
				continue;
			}
			AlternateForm.FormData[] forms = cartSlot2.partInSlot.alternateForms.forms;
			foreach (AlternateForm.FormData formData in forms)
			{
				if (!formData.part.AreAllAlternateFormsLocked && formData.part.IsLocked && cartSlot2.slot != CartSlot.Slots.body)
				{
					DataUtility.Instance.Unlock(formData.part.UIName.baseText);
				}
			}
			CartPart cartPart = cartSlot2.partInSlot.alternateForms.FindFirstWithForm(bodyForm);
			if (cartPart != null)
			{
				cartSlot2.partInSlot = cartPart;
			}
		}
	}

	// RECUPERADO-AOT PlayerInstance::ReleaseCart token 0x0600024b @0x000e5ab4
	public static void ReleaseCart()
	{
		CartSlot[] array = Instance.cartSlots;
		foreach (CartSlot cartSlot in array)
		{
			// ADAPTADO-U6: the original released the part's streamed asset only when
			// `cartSlot.partInSlot.guiText != null && cartSlot.partInSlot.bundlePath.baseText.Length > 0`
			// (Component.guiText, removed in Unity 2019). Kart parts carry no GUIText, so that branch never ran:
			//     StreamManager.ReleaseAsset(cartSlot.partInSlot.UIName.baseText);
			if (cartSlot.slotPaint != null)
			{
				cartSlot.slotPaint.multilayerTexture.ReleaseAssets();
			}
		}
		if (constructedCart != null)
		{
			UnityEngine.Object.Destroy(constructedCart);
		}
		constructedCart = null;
	}
}
