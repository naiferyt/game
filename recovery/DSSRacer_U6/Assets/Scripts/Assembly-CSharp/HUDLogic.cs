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
			RecoveryPending.Hit("HUDLogic.get_CatchUpNeeded");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("HUDLogic.set_CatchUpNeeded");
		}
	}

	public bool WrongWay
	{
		get
		{
			RecoveryPending.Hit("HUDLogic.get_WrongWay");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("HUDLogic.set_WrongWay");
		}
	}

	public static HUDLogic Instance
	{
		get
		{
			RecoveryPending.Hit("HUDLogic.get_Instance");
			return default(HUDLogic);
		}
	}

	public static GameObject playerCar
	{
		get
		{
			RecoveryPending.Hit("HUDLogic.get_playerCar");
			return default(GameObject);
		}
	}

	public bool isAchievementNoteEngaged()
	{
		RecoveryPending.Hit("HUDLogic.isAchievementNoteEngaged");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator PreraceCountCoroutine()
	{
		RecoveryPending.Hit("HUDLogic.PreraceCountCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator AchievementSlideNotificationCoroutine(int index, string name)
	{
		RecoveryPending.Hit("HUDLogic.AchievementSlideNotificationCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("HUDLogic.Start");
	}

	private void OnApplicationPause(bool pause)
	{
		RecoveryPending.Hit("HUDLogic.OnApplicationPause");
	}

	private void OnRaceInit()
	{
		RecoveryPending.Hit("HUDLogic.OnRaceInit");
	}

	private void Update()
	{
		RecoveryPending.Hit("HUDLogic.Update");
	}

	public void ShowDriftScale(bool forceToShow)
	{
		RecoveryPending.Hit("HUDLogic.ShowDriftScale");
	}

	[DebuggerHidden]
	private IEnumerator GimpedHudCoroutine()
	{
		RecoveryPending.Hit("HUDLogic.GimpedHudCoroutine");
		yield break;
	}

	private void UpdateHUD()
	{
		RecoveryPending.Hit("HUDLogic.UpdateHUD");
	}

	[DebuggerHidden]
	private IEnumerator DisplayNotificationCoroutine(string text, float duration)
	{
		RecoveryPending.Hit("HUDLogic.DisplayNotificationCoroutine");
		yield break;
	}

	public void DisplayNotification(string text, float duration)
	{
		RecoveryPending.Hit("HUDLogic.DisplayNotification");
	}

	[DebuggerHidden]
	public IEnumerator SignalMissionStart(bool hadPreviousMission)
	{
		RecoveryPending.Hit("HUDLogic.SignalMissionStart");
		yield break;
	}

	[DebuggerHidden]
	public IEnumerator SignalMissionComplete(bool noMoreMissions)
	{
		RecoveryPending.Hit("HUDLogic.SignalMissionComplete");
		yield break;
	}

	[DebuggerHidden]
	public IEnumerator AnimateBrakeButtonIn()
	{
		RecoveryPending.Hit("HUDLogic.AnimateBrakeButtonIn");
		yield break;
	}

	[DebuggerHidden]
	public IEnumerator AnimateDriftButtonIn()
	{
		RecoveryPending.Hit("HUDLogic.AnimateDriftButtonIn");
		yield break;
	}

	[DebuggerHidden]
	public IEnumerator AnimatePowerupDohickeyIn()
	{
		RecoveryPending.Hit("HUDLogic.AnimatePowerupDohickeyIn");
		yield break;
	}

	private void SignalCatchUp()
	{
		RecoveryPending.Hit("HUDLogic.SignalCatchUp");
	}

	private void PressedDrift()
	{
		RecoveryPending.Hit("HUDLogic.PressedDrift");
	}

	private void PressedPower()
	{
		RecoveryPending.Hit("HUDLogic.PressedPower");
	}

	private void PressedBuyButton()
	{
		RecoveryPending.Hit("HUDLogic.PressedBuyButton");
	}

	private void PressedPauseButton()
	{
		RecoveryPending.Hit("HUDLogic.PressedPauseButton");
	}

	public static void SetPlayerObject(GameObject player)
	{
		RecoveryPending.Hit("HUDLogic.SetPlayerObject");
	}

	[DebuggerHidden]
	public IEnumerator DoWrongWayNotice()
	{
		RecoveryPending.Hit("HUDLogic.DoWrongWayNotice");
		yield break;
	}

	public void ShowMineNotify(string text)
	{
		RecoveryPending.Hit("HUDLogic.ShowMineNotify");
	}

	public void ShowPreraceCount()
	{
		RecoveryPending.Hit("HUDLogic.ShowPreraceCount");
	}

	public void ShowAchievementNotification(AchievementListener listener)
	{
		RecoveryPending.Hit("HUDLogic.ShowAchievementNotification");
	}
}
