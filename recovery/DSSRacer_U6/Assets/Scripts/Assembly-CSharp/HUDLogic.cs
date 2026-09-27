using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race HUD: countdown, place / lap / coins, power-up slots and buttons, drift meter, wrong-way and
// mine notices, achievement banners, task display and the pause menu.
// Source listing: recovery/aot_listings/Assembly-CSharp/HUDLogic.txt
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

	// RECUPERADO-AOT HUDLogic::.ctor token 0x06000752 @0x00139988 (field initializers)
	public int buyAmountNeeded = 50;

	public float catchupDistance = 500f;

	private GameObject playerObject;

	private GameObject wrongWayPopup;

	private BlipTrackPublisher blipTrack;

	private GameObject pauseMenuInstance;

	private MineNotifyPublisher[] minePubs = new MineNotifyPublisher[4];

	private bool[] engagedAchievementNotifications = new bool[3];

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

	// RECUPERADO-AOT HUDLogic::isAchievementNoteEngaged token 0x06000758 @0x00139b18
	public bool isAchievementNoteEngaged()
	{
		for (int i = 0; i < engagedAchievementNotifications.Length; i++)
		{
			if (engagedAchievementNotifications[i])
			{
				return true;
			}
		}
		return false;
	}

	// RECUPERADO-AOT HUDLogic::PreraceCountCoroutine token 0x0600075b @0x00139cf0
	// RECUPERADO-AOT HUDLogic/<PreraceCountCoroutine>c__Iterator79::MoveNext token 0x06000ab1 @0x0015ee90
	// Traffic light: drops in from above, counts 3-2-1 one second apart, shows "Go" and flies back up.
	[DebuggerHidden]
	private IEnumerator PreraceCountCoroutine()
	{
		preRace = true;
		transforms["Prerace Count"].gameObject.SetActive(true);
		GetSprite("Traffic Go").gameObject.SetActive(false);
		for (int count = 3; count > 0; count--)
		{
			GetSprite("Traffic " + count).gameObject.SetActive(false);
		}
		UghSprite sprite = GetSprite("Traffic 3");
		sprite.gameObject.SetActive(true);
		float length = 0.5f;
		float timer = 0f;
		Vector3 goalPosition = sprite.transform.position;
		Vector3 startPosition = goalPosition + Vector3.up * 15f;
		while (timer < length)
		{
			timer += Time.deltaTime;
			sprite.transform.position = Vector3x.Coserp(startPosition, goalPosition, timer / length);
			yield return 0;
		}
		sprite.transform.position = goalPosition;
		for (int count2 = 3; count2 > 0; count2--)
		{
			GetSprite("Traffic " + count2).gameObject.SetActive(true);
			if (count2 < 3)
			{
				GetSprite("Traffic " + (count2 + 1)).gameObject.SetActive(false);
			}
			SoundLibrary.PlaySoundOnCamera("Countdown", false);
			yield return new WaitForSeconds(1f);
		}
		blockDriftScale = false;
		sprite = GetSprite("Traffic Go");
		sprite.gameObject.SetActive(true);
		GetSprite("Traffic 1").gameObject.SetActive(false);
		SoundLibrary.PlaySoundOnCamera("Countdown Go", false);
		yield return new WaitForSeconds(1f);
		startPosition = sprite.transform.position;
		goalPosition = startPosition + Vector3.up * 15f;
		timer = 0f;
		while (timer < length)
		{
			timer += Time.deltaTime;
			sprite.transform.position = Vector3x.Hermite(startPosition, goalPosition, timer / length);
			yield return 0;
		}
		SoundLibrary.StopSoundOnCamera();
		transforms["Prerace Count"].gameObject.SetActive(false);
		preRace = false;
	}

	// RECUPERADO-AOT HUDLogic::AchievementSlideNotificationCoroutine token 0x0600075c @0x00139d38
	// RECUPERADO-AOT HUDLogic/<AchievementSlideNotificationCoroutine>c__Iterator7A::MoveNext token 0x06000ab7 @0x0015f8ac
	// Slides achievement banner <index + 1> in from the right, ticks its checkmark, and slides it back.
	[DebuggerHidden]
	private IEnumerator AchievementSlideNotificationCoroutine(int index, string name)
	{
		if (engagedAchievementNotifications[index])
		{
			yield break;
		}
		Transform notification = transforms["Achievement Notification " + (index + 1)];
		Transform check = notification.Find("checkmark");
		if (check != null)
		{
			check.gameObject.SetActive(false);
		}
		engagedAchievementNotifications[index] = true;
		ughTexts["Achievement Name " + (index + 1)].Text = name;
		Vector3 startPos = notification.localPosition;
		startPos.x = 0f;
		Vector3 endPos = startPos;
		endPos.x = -7f;
		float rate = 0.01666667f;
		float speed = 3f;
		for (float delta = 0f; delta <= 1f; delta += rate * speed)
		{
			notification.localPosition = Vector3x.Berp(startPos, endPos, delta);
			yield return new WaitForSeconds(rate);
		}
		notification.localPosition = endPos;
		if (check != null)
		{
			check.gameObject.SetActive(true);
		}
		SoundLibrary.PlaySoundOnPlayer("Achievement Unlocked", true);
		yield return new WaitForSeconds(1f);
		speed *= 2f;
		for (float delta2 = 0f; delta2 <= 1f; delta2 += rate * speed)
		{
			notification.localPosition = Vector3.Lerp(endPos, startPos, delta2);
			yield return new WaitForSeconds(rate);
		}
		notification.localPosition = startPos;
		engagedAchievementNotifications[index] = false;
	}

	// RECUPERADO-AOT HUDLogic::Start token 0x0600075d @0x00139da0
	// Hides the tutorial arrow, countdown and achievement checkmarks, remembers the power / buy button
	// sprites, hides the drift and reverse buttons on non-iOS platforms, starts the 1 Hz HUD refresh and
	// waits for the race to finish initialising.
	// ADAPTADO-U6: Transform.FindChild -> Find.
	private void Start()
	{
		transforms["Tutorial Arrow"].gameObject.SetActive(false);
		transforms["Prerace Count"].gameObject.SetActive(false);
		for (int i = 0; i < 3; i++)
		{
			Transform transform = transforms["Achievement Notification " + (i + 1)].Find("checkmark");
			if (transform != null)
			{
				transform.gameObject.SetActive(false);
			}
		}
		oldButtonNormal = ughButtons["Power"].normal;
		oldButtonPressed = ughButtons["Power"].pressed;
		oldBuyButtonNormal = ughButtons["Buy"].normal;
		oldBuyButtonPressed = ughButtons["Buy"].pressed;
		if (Application.platform != RuntimePlatform.IPhonePlayer)
		{
			ughButtons["Drift"].gameObject.SetActive(false);
			ughButtons["Reverse"].gameObject.SetActive(false);
		}
		StartCoroutine(GimpedHudCoroutine());
		for (int j = 0; j < minePubs.Length; j++)
		{
			minePubs[j] = null;
		}
		RaceManager.raceInitFinishedEvent += OnRaceInit;
	}

	// RECUPERADO-AOT HUDLogic::OnApplicationPause token 0x0600075e @0x0013a11c
	// Losing focus mid-race opens the pause menu.
	private void OnApplicationPause(bool pause)
	{
		if (pause && !RaceManager.isPaused && RaceManager.elapsedTime != -1)
		{
			RaceManager.PauseRace(true);
			pauseMenuInstance = UnityEngine.Object.Instantiate(pauseScreenPrefab) as GameObject;
			pauseMenuInstance.GetComponent<PausePublisher>().transforms["Tutorial Logo"].gameObject.SetActive(false);
			pauseMenuInstance.GetComponent<PausePublisher>().SetupMissionText();
		}
	}

	// RECUPERADO-AOT HUDLogic::OnRaceInit token 0x0600075f @0x0013a264
	// Mission races show the task display instead of the position track and lap counter (and start with
	// power-ups off); other races set up the position track.
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	private void OnRaceInit()
	{
		RaceManager.raceInitFinishedEvent -= OnRaceInit;
		if (DataUtility.Instance.CurSettings != null && DataUtility.Instance.CurSettings.raceType == RaceSettings.RaceModes.Mission)
		{
			transforms["TaskDisplay"].gameObject.SetActive(true);
			transforms["BlipTrack"].gameObject.SetActive(false);
			ughTexts["LapCount"].gameObject.SetActive(false);
			GameObject playerCar = RaceManager.GetPlayerCar();
			if (playerCar != null)
			{
				PowerupHolder component = playerCar.GetComponent<PowerupHolder>();
				if (component != null)
				{
					component.allowPowerups = false;
				}
			}
			return;
		}
		if (transforms["TaskDisplay"] != null)
		{
			transforms["TaskDisplay"].gameObject.SetActive(false);
		}
		blipTrack = U4Compat.FindObjectOfType(typeof(BlipTrackPublisher)) as BlipTrackPublisher;
		if (blipTrack != null)
		{
			blipTrack.InitBlips();
			blipTrack.InitValues();
		}
		ughTexts["LapCount"].gameObject.SetActive(true);
	}

	// RECUPERADO-AOT HUDLogic::Update token 0x06000760 @0x0013a584
	// Buy button greyed out when no power-up can be taken; drift meter shown while drifting (or forced) and
	// not blocked; power button greyed out while disabled or before the start.
	private void Update()
	{
		if (playerCar != null)
		{
			PowerupHolder component = playerCar.GetComponent<PowerupHolder>();
			if (component != null)
			{
				powerupButtonDisabled = component.buttonDisabled;
				if (!component.CanTakePowerup)
				{
					ughButtons["Buy"].normal = buyButtonDisabledSprite;
					ughButtons["Buy"].pressed = buyButtonDisabledSprite;
					ughButtons["Buy"].UpdateMesh();
				}
				else
				{
					ughButtons["Buy"].normal = oldBuyButtonNormal;
					ughButtons["Buy"].pressed = oldBuyButtonPressed;
					ughButtons["Buy"].UpdateMesh();
				}
			}
			CarCollider component2 = playerCar.GetComponent<CarCollider>();
			bool flag = !blockDriftScale && (component2.isDrifting || forceDriftScaleToShow);
			bool flag2 = blockDriftScale || (!component2.isDrifting && !forceDriftScaleToShow);
			if (flag)
			{
				if (driftScale == null)
				{
					driftScale = Script.Instantiate<GameObject>(driftScalePrefab, transforms["Drift Scale Instance"].position, Quaternion.identity);
				}
			}
			else if (flag2 && driftScale != null)
			{
				UnityEngine.Object.Destroy(driftScale);
			}
		}
		if (powerupButtonDisabled || preRace)
		{
			ughButtons["Power"].normal = disableSprite;
			ughButtons["Power"].pressed = disableSprite;
			ughButtons["Power"].UpdateMesh();
		}
		else
		{
			ughButtons["Power"].normal = oldButtonNormal;
			ughButtons["Power"].pressed = oldButtonPressed;
			ughButtons["Power"].UpdateMesh();
		}
	}

	// RECUPERADO-AOT HUDLogic::ShowDriftScale token 0x06000761 @0x0013a9b8
	public void ShowDriftScale(bool forceToShow)
	{
		forceDriftScaleToShow = forceToShow;
	}

	// RECUPERADO-AOT HUDLogic::GimpedHudCoroutine token 0x06000762 @0x0013a9f4
	// RECUPERADO-AOT HUDLogic/<GimpedHudCoroutine>c__Iterator7B::MoveNext token 0x06000abd @0x00160098
	[DebuggerHidden]
	private IEnumerator GimpedHudCoroutine()
	{
		while (true)
		{
			UpdateHUD();
			yield return new WaitForSeconds(1f);
		}
	}

	// RECUPERADO-AOT HUDLogic::UpdateHUD token 0x06000763 @0x0013aa3c
	// RECUPERADO-AOT HUDLogic/<UpdateHUD>c__AnonStoreyA5::<>m__31/<>m__32/<>m__33 tokens 0x06000b5e-0x06000b60
	// Rebuilds the power-up slots when the reserve changed (one icon centred, or two side by side), then
	// place ("1st"...), lap ("Lap n / total"), mission task display or position track, and the coin balance
	// (millions shown as "1.2 M").
	private void UpdateHUD()
	{
		if (playerObject == null)
		{
			return;
		}
		if (playerObject.GetComponent<CarCollider>() != null)
		{
			PowerupHolder component = playerObject.GetComponent<PowerupHolder>();
			if (component != null && puNeedsUpdate)
			{
				string puType = null;
				Script.Instantiate<GameObject>(getPowerupPrefab, transforms["Get Powerup Particle Anchor"].position, Quaternion.identity);
				if (component.numEffects > 1)
				{
					for (int i = 0; i < transforms["PowerupSingle"].childCount; i++)
					{
						Transform child = transforms["PowerupSingle"].GetChild(i);
						if (child != null)
						{
							UnityEngine.Object.Destroy(child.gameObject);
						}
					}
					puType = component[0].GetType().ToString();
					PowerupDisplay powerupDisplay = Array.Find(powerupDisplayPrefabs, (PowerupDisplay x) => x != null && x.name == puType);
					if (powerupDisplay != null)
					{
						GameObject gameObject = Script.Instantiate<GameObject>(powerupDisplay.prefab);
						gameObject.transform.parent = transforms["PowerupOne"];
						gameObject.transform.localScale = transforms["PowerupOne"].localScale;
						gameObject.transform.localPosition = Vector3.zero;
						gameObject.SetActive(true);
					}
					puType = component[1].GetType().ToString();
					powerupDisplay = Array.Find(powerupDisplayPrefabs, (PowerupDisplay x) => x != null && x.name == puType);
					if (powerupDisplay != null)
					{
						GameObject gameObject2 = Script.Instantiate<GameObject>(powerupDisplay.prefab);
						gameObject2.transform.parent = transforms["PowerupTwo"];
						gameObject2.transform.localScale = transforms["PowerupTwo"].localScale;
						gameObject2.transform.localPosition = Vector3.zero;
						gameObject2.SetActive(true);
					}
				}
				else if (component.numEffects > 0)
				{
					puType = component[0].GetType().ToString();
					PowerupDisplay powerupDisplay2 = Array.Find(powerupDisplayPrefabs, (PowerupDisplay x) => x != null && x.name == puType);
					if (powerupDisplay2 != null)
					{
						GameObject gameObject3 = Script.Instantiate<GameObject>(powerupDisplay2.prefab);
						gameObject3.transform.parent = transforms["PowerupSingle"];
						gameObject3.transform.localPosition = Vector3.zero;
						gameObject3.transform.localScale = Vector3.one;
						gameObject3.SetActive(true);
					}
				}
				else
				{
					for (int j = 0; j < transforms["PowerupSingle"].childCount; j++)
					{
						Transform child2 = transforms["PowerupSingle"].GetChild(j);
						if (child2 != null)
						{
							UnityEngine.Object.Destroy(child2.gameObject);
						}
					}
					for (int k = 0; k < transforms["PowerupOne"].childCount; k++)
					{
						Transform child3 = transforms["PowerupOne"].GetChild(k);
						if (child3 != null)
						{
							UnityEngine.Object.Destroy(child3.gameObject);
						}
					}
					for (int l = 0; l < transforms["PowerupTwo"].childCount; l++)
					{
						Transform child4 = transforms["PowerupTwo"].GetChild(l);
						if (child4 != null)
						{
							UnityEngine.Object.Destroy(child4.gameObject);
						}
					}
				}
				puNeedsUpdate = false;
			}
			int num = RaceManager.GetCarPosition(playerCar) + 1;
			if (num == 1)
			{
				ughTexts["Place"].Text = Localize.Get("1st");
			}
			else if (num == 2)
			{
				ughTexts["Place"].Text = Localize.Get("2nd");
			}
			else if (num == 3)
			{
				ughTexts["Place"].Text = Localize.Get("3rd");
			}
			else
			{
				ughTexts["Place"].Text = num + Localize.Get("th");
			}
			int num2 = RaceManager.GetCarLap(playerCar);
			if (RaceManager.totalNumLaps != -1 && num2 > RaceManager.totalNumLaps)
			{
				num2 = RaceManager.totalNumLaps;
			}
			string text = Localize.Get("Lap ") + num2;
			if (RaceManager.totalNumLaps != -1)
			{
				text = text + " / " + RaceManager.totalNumLaps;
			}
			ughTexts["LapCount"].Text = text;
		}
		if (DataUtility.Instance.CurSettings.raceType == RaceSettings.RaceModes.Mission)
		{
			MissionManager component2 = playerCar.GetComponent<MissionManager>();
			if (component2 == null || !component2.GetHasStartedFirstMission())
			{
				transforms["TaskDisplay"].gameObject.SetActive(false);
			}
		}
		else if (blipTrack != null)
		{
			blipTrack.UpdateBlips();
		}
		float num3 = DataUtility.Instance.cloudData.playerMoney;
		if (num3 > 999999f)
		{
			ughTexts["Coins"].Text = (num3 / 1000000f).ToString("F1") + Localize.Get(" M");
		}
		else
		{
			ughTexts["Coins"].Text = num3.ToString();
		}
	}

	// RECUPERADO-AOT HUDLogic::DisplayNotificationCoroutine token 0x06000764 @0x0013b854
	// RECUPERADO-AOT HUDLogic/<DisplayNotificationCoroutine>c__Iterator7C::MoveNext token 0x06000ac3 @0x00160270
	// Task display with the message: eases down 2 units over 0.8 s, holds for the duration, eases back.
	[DebuggerHidden]
	private IEnumerator DisplayNotificationCoroutine(string text, float duration)
	{
		Transform tutDisplay = transforms["TaskDisplay"];
		ughTexts["TaskMessage"].Text = text;
		tutDisplay.localPosition = Vector3.zero;
		tutDisplay.gameObject.SetActive(true);
		for (float timer = 0f; timer < 0.8f; timer += Time.fixedDeltaTime)
		{
			tutDisplay.localPosition = Vector3x.Berp(Vector3.zero, Vector3.up * -2f, timer / 0.8f);
			yield return new WaitForSeconds(Time.fixedDeltaTime);
		}
		yield return new WaitForSeconds(duration);
		for (float timer2 = 0f; timer2 < 0.8f; timer2 += Time.fixedDeltaTime)
		{
			tutDisplay.localPosition = Vector3x.Berp(Vector3.up * -2f, Vector3.zero, timer2 / 0.8f);
			yield return new WaitForSeconds(Time.fixedDeltaTime);
		}
	}

	// RECUPERADO-AOT HUDLogic::DisplayNotification token 0x06000765 @0x0013b8d0
	public void DisplayNotification(string text, float duration)
	{
		StartCoroutine(DisplayNotificationCoroutine(text, duration));
	}

	// RECUPERADO-AOT HUDLogic::SignalMissionStart token 0x06000766 @0x0013b930
	// RECUPERADO-AOT HUDLogic/<SignalMissionStart>c__Iterator7D::MoveNext token 0x06000ac9 @0x001607b8
	// RECUPERADO-AOT HUDLogic/<SignalMissionStart>c__Iterator7D::<>m__34 token 0x06000acc @0x00161730 (arrow target predicate)
	// Mission task banner: drops in (or, after a previous mission, slides out and back in) with the task text, and
	// points the tutorial arrow at the mission's HUD target when the mission has one.
	// ADAPTADO-U6: Component.animation -> GetComponent<Animation>().
	[DebuggerHidden]
	public IEnumerator SignalMissionStart(bool hadPreviousMission)
	{
		BaseMission mission = playerCar.GetComponent<MissionManager>().GetCurrentMission();
		UnityEngine.Debug.Log("Mission Name: " + mission.GetCurrentMissionName() + " Untranslated: " + mission.GetCurrentUntranslatedMissionName());
		Transform tutDisplay = transforms["TaskDisplay"];
		Transform arrow = transforms["Tutorial Arrow"];
		ArrowTarget at = Array.Find(tutorialArrowTargets, (ArrowTarget x) => x.name == mission.GetCurrentUntranslatedMissionName());
		Transform target = null;
		if (at != null)
		{
			UnityEngine.Debug.LogWarning("Found an arrow target!");
			target = at.target;
		}
		else
		{
			UnityEngine.Debug.LogWarning("Did not find an arrow target!");
		}
		arrow.gameObject.SetActive(false);
		Vector3 closedPos = Vector3.zero;
		Vector3 openPos = Vector3.up * -2f;
		yield return 0;
		if (!hadPreviousMission)
		{
			tutDisplay.localPosition = closedPos;
			tutDisplay.gameObject.SetActive(true);
			while (!preRace)
			{
				yield return null;
			}
			ughTexts["TaskMessage"].Text = mission.GetTaskDisplay();
			arrow.gameObject.SetActive(mission.hasArrow);
			arrow.GetComponent<Animation>().Stop();
			if (mission.hasArrow)
			{
				if (target == null)
				{
					UnityEngine.Debug.LogError("this mission has no arrow target!!");
				}
				arrow.localPosition = new Vector3(target.position.x + mission.arrowXOffset, target.position.y + mission.arrowYOffset, -0.5f);
				arrow.eulerAngles = new Vector3(0f, 0f, mission.arrowRotation);
				arrow.localScale = Vector3.zero;
			}
			float rate = 1f / 60f;
			float speed = 3f;
			for (float timer = 0f; timer <= 1f; timer += rate * speed)
			{
				tutDisplay.localPosition = Vector3x.Berp(closedPos, openPos, timer);
				arrow.localScale = Vector3x.Berp(Vector3.zero, Vector3.one, timer);
				yield return new WaitForSeconds(rate);
			}
		}
		else
		{
			tutDisplay.localPosition = closedPos;
			tutDisplay.gameObject.SetActive(true);
			float rate2 = 1f / 60f;
			float speed2 = 6f;
			for (float timer2 = 0f; timer2 <= 1f; timer2 += rate2 * speed2)
			{
				tutDisplay.localPosition = Vector3.Lerp(openPos, closedPos, timer2);
				arrow.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, timer2);
				yield return new WaitForSeconds(rate2);
			}
			ughTexts["TaskMessage"].Text = mission.GetTaskDisplay();
			arrow.gameObject.SetActive(mission.hasArrow);
			if (mission.hasArrow)
			{
				if (target == null)
				{
					UnityEngine.Debug.LogError("this mission has no arrow target!!");
				}
				arrow.localPosition = new Vector3(target.position.x + mission.arrowXOffset, target.position.y + mission.arrowYOffset, -0.5f);
				arrow.eulerAngles = new Vector3(0f, 0f, mission.arrowRotation);
			}
			speed2 = 3f;
			for (float timer3 = 0f; timer3 <= 1f; timer3 += rate2 * speed2)
			{
				tutDisplay.localPosition = Vector3x.Berp(closedPos, openPos, timer3);
				arrow.localScale = Vector3x.Berp(Vector3.zero, Vector3.one, timer3);
				yield return new WaitForSeconds(rate2);
			}
		}
		arrow.GetComponent<Animation>().Play();
	}

	// RECUPERADO-AOT HUDLogic::SignalMissionComplete token 0x06000767 @0x0013b988
	// RECUPERADO-AOT HUDLogic/<SignalMissionComplete>c__Iterator7E::MoveNext token 0x06000ad0 @0x00161820
	// "Mission Complete!" on the task banner: the arrow shrinks away, then after 3 s the banner either slides up
	// (no more missions) or shows the next mission.
	// ADAPTADO-U6: Component.animation -> GetComponent<Animation>().
	[DebuggerHidden]
	public IEnumerator SignalMissionComplete(bool noMoreMissions)
	{
		Transform tutDisplay = transforms["TaskDisplay"];
		Transform arrow = transforms["Tutorial Arrow"];
		ughTexts["TaskMessage"].Text = Localize.Get("Mission Complete!");
		float timer = 0f;
		float effectLength = 3f;
		arrow.GetComponent<Animation>().Stop();
		while (timer < 0.5f)
		{
			timer += Time.deltaTime;
			arrow.localScale = Vector3.one * Mathfx.Berp(0f, 1f, (0.5f - timer) / 0.5f);
			yield return 0;
		}
		while (timer < effectLength)
		{
			timer += Time.deltaTime;
			yield return 0;
		}
		arrow.gameObject.SetActive(false);
		if (noMoreMissions)
		{
			timer = 0f;
			effectLength = 0.8f;
			while (timer < effectLength)
			{
				timer += Time.deltaTime;
				tutDisplay.localPosition = Vector3.up * 2f - Vector3.up * 2f * Mathfx.Berp(0f, 1f, (effectLength - timer) / effectLength);
				yield return 0;
			}
			tutDisplay.gameObject.SetActive(false);
		}
		else
		{
			StartCoroutine(SignalMissionStart(true));
			yield return 0;
		}
	}

	// RECUPERADO-AOT HUDLogic::AnimateBrakeButtonIn token 0x06000768 @0x0013b9e0
	// RECUPERADO-AOT HUDLogic/<AnimateBrakeButtonIn>c__Iterator7F::MoveNext token 0x06000ad6 @0x00161ed0
	[DebuggerHidden]
	public IEnumerator AnimateBrakeButtonIn()
	{
		float timer = 0f;
		float effectLength = 1f;
		while (timer < effectLength)
		{
			timer += Time.deltaTime;
			Instance.ughButtons["Reverse"].transform.localPosition = new Vector3(-2.8f, -2.03f + Mathfx.Coserp(0f, 1f, timer / effectLength) * 2f, 0f);
			yield return 0;
		}
	}

	// RECUPERADO-AOT HUDLogic::AnimateDriftButtonIn token 0x06000769 @0x0013ba20
	// RECUPERADO-AOT HUDLogic/<AnimateDriftButtonIn>c__Iterator80::MoveNext token 0x06000adc @0x00162274
	[DebuggerHidden]
	public IEnumerator AnimateDriftButtonIn()
	{
		float timer = 0f;
		float effectLength = 1f;
		while (timer < effectLength)
		{
			timer += Time.deltaTime;
			Vector3 pos = Instance.ughButtons["Drift"].transform.localPosition;
			pos.y = -2.03f + Mathfx.Coserp(0f, 1f, timer / effectLength) * 2f;
			Instance.ughButtons["Drift"].transform.localPosition = pos;
			yield return 0;
		}
	}

	// RECUPERADO-AOT HUDLogic::AnimatePowerupDohickeyIn token 0x0600076a @0x0013ba60
	// RECUPERADO-AOT HUDLogic/<AnimatePowerupDohickeyIn>c__Iterator81::MoveNext token 0x06000ae2 @0x00162620
	[DebuggerHidden]
	public IEnumerator AnimatePowerupDohickeyIn()
	{
		float timer = 0f;
		float effectLength = 1f;
		while (timer < effectLength)
		{
			timer += Time.deltaTime;
			Vector3 pos = Instance.ughButtons["Power"].transform.parent.localPosition;
			pos.y = -10.8f + Mathfx.Coserp(0f, 1f, timer / effectLength) * 6f;
			Instance.ughButtons["Power"].transform.parent.localPosition = pos;
			yield return 0;
		}
	}

	// RECUPERADO-AOT HUDLogic::SignalCatchUp token 0x0600076b @0x0013baa0 (empty in the original)
	private void SignalCatchUp()
	{
	}

	// RECUPERADO-AOT HUDLogic::PressedDrift token 0x0600076c @0x0013bacc (empty in the original)
	private void PressedDrift()
	{
	}

	// RECUPERADO-AOT HUDLogic::PressedPower token 0x0600076d @0x0013baf8
	private void PressedPower()
	{
		if (!preRace && !RaceManager.isPaused && !RaceManager.Instance.postRaceStarted && !(playerObject == null))
		{
			PowerupHolder component = playerObject.GetComponent<PowerupHolder>();
			if (!(component == null) && component.numEffects > 0)
			{
				component.ExecutePowerups();
			}
		}
	}

	// RECUPERADO-AOT HUDLogic::PressedBuyButton token 0x0600076e @0x0013bbb8
	// Buys a random power-up (booster, mine, rocket or shield; a strong 6 s booster when catch-up is due)
	// for buyAmountNeeded coins (free on tutorial tracks).
	// ADAPTADO-U6: the GDMO "in_app_currency_action" analytics event is removed (iOS services removed).
	private void PressedBuyButton()
	{
		bool flag = DataUtility.Instance.CurSettings.UIName.baseText.Contains("Tutorial");
		if (RaceManager.Instance.postRaceStarted || RaceManager.isPaused || (DataUtility.Instance.cloudData.playerMoney < buyAmountNeeded && !flag))
		{
			return;
		}
		CarCollider component = playerObject.GetComponent<CarCollider>();
		CarMetrics component2 = playerObject.GetComponent<CarMetrics>();
		if (component == null)
		{
			return;
		}
		PowerupHolder component3 = component.GetComponent<PowerupHolder>();
		if (component3 == null || !component3.CanTakePowerup)
		{
			return;
		}
		if (catchUpNeeded)
		{
			BoosterEffect boosterEffect = new BoosterEffect(component.gameObject);
			boosterEffect.power = 65;
			boosterEffect.time = 6f;
			boosterEffect.IsMultiLevel = true;
			component3.AddEffect(boosterEffect);
		}
		else
		{
			BaseEffect.EffectTypes[] array = new BaseEffect.EffectTypes[4]
			{
				BaseEffect.EffectTypes.BoosterEffect,
				BaseEffect.EffectTypes.MineEffect,
				BaseEffect.EffectTypes.RocketEffect,
				BaseEffect.EffectTypes.ShieldEffect
			};
			component3.AddEffect(BaseEffect.GetEffectInstance(array[UnityEngine.Random.Range(0, array.Length)], component.gameObject));
		}
		if (component2 != null)
		{
			component2.Signal("Purchased Powerup");
		}
		if (DataUtility.Instance.CurSettings.raceType != RaceSettings.RaceModes.Mission)
		{
			LifetimeMetrics.Signal("Lifetime Powerup Purchased");
		}
		MissionManager component4 = component.GetComponent<MissionManager>();
		if (component4 != null)
		{
			component4.Signal("Bought Powerup");
		}
		if (!flag)
		{
			DataUtility.Instance.AddPlayerMoney(-buyAmountNeeded);
		}
		Script.Instantiate<GameObject>(buyPowerupPrefab, transforms["Buy Particle Anchor"].position, Quaternion.identity);
		SoundLibrary.PlaySoundOnPlayer("Buy Powerup", true);
	}

	// RECUPERADO-AOT HUDLogic::PressedPauseButton token 0x0600076f @0x0013c2c4
	// Toggles the pause menu (only once the race clock runs).
	private void PressedPauseButton()
	{
		if (pauseMenuInstance != null)
		{
			RaceManager.PauseRace(false);
			UnityEngine.Object.Destroy(pauseMenuInstance);
			pauseMenuInstance = null;
		}
		else if (RaceManager.elapsedTime != -1)
		{
			RaceManager.PauseRace(true);
			pauseMenuInstance = UnityEngine.Object.Instantiate(pauseScreenPrefab) as GameObject;
			pauseMenuInstance.GetComponent<PausePublisher>().transforms["Tutorial Logo"].gameObject.SetActive(false);
			pauseMenuInstance.GetComponent<PausePublisher>().SetupMissionText();
			MissionManager component = RaceManager.GetPlayerCar().GetComponent<MissionManager>();
			if (component != null)
			{
				component.Signal("Paused Game");
			}
		}
	}

	// RECUPERADO-AOT HUDLogic::SetPlayerObject token 0x06000770 @0x0013c470
	public static void SetPlayerObject(GameObject player)
	{
		if (!(Instance == null))
		{
			Instance.playerObject = player;
		}
	}

	// RECUPERADO-AOT HUDLogic::DoWrongWayNotice token 0x06000771 @0x0013c4bc
	// RECUPERADO-AOT HUDLogic/<DoWrongWayNotice>c__Iterator82::MoveNext token 0x06000ae8 @0x001629e4
	// Blinks the wrong-way popup (1 s on, 1 s off, with its sound) while the flag stays set.
	[DebuggerHidden]
	public IEnumerator DoWrongWayNotice()
	{
		if (wrongWayPopup == null)
		{
			wrongWayPopup = Script.Instantiate<GameObject>(wrongwayPrefab);
		}
		while (wrongWay)
		{
			if (RaceManager.isPaused)
			{
				yield return null;
				continue;
			}
			wrongWayPopup.SetActive(true);
			SoundLibrary.PlaySoundOnPlayer("Wrong Way", true);
			yield return new WaitForSeconds(1f);
			wrongWayPopup.SetActive(false);
			yield return new WaitForSeconds(1f);
		}
		yield return 0;
	}

	// RECUPERADO-AOT HUDLogic::ShowMineNotify token 0x06000772 @0x0013c504
	// Stacks up to four "mine" notices, one frame height (plus 0.1) apart from (5.5, -2, -10).
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public void ShowMineNotify(string text)
	{
		Vector3 zero = Vector3.zero;
		float num = 1.2f;
		Transform transform = mineNotifyPrefab.transform.Find("Frame");
		if (transform != null)
		{
			UghSprite component = transform.GetComponent<UghSprite>();
			if (component != null)
			{
				num = component.normal.size.y * transform.localScale.y + 0.1f;
			}
		}
		for (int i = 0; i < minePubs.Length; i++)
		{
			if (minePubs[i] == null)
			{
				GameObject gameObject = Script.Instantiate<GameObject>(mineNotifyPrefab);
				minePubs[i] = gameObject.GetComponent<MineNotifyPublisher>();
				minePubs[i].SetDisplayName(text);
				zero = new Vector3(5.5f, -2f, -10f);
				zero.y += (float)i * num;
				gameObject.transform.position = zero;
				break;
			}
		}
	}

	// RECUPERADO-AOT HUDLogic::ShowPreraceCount token 0x06000773 @0x0013c7fc
	public void ShowPreraceCount()
	{
		StartCoroutine(PreraceCountCoroutine());
	}

	// RECUPERADO-AOT HUDLogic::ShowAchievementNotification token 0x06000774 @0x0013c84c
	// Uses the first free banner slot.
	public void ShowAchievementNotification(AchievementListener listener)
	{
		for (int i = 0; i < engagedAchievementNotifications.Length; i++)
		{
			if (!engagedAchievementNotifications[i])
			{
				StartCoroutine(AchievementSlideNotificationCoroutine(i, listener.UIName.Text));
				break;
			}
		}
	}
}
