using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

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

	private int finishCounter;

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
		get
		{
			RecoveryPending.Hit("RaceManager.get_allCars");
			return default(GameObject[]);
		}
	}

	public static GameObject leadCar
	{
		get
		{
			RecoveryPending.Hit("RaceManager.get_leadCar");
			return default(GameObject);
		}
	}

	public static int elapsedTime
	{
		get
		{
			RecoveryPending.Hit("RaceManager.get_elapsedTime");
			return default(int);
		}
	}

	public static int totalNumLaps
	{
		get
		{
			RecoveryPending.Hit("RaceManager.get_totalNumLaps");
			return default(int);
		}
	}

	public static WaypointLogic lastWaypoint
	{
		get
		{
			RecoveryPending.Hit("RaceManager.get_lastWaypoint");
			return default(WaypointLogic);
		}
	}

	public static float totalTrackLength
	{
		get
		{
			RecoveryPending.Hit("RaceManager.get_totalTrackLength");
			return default(float);
		}
	}

	// RECUPERADO-AOT RaceManager::add_raceInitFinishedEvent token 0x0600052b @0x0010e50c
	// RECUPERADO-AOT RaceManager::remove_raceInitFinishedEvent token 0x0600052c @0x0010e5ac
	// (compiler-generated field-like event accessors: Delegate.Combine / Delegate.Remove)
	public static event RaceInitHandler raceInitFinishedEvent;

	[DebuggerHidden]
	private IEnumerator RaceOutCoroutine()
	{
		RecoveryPending.Hit("RaceManager.RaceOutCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator CalculateCarPositionPump()
	{
		RecoveryPending.Hit("RaceManager.CalculateCarPositionPump");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator PreraceCountdown()
	{
		RecoveryPending.Hit("RaceManager.PreraceCountdown");
		yield break;
	}

	[DebuggerHidden]
	public IEnumerator DoFinishLineEffect(GameObject player, bool elimination)
	{
		RecoveryPending.Hit("RaceManager.DoFinishLineEffect");
		yield break;
	}

	[DebuggerHidden]
	public IEnumerator PostRaceCountdown(bool elimination)
	{
		RecoveryPending.Hit("RaceManager.PostRaceCountdown");
		yield break;
	}

	private void PlayRandomAnimation(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.PlayRandomAnimation");
	}

	[DebuggerHidden]
	private IEnumerator PreLaunchCoroutine()
	{
		RecoveryPending.Hit("RaceManager.PreLaunchCoroutine");
		yield break;
	}

	private void CalculateCarPositions()
	{
		RecoveryPending.Hit("RaceManager.CalculateCarPositions");
	}

	private void SpawnCoins()
	{
		RecoveryPending.Hit("RaceManager.SpawnCoins");
	}

	private void SpawnCoins(int numToSpawn)
	{
		RecoveryPending.Hit("RaceManager.SpawnCoins");
	}

	private void Init(bool rewind)
	{
		RecoveryPending.Hit("RaceManager.Init");
	}

	private void PlayAmbientNoise()
	{
		RecoveryPending.Hit("RaceManager.PlayAmbientNoise");
	}

	public void EndRace()
	{
		RecoveryPending.Hit("RaceManager.EndRace");
	}

	public static void CleanupRace()
	{
		RecoveryPending.Hit("RaceManager.CleanupRace");
	}

	public static int AdvanceCarLap(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.AdvanceCarLap");
		return default(int);
	}

	[DebuggerHidden]
	private IEnumerator EliminateCar(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.EliminateCar");
		yield break;
	}

	public static int GetCarLap(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.GetCarLap");
		return default(int);
	}

	public static void SetCarProgressTrigger(GameObject car, ProgressTriggerLogic progTrigger)
	{
		RecoveryPending.Hit("RaceManager.SetCarProgressTrigger");
	}

	public static ProgressTriggerLogic GetCarLastProgressTrigger(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.GetCarLastProgressTrigger");
		return default(ProgressTriggerLogic);
	}

	public static int GetCarPosition(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.GetCarPosition");
		return default(int);
	}

	public static GameObject GetCarInPosition(int position)
	{
		RecoveryPending.Hit("RaceManager.GetCarInPosition");
		return default(GameObject);
	}

	public static float GetCarLastTrackDistance(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.GetCarLastTrackDistance");
		return default(float);
	}

	public static GameObject[] GetOrderedCarList()
	{
		RecoveryPending.Hit("RaceManager.GetOrderedCarList");
		return default(GameObject[]);
	}

	private void StartMusic(string levelName)
	{
		RecoveryPending.Hit("RaceManager.StartMusic");
	}

	public static void InitRace(int lapNum)
	{
		RecoveryPending.Hit("RaceManager.InitRace");
	}

	[DebuggerHidden]
	public static IEnumerator StartRaceRewind(int lapNum)
	{
		RecoveryPending.Hit("RaceManager.StartRaceRewind");
		yield break;
	}

	public static void PauseRace(bool state)
	{
		RecoveryPending.Hit("RaceManager.PauseRace");
	}

	public static GameObject GetPlayerCar()
	{
		RecoveryPending.Hit("RaceManager.GetPlayerCar");
		return default(GameObject);
	}

	public static bool IsPlayerCar(GameObject obj)
	{
		RecoveryPending.Hit("RaceManager.IsPlayerCar");
		return default(bool);
	}

	public void RecordSnapshot()
	{
		RecoveryPending.Hit("RaceManager.RecordSnapshot");
	}

	public bool GetCarIsActive(GameObject car)
	{
		RecoveryPending.Hit("RaceManager.GetCarIsActive");
		return default(bool);
	}

	public void RaceRewind(int lapNum)
	{
		RecoveryPending.Hit("RaceManager.RaceRewind");
	}
}
