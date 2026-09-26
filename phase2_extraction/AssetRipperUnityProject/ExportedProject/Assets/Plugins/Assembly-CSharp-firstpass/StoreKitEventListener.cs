using System.Collections.Generic;
using UnityEngine;

public class StoreKitEventListener : MonoBehaviour
{
	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void productListReceived(List<StoreKitProduct> productList)
	{
	}

	private void productListRequestFailed(string error)
	{
	}

	private void receiptValidationSuccessful()
	{
	}

	private void receiptValidationFailed(string error)
	{
	}

	private void receiptValidationRawResponseReceived(string response)
	{
	}

	private void purchaseFailed(string error)
	{
	}

	private void purchaseCancelled(string error)
	{
	}

	private void purchaseSuccessful(StoreKitTransaction transaction)
	{
	}

	private void restoreTransactionsFailed(string error)
	{
	}

	private void restoreTransactionsFinished()
	{
	}
}
