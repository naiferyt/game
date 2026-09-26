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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void LoadPartCosts(string textData)
	{
	}

	[DebuggerHidden]
	private IEnumerator ModifyPartCostsCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static CartPart[] GetAllParts()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static CartPart GetPart(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static CartPart[] GetSlotPartList(CartSlot.Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static CartPart[] GetDefaultParts()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static PaintJob[] GetAllPaintJobs()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static PaintJob GetPaintJob(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static PaintJob[] GetSlotPaintJobList(CartSlot.Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static CartPart GetNextPurchasablePartForSlot(CartSlot.Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static CartPart GetMostExpensiveAffordablePart(int threshold)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static CartPart GetMostExpensiveUnlockableAffordablePart(int threshold)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
