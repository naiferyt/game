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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static GameObject GetConstructedCart()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public static IEnumerator ConstructCart()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void MatchAlternateForms()
	{
	}

	public static void ReleaseCart()
	{
	}
}
