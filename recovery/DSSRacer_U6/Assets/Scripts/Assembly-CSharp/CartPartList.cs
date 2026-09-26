using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Global catalog of kart parts and paint jobs (prefab in EnsureGlobals), indexed per slot; applies the part-cost archive.
// Source listing: recovery/aot_listings/Assembly-CSharp/CartPartList.txt
public class CartPartList : MonoBehaviour
{
	public CartPart[] cartParts;

	public PaintJob[] paintJobs;

	public CartPart[] defaultEquipment;

	private Dictionary<CartSlot.Slots, List<CartPart>> carSlotMap;

	private Dictionary<CartSlot.Slots, List<PaintJob>> paintJobMap;

	// RECUPERADO-AOT CartPartList::GetInstance token 0x06000220 @0x000e2184
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	private static CartPartList GetInstance()
	{
		CartPartList cartPartList = U4Compat.FindObjectOfType(typeof(CartPartList)) as CartPartList;
		if (cartPartList == null)
		{
			UnityEngine.Debug.LogError("Must have CartPartList in the scene!");
		}
		return cartPartList;
	}

	// RECUPERADO-AOT CartPartList::LoadPartCosts token 0x06000221 @0x000e222c
	// (predicates <LoadPartCosts>c__AnonStorey90::<>m__2 token 0x06000b32, <>m__3 token 0x06000b33)
	// Only the locally cached archive reaches this method: the PartCosts.epa download is ELIMINADO (see ExternalPersistentArchive).
	private void LoadPartCosts(string textData)
	{
		if (textData == null)
		{
			return;
		}
		Hashtable hashtable = (Hashtable)MiniJSON.jsonDecode(textData);
		if (hashtable == null)
		{
			UnityEngine.Debug.LogWarning("LoadPartCosts: hash table is null:\n" + textData);
		}
		else
		{
			if (!hashtable.ContainsKey("Part Costs"))
			{
				return;
			}
			ArrayList arrayList = hashtable["Part Costs"] as ArrayList;
			foreach (Hashtable item in arrayList)
			{
				if (!item.ContainsKey("Name") || !item.ContainsKey("Cost"))
				{
					UnityEngine.Debug.LogWarning("LoadPartCosts: incomplete part cost entry!");
					continue;
				}
				string partName = item["Name"] as string;
				int cost = int.Parse(item["Cost"] as string);
				CartPart cartPart = Array.Find(cartParts, (CartPart x) => x.UIName.baseText == partName);
				if (cartPart != null)
				{
					cartPart.cost = cost;
					continue;
				}
				PaintJob paintJob = Array.Find(paintJobs, (PaintJob x) => x.name == partName);
				if (paintJob != null)
				{
					paintJob.cost = cost;
				}
				else
				{
					UnityEngine.Debug.LogWarning("Could not find a part to modify with name " + partName);
				}
			}
		}
	}

	// RECUPERADO-AOT CartPartList::ModifyPartCostsCoroutine token 0x06000222 @0x000e2878
	// (iterator <ModifyPartCostsCoroutine>c__Iterator1F MoveNext token 0x0600088a @0x00145c30)
	[DebuggerHidden]
	private IEnumerator ModifyPartCostsCoroutine()
	{
		ExternalPersistentArchive archive = GetComponent<ExternalPersistentArchive>();
		if (archive == null)
		{
			UnityEngine.Debug.LogError("No ExternalPersistentArchive component!");
			yield break;
		}
		while (archive.TextData == null)
		{
			yield return null;
		}
		LoadPartCosts(archive.TextData);
	}

	// RECUPERADO-AOT CartPartList::OnExternalArchiveRead token 0x06000223 @0x000e28c0
	private void OnExternalArchiveRead(ExternalPersistentArchive archive)
	{
		LoadPartCosts(archive.TextData);
	}

	// RECUPERADO-AOT CartPartList::OnEnable token 0x06000224 @0x000e2900
	private void OnEnable()
	{
		ExternalPersistentArchive component = GetComponent<ExternalPersistentArchive>();
		if (component != null)
		{
			component.OnExternalAchiveRead = (Action<ExternalPersistentArchive>)Delegate.Combine(component.OnExternalAchiveRead, new Action<ExternalPersistentArchive>(OnExternalArchiveRead));
		}
	}

	// RECUPERADO-AOT CartPartList::OnDisable token 0x06000225 @0x000e2a14
	private void OnDisable()
	{
		ExternalPersistentArchive component = GetComponent<ExternalPersistentArchive>();
		if (component != null)
		{
			component.OnExternalAchiveRead = (Action<ExternalPersistentArchive>)Delegate.Remove(component.OnExternalAchiveRead, new Action<ExternalPersistentArchive>(OnExternalArchiveRead));
		}
	}

