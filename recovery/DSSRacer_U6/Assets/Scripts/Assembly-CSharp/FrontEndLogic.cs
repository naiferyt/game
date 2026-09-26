using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

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

	private static bool firstLoad;

	public int dailyBonusBase;

	public MenuStruct CurrentMenu
	{
		get
		{
			RecoveryPending.Hit("FrontEndLogic.get_CurrentMenu");
			return default(MenuStruct);
		}
	}

	private static FrontEndLogic GetInstance()
	{
		RecoveryPending.Hit("FrontEndLogic.GetInstance");
		return default(FrontEndLogic);
	}

	public static void HideMenu()
	{
		RecoveryPending.Hit("FrontEndLogic.HideMenu");
	}

	[DebuggerHidden]
	private IEnumerator HideMenuHelper()
	{
		RecoveryPending.Hit("FrontEndLogic.HideMenuHelper");
		yield break;
	}

	private void StartMenuTransition(MenuStruct menu)
	{
		RecoveryPending.Hit("FrontEndLogic.StartMenuTransition");
	}

	[DebuggerHidden]
	private IEnumerator CheckMenuTransitionOK(MenuStruct menu)
	{
		RecoveryPending.Hit("FrontEndLogic.CheckMenuTransitionOK");
		yield break;
	}

	public static void PlayRandomWhoosh()
	{
		RecoveryPending.Hit("FrontEndLogic.PlayRandomWhoosh");
	}

	private void CheckForDailyBonus()
	{
		RecoveryPending.Hit("FrontEndLogic.CheckForDailyBonus");
	}

	private void PopupDailyBonusNote()
	{
		RecoveryPending.Hit("FrontEndLogic.PopupDailyBonusNote");
	}

	private void GiveDailyBonus(bool shouldReset)
	{
		RecoveryPending.Hit("FrontEndLogic.GiveDailyBonus");
	}

	private void Start()
	{
		RecoveryPending.Hit("FrontEndLogic.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("FrontEndLogic.Update");
	}

	private void OnApplicationPause(bool pause)
	{
		RecoveryPending.Hit("FrontEndLogic.OnApplicationPause");
	}

	public static void RequestMenuChange(string menuName)
	{
		RecoveryPending.Hit("FrontEndLogic.RequestMenuChange");
	}

	public static void NeedMoreCoins(string id, int cost, bool forceBuy = false)
	{
		RecoveryPending.Hit("FrontEndLogic.NeedMoreCoins");
	}
}
