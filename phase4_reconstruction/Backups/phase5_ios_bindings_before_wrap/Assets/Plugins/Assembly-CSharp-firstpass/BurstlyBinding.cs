using System.Runtime.InteropServices;
using UnityEngine;

public static class BurstlyBinding
{
	[DllImport("__Internal")]
	private static extern void _Init(string _appID);

	public static void Init(string appID)
	{
	}

	[DllImport("__Internal")]
	private static extern void _ShowBanner(float x, float y, float width, float height, string _zoneID, float alignX, float alignY);

	public static void ShowBanner(Rect frame, string zoneID, Vector2 align)
	{
	}

	[DllImport("__Internal")]
	private static extern void _HideBanner();

	public static void HideBanner()
	{
	}

	[DllImport("__Internal")]
	private static extern void _SetRefreshInterval(float interval);

	public static void SetRefreshInterval(float interval)
	{
	}

	[DllImport("__Internal")]
	private static extern void _PlaceFakeBanner(float x, float y, float width, float height);

	public static void PlaceFakeBanner(Rect frame)
	{
	}

	[DllImport("__Internal")]
	private static extern void _RemoveFakeBanner();

	public static void RemoveFakeBanner()
	{
	}

	[DllImport("__Internal")]
	private static extern void _CacheInterstitial(string _zoneID);

	public static void CacheInterstitial(string zoneID)
	{
	}

	[DllImport("__Internal")]
	private static extern void _SetInterstitialAutoCache(string _zoneID, bool state);

	public static void SetInterstitialAutoCache(string zoneID, bool state)
	{
	}

	[DllImport("__Internal")]
	private static extern void _ShowInterstitial(string _zoneID);

	public static void ShowInterstitial(string zoneID)
	{
	}
}
