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
	}

	private void Update()
	{
	}

	public void Signal(string signal, float value)
	{
	}

	public void Signal(string signal)
	{
	}

	public CarMetrics CloneToObject(GameObject go)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public CarMetrics CopyMetrics()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void DebugDump()
	{
	}

	public static void CleanupCopiedMetrics()
	{
	}
}
