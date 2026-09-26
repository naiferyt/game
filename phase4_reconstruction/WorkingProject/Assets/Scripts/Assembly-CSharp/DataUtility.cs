using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUtility : MonoBehaviour
{
	private static DataUtility s_Instance;

	[NonSerialized]
	public bool forceWebPlayer;

	public bool didPurchase;

	public CloudSaveData cloudData;

	public LifetimeMetrics lifeTimeMetrics;

	public bool isCloudDataLoaded;

	public bool shouldShowTitleScreen;

	public LocalOptionsData localOptions;

	private List<SnapShotInfo> snapshots;

	private List<StoreKitProduct> productsForPurchase;

	private bool popupDone;

	private RaceSettings curSettings;

	public GameObject purchasePopupPrefab;

	private GameObject purchasePopup;

	private bool waitingOnStore;

	private bool haveProducts;

	public static DataUtility Instance
	{
		get
		{
			return default(DataUtility);
		}
	}

	public static bool Exists
	{
		get
		{
			return default(bool);
		}
	}

	public int playerCoins
	{
		get
		{
			return default(int);
		}
	}

	public bool PopupDone
	{
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public RaceSettings CurSettings
	{
		get
		{
			return default(RaceSettings);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void DoActualPurchase(string id, int cost)
	{
	}

	public bool IsUnlocked(string key)
	{
		return default(bool);
	}

	private void iCloudDataChanged(ArrayList changed)
	{
	}

	public void Unlock(string key)
	{
	}

	public void Relock(string key)
	{
	}

	public void SetCartPart(CartSlot.Slots slot, string val)
	{
	}

	public void SetCartPaint(CartSlot.Slots slot, string val)
	{
	}

	public bool IsCurrentPaint(CartSlot slot)
	{
		return default(bool);
	}

	public void Load()
	{
	}

	public void Save()
	{
	}

	public bool BuyItem(string id, int cost)
	{
		return default(bool);
	}

	public void AddPlayerMoney(int money)
	{
	}

	public void AddPlayerMoney(int money, bool toSet)
	{
	}

	public void PurchaseCoinsFromStoreKit(int tier)
	{
	}

	private void SetupItemsForPurchase()
	{
	}

	public void PurchaseFailed(string error)
	{
	}

	public void PurchaseSuccessful(StoreKitTransaction trans)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator StartStorePurchase()
	{
		return default(IEnumerator);
	}

	private void FinalizeStore(StoreKitTransaction trans, bool fail)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator FinalizePurchase(StoreKitTransaction trans, bool fail)
	{
		return default(IEnumerator);
	}

	public void ProductListRecieved(List<StoreKitProduct> list)
	{
	}

	public void ProductListRequestFailed(string error)
	{
	}

	public int AddSnapshot(SnapShotInfo snap)
	{
		return default(int);
	}

	public SnapShotInfo GetSnapshot(int lap)
	{
		return default(SnapShotInfo);
	}

	public void CleanupSnapShots(int lapNum)
	{
	}

	public void CleanupAllSnapShots()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnApplicationPause(bool pause)
	{
	}

	private void OnApplicationQuit()
	{
	}

	private void JCloudDataDidChangeExternally(string[] keys)
	{
	}

	public static string PrependBundlePath(string path)
	{
		return default(string);
	}

	public void gcPlayerAuthenticated()
	{
	}

	public void gcPlayerAuthenticateFailed(string error)
	{
	}

	public void gcDisplayReportedAchievement(string str)
	{
	}

	public void gcReportAchievementFailed(string error)
	{
	}
}
