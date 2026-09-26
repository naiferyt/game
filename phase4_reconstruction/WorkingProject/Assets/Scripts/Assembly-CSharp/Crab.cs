using System.Collections;
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

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator SleepRoutine(float time)
	{
		return default(IEnumerator);
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
