using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Garage / front-end controller: opens menus (with camera move and fades), daily bonus, music.
// Source listing: recovery/aot_listings/Assembly-CSharp/FrontEndLogic.txt
public class FrontEndLogic : MonoBehaviour
{
	[Serializable]
	public class MenuStruct
	{
		public string name;

		public FrontEndCameraTarget cameraTarget;

		public GameObject menuPrefab;
	}

	public GameObject moreCoinsPopupPrefab;

	public GameObject playerCar;

	public GameObject tutorialLauncherPrefab;

	public GameObject dailyBonusPrefab;

	public GameObject purchaseNotificationPrefab;

	public Renderer garageRenderer;

	public Texture pranksgivingGarageTexture;

	public int initialMenuIndex;

	public MenuStruct[] menues;

	private MenuStruct currentMenu;

	private GameObject displayedMenuObject;

	private FrontEndCamera menuCamera;

	private GameObject moreCoinsDialog;

	// RECUPERADO-AOT FrontEndLogic::.cctor token 0x06000666 @0x0012a464
	private static bool firstLoad = true;

	// RECUPERADO-AOT FrontEndLogic::.ctor token 0x06000665 @0x0012a428 (field initializers)
	public int dailyBonusBase = 10;

	// RECUPERADO-AOT FrontEndLogic::get_CurrentMenu token 0x06000667 @0x0012a4a0
	public MenuStruct CurrentMenu
	{
		get
		{
			return currentMenu;
		}
	}

	// RECUPERADO-AOT FrontEndLogic::GetInstance token 0x06000668 @0x0012a4d4
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	private static FrontEndLogic GetInstance()
	{
		FrontEndLogic frontEndLogic = U4Compat.FindObjectOfType(typeof(FrontEndLogic)) as FrontEndLogic;
		if (frontEndLogic == null)
		{
			UnityEngine.Debug.LogError("This scene requires a FrontEndLogic object!");
		}
		return frontEndLogic;
	}

	// RECUPERADO-AOT FrontEndLogic::HideMenu token 0x06000669 @0x0012a57c
	public static void HideMenu()
	{
		FrontEndLogic instance = GetInstance();
		if (instance.displayedMenuObject != null)
		{
			instance.StartCoroutine(instance.HideMenuHelper());
		}
	}

	// RECUPERADO-AOT FrontEndLogic::HideMenuHelper token 0x0600066a @0x0012a5ec
	// (iterator <HideMenuHelper>c__Iterator58 MoveNext token 0x060009e4 @0x00154688)
	[DebuggerHidden]
	private IEnumerator HideMenuHelper()
	{
		FadeHelper.Instance.FadeRecursively(displayedMenuObject.transform, 0.2f, false);
		while (FadeHelper.Instance.IsFading(displayedMenuObject.transform))
		{
			yield return null;
		}
		displayedMenuObject.SetActive(false);
	}

	// RECUPERADO-AOT FrontEndLogic::StartMenuTransition token 0x0600066b @0x0012a634
	private void StartMenuTransition(MenuStruct menu)
	{
		StartCoroutine(CheckMenuTransitionOK(menu));
	}

	// RECUPERADO-AOT FrontEndLogic::CheckMenuTransitionOK token 0x0600066c @0x0012a67c
	// (iterator <CheckMenuTransitionOK>c__Iterator59 MoveNext token 0x060009ea @0x001548c8)
	// ADAPTADO-U6: Object.DestroyObject (removed) -> Object.Destroy.
	[DebuggerHidden]
	private IEnumerator CheckMenuTransitionOK(MenuStruct menu)
	{
		while (PreviewCart.IsLoading)
		{
			yield return 0;
		}
		if (displayedMenuObject != null)
		{
			FadeHelper.Instance.FadeRecursively(displayedMenuObject.transform, 0.2f, false);
			yield return null;
			while (FadeHelper.Instance.IsFading(displayedMenuObject.transform))
			{
				yield return null;
			}
			UnityEngine.Object.Destroy(displayedMenuObject);
		}
		if (menuCamera != null && menu != null)
		{
			menuCamera.SendMessage("SetCameraTarget", menu.cameraTarget);
		}
		currentMenu = menu;
	}

	// RECUPERADO-AOT FrontEndLogic::PlayRandomWhoosh token 0x0600066d @0x0012a6d4
	public static void PlayRandomWhoosh()
	{
		FrontEndLogic instance = GetInstance();
		if (!(instance == null) && instance.currentMenu != null && !(instance.currentMenu.name == "Play"))
		{
			SoundLibrary.PlayRandomWhoosh();
		}
	}

