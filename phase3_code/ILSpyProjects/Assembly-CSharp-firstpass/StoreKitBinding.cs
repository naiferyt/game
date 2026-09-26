using System.Collections.Generic;
using System.Runtime.InteropServices;

public class StoreKitBinding
{
	[DllImport("__Internal")]
	private static extern bool _storeKitCanMakePayments();

	public static bool canMakePayments()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _storeKitRequestProductData(string productIdentifier);

	public static void requestProductData(string[] productIdentifiers)
	{
	}

	[DllImport("__Internal")]
	private static extern void _storeKitPurchaseProduct(string productIdentifier, int quantity);

	public static void purchaseProduct(string productIdentifier, int quantity)
	{
	}

	[DllImport("__Internal")]
	private static extern void _storeKitRestoreCompletedTransactions();

	public static void restoreCompletedTransactions()
	{
	}

	[DllImport("__Internal")]
	private static extern void _storeKitValidateReceipt(string base64EncodedTransactionReceipt, bool isTest);

	public static void validateReceipt(string base64EncodedTransactionReceipt, bool isTest)
	{
	}

	[DllImport("__Internal")]
	private static extern void _storeKitValidateAutoRenewableReceipt(string base64EncodedTransactionReceipt, string secret, bool isTest);

	public static void validateAutoRenewableReceipt(string base64EncodedTransactionReceipt, string secret, bool isTest)
	{
	}

	[DllImport("__Internal")]
	private static extern string _storeKitGetAllSavedTransactions();

	public static List<StoreKitTransaction> getAllSavedTransactions()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
