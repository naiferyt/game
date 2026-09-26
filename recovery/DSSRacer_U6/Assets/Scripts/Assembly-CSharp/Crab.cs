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
		RecoveryPending.Hit("Crab.SleepRoutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("Crab.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("Crab.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("Crab.FixedUpdate");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("Crab.OnTriggerEnter");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("Crab.OnDrawGizmos");
	}
}
