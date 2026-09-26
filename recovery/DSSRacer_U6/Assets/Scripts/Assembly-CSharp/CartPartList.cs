using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
		RecoveryPending.Hit("CartPartList.GetInstance");
		return default(CartPartList);
	}

	private void LoadPartCosts(string textData)
	{
		RecoveryPending.Hit("CartPartList.LoadPartCosts");
	}

	[DebuggerHidden]
	private IEnumerator ModifyPartCostsCoroutine()
	{
		RecoveryPending.Hit("CartPartList.ModifyPartCostsCoroutine");
		yield break;
	}

	private void OnExternalArchiveRead(ExternalPersistentArchive archive)
	{
		RecoveryPending.Hit("CartPartList.OnExternalArchiveRead");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("CartPartList.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("CartPartList.OnDisable");
	}

	private void Start()
	{
		RecoveryPending.Hit("CartPartList.Start");
	}

	public static bool CartPartListExists()
	{
		RecoveryPending.Hit("CartPartList.CartPartListExists");
		return default(bool);
	}

	public static CartPart[] GetAllParts()
	{
		RecoveryPending.Hit("CartPartList.GetAllParts");
		return default(CartPart[]);
	}

	public static CartPart GetPart(string name)
	{
		RecoveryPending.Hit("CartPartList.GetPart");
		return default(CartPart);
	}

	public static CartPart[] GetSlotPartList(CartSlot.Slots slot)
	{
		RecoveryPending.Hit("CartPartList.GetSlotPartList");
		return default(CartPart[]);
	}

	public static CartPart[] GetDefaultParts()
	{
		RecoveryPending.Hit("CartPartList.GetDefaultParts");
		return default(CartPart[]);
	}

	public static PaintJob[] GetAllPaintJobs()
	{
		RecoveryPending.Hit("CartPartList.GetAllPaintJobs");
		return default(PaintJob[]);
	}

	public static PaintJob GetPaintJob(string name)
	{
		RecoveryPending.Hit("CartPartList.GetPaintJob");
		return default(PaintJob);
	}

	public static PaintJob[] GetSlotPaintJobList(CartSlot.Slots slot)
	{
		RecoveryPending.Hit("CartPartList.GetSlotPaintJobList");
		return default(PaintJob[]);
	}

	public static CartPart GetNextPurchasablePartForSlot(CartSlot.Slots slot)
	{
		RecoveryPending.Hit("CartPartList.GetNextPurchasablePartForSlot");
		return default(CartPart);
	}

	public static CartPart GetMostExpensiveAffordablePart(int threshold)
	{
		RecoveryPending.Hit("CartPartList.GetMostExpensiveAffordablePart");
		return default(CartPart);
	}

	public static CartPart GetMostExpensiveUnlockableAffordablePart(int threshold)
	{
		RecoveryPending.Hit("CartPartList.GetMostExpensiveUnlockableAffordablePart");
		return default(CartPart);
	}
}
