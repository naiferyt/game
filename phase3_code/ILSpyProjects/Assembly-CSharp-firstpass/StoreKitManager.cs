using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoreKitManager : MonoBehaviour
{
	public static event Action<StoreKitTransaction> purchaseSuccessful
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<List<StoreKitProduct>> productListReceived
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<string> productListRequestFailed
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<string> purchaseFailed
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<string> purchaseCancelled
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<string> receiptValidationFailed
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<string> receiptValidationRawResponseReceived
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action receiptValidationSuccessful
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<string> restoreTransactionsFailed
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action restoreTransactionsFinished
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void productPurchased(string json)
	{
	}

	public void productPurchaseFailed(string error)
	{
	}

	public void productPurchaseCancelled(string error)
	{
	}

	public void productsReceived(string json)
	{
	}

	public void productsRequestDidFail(string error)
	{
	}

	public void validateReceiptFailed(string error)
	{
	}

	public void validateReceiptRawResponse(string response)
	{
	}

	public void validateReceiptFinished(string statusCode)
	{
	}

	public void restoreCompletedTransactionsFailed(string error)
	{
	}

	public void restoreCompletedTransactionsFinished(string empty)
	{
	}
}
