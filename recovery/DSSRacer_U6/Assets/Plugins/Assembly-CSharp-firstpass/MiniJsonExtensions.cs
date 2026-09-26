using System.Collections;
using System.Collections.Generic;

public static class MiniJsonExtensions
{
	public static string toJson(this Hashtable obj)
	{
		RecoveryPending.Hit("MiniJsonExtensions.toJson");
		return default(string);
	}

	public static string toJson(this Dictionary<string, string> obj)
	{
		RecoveryPending.Hit("MiniJsonExtensions.toJson");
		return default(string);
	}

	public static ArrayList arrayListFromJson(this string json)
	{
		RecoveryPending.Hit("MiniJsonExtensions.arrayListFromJson");
		return default(ArrayList);
	}

	public static Hashtable hashtableFromJson(this string json)
	{
		RecoveryPending.Hit("MiniJsonExtensions.hashtableFromJson");
		return default(Hashtable);
	}
}
