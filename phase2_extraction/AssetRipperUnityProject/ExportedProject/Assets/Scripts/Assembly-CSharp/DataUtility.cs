using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool Exists
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public int playerCoins
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool PopupDone
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public RaceSettings CurSettings
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void Load()
	{
	}

	public void Save()
	{
	}

	public bool BuyItem(string id, int cost)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator StartStorePurchase()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void FinalizeStore(StoreKitTransaction trans, bool fail)
	{
	}

	[DebuggerHidden]
	private IEnumerator FinalizePurchase(StoreKitTransaction trans, bool fail)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void ProductListRecieved(List<StoreKitProduct> list)
	{
	}

	public void ProductListRequestFailed(string error)
	{
	}

	public int AddSnapshot(SnapShotInfo snap)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public SnapShotInfo GetSnapshot(int lap)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
