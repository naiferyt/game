using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class HUDLogic : UghPublisher
{
	[Serializable]
	public class PowerupDisplay
	{
		public string name;

		public GameObject prefab;
	}

	[Serializable]
	public class ArrowTarget
	{
		public string name;

		public Transform target;
	}

	public GameObject pauseScreenPrefab;

	public GameObject wrongwayPrefab;

	public GameObject mineNotifyPrefab;

	public GameObject buyPowerupPrefab;

	public GameObject getPowerupPrefab;

	public int buyAmountNeeded;

	public float catchupDistance;

	private GameObject playerObject;

	private GameObject wrongWayPopup;

	private BlipTrackPublisher blipTrack;

	private GameObject pauseMenuInstance;

	private MineNotifyPublisher[] minePubs;

	private bool[] engagedAchievementNotifications;

	private bool powerupButtonDisabled;

	public UghSpritePrototype disableSprite;

	private UghSpritePrototype oldButtonNormal;

	private UghSpritePrototype oldButtonPressed;

	public UghSpritePrototype buyButtonDisabledSprite;

	private UghSpritePrototype oldBuyButtonNormal;

	private UghSpritePrototype oldBuyButtonPressed;

	public GameObject driftScalePrefab;

	private GameObject driftScale;

	private bool preRace;

	public bool forceDriftScaleToShow;

	public bool blockDriftScale;

	public PowerupDisplay[] powerupDisplayPrefabs;

	public ArrowTarget[] tutorialArrowTargets;

	public bool puNeedsUpdate;

	private bool catchUpNeeded;

	private bool wrongWay;

	private static HUDLogic s_Instance;

	public bool CatchUpNeeded
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public bool WrongWay
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public static HUDLogic Instance
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static GameObject playerCar
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool isAchievementNoteEngaged()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator PreraceCountCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator AchievementSlideNotificationCoroutine(int index, string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Start()
	{
	}

	private void OnApplicationPause(bool pause)
	{
	}

	private void OnRaceInit()
	{
	}

	private void Update()
	{
	}

	public void ShowDriftScale(bool forceToShow)
	{
	}

	[DebuggerHidden]
	private IEnumerator GimpedHudCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void UpdateHUD()
	{
	}

	[DebuggerHidden]
	private IEnumerator DisplayNotificationCoroutine(string text, float duration)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void DisplayNotification(string text, float duration)
	{
	}

	[DebuggerHidden]
	public IEnumerator SignalMissionStart(bool hadPreviousMission)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public IEnumerator SignalMissionComplete(bool noMoreMissions)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public IEnumerator AnimateBrakeButtonIn()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public IEnumerator AnimateDriftButtonIn()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public IEnumerator AnimatePowerupDohickeyIn()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void SignalCatchUp()
	{
	}

	private void PressedDrift()
	{
	}

	private void PressedPower()
	{
	}

	private void PressedBuyButton()
	{
	}

	private void PressedPauseButton()
	{
	}

	public static void SetPlayerObject(GameObject player)
	{
	}

	[DebuggerHidden]
	public IEnumerator DoWrongWayNotice()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void ShowMineNotify(string text)
	{
	}

	public void ShowPreraceCount()
	{
	}

	public void ShowAchievementNotification(AchievementListener listener)
	{
	}
}
