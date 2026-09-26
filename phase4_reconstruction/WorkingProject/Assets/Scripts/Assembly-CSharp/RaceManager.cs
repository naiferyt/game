using System;
using System.Collections;
using System.Collections.Generic;
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
		get
		{
			return default(RaceManager);
		}
	}

	public static bool Exists
	{
		get
		{
			return default(bool);
		}
	}

	public static bool isPaused
	{
		get
		{
			return default(bool);
		}
	}

	public static GameObject[] allCars
	{
		get
		{
			return default(GameObject[]);
		}
	}

	public static GameObject leadCar
	{
		get
		{
			return default(GameObject);
		}
	}

	public static int elapsedTime
	{
		get
		{
			return default(int);
		}
	}

	public static int totalNumLaps
	{
		get
		{
			return default(int);
		}
	}

	public static WaypointLogic lastWaypoint
	{
		get
		{
			return default(WaypointLogic);
		}
	}

	public static float totalTrackLength
	{
		get
		{
			return default(float);
		}
	}

	public static event RaceInitHandler raceInitFinishedEvent
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator RaceOutCoroutine()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CalculateCarPositionPump()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator PreraceCountdown()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator DoFinishLineEffect(GameObject player, bool elimination)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator PostRaceCountdown(bool elimination)
	{
		return default(IEnumerator);
	}

	private void PlayRandomAnimation(GameObject car)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator PreLaunchCoroutine()
	{
		return default(IEnumerator);
	}

	private void CalculateCarPositions()
	{
	}

	private void SpawnCoins()
	{
	}

	private void SpawnCoins(int numToSpawn)
	{
	}

	private void Init(bool rewind)
	{
	}

	private void PlayAmbientNoise()
	{
	}

	public void EndRace()
	{
	}

	public static void CleanupRace()
	{
	}

	public static int AdvanceCarLap(GameObject car)
	{
		return default(int);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator EliminateCar(GameObject car)
	{
		return default(IEnumerator);
	}

	public static int GetCarLap(GameObject car)
	{
		return default(int);
	}

	public static void SetCarProgressTrigger(GameObject car, ProgressTriggerLogic progTrigger)
	{
	}

	public static ProgressTriggerLogic GetCarLastProgressTrigger(GameObject car)
	{
		return default(ProgressTriggerLogic);
	}

	public static int GetCarPosition(GameObject car)
	{
		return default(int);
	}

	public static GameObject GetCarInPosition(int position)
	{
		return default(GameObject);
	}

	public static float GetCarLastTrackDistance(GameObject car)
	{
		return default(float);
	}

	public static GameObject[] GetOrderedCarList()
	{
		return default(GameObject[]);
	}

	private void StartMusic(string levelName)
	{
	}

	public static void InitRace(int lapNum)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	public static IEnumerator StartRaceRewind(int lapNum)
	{
		return default(IEnumerator);
	}

	public static void PauseRace(bool state)
	{
	}

	public static GameObject GetPlayerCar()
	{
		return default(GameObject);
	}

	public static bool IsPlayerCar(GameObject obj)
	{
		return default(bool);
	}

	public void RecordSnapshot()
	{
	}

	public bool GetCarIsActive(GameObject car)
	{
		return default(bool);
	}

	public void RaceRewind(int lapNum)
	{
	}
}
