using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// Race controller: spawns the karts on the grid, runs the pre-race and countdown, tracks laps and positions,
// handles the finish, Elimination mode, rewards and the exit to the results screen.
// Source listing: recovery/aot_listings/Assembly-CSharp/RaceManager.txt
public class RaceManager : MonoBehaviour
{
	public enum RaceDifficultyLevel
	{
		EASY = 0,
		MEDIUM = 1,
		HARD = 2,
		NINTENDO_HARD = 3
	}

	public delegate void RaceInitHandler();

	private const int groundLayerMask = 256;

	private const int collideLayerMask = 1024;

	private const int COINS_TO_SPAWN = 20;

	private const float CATCHUP_DISTANCE = 400f;

	private const float SLOWDOWN_DISTANCE = 200f;

	private const bool ENABLE_PRERACE_COUNTDOWN = true;

	private const int BASE_FIRST_PLACE_REWARD = 300;

	private const int BASE_NON_PLACE_REWARD = 10;

	private const int PLACEMENT_DIVISOR = 2;

	public RaceDifficultyLevel raceDifficulty;

	public static Action raceEndEvent;

	private int numLaps;

	public WaypointLogic firstWaypoint;

	public ProgressTriggerLogic lapLine;

	private List<GameObject> carList;

	private GameObject playerCar;

	private Dictionary<GameObject, CarProgress> carProgressMap;

	private int[] carOrderList;

	private DateTime raceStart;

	// RECUPERADO-AOT RaceManager::.ctor token 0x06000529 @0x0010e4ac (field initializer)
	private int finishCounter = 1;

	private bool isPausedState;

	private DateTime pauseStart;

	public int inactiveCars;

	public bool preRaceActive;

	public bool postRaceStarted;

	private Dictionary<GameObject, int> elimMap;

	private float rewindRaceTime;

	private int rewindCoinsToSpawn;

	private static RaceManager s_Instance;

	public static RaceManager Instance
	{
		// RECUPERADO-AOT RaceManager.get_Instance token 0x0600052d @0x0010e64c
		get
		{
			if (s_Instance == null)
			{
				// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat (FindAnyObjectByType)
				s_Instance = U4Compat.FindObjectOfType(typeof(RaceManager)) as RaceManager;
				if (s_Instance == null)
				{
					GameObject go = new GameObject("+RaceManager");
					// ADAPTADO-U6: AddComponent("RaceManager") (string overload removed) -> AddComponent<RaceManager>()
					s_Instance = go.AddComponent<RaceManager>();
					if (s_Instance == null)
					{
						UnityEngine.Debug.LogError("Could not create an instance of RaceManager!");
					}
				}
			}
			return s_Instance;
		}
	}

	public static bool Exists
	{
		// RECUPERADO-AOT RaceManager.get_Exists token 0x0600052e @0x0010e818
		get
		{
			return s_Instance != null;
		}
	}

	public static bool isPaused
	{
		// RECUPERADO-AOT RaceManager.get_isPaused token 0x0600052f @0x0010e858
		get
		{
			if (!Exists)
			{
				return false;
			}
			return Instance.isPausedState;
		}
	}

	public static GameObject[] allCars
	{
		// RECUPERADO-AOT RaceManager::get_allCars token 0x0600053d @0x00111350
		get
		{
			RaceManager instance = Instance;
			if (instance.carList == null)
			{
				return null;
			}
			return instance.carList.ToArray();
		}
	}

	public static GameObject leadCar
	{
		// RECUPERADO-AOT RaceManager::get_leadCar token 0x0600053e @0x001113a4
		get
		{
			return GetCarInPosition(0);
		}
	}

	public static int elapsedTime
	{
		// RECUPERADO-AOT RaceManager::get_elapsedTime token 0x0600053f @0x001113d0
		// Whole seconds since the start (-1 before the countdown ends).
		get
		{
			RaceManager instance = Instance;
			if (instance.raceStart == DateTime.MinValue)
			{
				return -1;
			}
			return (int)((double)(DateTime.Now - instance.raceStart).Ticks / 10000000.0);
		}
	}

	public static int totalNumLaps
	{
		// RECUPERADO-AOT RaceManager::get_totalNumLaps token 0x06000540 @0x0011150c
		get
		{
			return Instance.numLaps;
		}
	}

	public static WaypointLogic lastWaypoint
	{
		// RECUPERADO-AOT RaceManager::get_lastWaypoint token 0x06000541 @0x00111538
		get
		{
			RaceManager instance = Instance;
			if (instance.firstWaypoint == null)
			{
				return null;
			}
			return instance.firstWaypoint.backwardPoint;
		}
	}

	public static float totalTrackLength
	{
		// RECUPERADO-AOT RaceManager::get_totalTrackLength token 0x06000542 @0x0011158c
		get
		{
			WaypointLogic waypointLogic = lastWaypoint;
			if (waypointLogic == null)
			{
				return 0f;
			}
			return waypointLogic.totalTrackDistance + waypointLogic.distanceToNext;
		}
	}

	// RECUPERADO-AOT RaceManager::add_raceInitFinishedEvent token 0x0600052b @0x0010e50c
	// RECUPERADO-AOT RaceManager::remove_raceInitFinishedEvent token 0x0600052c @0x0010e5ac
	// (compiler-generated field-like event accessors: Delegate.Combine / Delegate.Remove)
	public static event RaceInitHandler raceInitFinishedEvent;

	// RECUPERADO-AOT RaceManager::RaceOutCoroutine token 0x06000530 @0x0010e8a0
	// (iterator <RaceOutCoroutine>c__Iterator40 MoveNext token 0x06000954 @0x0014e770)
	// Waits for achievement notes, fades out and loads the results screen (the garage after a mission).
	// ELIMINADO (anuncios): BurstlyBinding.ShowInterstitial("0759142059127234080") before the fade.
	// ADAPTADO-U6: Application.LoadLevel -> SceneManager.LoadScene.
	[DebuggerHidden]
	private IEnumerator RaceOutCoroutine()
	{
		yield return 0;
		while (HUDLogic.Instance.isAchievementNoteEngaged())
		{
			yield return 0;
		}
		yield return new WaitForSeconds(0.5f);
		ScreenFader.Instance.FadeOut();
		yield return new WaitForSeconds(1f);
		CleanupRace();
		if (DataUtility.Instance.CurSettings.RaceType == RaceSettings.RaceModes.Mission)
		{
			SceneManager.LoadScene("PreFrontEnd");
		}
		else
		{
			SceneManager.LoadScene("RaceResults");
		}
	}

