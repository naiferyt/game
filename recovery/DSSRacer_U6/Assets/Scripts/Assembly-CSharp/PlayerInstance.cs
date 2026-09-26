using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
	public CartSlot[] cartSlots;

	private Material multilayerMaterial;

	private bool hasBootstrapped;

	private static PlayerInstance s_Instance;

	private static GameObject constructedCart;

	public static PlayerInstance Instance
	{
		get
		{
			RecoveryPending.Hit("PlayerInstance.get_Instance");
			return default(PlayerInstance);
		}
	}

	private PlayerInstance()
	{
		RecoveryPending.Hit("PlayerInstance..ctor");
	}

	private void Awake()
	{
		RecoveryPending.Hit("PlayerInstance.Awake");
	}

	private void Start()
	{
		RecoveryPending.Hit("PlayerInstance.Start");
	}

	public static void Bootstrap()
	{
		RecoveryPending.Hit("PlayerInstance.Bootstrap");
	}

	public static CartSlot GetCartSlot(CartSlot.Slots slot)
	{
		RecoveryPending.Hit("PlayerInstance.GetCartSlot");
		return default(CartSlot);
	}

	public static GameObject GetConstructedCart()
	{
		RecoveryPending.Hit("PlayerInstance.GetConstructedCart");
		return default(GameObject);
	}

	[DebuggerHidden]
	public static IEnumerator ConstructCart()
	{
		RecoveryPending.Hit("PlayerInstance.ConstructCart");
		yield break;
	}

	public static void MatchAlternateForms()
	{
		RecoveryPending.Hit("PlayerInstance.MatchAlternateForms");
	}

	public static void ReleaseCart()
	{
		RecoveryPending.Hit("PlayerInstance.ReleaseCart");
	}
}
