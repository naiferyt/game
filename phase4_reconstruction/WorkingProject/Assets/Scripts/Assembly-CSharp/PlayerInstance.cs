using System.Collections;
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
			return default(PlayerInstance);
		}
	}

	private PlayerInstance()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public static void Bootstrap()
	{
	}

	public static CartSlot GetCartSlot(CartSlot.Slots slot)
	{
		return default(CartSlot);
	}

	public static GameObject GetConstructedCart()
	{
		return default(GameObject);
	}

	[System.Diagnostics.DebuggerHidden]
	public static IEnumerator ConstructCart()
	{
		return default(IEnumerator);
	}

	public static void MatchAlternateForms()
	{
	}

	public static void ReleaseCart()
	{
	}
}