	// RECUPERADO-AOT RaceManager::CalculateCarPositionPump token 0x06000531 @0x0010e8e0
	// (iterator <CalculateCarPositionPump>c__Iterator41 MoveNext token 0x0600095a @0x0014ea5c)
	[DebuggerHidden]
	private IEnumerator CalculateCarPositionPump()
	{
		while (true)
		{
			CalculateCarPositions();
			yield return new WaitForSeconds(1f);
		}
	}

	// RECUPERADO-AOT RaceManager::PreraceCountdown token 0x06000532 @0x0010e928
	// (iterator <PreraceCountdown>c__Iterator42 MoveNext token 0x06000960 @0x0014ec34)
	// Track fly-by, then the HUD countdown; the race clock starts 3.5 s later (minus the rewound time).
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	[DebuggerHidden]
	private IEnumerator PreraceCountdown()
	{
		PreRaceCamera preCam = (PreRaceCamera)U4Compat.FindObjectOfType(typeof(PreRaceCamera));
		preCam.StartCamera();
		while (preRaceActive)
		{
			yield return 0;
		}
		HUDLogic hud = U4Compat.FindObjectOfType(typeof(HUDLogic)) as HUDLogic;
		if (hud != null)
		{
			hud.ShowPreraceCount();
		}
		raceStart = DateTime.MinValue;
		yield return new WaitForSeconds(3.5f);
		raceStart = DateTime.Now - TimeSpan.FromSeconds(rewindRaceTime);
	}

	// RECUPERADO-AOT RaceManager::DoFinishLineEffect token 0x06000533 @0x0010e970
	// (iterator <DoFinishLineEffect>c__Iterator43 MoveNext token 0x06000966 @0x0014eff0)
	// "1st/2nd/3rd/Nth" banner that grows, holds 2 s and shrinks away ("Tutorial Complete!" on the tutorial).
	[DebuggerHidden]
	public IEnumerator DoFinishLineEffect(GameObject player, bool elimination)
	{
		if (DataUtility.Instance.CurSettings.UIName.baseText == "Tutorial")
		{
			HUDLogic.Instance.DisplayNotification(Localize.Get("Tutorial Complete!"), 2f);
		}
		else
		{
			GameObject effect = UnityEngine.Object.Instantiate(ParticleLibrary.Instance.GetPrefab("FinishLine")) as GameObject;
			UghPublisher pub = effect.GetComponent<UghPublisher>();
			if (pub != null)
			{
				int place = carProgressMap[player].finalPlace;
				string placeMod = string.Empty;
				switch (place)
				{
				case 1:
					placeMod = Localize.Get("st");
					break;
				case 2:
					placeMod = Localize.Get("nd");
					break;
				case 3:
					placeMod = Localize.Get("rd");
					break;
				default:
					placeMod = Localize.Get("th");
					break;
				}
				pub.ughTexts["finishText"].Text = place.ToString();
				pub.ughTexts["finishTextPost"].Text = placeMod;
				Vector3 scale = pub.transforms["Scaler"].transform.localScale;
				float size = 0.2f;
				bool toggle = true;
				float time = Time.deltaTime * 2f;
				while (true)
				{
					size += (toggle ? time : (time * -1f));
					if (size >= 1.5f)
					{
						yield return new WaitForSeconds(2f);
						toggle = !toggle;
					}
					if (size < 0.1f)
					{
						break;
					}
					pub.transforms["Scaler"].transform.localScale = scale * size;
					yield return new WaitForFixedUpdate();
				}
				UnityEngine.Object.Destroy(effect);
				yield break;
			}
		}
		yield return 0;
	}

