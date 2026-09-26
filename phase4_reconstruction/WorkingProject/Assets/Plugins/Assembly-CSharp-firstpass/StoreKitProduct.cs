using System.Collections;
using System.Collections.Generic;

public class StoreKitProduct
{
	public string productIdentifier;

	public string title;

	public string description;

	public string price;

	public string currencySymbol;

	public string currencyCode;

	public string formattedPrice;

	public static List<StoreKitProduct> productsFromJson(string json)
	{
		return default(List<StoreKitProduct>);
	}

	public static StoreKitProduct productFromHashtable(Hashtable ht)
	{
		return default(StoreKitProduct);
	}

	public override string ToString()
	{
		return default(string);
	}
}
