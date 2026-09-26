using System.Collections;
using System.Collections.Generic;

public class StoreKitTransaction
{
	public string productIdentifier;

	public string base64EncodedTransactionReceipt;

	public int quantity;

	public static List<StoreKitTransaction> transactionsFromJson(string json)
	{
		return default(List<StoreKitTransaction>);
	}

	public static StoreKitTransaction transactionFromJson(string json)
	{
		return default(StoreKitTransaction);
	}

	public static StoreKitTransaction transactionFromHashtable(Hashtable ht)
	{
		return default(StoreKitTransaction);
	}

	public override string ToString()
	{
		return default(string);
	}
}