	// RECUPERADO-AOT FrontEndLogic::CheckForDailyBonus token 0x0600066e @0x0012a748
	private void CheckForDailyBonus()
	{
		if (DataUtility.Instance.cloudData.timeStamp != long.MinValue)
		{
			DateTime dateTime = DateTime.Today.ToUniversalTime();
			if (dateTime > DateTime.FromBinary(DataUtility.Instance.cloudData.timeStamp).AddDays(1.0).ToUniversalTime())
			{
				bool shouldReset = dateTime > DateTime.FromBinary(DataUtility.Instance.cloudData.timeStamp).AddDays(2.0).ToUniversalTime();
				GiveDailyBonus(shouldReset);
				DataUtility.Instance.cloudData.timeStamp = DateTime.Today.ToUniversalTime().ToBinary();
			}
		}
		else
		{
			DataUtility.Instance.cloudData.timeStamp = DateTime.Today.ToUniversalTime().ToBinary();
			// ELIMINADO (servicio iOS): Object.Instantiate(purchaseNotificationPrefab), el aviso de primera
			// ejecucion "Purchase Notification Popup" sobre compras con dinero real en iTunes (StoreKit).
		}
		// ELIMINADO (servicio iOS): NotificationServices.CancelAllLocalNotifications() y dos
		// LocalNotification "Come back to claim your daily token reward!" programadas para dentro de
		// 3 y 7 dias (DateTime.Today + TimeSpan.FromDays(3.0/7.0)).
	}

