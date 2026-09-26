using System.Collections;
using System.Runtime.InteropServices;

public class iCloudBinding
{
	[DllImport("__Internal")]
	private static extern bool _iCloudIsiCloudAvailable();

	public static bool isiCloudAvailable()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudSynchronize();

	public static bool synchronize()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudRemoveObjectForKey(string key);

	public static void removeObjectForKey(string aKey)
	{
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudHasKey(string key);

	public static bool hasKey(string key)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern string _iCloudStringForKey(string key);

	public static string stringForKey(string key)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetString(string aString, string aKey);

	public static void setString(string aString, string aKey)
	{
	}

	[DllImport("__Internal")]
	private static extern string _iCloudDictionaryForKey(string aKey);

	public static Hashtable dictionaryForKey(string aKey)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetDictionary(string dict, string aKey);

	public static void setDictionary(string dict, string aKey)
	{
	}

	[DllImport("__Internal")]
	private static extern float _iCloudDoubleForKey(string aKey);

	public static float doubleForKey(string aKey)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetDouble(double value, string aKey);

	public static void setDouble(double value, string aKey)
	{
	}

	[DllImport("__Internal")]
	private static extern int _iCloudIntForKey(string aKey);

	public static int intForKey(string aKey)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetInt(int value, string aKey);

	public static void setInt(int value, string aKey)
	{
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudBoolForKey(string aKey);

	public static bool boolForKey(string aKey)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetBool(bool value, string aKey);

	public static void setBool(bool value, string aKey)
	{
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudDocumentStoreAvailable();

	public static bool documentStoreAvailable()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern string _iCloudDocumentsDirectory();

	public static string documentsDirectory()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudIsFileInCloud(string file);

	public static bool isFileInCloud(string file)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudIsFileDownloaded(string file);

	public static bool isFileDownloaded(string file)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudAddFile(string file);

	public static bool addFile(string file)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudEvictFile(string file);

	public static void evictFile(string file)
	{
	}
}
