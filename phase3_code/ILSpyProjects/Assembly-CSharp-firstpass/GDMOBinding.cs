using System.Collections;
using System.Runtime.InteropServices;

public class GDMOBinding
{
	[DllImport("__Internal")]
	private static extern void _GDMOInitWithAppKey(string key, string secret);

	public static void InitWithAppKey(string key, string secret)
	{
	}

	[DllImport("__Internal")]
	private static extern void _GDMOInitWithAppKeyEx(string key, string secret, bool useNotifications);

	public static void InitWithAppKey(string key, string secret, bool useNotifications)
	{
	}

	[DllImport("__Internal")]
	private static extern void _GDMOLogAnalyticsEvent(string eventDescription);

	public static void LogAnalyticsEvent(string eventDescription)
	{
	}

	[DllImport("__Internal")]
	private static extern void _GDMOLogAnalyticsEventWithJSON(string scope, string json);

	public static void LogAnalyticsEventWithContext(string scope, Hashtable details)
	{
	}

	[DllImport("__Internal")]
	private static extern void _GDMOFlushAnalyticsQueue();

	public static void FlushAnalyticsQueue()
	{
	}
}
