using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DataUtility : MonoBehaviour
{
	// ELIMINADO (servicio iOS/externo, decision del usuario 2026-09-26, RECOVERY_REPORT.md 11.2): compras StoreKit, callbacks de Game Center e iCloud
	//   - private List<StoreKitProduct> productsForPurchase;
	//   - public GameObject purchasePopupPrefab;
	//   - private GameObject purchasePopup;
	//   - private bool waitingOnStore;
	//   - private bool haveProducts;
	//   - private void iCloudDataChanged(ArrayList changed)
	//   - public void PurchaseCoinsFromStoreKit(int tier)
	//   - private void SetupItemsForPurchase()
	//   - public void PurchaseFailed(string error)
	//   - public void PurchaseSuccessful(StoreKitTransaction trans)
	//   - private IEnumerator StartStorePurchase()
	//   - private void FinalizeStore(StoreKitTransaction trans, bool fail)
	//   - private IEnumerator FinalizePurchase(StoreKitTransaction trans, bool fail)
	//   - public void ProductListRecieved(List<StoreKitProduct> list)
	//   - public void ProductListRequestFailed(string error)
	//   - private void JCloudDataDidChangeExternally(string[] keys)
	//   - public void gcPlayerAuthenticated()
	//   - public void gcPlayerAuthenticateFailed(string error)
	//   - public void gcDisplayReportedAchievement(string str)
	//   - public void gcReportAchievementFailed(string error)

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

	private bool popupDone;

	private RaceSettings curSettings;

	public static DataUtility Instance
	{
		get
		{
			RecoveryPending.Hit("DataUtility.get_Instance");
			return default(DataUtility);
		}
	}

	public static bool Exists
	{
		get
		{
			RecoveryPending.Hit("DataUtility.get_Exists");
			return default(bool);
		}
	}

	public int playerCoins
	{
		get
		{
			RecoveryPending.Hit("DataUtility.get_playerCoins");
			return default(int);
		}
	}

	public bool PopupDone
	{
		get
		{
			RecoveryPending.Hit("DataUtility.get_PopupDone");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("DataUtility.set_PopupDone");
		}
	}

	public RaceSettings CurSettings
	{
		get
		{
			RecoveryPending.Hit("DataUtility.get_CurSettings");
			return default(RaceSettings);
		}
		set
		{
			RecoveryPending.Hit("DataUtility.set_CurSettings");
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("DataUtility.Awake");
	}

	private void DoActualPurchase(string id, int cost)
	{
		RecoveryPending.Hit("DataUtility.DoActualPurchase");
	}

	public bool IsUnlocked(string key)
	{
		RecoveryPending.Hit("DataUtility.IsUnlocked");
		return default(bool);
	}

	public void Unlock(string key)
	{
		RecoveryPending.Hit("DataUtility.Unlock");
	}

	public void Relock(string key)
	{
		RecoveryPending.Hit("DataUtility.Relock");
	}

	public void SetCartPart(CartSlot.Slots slot, string val)
	{
		RecoveryPending.Hit("DataUtility.SetCartPart");
	}

	public void SetCartPaint(CartSlot.Slots slot, string val)
	{
		RecoveryPending.Hit("DataUtility.SetCartPaint");
	}

	public bool IsCurrentPaint(CartSlot slot)
	{
		RecoveryPending.Hit("DataUtility.IsCurrentPaint");
		return default(bool);
	}

	public void Load()
	{
		RecoveryPending.Hit("DataUtility.Load");
	}

	public void Save()
	{
		RecoveryPending.Hit("DataUtility.Save");
	}

	public bool BuyItem(string id, int cost)
	{
		RecoveryPending.Hit("DataUtility.BuyItem");
		return default(bool);
	}

	public void AddPlayerMoney(int money)
	{
		RecoveryPending.Hit("DataUtility.AddPlayerMoney");
	}

	public void AddPlayerMoney(int money, bool toSet)
	{
		RecoveryPending.Hit("DataUtility.AddPlayerMoney");
	}

	public int AddSnapshot(SnapShotInfo snap)
	{
		RecoveryPending.Hit("DataUtility.AddSnapshot");
		return default(int);
	}

	public SnapShotInfo GetSnapshot(int lap)
	{
		RecoveryPending.Hit("DataUtility.GetSnapshot");
		return default(SnapShotInfo);
	}

	public void CleanupSnapShots(int lapNum)
	{
		RecoveryPending.Hit("DataUtility.CleanupSnapShots");
	}

	public void CleanupAllSnapShots()
	{
		RecoveryPending.Hit("DataUtility.CleanupAllSnapShots");
	}

	private void Start()
	{
		RecoveryPending.Hit("DataUtility.Start");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("DataUtility.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("DataUtility.OnDisable");
	}

	private void OnApplicationPause(bool pause)
	{
		RecoveryPending.Hit("DataUtility.OnApplicationPause");
	}

	private void OnApplicationQuit()
	{
		RecoveryPending.Hit("DataUtility.OnApplicationQuit");
	}

	public static string PrependBundlePath(string path)
	{
		RecoveryPending.Hit("DataUtility.PrependBundlePath");
		return default(string);
	}

}
