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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private static FrontEndLogic GetInstance()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void HideMenu()
	{
	}

	[DebuggerHidden]
	private IEnumerator HideMenuHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void StartMenuTransition(MenuStruct menu)
	{
	}

	[DebuggerHidden]
	private IEnumerator CheckMenuTransitionOK(MenuStruct menu)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
