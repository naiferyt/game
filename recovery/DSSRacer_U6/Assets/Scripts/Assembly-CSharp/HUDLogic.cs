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

	// RECUPERADO-AOT HUDLogic::get_CatchUpNeeded token 0x06000754 @0x00139a38
	// RECUPERADO-AOT HUDLogic::set_CatchUpNeeded token 0x06000755 @0x00139a6c
	public bool CatchUpNeeded
	{
		get
		{
			return catchUpNeeded;
		}
		set
		{
			catchUpNeeded = value;
		}
	}

	// RECUPERADO-AOT HUDLogic::get_WrongWay token 0x06000756 @0x00139aa8
	// RECUPERADO-AOT HUDLogic::set_WrongWay token 0x06000757 @0x00139adc
	public bool WrongWay
	{
		get
		{
			return wrongWay;
		}
		set
		{
			wrongWay = value;
		}
	}

	// RECUPERADO-AOT HUDLogic::get_Instance token 0x06000759 @0x00139ba0
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	public static HUDLogic Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(HUDLogic)) as HUDLogic;
				if (s_Instance == null)
				{
					UnityEngine.Debug.LogError("There must be a HUDLogic object in this scene!");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT HUDLogic::get_playerCar token 0x0600075a @0x00139ca4
	public static GameObject playerCar
	{
		get
		{
			if (Instance == null)
			{
				return null;
			}
			return Instance.playerObject;
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
