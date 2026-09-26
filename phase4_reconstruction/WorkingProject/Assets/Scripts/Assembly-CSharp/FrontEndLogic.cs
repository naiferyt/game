using System;
using System.Collections;
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
			return default(MenuStruct);
		}
	}

	private static FrontEndLogic GetInstance()
	{
		return default(FrontEndLogic);
	}

	public static void HideMenu()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator HideMenuHelper()
	{
		return default(IEnumerator);
	}

	private void StartMenuTransition(MenuStruct menu)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CheckMenuTransitionOK(MenuStruct menu)
	{
		return default(IEnumerator);
	}

	public static void PlayRandomWhoosh()
	{
	}

	private void CheckForDailyBonus()
	{
	}

	private void PopupDailyBonusNote()
	{
	}

	private void GiveDailyBonus(bool shouldReset)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnApplicationPause(bool pause)
	{
	}

	public static void RequestMenuChange(string menuName)
	{
	}

	public static void NeedMoreCoins(string id, int cost, bool forceBuy = false)
	{
	}
}
