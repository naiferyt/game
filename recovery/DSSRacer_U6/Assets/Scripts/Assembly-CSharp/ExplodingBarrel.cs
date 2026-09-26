using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
	public float lifeTime;

	public bool stationary;

	private Vector3 velocityForPause;

	private bool paused;

	[DebuggerHidden]
	private IEnumerator LifeCountdown()
	{
		RecoveryPending.Hit("ExplodingBarrel.LifeCountdown");
		yield break;
	}

	private void Update()
	{
		RecoveryPending.Hit("ExplodingBarrel.Update");
	}

	[DebuggerHidden]
	private IEnumerator Explode()
	{
		RecoveryPending.Hit("ExplodingBarrel.Explode");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("ExplodingBarrel.Start");
	}

	private void OnCollisionEnter(Collision col)
	{
		RecoveryPending.Hit("ExplodingBarrel.OnCollisionEnter");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("ExplodingBarrel.OnTriggerEnter");
	}
}
