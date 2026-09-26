using System.Collections.Generic;
using UnityEngine;

public class CarMetrics : MonoBehaviour
{
	public int worstPlaceHeld;

	public int bestPlaceHeld;

	public float maxSpeed;

	public float longestTimeInAir;

	public float totalTimeInAir;

	public Dictionary<string, float> otherMetrics;

	private CarCollider carCollider;

	private bool isPlayer;

	private float timeInAirAccumulator;

	private void Start()
	{
		RecoveryPending.Hit("CarMetrics.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("CarMetrics.Update");
	}

	public void Signal(string signal, float value)
	{
		RecoveryPending.Hit("CarMetrics.Signal");
	}

	public void Signal(string signal)
	{
		RecoveryPending.Hit("CarMetrics.Signal");
	}

	public CarMetrics CloneToObject(GameObject go)
	{
		RecoveryPending.Hit("CarMetrics.CloneToObject");
		return default(CarMetrics);
	}

	public CarMetrics CopyMetrics()
	{
		RecoveryPending.Hit("CarMetrics.CopyMetrics");
		return default(CarMetrics);
	}

	public void DebugDump()
	{
		RecoveryPending.Hit("CarMetrics.DebugDump");
	}

	public static void CleanupCopiedMetrics()
	{
		RecoveryPending.Hit("CarMetrics.CleanupCopiedMetrics");
	}
}