	// RECUPERADO-AOT FrontEndLogic::PopupDailyBonusNote token 0x0600066f @0x0012abf8
	private void PopupDailyBonusNote()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(dailyBonusPrefab) as GameObject;
		UghPublisher component = gameObject.GetComponent<UghPublisher>();
		component.transforms["Prize Box"].gameObject.SetActive(false);
		component.ughTexts["Claim"].Text = Localize.Get("TAP here!");
		component.ughTexts["HeadLine"].Text = Localize.Get("Welcome!");
		component.ughTexts["Instruction"].Text = Localize.Get("Play again tomorrow to claim a bonus prize!");
	}

	// RECUPERADO-AOT FrontEndLogic::GiveDailyBonus token 0x06000670 @0x0012adc4
	// Goofy's circuit doubles the base bonus and Donald's triples it (checked in that order, as compiled).
	private void GiveDailyBonus(bool shouldReset)
	{
		int num = dailyBonusBase;
		TrackUnlockHelper trackUnlockHelper = (TrackUnlockHelper)U4Compat.FindObjectOfType(typeof(TrackUnlockHelper));
		if (trackUnlockHelper != null)
		{
			if (trackUnlockHelper.IsCircuitUnlocked("Goofy"))
			{
				num *= 2;
			}
			else if (trackUnlockHelper.IsCircuitUnlocked("Donald"))
			{
				num *= 3;
			}
		}
		int num2 = num;
		if (shouldReset)
		{
			DataUtility.Instance.cloudData.bonusCount = 0;
		}
		else
		{
			int num3 = (int)((float)num * 0.5f);
			num2 += DataUtility.Instance.cloudData.bonusCount * num3;
		}
		DataUtility.Instance.AddPlayerMoney(num2);
		GameObject gameObject = UnityEngine.Object.Instantiate(dailyBonusPrefab) as GameObject;
		UghPublisher component = gameObject.GetComponent<UghPublisher>();
		component.transforms["Prize Box"].gameObject.SetActive(true);
		component.ughTexts["Claim"].Text = Localize.Get("TAP to claim today's prize!");
		component.ughTexts["HeadLine"].Text = Localize.Get("Welcome Back!");
		component.ughTexts["Instruction"].Text = Localize.Get("Play again tomorrow to claim an even bigger prize!");
		component.ughTexts["Prize"].Text = num2.ToString();
	}

	// RECUPERADO-AOT FrontEndLogic::Start token 0x06000671 @0x0012b178
	private void Start()
	{
		ScreenTimeoutController.AllowSleep();
		if (!DataUtility.Instance.isCloudDataLoaded)
		{
			DataUtility.Instance.Load();
		}
		menuCamera = U4Compat.FindObjectOfType(typeof(FrontEndCamera)) as FrontEndCamera;
		if (menuCamera == null)
		{
			UnityEngine.Debug.LogError("This scene requires a FrontEndCamera object!");
		}
		if (firstLoad)
		{
			firstLoad = false;
			// ELIMINADO (servicio iOS/externo): GDMOManager.SendWithContext("player_info", {"player_id":
			// SystemInfo.deviceUniqueIdentifier, "soft_currency": {"coins": playerMoney}}) (analitica).
		}
		// ADAPTADO-U6: Application.isWebPlayer (siempre false fuera del web player, que no existe en Unity 6).
		if (!DataUtility.Instance.forceWebPlayer)
		{
			CheckForDailyBonus();
		}
		if ((bool)MusicPlayer.Instance)
		{
			MusicPlayer.Instance.PlayMusic();
		}
		if (menues.Length > 0)
		{
			GameObject gameObject = GameObject.Find("Race Results Flag Object");
			ShiftUIPublisher shiftUIPublisher = (ShiftUIPublisher)U4Compat.FindObjectOfType(typeof(ShiftUIPublisher));
			if (gameObject != null)
			{
				UnityEngine.Object.Destroy(gameObject);
				if (shiftUIPublisher != null)
				{
					shiftUIPublisher.PressedCartCustomizer();
				}
			}
			else if (!DataUtility.Instance.shouldShowTitleScreen)
			{
				if (shiftUIPublisher != null)
				{
					shiftUIPublisher.Show(true);
					shiftUIPublisher.PressedPlayButton();
				}
			}
			else
			{
				DataUtility.Instance.shouldShowTitleScreen = false;
				StartMenuTransition(menues[initialMenuIndex]);
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("FrontEndLogic does not have any defined menues.");
		}
		PlayerInstance.Bootstrap();
		PreviewCart.GenerateCartPreview();
		CharacterPreview.Refresh(false);
		StreamManager.Cleanup();
		AchievementManager.Instance.InitFrontEndAchievements();
		TrackUnlockHelper trackUnlockHelper = (TrackUnlockHelper)U4Compat.FindObjectOfType(typeof(TrackUnlockHelper));
		if (trackUnlockHelper != null && trackUnlockHelper.CanPranksgiving)
		{
			garageRenderer.materials[0].mainTexture = pranksgivingGarageTexture;
		}
		// ELIMINADO (servicio iOS/externo): BurstlyBinding.Init("u0gCO_b0tEismmt7js_pGg") (anuncios).
	}

	// RECUPERADO-AOT FrontEndLogic::Update token 0x06000672 @0x0012b678
	private void Update()
	{
		if (currentMenu != null && displayedMenuObject == null && !menuCamera.isTransitioning)
		{
			displayedMenuObject = UnityEngine.Object.Instantiate(currentMenu.menuPrefab) as GameObject;
			FadeHelper.Instance.SetOpacityRecursively(displayedMenuObject.transform, 0f);
			FadeHelper.Instance.FadeRecursively(displayedMenuObject.transform, 0.2f, true);
		}
	}

	// RECUPERADO-AOT FrontEndLogic::OnApplicationPause token 0x06000673 @0x0012b7e0
	// ADAPTADO-U6: Application.isWebPlayer dropped (always false).
	private void OnApplicationPause(bool pause)
	{
		if (!pause && !DataUtility.Instance.forceWebPlayer)
		{
			CheckForDailyBonus();
		}
	}

	// RECUPERADO-AOT FrontEndLogic::RequestMenuChange token 0x06000674 @0x0012b840
	// (predicate <RequestMenuChange>c__AnonStoreyA0::<>m__24 token 0x06000b54)
	public static void RequestMenuChange(string menuName)
	{
		FrontEndLogic instance = GetInstance();
		if (instance.currentMenu == null || !(instance.currentMenu.name == menuName))
		{
			MenuStruct menuStruct = Array.Find(instance.menues, (MenuStruct test) => test.name == menuName);
			if (menuStruct != null)
			{
				instance.StartMenuTransition(menuStruct);
			}
		}
	}

	// RECUPERADO-AOT FrontEndLogic::NeedMoreCoins token 0x06000675 @0x0012b94c
	// ELIMINADO (servicio iOS): instanciaba moreCoinsPopupPrefab (BuyCoinsPrefab, DebugMoreCoinsPublisher,
	// tienda de monedas StoreKit). Sin forceBuy mostraba "Need More Tokens" + appPurchasesOffMessage con
	// solo el boton OK y los paneles de compra ocultos; con forceBuy, "More Tokens" con los paneles.
	public static void NeedMoreCoins(string id, int cost, bool forceBuy = false)
	{
		UnityEngine.Debug.Log("NeedMoreCoins(" + id + ", " + cost + "): coin store removed (StoreKit).");
	}
}
