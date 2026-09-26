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
		EASY,
		MEDIUM,
		HARD,
		NINTENDO_HARD
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool Exists
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool isPaused
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static GameObject[] allCars
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static GameObject leadCar
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static int elapsedTime
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static int totalNumLaps
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static WaypointLogic lastWaypoint
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static float totalTrackLength
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static event RaceInitHandler raceInitFinishedEvent
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	[DebuggerHidden]
	private IEnumerator RaceOutCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator CalculateCarPositionPump()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator PreraceCountdown()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public IEnumerator DoFinishLineEffect(GameObject player, bool elimination)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	public IEnumerator PostRaceCountdown(bool elimination)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void PlayRandomAnimation(GameObject car)
	{
	}

	[DebuggerHidden]
	private IEnumerator PreLaunchCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator EliminateCar(GameObject car)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static int GetCarLap(GameObject car)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void SetCarProgressTrigger(GameObject car, ProgressTriggerLogic progTrigger)
	{
	}

	public static ProgressTriggerLogic GetCarLastProgressTrigger(GameObject car)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static int GetCarPosition(GameObject car)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static GameObject GetCarInPosition(int position)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static float GetCarLastTrackDistance(GameObject car)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static GameObject[] GetOrderedCarList()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void StartMusic(string levelName)
	{
	}

	public static void InitRace(int lapNum)
	{
	}

	[DebuggerHidden]
	public static IEnumerator StartRaceRewind(int lapNum)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void PauseRace(bool state)
	{
	}

	public static GameObject GetPlayerCar()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static bool IsPlayerCar(GameObject obj)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void RecordSnapshot()
	{
	}

	public bool GetCarIsActive(GameObject car)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void RaceRewind(int lapNum)
	{
	}
}
