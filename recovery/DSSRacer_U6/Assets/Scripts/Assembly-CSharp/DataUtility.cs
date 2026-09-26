using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Global save/options owner (persistent object created by EnsureGlobals). Keeps the original data model; the
// storage backend is local (LocalSaveStore) instead of iCloud/JCloud.
// Source listing: recovery/aot_listings/Assembly-CSharp/DataUtility.txt
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

	// RECUPERADO-AOT DataUtility..ctor token 0x06000257 @0x000e6348 (field initializers)
	public LifetimeMetrics lifeTimeMetrics = new LifetimeMetrics();

	public bool isCloudDataLoaded;

	public bool shouldShowTitleScreen = true;

	public LocalOptionsData localOptions = new LocalOptionsData(0.25f, 0.75f, true, RaceManager.RaceDifficultyLevel.EASY);

	private List<SnapShotInfo> snapshots;

	private bool popupDone;

	private RaceSettings curSettings;

	public static DataUtility Instance
	{
		// RECUPERADO-AOT DataUtility.get_Instance token 0x06000259 @0x000e6438
		get
		{
			if (s_Instance == null)
			{
				// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat (FindAnyObjectByType)
				s_Instance = U4Compat.FindObjectOfType(typeof(DataUtility)) as DataUtility;
				if (s_Instance == null)
				{
					Debug.LogError("Could not find a DataUtility!");
					return null;
				}
			}
			return s_Instance;
		}
	}

	public static bool Exists
	{
		// RECUPERADO-AOT DataUtility.get_Exists token 0x0600025a @0x000e6538
		get
		{
			return s_Instance != null;
		}
	}

	public int playerCoins
	{
		// RECUPERADO-AOT DataUtility.get_playerCoins token 0x0600025c @0x000e65d0
		get
		{
			return cloudData.playerMoney;
		}
	}

	public bool PopupDone
	{
		// RECUPERADO-AOT DataUtility.get_PopupDone token 0x0600025d @0x000e6608
		get
		{
			return popupDone;
		}
		// RECUPERADO-AOT DataUtility.set_PopupDone token 0x0600025e @0x000e663c
		set
		{
			popupDone = value;
		}
	}

	public RaceSettings CurSettings
	{
		// RECUPERADO-AOT DataUtility.get_CurSettings token 0x0600025f @0x000e6678
		get
		{
			return curSettings;
		}
		// RECUPERADO-AOT DataUtility.set_CurSettings token 0x06000260 @0x000e66ac
		set
		{
			if (curSettings != null)
			{
				UnityEngine.Object.DestroyImmediate(curSettings);
				curSettings = null;
			}
			curSettings = value;
		}
	}

	// RECUPERADO-AOT DataUtility.Awake token 0x0600025b @0x000e6578
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		// ELIMINADO (servicio iOS): JCloudData.AcceptJailbrokenDevices = false;
		//   JCloudData.RegisterCloudDataExternalChanges(this) (avisos de cambios hechos en otro dispositivo).
	}

	// RECUPERADO-AOT DataUtility.DoActualPurchase token 0x06000261 @0x000e6708
	private void DoActualPurchase(string id, int cost)
	{
		cloudData.playerMoney -= cost;
		Unlock(id);
		didPurchase = true;
		LifetimeMetrics.Signal("Tokens Spent", cost);
	}

	// RECUPERADO-AOT DataUtility.IsUnlocked token 0x06000262 @0x000e6794
	public bool IsUnlocked(string key)
	{
		if (!cloudData.unlockDictionary.ContainsKey(key))
		{
			return false;
		}
		return bool.Parse(cloudData.unlockDictionary[key]);
	}

	// RECUPERADO-AOT DataUtility.Unlock token 0x06000264 @0x000e685c
	public void Unlock(string key)
	{
		if (cloudData.unlockDictionary.ContainsKey(key))
		{
			cloudData.unlockDictionary[key] = true.ToString();
		}
		else
		{
			cloudData.unlockDictionary.Add(key, true.ToString());
		}
		Save();
		CartCustomizerPublisher.Refresh();
	}

	// RECUPERADO-AOT DataUtility.Relock token 0x06000265 @0x000e6934
	public void Relock(string key)
	{
		if (cloudData.unlockDictionary.ContainsKey(key))
		{
			cloudData.unlockDictionary[key] = false.ToString();
			Save();
			CartCustomizerPublisher.Refresh();
		}
	}

	// RECUPERADO-AOT DataUtility.SetCartPart token 0x06000266 @0x000e69cc
	public void SetCartPart(CartSlot.Slots slot, string val)
	{
		if (cloudData.playerCartParts != null)
		{
			if (cloudData.playerCartParts.ContainsKey(slot.ToString()))
			{
				cloudData.playerCartParts[slot.ToString()] = val;
			}
			else
			{
				cloudData.playerCartParts.Add(slot.ToString(), val);
			}
		}
		else
		{
			Debug.LogWarning("You are trying to write to the playerCartParts when it hasn't been initialized");
		}
	}

	// RECUPERADO-AOT DataUtility.SetCartPaint token 0x06000267 @0x000e6b20
	public void SetCartPaint(CartSlot.Slots slot, string val)
	{
		// (the original tests playerCartParts, not playerPaintJob, before writing the paint job)
		if (cloudData.playerCartParts != null)
		{
			if (cloudData.playerPaintJob.ContainsKey(slot.ToString()))
			{
				cloudData.playerPaintJob[slot.ToString()] = val;
			}
			else
			{
				cloudData.playerPaintJob.Add(slot.ToString(), val);
			}
		}
		else
		{
			Debug.LogWarning("You are trying to write to the playerPaintJob when it hasn't been initialized");
		}
	}

	// RECUPERADO-AOT DataUtility.IsCurrentPaint token 0x06000268 @0x000e6c74
	public bool IsCurrentPaint(CartSlot slot)
	{
		if (!cloudData.playerPaintJob.ContainsKey(slot.slot.ToString()))
		{
			return false;
		}
		return cloudData.playerPaintJob[slot.slot.ToString()] == slot.slotPaint.name;
	}

	// RECUPERADO-AOT DataUtility.Load token 0x06000269 @0x000e6d8c
	public void Load()
	{
		if (lifeTimeMetrics != null)
		{
			lifeTimeMetrics.Load();
		}
		if (cloudData == null)
		{
			cloudData = new CloudSaveData();
		}
		// ELIMINADO (servicio iOS): the original read every field twice, first from GravCloudPrefs (logging
		// "GravCloud has key: <name>") and then from JCloudData, which won. Both are replaced by one local store with
		// the same keys (field names) and the same per-type encoding (RECONSTRUIDO backend: LocalSaveStore).
		FieldInfo[] fields = cloudData.GetType().GetFields();
		foreach (FieldInfo field in fields)
		{
			if (!LocalSaveStore.HasKey(field.Name))
			{
				continue;
			}
			if (field.FieldType == typeof(short))
			{
				field.SetValue(cloudData, (short)LocalSaveStore.GetInt(field.Name));
			}
			else if (field.FieldType == typeof(int))
			{
				field.SetValue(cloudData, LocalSaveStore.GetInt(field.Name));
			}
			else if (field.FieldType == typeof(long))
			{
				field.SetValue(cloudData, long.Parse(LocalSaveStore.GetString(field.Name)));
			}
			else if (field.FieldType == typeof(string))
			{
				field.SetValue(cloudData, LocalSaveStore.GetString(field.Name));
			}
			else if (field.FieldType == typeof(float))
			{
				field.SetValue(cloudData, LocalSaveStore.GetFloat(field.Name));
			}
			else if (field.FieldType == typeof(bool))
			{
				field.SetValue(cloudData, LocalSaveStore.GetInt(field.Name) == 1);
			}
			else if (field.FieldType == typeof(Dictionary<string, string>))
			{
				Dictionary<string, string> dict = DictionaryToString.Parse(LocalSaveStore.GetString(field.Name, string.Empty));
				if (dict != null)
				{
					field.SetValue(cloudData, dict);
				}
			}
			else
			{
				Debug.LogWarning(string.Concat("Could not load object ", field.Name, " with type ", field.FieldType));
			}
		}
		if (cloudData.cloudSaveDataVersion != 1)
		{
			Debug.Log("Cloud data version " + cloudData.cloudSaveDataVersion.ToString() + " does not match current version " + 1.ToString() + ", wiping cloud data.");
			cloudData = new CloudSaveData();
		}
		isCloudDataLoaded = true;
	}

	// RECUPERADO-AOT DataUtility.Save token 0x0600026a @0x000e784c
	public void Save()
	{
		if (lifeTimeMetrics != null)
		{
			lifeTimeMetrics.Save();
		}
		if (cloudData == null)
		{
			return;
		}
		FieldInfo[] fields = cloudData.GetType().GetFields();
		foreach (FieldInfo field in fields)
		{
			if (field.GetValue(cloudData) == null)
			{
				Debug.LogWarning("Trying to save, but there is a null value?");
			}
			// ELIMINADO (servicio iOS): JCloudData.Set* -> LocalSaveStore.Set* (same keys and encoding)
			if (field.FieldType == typeof(short))
			{
				LocalSaveStore.SetInt(field.Name, (short)field.GetValue(cloudData));
			}
			else if (field.FieldType == typeof(int))
			{
				LocalSaveStore.SetInt(field.Name, (int)field.GetValue(cloudData));
			}
			else if (field.FieldType == typeof(long))
			{
				LocalSaveStore.SetString(field.Name, field.GetValue(cloudData).ToString());
			}
			else if (field.FieldType == typeof(string))
			{
				LocalSaveStore.SetString(field.Name, field.GetValue(cloudData) as string);
			}
			else if (field.FieldType == typeof(float))
			{
				LocalSaveStore.SetFloat(field.Name, (float)field.GetValue(cloudData));
			}
			else if (field.FieldType == typeof(bool))
			{
				LocalSaveStore.SetInt(field.Name, ((bool)field.GetValue(cloudData)) ? 1 : 0);
			}
			else if (field.FieldType == typeof(Dictionary<string, string>))
			{
				Dictionary<string, string> dict = field.GetValue(cloudData) as Dictionary<string, string>;
				// ADAPTADO-U6 (robustez): the original passed a null dictionary on and crashed inside ToString;
				// playerCartParts/playerPaintJob start null until the garage cart is built (Stage 2).
				if (dict != null)
				{
					LocalSaveStore.SetString(field.Name, DictionaryToString.ToString(dict));
				}
			}
		}
		// ELIMINADO (servicio iOS): JCloudData.Save(); GravCloudPrefs.DeleteGravCloudFile() (migración del
		// formato antiguo). Ahora se escribe el archivo local.
		LocalSaveStore.Save();
	}

	// RECUPERADO-AOT DataUtility.BuyItem token 0x0600026b @0x000e7d90
	public bool BuyItem(string id, int cost)
	{
		didPurchase = false;
		if (id == string.Empty)
		{
			return false;
		}
		if (cloudData.unlockDictionary.ContainsKey(id) && bool.Parse(cloudData.unlockDictionary[id]))
		{
			return false;
		}
		if (cloudData.playerMoney < cost)
		{
			FrontEndLogic.NeedMoreCoins(id, cost, false);
		}
		else
		{
			DoActualPurchase(id, cost);
		}
		return didPurchase;
	}

	// RECUPERADO-AOT DataUtility.AddPlayerMoney token 0x0600026c @0x000e7e7c
	public void AddPlayerMoney(int money)
	{
		cloudData.playerMoney += money;
		if (cloudData.playerMoney < 0)
		{
			cloudData.playerMoney = 0;
		}
	}

	// RECUPERADO-AOT DataUtility.AddPlayerMoney token 0x0600026d @0x000e7edc
	public void AddPlayerMoney(int money, bool toSet)
	{
		if (toSet)
		{
			cloudData.playerMoney = money;
		}
		else
		{
			cloudData.playerMoney += money;
		}
		if (cloudData.playerMoney < 0)
		{
			cloudData.playerMoney = 0;
		}
	}

	// RECUPERADO-AOT DataUtility.AddSnapshot token 0x06000277 @0x000e8670
	public int AddSnapshot(SnapShotInfo snap)
	{
		if (snapshots == null)
		{
			snapshots = new List<SnapShotInfo>();
		}
		snapshots.Add(snap);
		return snapshots.IndexOf(snap) + 2;
	}

	// RECUPERADO-AOT DataUtility.GetSnapshot token 0x06000278 @0x000e8708
	public SnapShotInfo GetSnapshot(int lap)
	{
		if (snapshots == null)
		{
			Debug.LogError("Snapshots hasn't been initialized for some stupid reason!");
			return null;
		}
		if (snapshots.Count == 0)
		{
			Debug.Log("There is nothing in the snapshots");
		}
		return snapshots[snapshots.Count - 1];
	}

	// RECUPERADO-AOT DataUtility.CleanupSnapShots token 0x06000279 @0x000e87b0
	public void CleanupSnapShots(int lapNum)
	{
		for (int i = lapNum - 2; i < Math.Max(snapshots.Count - lapNum, 1); i++)
		{
			foreach (CarSnapShot carSnap in snapshots[i].carSnaps)
			{
				if (carSnap.metrics != null)
				{
					GameObject go = carSnap.metrics.gameObject;
					if (go != null)
					{
						UnityEngine.Object.Destroy(go);
					}
				}
			}
		}
		if (lapNum - 2 <= snapshots.Count)
		{
			snapshots.RemoveRange(lapNum - 2, Math.Max(snapshots.Count - lapNum, 1));
		}
	}

	// RECUPERADO-AOT DataUtility.CleanupAllSnapShots token 0x0600027a @0x000e89d8
	public void CleanupAllSnapShots()
	{
		if (snapshots == null)
		{
			return;
		}
		foreach (SnapShotInfo snap in snapshots)
		{
			foreach (CarSnapShot carSnap in snap.carSnaps)
			{
				if (carSnap.metrics != null)
				{
					GameObject go = carSnap.metrics.gameObject;
					if (go != null)
					{
						UnityEngine.Object.Destroy(go);
					}
				}
			}
		}
		snapshots.Clear();
	}

	// RECUPERADO-AOT DataUtility.Start token 0x0600027b @0x000e8c68
	private void Start()
	{
		Debug.Log("DataUtility: Start()");
		// ADAPTADO-U6: Object.FindObjectsOfType -> U4Compat (FindObjectsByType)
		if (U4Compat.FindObjectsOfType(typeof(DataUtility)).Length > 1)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		if (!isCloudDataLoaded)
		{
			Load();
		}
		localOptions.Load();
		// ELIMINADO (servicio iOS): SetupItemsForPurchase() (StoreKit); GameCenterBinding.authenticateLocalPlayer().
		BaseEffect.InitComboLookup();
	}

	// RECUPERADO-AOT DataUtility.OnEnable token 0x0600027c @0x000e8d08
	private void OnEnable()
	{
		// ELIMINADO (servicio iOS): the original only subscribed to StoreKitManager (product list, purchase
		// success/failure/cancel), iCloudManager.keyValueStoreDidChangeEvent and GameCenterManager events.
	}

	// RECUPERADO-AOT DataUtility.OnDisable token 0x0600027d @0x000e903c
	private void OnDisable()
	{
		Save();
		localOptions.Save();
		// ELIMINADO (servicio iOS): unsubscription from the StoreKit / iCloud / Game Center events.
	}

	// RECUPERADO-AOT DataUtility.OnApplicationPause token 0x0600027e @0x000e9388
	private void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			Save();
			localOptions.Save();
		}
		else
		{
			// ELIMINADO (servicio iOS): SetupItemsForPurchase(); GameCenterBinding.authenticateLocalPlayer();
			Load();
			localOptions.Load();
		}
	}

	// RECUPERADO-AOT DataUtility.OnApplicationQuit token 0x0600027f @0x000e9404
	private void OnApplicationQuit()
	{
		Save();
		localOptions.Save();
	}

	// RECUPERADO-AOT DataUtility.PrependBundlePath token 0x06000281 @0x000e94ac
	public static string PrependBundlePath(string path)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			path = "IOSBundles/" + path;
		}
		// ADAPTADO-U6: the Application.isWebPlayer branch ("/WebBundles/") was removed with the web player.
		else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
		{
			path = "/Bundles/WebBundles/" + path;
		}
		else
		{
			Debug.LogError("Undefined platform!");
		}
		return StreamManager.PrependRootFileLocation(path);
	}
}