	// RECUPERADO-AOT RaceManager::PostRaceCountdown token 0x06000534 @0x0010e9cc
	// (iterator <PostRaceCountdown>c__Iterator44 MoveNext token 0x0600096c @0x0014f6c8)
	// Player finished: win/lose sting, voice line, finish banner; the player's kart is handed to the AI to
	// keep driving; a top-3 finish triggers a celebration; results 3 s later.
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	[DebuggerHidden]
	public IEnumerator PostRaceCountdown(bool elimination)
	{
		postRaceStarted = true;
		HUDLogic hud = U4Compat.FindObjectOfType(typeof(HUDLogic)) as HUDLogic;
		if (hud != null)
		{
			hud.blockDriftScale = true;
		}
		GameObject car = GetPlayerCar();
		if (car != null)
		{
			int place = carProgressMap[car].finalPlace;
			if (car.GetComponent<EffectManager>() != null)
			{
				car.GetComponent<EffectManager>().RemoveAllEffects();
			}
			string sound = "Race ";
			sound = ((place != 1) ? (sound + "Lose") : (sound + "Win"));
			MusicPlayer.Instance.HijackMusicPlayerForSoundStings(sound, false);
			CharacterVOController voc = car.GetVOController();
			if (voc != null)
			{
				if (place <= 3)
				{
					voc.PlayCelebrate();
				}
				else
				{
					voc.PlayPout();
				}
			}
			StartCoroutine(DoFinishLineEffect(car, elimination));
			if (elimination)
			{
				yield return new WaitForSeconds(3f);
				EndRace();
				yield break;
			}
			yield return 0;
			float speed = car.GetComponent<CarCollider>().GetVelocity().magnitude;
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				car.GetComponent<PlayerAccelControl>().enabled = false;
			}
			else
			{
				car.GetComponent<PlayerKeyboardControl>().enabled = false;
			}
			if (U4Compat.FindObjectOfType(typeof(CarAIPathManager)) != null)
			{
				car.GetComponent<PlayerControlLinker>().enabled = false;
				car.GetComponent<CarCollider>().enabled = false;
				GimpedCarAI ai = car.AddComponent<GimpedCarAI>();
				ai.LinearVelocity = speed;
				ai.SetToClosestPathHead();
			}
			yield return 0;
			if (place <= 3)
			{
				PlayRandomAnimation(car);
			}
		}
		yield return new WaitForSeconds(3f);
		EndRace();
	}

	// RECUPERADO-AOT RaceManager::PlayRandomAnimation token 0x06000535 @0x0010ea24
	// (string switch on Random.Range(0, 4))
	private void PlayRandomAnimation(GameObject car)
	{
		if (car == null)
		{
			return;
		}
		AnimationDriver component = car.GetComponent<AnimationDriver>();
		if (component != null)
		{
			string text = "driving";
			switch (UnityEngine.Random.Range(0, 4))
			{
			case 0:
				text = "wave";
				break;
			case 1:
				text = "handsUp";
				break;
			case 2:
				text = "fist";
				break;
			case 3:
				text = "cheering";
				break;
			}
			UnityEngine.Debug.Log("Triggering: " + text + " animation");
			component.Play(text, true);
		}
	}

	// RECUPERADO-AOT RaceManager::PreLaunchCoroutine token 0x06000536 @0x0010eb70
	// (iterator <PreLaunchCoroutine>c__Iterator45 MoveNext token 0x06000972 @0x0014fd50)
	[DebuggerHidden]
	private IEnumerator PreLaunchCoroutine()
	{
		yield return new WaitForSeconds(1f);
		StartCoroutine(CalculateCarPositionPump());
		StartCoroutine(PreraceCountdown());
		ScreenFader.Instance.FadeIn();
	}

	// RECUPERADO-AOT RaceManager::CalculateCarPositions token 0x06000537 @0x0010ebb8
	// (comparison <CalculateCarPositions>m__12 token 0x06000556 @0x00113788)
	// Race distance = laps × track length + distance along the track (0 until the first progress trigger, or
	// when the jump looks like a wrong lap crossing); orders the karts. On Easy/Medium, rivals 200+ units
	// ahead of the player get a slowdown effect.
	private void CalculateCarPositions()
	{
		List<KeyValuePair<int, float>> list = new List<KeyValuePair<int, float>>(carList.Count);
		for (int i = 0; i < carList.Count; i++)
		{
			GameObject gameObject = carList[i];
			if (gameObject == null)
			{
				return;
			}
			float num = totalTrackLength * (float)carProgressMap[gameObject].lapCount;
			float num2 = WaypointLogic.GetTrackDistanceForPoint(gameObject.transform.position);
			if (carProgressMap[gameObject].lastProgressTrigger == null)
			{
				num2 = 0f;
			}
			else if (carProgressMap[gameObject].lastDistance + 1000f < num2 + num)
			{
				num2 = 0f;
			}
			float value = num2 + num;
			list.Add(new KeyValuePair<int, float>(i, value));
			carProgressMap[gameObject].lastDistance = value;
		}
		list.Sort(delegate(KeyValuePair<int, float> first, KeyValuePair<int, float> second)
		{
			float num4 = second.Value - first.Value;
			if (num4 < 0f)
			{
				return -1;
			}
			return (num4 > 1f) ? 1 : 0;
		});
		for (int j = 0; j < carList.Count; j++)
		{
			carOrderList[j] = list[j].Key;
		}
		float lastDistance = carProgressMap[playerCar].lastDistance;
		foreach (GameObject car in carList)
		{
			if (car == playerCar)
			{
				continue;
			}
			// MODIFICADO (petición del usuario, 2026-09-27; with RivalTuning on): no slowdown until both karts have a
			// progress trigger. At the start the front-row rivals reach their first trigger before the player, their
			// race distance jumps to about one lap while the player's is still 0, and the original slowed them to 50%
			// for 5-10 s right off the grid.
			if (RivalTuning.Enabled && (carProgressMap[car].lastProgressTrigger == null || carProgressMap[playerCar].lastProgressTrigger == null))
			{
				continue;
			}
			float num3 = carProgressMap[car].lastDistance - lastDistance;
			if ((raceDifficulty != RaceDifficultyLevel.EASY && raceDifficulty != RaceDifficultyLevel.MEDIUM) || !(num3 >= 200f))
			{
				continue;
			}
			EffectManager component = car.GetComponent<EffectManager>();
			if (!(component == null) && !component.HasEffect(typeof(SlowdownEffect)))
			{
				SlowdownEffect slowdownEffect = new SlowdownEffect(car);
				slowdownEffect.power = 50;
				slowdownEffect.time = 5f * (1f + UnityEngine.Random.value);
				component.AddEffect(slowdownEffect);
			}
		}
	}

	// RECUPERADO-AOT RaceManager::SpawnCoins token 0x06000538 @0x0010f220
	private void SpawnCoins()
	{
		SpawnCoins(20);
	}

	// RECUPERADO-AOT RaceManager::SpawnCoins token 0x06000539 @0x0010f258
	// Spreads the coins over the CoinPoints proportionally to their weight.
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	private void SpawnCoins(int numToSpawn)
	{
		UnityEngine.Object[] array = U4Compat.FindObjectsOfType(typeof(CoinPoint));
		float num = 0f;
		for (int i = 0; i < array.Length; i++)
		{
			num += ((CoinPoint)array[i]).weight;
		}
		for (int j = 0; j < array.Length; j++)
		{
			CoinPoint coinPoint = (CoinPoint)array[j];
			int num2 = (int)((float)numToSpawn * coinPoint.weight / num);
			if (num2 > 0)
			{
				coinPoint.SpawnCoins(num2);
			}
		}
	}

	// RECUPERADO-AOT RaceManager::Init token 0x0600053a @0x0010f440
	// (comparison <Init>m__13 token 0x06000557 @0x00113860)
	// Spawns the AI karts (top speed and aggression by difficulty) and the player's kart, puts them on the
	// "Pole Position" markers (sorted by name, snapped to the ground), finds the lap line and the first
	// waypoint, spawns coins, removes the scene lights (the tracks are lightmapped) and starts the pre-race.
	// ADAPTADO-U6: FindObjectOfType(s) -> U4Compat; the Self-Illumin check also accepts the Unity 6 name
	//     "Legacy Shaders/Self-Illumin/Diffuse" (the Stage 0 remap renamed the built-in shader).
	// ELIMINADO (analitica): GDMOManager.SendWithContext("game_action", {player_id, context: "race",
	//     action: "start" (+ "rewind"), type: level name}).
	private void Init(bool rewind)
	{
		HUDLogic hUDLogic = U4Compat.FindObjectOfType(typeof(HUDLogic)) as HUDLogic;
		if (hUDLogic != null)
		{
			hUDLogic.blockDriftScale = true;
		}
		QualityControl.Apply();
		RaceSettings curSettings = DataUtility.Instance.CurSettings;
		finishCounter = 1;
		if (curSettings.raceType == RaceSettings.RaceModes.Elimination)
		{
			numLaps = curSettings.AICarts.Length;
		}
		else
		{
			numLaps = curSettings.numLaps;
		}
		raceDifficulty = DataUtility.Instance.localOptions.raceDifficulty;
		carList = new List<GameObject>();
		carProgressMap = new Dictionary<GameObject, CarProgress>();
		RaceSettings.AICartSettings[] aICarts = curSettings.AICarts;
		foreach (RaceSettings.AICartSettings aICartSettings in aICarts)
		{
			StreamManager.Asset asset = StreamManager.RequestAsset(aICartSettings.assetName, string.Empty, StreamManager.StreamType.UNKNOWN);
			if (asset == null || !asset.isDone)
			{
				UnityEngine.Debug.LogError("Could not load an AI asset with name " + aICartSettings.assetName);
				continue;
			}
			GameObject gameObject = (GameObject)asset.mainAsset;
			if (gameObject == null)
			{
				UnityEngine.Debug.LogError("There appears to be an error loading AI asset with name " + aICartSettings.assetName);
				continue;
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject) as GameObject;
			gameObject2.name = aICartSettings.characterName;
			carList.Add(gameObject2);
			carProgressMap.Add(gameObject2, new CarProgress(gameObject2.name));
			GimpedCarAI componentInChildren = gameObject2.GetComponentInChildren<GimpedCarAI>();
			CarCollider component = gameObject2.GetComponent<CarCollider>();
			switch (raceDifficulty)
			{
			case RaceDifficultyLevel.EASY:
				component.attributes.maxSpeed = 39f;
				if (componentInChildren != null)
				{
					componentInChildren.aggressionIndex = 0.5f;
				}
				break;
			case RaceDifficultyLevel.MEDIUM:
				component.attributes.maxSpeed = 45.5f;
				if (componentInChildren != null)
				{
					componentInChildren.aggressionIndex = 1.25f;
				}
				break;
			case RaceDifficultyLevel.HARD:
				component.attributes.maxSpeed = 47f;
				if (componentInChildren != null)
				{
					componentInChildren.aggressionIndex = 1.75f;
				}
				break;
			case RaceDifficultyLevel.NINTENDO_HARD:
				component.attributes.maxSpeed = 51.5f;
				if (componentInChildren != null)
				{
					componentInChildren.aggressionIndex = 2.5f;
				}
				break;
			}
		}
		playerCar = PlayerInstance.GetConstructedCart();
		AnimationDriver component2 = playerCar.GetComponent<AnimationDriver>();
		if (component2 != null)
		{
			component2.SetAnimationTarget(playerCar);
		}
		carList.Add(playerCar);
		carProgressMap.Add(playerCar, new CarProgress(playerCar.name));
		playerCar.tag = "Player";
		CarCollider component3 = playerCar.GetComponent<CarCollider>();
		if (component3.attributes.handling < 2f)
		{
			component3.attributes.handling = 2f;
		}
		if (curSettings.raceType != RaceSettings.RaceModes.Mission)
		{
			playerCar.AddComponent(typeof(CarMetrics));
		}
		HUDLogic.SetPlayerObject(playerCar);
		if (curSettings.raceType == RaceSettings.RaceModes.Mission)
		{
			MissionManager missionManager = playerCar.AddComponent(typeof(MissionManager)) as MissionManager;
			BaseMission[] missions = curSettings.missions;
			foreach (BaseMission mission in missions)
			{
				missionManager.AddMission(mission);
			}
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Pole Position");
		if (array.Length < carList.Count)
		{
			UnityEngine.Debug.LogError("Not enough pole positions for cars! (" + array.Length + " poles and " + carList.Count + " cars)");
		}
		else
		{
			Array.Sort(array, (GameObject pole1, GameObject pole2) => pole1.name.CompareTo(pole2.name));
			for (int k = 0; k < carList.Count; k++)
			{
				RaycastHit hitInfo;
				if (Physics.Raycast(array[k].transform.position + Vector3.up * 5f, Vector3.down, out hitInfo, float.PositiveInfinity, 1280))
				{
					Vector3 vector = new Vector3(0f, carList[k].GetComponent<CarCollider>().attributes.groundHeight, 0f);
					carList[k].transform.position = hitInfo.point + vector;
				}
				else
				{
					carList[k].transform.position = array[k].transform.position;
				}
				carList[k].transform.rotation = array[k].transform.rotation;
			}
		}
		carOrderList = new int[carList.Count];
		for (int l = 0; l < carList.Count; l++)
		{
			carOrderList[l] = l;
		}
		UnityEngine.Object[] array2 = U4Compat.FindObjectsOfType(typeof(ProgressTriggerLogic));
		for (int m = 0; m < array2.Length; m++)
		{
			ProgressTriggerLogic progressTriggerLogic = (ProgressTriggerLogic)array2[m];
			if (progressTriggerLogic.isLapLine)
			{
				lapLine = progressTriggerLogic;
				break;
			}
		}
		GameObject gameObject3 = null;
		GameObject[] array3 = GameObject.FindGameObjectsWithTag("Waypoint");
		foreach (GameObject gameObject4 in array3)
		{
			if (gameObject4.GetComponent<WaypointLogic>() != null && gameObject4.GetComponent<WaypointLogic>().isFirst)
			{
				gameObject3 = gameObject4;
				break;
			}
		}
		if (gameObject3 == null)
		{
			UnityEngine.Debug.LogError("Could not find first waypoint game object!");
		}
		firstWaypoint = gameObject3.GetComponent<WaypointLogic>();
		if (firstWaypoint == null)
		{
			UnityEngine.Debug.LogError("Could not find first waypoint component!");
		}
		if (firstWaypoint != null)
		{
			WaypointLogic.WaypointPrecalculations(firstWaypoint);
		}
		if (curSettings.raceType == RaceSettings.RaceModes.Campaign && !rewind)
		{
			SpawnCoins();
		}
		UnityEngine.Object[] array4 = U4Compat.FindObjectsOfType(typeof(Light));
		for (int num = 0; num < array4.Length; num++)
		{
			UnityEngine.Object.Destroy(array4[num]);
		}
		UnityEngine.Object[] array5 = U4Compat.FindObjectsOfType(typeof(Renderer));
		for (int num2 = 0; num2 < array5.Length; num2++)
		{
			Renderer renderer = (Renderer)array5[num2];
			if (renderer.name != "ScreenFader")
			{
				string text = renderer.material.shader.name;
				if (text == "Self-Illumin/Diffuse" || text == "Legacy Shaders/Self-Illumin/Diffuse")
				{
					renderer.material.shader = Shader.Find("Mobile/Unlit (Supports Lightmap)");
				}
			}
		}
		StartCoroutine(PreLaunchCoroutine());
		if (RaceManager.raceInitFinishedEvent != null)
		{
			RaceManager.raceInitFinishedEvent();
		}
		StartMusic(curSettings.UIName.baseText);
		PlayAmbientNoise();
	}

	// RECUPERADO-AOT RaceManager::PlayAmbientNoise token 0x0600053b @0x001108d0
	private void PlayAmbientNoise()
	{
		string text = DataUtility.Instance.CurSettings.levelName.baseText;
		if (text.Contains("Kick") || text.Contains("Tutorial"))
		{
			text = "Kick";
		}
		else if (text.Contains("Phineas"))
		{
			text = "Phineas";
		}
		else if (text.Contains("Fish"))
		{
			text = "Fish";
		}
		SoundLibrary.PlaySoundOnCamera(text + " Ambient", true);
	}

	// RECUPERADO-AOT RaceManager::EndRace token 0x0600053c @0x00110a0c
	// (comparison <EndRace>m__14 token 0x06000558 @0x001138c0, predicate <EndRace>m__15 token 0x06000559 @0x00113a20)
	// Builds the "Stats Object" with the ordered results (karts still racing get places and estimated
	// times from their distance), pays the placement reward and leaves the race.
	// ADAPTADO-U6: AddComponent("RaceResults") -> AddComponent<RaceResults>(); FindObjectsOfType -> U4Compat.
	// ELIMINADO (analitica): GDMOManager.SendWithContext("game_action", {player_id, context: "race",
	//     action: "end", type: level name}).
	public void EndRace()
	{
		GameObject gameObject = new GameObject("Stats Object");
		RaceResults raceResults = gameObject.AddComponent<RaceResults>();
		raceResults.raceRewindTime = rewindRaceTime;
		rewindCoinsToSpawn = U4Compat.FindObjectsOfType(typeof(Coin)).Length;
		raceResults.rewindCoinsToSpawn = rewindCoinsToSpawn;
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		raceResults.ordredResultList = new CarProgress[carList.Count];
		for (int i = 0; i < carList.Count; i++)
		{
			raceResults.ordredResultList[i] = carProgressMap[carList[i]];
		}
		Array.Sort(raceResults.ordredResultList, delegate(CarProgress prog1, CarProgress prog2)
		{
			if (DataUtility.Instance.CurSettings.raceType != RaceSettings.RaceModes.Elimination)
			{
				if (prog1.finalPlace == 0 && prog2.finalPlace > 0)
				{
					return 1;
				}
				if (prog2.finalPlace == 0 && prog1.finalPlace > 0)
				{
					return -1;
				}
			}
			if ((prog1.finalPlace == 0 && prog2.finalPlace == 0) || DataUtility.Instance.CurSettings.raceType == RaceSettings.RaceModes.Elimination)
			{
				float num6 = prog2.lastDistance - prog1.lastDistance;
				if (num6 < 0f)
				{
					return -1;
				}
				return (num6 > 0f) ? 1 : 0;
			}
			return prog1.finalPlace - prog2.finalPlace;
		});
		float lastDistance = raceResults.ordredResultList[0].lastDistance;
		int num = elapsedTime;
		CarProgress[] ordredResultList = raceResults.ordredResultList;
		foreach (CarProgress carProgress in ordredResultList)
		{
			if (carProgress.finalPlace == 0)
			{
				carProgress.finalPlace = finishCounter;
				finishCounter++;
				float num2 = (lastDistance - carProgress.lastDistance) / 40f;
				carProgress.finishTime = elapsedTime + (int)num2 + UnityEngine.Random.Range(1, 5);
				if (carProgress.finishTime < num)
				{
					carProgress.finishTime = num + UnityEngine.Random.Range(1, 5);
				}
				num = carProgress.finishTime;
			}
		}
		raceResults.playerCarIndex = Array.FindIndex(raceResults.ordredResultList, (CarProgress x) => x.carName == playerCar.name);
		CarMetrics component = playerCar.GetComponent<CarMetrics>();
		if (component != null)
		{
			component.Signal("Base Placement Reward", 0f);
			component.Signal("Reward Difficulty Multiplier", 0f);
			component.Signal("Placement Reward", 0f);
		}
		if (raceResults.playerCarIndex < carList.Count)
		{
			int num3 = (int)raceDifficulty * 2;
			if (num3 == 0)
			{
				num3 = 1;
			}
			int num4 = raceResults.playerCarIndex * 2;
			if (num4 == 0)
			{
				num4 = 1;
			}
			if (DataUtility.Instance.CurSettings.raceType != RaceSettings.RaceModes.Mission)
			{
				int num5 = 0;
				if (raceResults.playerCarIndex < 3)
				{
					if (component != null)
					{
						component.Signal("Base Placement Reward", (float)(300 / num4));
					}
					num5 = num3 * 300 / num4;
				}
				else
				{
					if (component != null)
					{
						component.Signal("Base Placement Reward", 10f);
					}
					num5 = num3 * 10;
				}
				if (component != null)
				{
					component.Signal("Reward Difficulty Multiplier", (float)num3);
					component.Signal("Placement Reward", (float)num5);
				}
				DataUtility.Instance.AddPlayerMoney(num5);
				UnityEngine.Debug.Log("Player scored " + num5 + " placement Tokens.");
			}
		}
		if (component != null)
		{
			raceResults.playerMetrics = component.CloneToObject(raceResults.gameObject);
			raceResults.playerMetrics.enabled = false;
		}
		if (raceEndEvent != null)
		{
			raceEndEvent();
		}
		StartCoroutine(RaceOutCoroutine());
	}

	// RECUPERADO-AOT RaceManager::CleanupRace token 0x06000543 @0x00111604
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	public static void CleanupRace()
	{
		Instance.StopAllCoroutines();
		UnityEngine.Object[] array = U4Compat.FindObjectsOfType(typeof(SoundLibraryAddendum));
		for (int i = 0; i < array.Length; i++)
		{
			((SoundLibraryAddendum)array[i]).Dispose();
		}
		RaceSettings curSettings = DataUtility.Instance.CurSettings;
		PlayerInstance.ReleaseCart();
		RaceSettings.AICartSettings[] aICarts = curSettings.AICarts;
		foreach (RaceSettings.AICartSettings aICartSettings in aICarts)
		{
			StreamManager.ReleaseAsset(aICartSettings.assetName);
		}
	}

	// RECUPERADO-AOT RaceManager::AdvanceCarLap token 0x06000544 @0x00111758
	// Called by the lap line. Handles mission laps, Elimination (the last kart on each lap is eliminated) and
	// the finish; returns the kart's lap count (-1 unknown kart, 0 in missions).
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static int AdvanceCarLap(GameObject car)
	{
		RaceManager instance = Instance;
		CarProgress carProgress = instance.carProgressMap[car];
		if (carProgress == null)
		{
			return -1;
		}
		carProgress.lapCount++;
		if (car == instance.playerCar && DataUtility.Instance.CurSettings.raceType == RaceSettings.RaceModes.Mission)
		{
			MissionManager component = car.GetComponent<MissionManager>();
			if (component != null)
			{
				component.Signal("Finished Lap");
			}
			carProgress.finalPlace = instance.finishCounter;
			carProgress.finishTime = elapsedTime;
			return 0;
		}
		if (DataUtility.Instance.CurSettings.raceType == RaceSettings.RaceModes.Elimination && carProgress.lapCount > 1)
		{
			if (instance.elimMap == null)
			{
				instance.elimMap = new Dictionary<GameObject, int>();
				foreach (GameObject item in instance.carList)
				{
					instance.elimMap.Add(item, 0);
				}
				instance.elimMap[car] = instance.elimMap[car] + 1;
			}
			else
			{
				instance.elimMap[car] = instance.elimMap[car] + 1;
				int num = 0;
				foreach (GameObject key in instance.elimMap.Keys)
				{
					if (instance.elimMap[key] < 1 && instance.carProgressMap[key].isActive)
					{
						num++;
					}
				}
				if (num == 1)
				{
					instance.StartCoroutine(instance.EliminateCar(GetCarInPosition(GetCarPosition(car) + 1)));
				}
			}
		}
		if (instance.numLaps != -1 && carProgress.lapCount >= instance.numLaps + 1)
		{
			instance.CalculateCarPositions();
			if (carProgress.finalPlace == 0)
			{
				carProgress.finalPlace = instance.finishCounter;
				instance.finishCounter++;
				carProgress.finishTime = elapsedTime;
			}
			UnityEngine.Debug.Log(car.name + " just crossed the finish line in " + elapsedTime + " seconds at " + carProgress.finalPlace + " place.");
			if (car == instance.playerCar)
			{
				CarMetrics component2 = car.GetComponent<CarMetrics>();
				WaypointLogic waypointLogic = WaypointLogic.FindNextWaypoint(car.transform.position);
				if (waypointLogic != null && waypointLogic.backwardPoint != null)
				{
					Vector3 to = waypointLogic.transform.position - waypointLogic.backwardPoint.transform.position;
					float f = Vector3.Angle(car.transform.forward, to);
					if (Mathf.Abs(f) > 105f)
					{
						component2.Signal("Crossed Finish Line Backwards");
					}
				}
				instance.StartCoroutine(instance.PostRaceCountdown(false));
			}
		}
		if (car == Instance.playerCar && carProgress.lapCount == totalNumLaps)
		{
			Instance.RecordSnapshot();
		}
		return carProgress.lapCount;
	}

	// RECUPERADO-AOT RaceManager::EliminateCar token 0x06000545 @0x00111fcc
	// (iterator <EliminateCar>c__Iterator46 MoveNext token 0x06000978 @0x0014ffa4)
	[DebuggerHidden]
	private IEnumerator EliminateCar(GameObject car)
	{
		if (car == null)
		{
			yield break;
		}
		CarCollider collider = car.GetComponent<CarCollider>();
		if (collider != null)
		{
			collider.isCarLocked = true;
		}
		carProgressMap[car].finalPlace = allCars.Length - inactiveCars;
		if (car == GetPlayerCar())
		{
			StartCoroutine(PostRaceCountdown(true));
		}
		else
		{
			HUDLogic.Instance.DisplayNotification(car.name + Localize.Get(" eliminated!"), 1f);
		}
		yield return new WaitForSeconds(3f);
		carProgressMap[car].isActive = false;
		car.SetActive(false);
		Dictionary<GameObject, int> tempMap = new Dictionary<GameObject, int>();
		foreach (GameObject obj in elimMap.Keys)
		{
			tempMap.Add(obj, elimMap[obj] - 1);
		}
		elimMap = tempMap;
		inactiveCars++;
	}

	// RECUPERADO-AOT RaceManager::GetCarLap token 0x06000546 @0x00112024
	public static int GetCarLap(GameObject car)
	{
		CarProgress carProgress = Instance.carProgressMap[car];
		if (carProgress == null)
		{
			return -1;
		}
		return carProgress.lapCount;
	}

	// RECUPERADO-AOT RaceManager::SetCarProgressTrigger token 0x06000547 @0x00112080
	public static void SetCarProgressTrigger(GameObject car, ProgressTriggerLogic progTrigger)
	{
		CarProgress carProgress = Instance.carProgressMap[car];
		if (carProgress != null)
		{
			carProgress.lastProgressTrigger = progTrigger;
		}
	}

	// RECUPERADO-AOT RaceManager::GetCarLastProgressTrigger token 0x06000548 @0x001120dc
	public static ProgressTriggerLogic GetCarLastProgressTrigger(GameObject car)
	{
		RaceManager instance = Instance;
		if (!instance.carProgressMap.ContainsKey(car))
		{
			return null;
		}
		CarProgress carProgress = instance.carProgressMap[car];
		if (carProgress == null)
		{
			return null;
		}
		return carProgress.lastProgressTrigger;
	}

	// RECUPERADO-AOT RaceManager::GetCarPosition token 0x06000549 @0x00112160
	// 0-based place, -1 if not racing.
	public static int GetCarPosition(GameObject car)
	{
		RaceManager instance = Instance;
		for (int i = 0; i < instance.carOrderList.Length; i++)
		{
			if (car == GetCarInPosition(i))
			{
				return i;
			}
		}
		return -1;
	}

	// RECUPERADO-AOT RaceManager::GetCarInPosition token 0x0600054a @0x001121d8
	public static GameObject GetCarInPosition(int position)
	{
		RaceManager instance = Instance;
		if (position < 0 || position >= instance.carList.Count)
		{
			return null;
		}
		return instance.carList[instance.carOrderList[position]];
	}

	// RECUPERADO-AOT RaceManager::GetCarLastTrackDistance token 0x0600054b @0x00112270
	public static float GetCarLastTrackDistance(GameObject car)
	{
		RaceManager instance = Instance;
		if (!instance.carProgressMap.ContainsKey(car))
		{
			return -1f;
		}
		CarProgress carProgress = instance.carProgressMap[car];
		if (carProgress == null)
		{
			return -1f;
		}
		return carProgress.lastDistance;
	}

	// RECUPERADO-AOT RaceManager::GetOrderedCarList token 0x0600054c @0x00112328
	public static GameObject[] GetOrderedCarList()
	{
		RaceManager instance = Instance;
		GameObject[] array = new GameObject[instance.carList.Count];
		for (int i = 0; i < instance.carList.Count; i++)
		{
			array[i] = instance.carList[instance.carOrderList[i]];
		}
		return array;
	}

	// RECUPERADO-AOT RaceManager::StartMusic token 0x0600054d @0x001123f8
	// The world's race music by track name (string switch <>f__switch$map0); unknown names pass an empty string.
	private void StartMusic(string levelName)
	{
		string levelName2 = string.Empty;
		if (levelName != null)
		{
			switch (levelName)
			{
			case "Tutorial":
			case "Bus Jumper":
			case "Dirt Devils":
			case "Kick Butt!":
				levelName2 = "Kick";
				break;
			case "Danville River":
			case "Danville Arena":
			case "Doof's Tower":
				levelName2 = "Phineas";
				break;
			case "Freshwater High":
			case "Fishtankia":
			case "Hokey Poke":
				levelName2 = "Fish";
				break;
			}
		}
		if ((bool)MusicPlayer.Instance)
		{
			MusicPlayer.Instance.PlayMusic(levelName2);
		}
	}

	// RECUPERADO-AOT RaceManager::InitRace token 0x0600054e @0x001126a4
	// lapNum > -1 means "restart from a recorded lap" (rewind).
	public static void InitRace(int lapNum)
	{
		bool flag = false;
		RaceManager instance = Instance;
		if (lapNum > -1)
		{
			flag = true;
		}
		instance.Init(flag);
		if (flag)
		{
			instance.StartCoroutine(StartRaceRewind(lapNum));
		}
	}

	// RECUPERADO-AOT RaceManager::StartRaceRewind token 0x0600054f @0x0011272c
	// (iterator <StartRaceRewind>c__Iterator47 MoveNext token 0x0600097e @0x0015054c)
	[DebuggerHidden]
	public static IEnumerator StartRaceRewind(int lapNum)
	{
		yield return new WaitForEndOfFrame();
		yield return 0;
		Instance.RaceRewind(lapNum);
	}

	// RECUPERADO-AOT RaceManager::PauseRace token 0x06000550 @0x00112778
	// Pausing shifts the race clock by the paused time and stops particle emission.
	// ADAPTADO-U6: the legacy ParticleEmitters were converted to ParticleSystems in Stage 0; their emission is
	//     switched instead of ParticleEmitter.enabled (FindObjectsOfType -> U4Compat).
	public static void PauseRace(bool state)
	{
		if (isPaused == state)
		{
			return;
		}
		RaceManager instance = Instance;
		if (state)
		{
			instance.pauseStart = DateTime.Now;
		}
		else
		{
			TimeSpan timeSpan = DateTime.Now - instance.pauseStart;
			instance.raceStart += timeSpan;
		}
		instance.isPausedState = state;
		UnityEngine.Object[] array = U4Compat.FindObjectsOfType(typeof(ParticleSystem));
		for (int i = 0; i < array.Length; i++)
		{
			ParticleSystem.EmissionModule emission = ((ParticleSystem)array[i]).emission;
			emission.enabled = !state;
		}
	}

	// RECUPERADO-AOT RaceManager::GetPlayerCar token 0x06000551 @0x001129cc
	public static GameObject GetPlayerCar()
	{
		return Instance.playerCar;
	}

	// RECUPERADO-AOT RaceManager::IsPlayerCar token 0x06000552 @0x001129f8
	public static bool IsPlayerCar(GameObject obj)
	{
		return obj == Instance.playerCar;
	}

	// RECUPERADO-AOT RaceManager::RecordSnapshot token 0x06000553 @0x00112a34
	// Taken when the player starts the last lap: position, progress, effects, powerups, metrics, AI path and
	// money of every kart, so the results screen can offer to rewind that lap (RaceRewind).
	public void RecordSnapshot()
	{
		UnityEngine.Debug.Log("Recording Snapshot");
		DataUtility.Instance.CleanupAllSnapShots();
		SnapShotInfo snapShotInfo = new SnapShotInfo();
		foreach (GameObject car in carList)
		{
			CarSnapShot carSnapShot = new CarSnapShot();
			carSnapShot.position = car.transform.position;
			carSnapShot.rotation = car.transform.rotation;
			carSnapShot.name = car.name;
			carSnapShot.prog = carProgressMap[car].GetProgressCopy();
			EffectManager component = car.GetComponent<EffectManager>();
			PowerupHolder component2 = car.GetComponent<PowerupHolder>();
			CarMetrics carMetrics = null;
			GimpedCarAI component3 = car.GetComponent<GimpedCarAI>();
			int playerMoney = -1;
			if (IsPlayerCar(car))
			{
				carMetrics = car.GetComponent<CarMetrics>();
				playerMoney = DataUtility.Instance.cloudData.playerMoney;
			}
			else if (component3 != null)
			{
				component3.GetGimpedSnapShot(out carSnapShot.gimpedPathIndex, out carSnapShot.gimpedPointIndex);
			}
			if (component != null)
			{
				for (int i = 0; i < component.GetEffectCount(typeof(BaseEffect)); i++)
				{
					carSnapShot.AddToEffectList(component.GetEffect(i).GetEffectSnapShot());
				}
			}
			if (component2 != null)
			{
				for (int j = 0; j < component2.numEffects; j++)
				{
					carSnapShot.AddEffectToPowerUpholder(component2[j].GetEffectSnapShot());
				}
			}
			if (carMetrics != null)
			{
				CarMetrics.CleanupCopiedMetrics();
				carSnapShot.metrics = carMetrics.CopyMetrics();
				carSnapShot.metrics.enabled = false;
			}
			if (playerMoney > -1)
			{
				carSnapShot.playerMoney = playerMoney;
			}
			snapShotInfo.AddCarSnap(carSnapShot);
		}
		if (rewindRaceTime > 0f)
		{
			snapShotInfo.raceTime = rewindRaceTime;
		}
		else
		{
			snapShotInfo.raceTime = elapsedTime;
		}
		UnityEngine.Debug.Log("SnapShot Race Time: " + snapShotInfo.raceTime);
		DataUtility.Instance.AddSnapshot(snapShotInfo);
	}

	// RECUPERADO-AOT RaceManager::GetCarIsActive token 0x06000554 @0x00113000
	public bool GetCarIsActive(GameObject car)
	{
		if (carProgressMap == null || !carProgressMap.ContainsKey(car))
		{
			return false;
		}
		CarProgress carProgress = carProgressMap[car];
		if (carProgress == null)
		{
			return false;
		}
		return carProgress.isActive;
	}

	// RECUPERADO-AOT RaceManager::RaceRewind token 0x06000555 @0x0011308c
	// Runs in the reloaded race scene (StartRaceRewind): takes the rewind time and coins from the previous
	// RaceResults, then puts every kart back where RecordSnapshot left it at the start of the last lap.
	public void RaceRewind(int lapNum)
	{
		RaceResults raceResults = U4Compat.FindObjectOfType(typeof(RaceResults)) as RaceResults;
		if (raceResults != null)
		{
			rewindRaceTime = raceResults.raceRewindTime;
			rewindCoinsToSpawn = raceResults.rewindCoinsToSpawn;
			UnityEngine.Object.Destroy(raceResults.gameObject);
		}
		if (rewindCoinsToSpawn > 0)
		{
			SpawnCoins(rewindCoinsToSpawn);
		}
		SnapShotInfo snapshot = DataUtility.Instance.GetSnapshot(lapNum);
		snapshot.DebugDump();
		foreach (GameObject car in carList)
		{
			for (int i = 0; i < snapshot.carSnaps.Count; i++)
			{
				CarSnapShot carSnapShot = snapshot.carSnaps[i];
				if (!(carSnapShot.name == car.name))
				{
					continue;
				}
				car.transform.position = carSnapShot.position;
				car.transform.rotation = carSnapShot.rotation;
				CarCollider component = car.GetComponent<CarCollider>();
				if (component != null && component.isInAir)
				{
					component.DoResetCarOnTrack(false);
				}
				carProgressMap[car] = carSnapShot.prog;
				car.SetActive(carProgressMap[car].isActive);
				if (car == playerCar)
				{
					carProgressMap[car].lapCount--;
				}
				EffectManager component2 = car.GetComponent<EffectManager>();
				if ((bool)component2)
				{
					for (int j = 0; j < carSnapShot.effectList.Count; j++)
					{
						component2.AddEffect(carSnapShot.effectList[j]);
					}
				}
				PowerupHolder component3 = car.GetComponent<PowerupHolder>();
				if ((bool)component3)
				{
					for (int k = 0; k < carSnapShot.powerupHolder.Count; k++)
					{
						component3.AddEffect(BaseEffect.GetEffectInstance(carSnapShot.powerupHolder[k].effectType, car));
					}
				}
				if (car.GetComponent<CarMetrics>() != null)
				{
					carSnapShot.metrics.CloneToObject(car);
				}
				GimpedCarAI component4 = car.GetComponent<GimpedCarAI>();
				if (component4 != null)
				{
					if (carSnapShot.gimpedPathIndex != -1 && carSnapShot.gimpedPointIndex != -1)
					{
						component4.SetGimpedSnapShot(carSnapShot.gimpedPathIndex, carSnapShot.gimpedPointIndex);
					}
					else
					{
						UnityEngine.Debug.LogWarning("GimpedAI indices were not saved properly");
					}
				}
				else
				{
					UnityEngine.Debug.Log("No GimpedCarAI!!!");
				}
				snapshot.carSnaps.Remove(snapshot.carSnaps[i]);
				// Karts that had already finished before the snapshot finish again.
				if (carProgressMap[car].finalPlace != 0)
				{
					AdvanceCarLap(car);
					finishCounter++;
				}
				break;
			}
		}
		RaceManager raceManager = U4Compat.FindObjectOfType(typeof(RaceManager)) as RaceManager;
		if (raceManager != null)
		{
			rewindRaceTime = snapshot.raceTime;
		}
	}
}
