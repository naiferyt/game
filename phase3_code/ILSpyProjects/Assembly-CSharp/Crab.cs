using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Crab : MonoBehaviour
{
	public float wanderRadius;

	public float wanderRate;

	public float wanderMaxSpeed;

	public float wanderAccel;

	private Vector3 homePoint;

	private Vector3 wanderPoint;

	private float wanderTimer;

	private float linearVelocity;

	[DebuggerHidden]
	private IEnumerator SleepRoutine(float time)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnDrawGizmos()
	{
	}
}
