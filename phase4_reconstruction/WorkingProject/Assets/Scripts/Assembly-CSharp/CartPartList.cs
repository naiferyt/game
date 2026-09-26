using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPartList : MonoBehaviour
{
	public CartPart[] cartParts;

	public PaintJob[] paintJobs;

	public CartPart[] defaultEquipment;

	private Dictionary<CartSlot.Slots, List<CartPart>> carSlotMap;

	private Dictionary<CartSlot.Slots, List<PaintJob>> paintJobMap;

	private static CartPartList GetInstance()
	{
		return default(CartPartList);
	}

	private void LoadPartCosts(string textData)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ModifyPartCostsCoroutine()
	{
		return default(IEnumerator);
	}

	private void OnExternalArchiveRead(ExternalPersistentArchive archive)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public static bool CartPartListExists()
	{
		return default(bool);
	}

	public static CartPart[] GetAllParts()
	{
		return default(CartPart[]);
	}

	public static CartPart GetPart(string name)
	{
		return default(CartPart);
	}

	public static CartPart[] GetSlotPartList(CartSlot.Slots slot)
	{
		return default(CartPart[]);
	}

	public static CartPart[] GetDefaultParts()
	{
		return default(CartPart[]);
	}

	public static PaintJob[] GetAllPaintJobs()
	{
		return default(PaintJob[]);
	}

	public static PaintJob GetPaintJob(string name)
	{
		return default(PaintJob);
	}

	public static PaintJob[] GetSlotPaintJobList(CartSlot.Slots slot)
	{
		return default(PaintJob[]);
	}

	public static CartPart GetNextPurchasablePartForSlot(CartSlot.Slots slot)
	{
		return default(CartPart);
	}

	public static CartPart GetMostExpensiveAffordablePart(int threshold)
	{
		return default(CartPart);
	}

	public static CartPart GetMostExpensiveUnlockableAffordablePart(int threshold)
	{
		return default(CartPart);
	}
}