	// RECUPERADO-AOT CartPartList::Start token 0x06000226 @0x000e2b28
	private void Start()
	{
		Array values = Enum.GetValues(typeof(CartSlot.Slots));
		carSlotMap = new Dictionary<CartSlot.Slots, List<CartPart>>(values.Length);
		paintJobMap = new Dictionary<CartSlot.Slots, List<PaintJob>>(values.Length);
		foreach (CartSlot.Slots item in values)
		{
			carSlotMap[item] = new List<CartPart>();
			paintJobMap[item] = new List<PaintJob>();
		}
		CartPart[] array = cartParts;
		foreach (CartPart cartPart in array)
		{
			carSlotMap[cartPart.cartSlot].Add(cartPart);
		}
		PaintJob[] array2 = paintJobs;
		foreach (PaintJob paintJob in array2)
		{
			paintJobMap[paintJob.slot].Add(paintJob);
		}
		StartCoroutine(ModifyPartCostsCoroutine());
		if (!UnityEngine.Debug.isDebugBuild)
		{
			return;
		}
		for (int j = 0; j < cartParts.Length; j++)
		{
			CartPart cartPart2 = cartParts[j];
			for (int k = j + 1; k < cartParts.Length; k++)
			{
				if (cartPart2.UIName.baseText == cartParts[k].UIName.baseText)
				{
					UnityEngine.Debug.LogError("Duplicate part names found: " + cartPart2.UIName.baseText);
					UnityEngine.Debug.Break();
				}
			}
		}
		for (int l = 0; l < paintJobs.Length; l++)
		{
			PaintJob paintJob2 = paintJobs[l];
			for (int m = l + 1; m < paintJobs.Length; m++)
			{
				if (paintJob2.name == paintJobs[m].name)
				{
					UnityEngine.Debug.LogError("Duplicate paint job names found: " + paintJob2.name);
					UnityEngine.Debug.Break();
				}
			}
		}
	}

	// RECUPERADO-AOT CartPartList::CartPartListExists token 0x06000227 @0x000e31cc
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static bool CartPartListExists()
	{
		CartPartList cartPartList = U4Compat.FindObjectOfType(typeof(CartPartList)) as CartPartList;
		return cartPartList != null;
	}

	// RECUPERADO-AOT CartPartList::GetAllParts token 0x06000228 @0x000e3254
	public static CartPart[] GetAllParts()
	{
		return GetInstance().cartParts;
	}

	// RECUPERADO-AOT CartPartList::GetPart token 0x06000229 @0x000e3280
	// A part with alternate forms is matched only through its forms list (which includes itself).
	public static CartPart GetPart(string name)
	{
		CartPart[] array = GetInstance().cartParts;
		foreach (CartPart cartPart in array)
		{
			if (cartPart.alternateForms == null)
			{
				if (cartPart.UIName.baseText == name)
				{
					return cartPart;
				}
				continue;
			}
			AlternateForm.FormData[] forms = cartPart.alternateForms.forms;
			foreach (AlternateForm.FormData formData in forms)
			{
				if (formData.part.UIName.baseText == name)
				{
					return formData.part;
				}
			}
		}
		return null;
	}

	// RECUPERADO-AOT CartPartList::GetSlotPartList token 0x0600022a @0x000e33ac
	public static CartPart[] GetSlotPartList(CartSlot.Slots slot)
	{
		return GetInstance().carSlotMap[slot].ToArray();
	}

	// RECUPERADO-AOT CartPartList::GetDefaultParts token 0x0600022b @0x000e33fc
	public static CartPart[] GetDefaultParts()
	{
		return GetInstance().defaultEquipment;
	}

	// RECUPERADO-AOT CartPartList::GetAllPaintJobs token 0x0600022c @0x000e3428
	public static PaintJob[] GetAllPaintJobs()
	{
		return GetInstance().paintJobs;
	}

	// RECUPERADO-AOT CartPartList::GetPaintJob token 0x0600022d @0x000e3454
	public static PaintJob GetPaintJob(string name)
	{
		PaintJob[] array = GetInstance().paintJobs;
		foreach (PaintJob paintJob in array)
		{
			if (paintJob.name == name)
			{
				return paintJob;
			}
		}
		return null;
	}

	// RECUPERADO-AOT CartPartList::GetSlotPaintJobList token 0x0600022e @0x000e34f4
	public static PaintJob[] GetSlotPaintJobList(CartSlot.Slots slot)
	{
		return GetInstance().paintJobMap[slot].ToArray();
	}

	// RECUPERADO-AOT CartPartList::GetNextPurchasablePartForSlot token 0x0600022f @0x000e3544
	public static CartPart GetNextPurchasablePartForSlot(CartSlot.Slots slot)
	{
		CartPart[] array = GetInstance().cartParts;
		foreach (CartPart cartPart in array)
		{
			if (cartPart.cartSlot == slot && cartPart.IsLocked)
			{
				return cartPart;
			}
		}
		return null;
	}

	// RECUPERADO-AOT CartPartList::GetMostExpensiveAffordablePart token 0x06000230 @0x000e35e8
	public static CartPart GetMostExpensiveAffordablePart(int threshold)
	{
		CartPart cartPart = null;
		CartPart[] array = GetInstance().cartParts;
		foreach (CartPart cartPart2 in array)
		{
			if (cartPart2.IsLocked && cartPart2.cost <= threshold && (cartPart == null || cartPart2.cost > cartPart.cost))
			{
				cartPart = cartPart2;
			}
		}
		return cartPart;
	}

	// RECUPERADO-AOT CartPartList::GetMostExpensiveUnlockableAffordablePart token 0x06000231 @0x000e36bc
	public static CartPart GetMostExpensiveUnlockableAffordablePart(int threshold)
	{
		List<CartPart> list = new List<CartPart>();
		foreach (CartSlot.Slots value in Enum.GetValues(typeof(CartSlot.Slots)))
		{
			if (value != CartSlot.Slots.character)
			{
				CartPart nextPurchasablePartForSlot = GetNextPurchasablePartForSlot(value);
				if (nextPurchasablePartForSlot != null)
				{
					list.Add(nextPurchasablePartForSlot);
				}
			}
		}
		CartPart cartPart = null;
		foreach (CartPart item in list)
		{
			if (item.cost <= threshold && (cartPart == null || item.cost > cartPart.cost))
			{
				cartPart = item;
			}
		}
		return cartPart;
	}
}
