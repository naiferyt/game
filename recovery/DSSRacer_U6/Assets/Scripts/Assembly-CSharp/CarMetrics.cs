using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Per-kart race statistics (best / worst place, top ground speed, air time) plus free-form counters
// signalled by gameplay code ("PowerSlide Boost", "Max Crash Speed", "SmashEffect success"...).
// Source listing: recovery/aot_listings/Assembly-CSharp/CarMetrics.txt
public class CarMetrics : MonoBehaviour
{
	// RECUPERADO-AOT CarMetrics::.ctor token 0x0600050d @0x0010cff0 (field initializers)
	public int worstPlaceHeld = int.MinValue;

	public int bestPlaceHeld = int.MaxValue;

	public float maxSpeed;

	public float longestTimeInAir;

	public float totalTimeInAir;

	public Dictionary<string, float> otherMetrics = new Dictionary<string, float>();

	private CarCollider carCollider;

	private bool isPlayer;

	private float timeInAirAccumulator;

	// RECUPERADO-AOT CarMetrics::Start token 0x0600050e @0x0010d058
	private void Start()
	{
		carCollider = GetComponent<CarCollider>();
		isPlayer = RaceManager.IsPlayerCar(base.gameObject);
	}

	// RECUPERADO-AOT CarMetrics::Update token 0x0600050f @0x0010d0b0
	private void Update()
	{
		int carPosition = RaceManager.GetCarPosition(base.gameObject);
		if (carPosition > worstPlaceHeld)
		{
			worstPlaceHeld = carPosition;
		}
		if (carPosition < bestPlaceHeld)
		{
			bestPlaceHeld = carPosition;
		}
		float magnitude = carCollider.GetVelocity().magnitude;
		if (!carCollider.isInAir && maxSpeed < magnitude)
		{
			maxSpeed = magnitude;
		}
		if (carCollider.isInAir)
		{
			timeInAirAccumulator += Time.deltaTime;
			totalTimeInAir += Time.deltaTime;
			if (isPlayer)
			{
				LifetimeMetrics.Signal("Total Time In Air", Time.deltaTime);
			}
		}
		else
		{
			if (longestTimeInAir < timeInAirAccumulator)
			{
				longestTimeInAir = timeInAirAccumulator;
			}
			timeInAirAccumulator = 0f;
		}
	}

	// RECUPERADO-AOT CarMetrics::Signal token 0x06000510 @0x0010d2a0
	public void Signal(string signal, float value)
	{
		if (otherMetrics.ContainsKey(signal))
		{
			otherMetrics[signal] += value;
		}
		else
		{
			otherMetrics.Add(signal, value);
		}
	}

	// RECUPERADO-AOT CarMetrics::Signal token 0x06000511 @0x0010d384
	public void Signal(string signal)
	{
		Signal(signal, 1f);
	}

	// RECUPERADO-AOT CarMetrics::CloneToObject token 0x06000512 @0x0010d3dc
	public CarMetrics CloneToObject(GameObject go)
	{
		CarMetrics carMetrics = go.GetComponent<CarMetrics>();
		if (carMetrics == null)
		{
			carMetrics = go.AddComponent<CarMetrics>();
		}
		carMetrics.worstPlaceHeld = worstPlaceHeld;
		carMetrics.bestPlaceHeld = bestPlaceHeld;
		carMetrics.maxSpeed = maxSpeed;
		carMetrics.longestTimeInAir = longestTimeInAir;
		carMetrics.otherMetrics = new Dictionary<string, float>(otherMetrics);
		return carMetrics;
	}

	// RECUPERADO-AOT CarMetrics::CopyMetrics token 0x06000513 @0x0010d4c8
	// Snapshot on a persistent "Copied Metrics" object so the results screen can read it after the race.
	public CarMetrics CopyMetrics()
	{
		GameObject gameObject = new GameObject("Copied Metrics");
		Object.DontDestroyOnLoad(gameObject);
		CarMetrics carMetrics = gameObject.AddComponent<CarMetrics>();
		carMetrics.bestPlaceHeld = bestPlaceHeld;
		carMetrics.worstPlaceHeld = worstPlaceHeld;
		carMetrics.longestTimeInAir = longestTimeInAir;
		carMetrics.totalTimeInAir = totalTimeInAir;
		carMetrics.maxSpeed = maxSpeed;
		carMetrics.otherMetrics = new Dictionary<string, float>(otherMetrics);
		return carMetrics;
	}

	// RECUPERADO-AOT CarMetrics::DebugDump token 0x06000514 @0x0010d5cc
	public void DebugDump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("**********************************");
		stringBuilder.AppendLine("***   Car Metrics");
		stringBuilder.AppendLine("* Race Data");
		stringBuilder.AppendLine("Worst Place Held: " + worstPlaceHeld);
		stringBuilder.AppendLine("Best Place Held: " + bestPlaceHeld);
		stringBuilder.AppendLine("Max Speed: " + maxSpeed);
		stringBuilder.AppendLine("Longest Time In Air: " + longestTimeInAir);
		stringBuilder.AppendLine("* Other Data");
		foreach (KeyValuePair<string, float> otherMetric in otherMetrics)
		{
			stringBuilder.AppendLine(otherMetric.Key + ": " + otherMetric.Value);
		}
		Debug.Log(stringBuilder.ToString());
	}

	// RECUPERADO-AOT CarMetrics::CleanupCopiedMetrics token 0x06000515 @0x0010d994
	// ADAPTADO-U6: Object.FindObjectsOfType -> U4Compat.
	public static void CleanupCopiedMetrics()
	{
		Object[] array = U4Compat.FindObjectsOfType(typeof(CarMetrics));
		if (array == null)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			CarMetrics carMetrics = (CarMetrics)array[i];
			if (carMetrics.name == "Copied Metrics")
			{
				Object.Destroy(carMetrics.gameObject);
			}
		}
	}
}
