using System;
using System.Collections;
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
			return default(bool);
		}
		set
		{
		}
	}

	public bool WrongWay
	{
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public static HUDLogic Instance
	{
		get
		{
			return default(HUDLogic);
		}
	}

	public static GameObject playerCar
	{
		get
		{
			return default(GameObject);
		}
	}

	public bool isAchievementNoteEngaged()
	{
		return default(bool);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator PreraceCountCoroutine()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AchievementSlideNotificationCoroutine(int index, string name)
	{
		return default(IEnumerator);
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

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator GimpedHudCoroutine()
	{
		return default(IEnumerator);
	}

	private void UpdateHUD()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator DisplayNotificationCoroutine(string text, float duration)
	{
		return default(IEnumerator);
	}

	public void DisplayNotification(string text, float duration)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator SignalMissionStart(bool hadPreviousMission)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator SignalMissionComplete(bool noMoreMissions)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator AnimateBrakeButtonIn()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator AnimateDriftButtonIn()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator AnimatePowerupDohickeyIn()
	{
		return default(IEnumerator);
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

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator DoWrongWayNotice()
	{
		return default(IEnumerator);
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
