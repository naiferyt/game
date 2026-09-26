using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PieAttack : MonoBehaviour
{
	public float lifeTime;

	public bool stationary;

	private Vector3 velocityForPause;

	private bool paused;

	[DebuggerHidden]
	private IEnumerator LifeCountdown()
	{
		RecoveryPending.Hit("PieAttack.LifeCountdown");
		yield break;
	}

	private void Update()
	{
		RecoveryPending.Hit("PieAttack.Update");
	}

	public void Explode()
	{
		RecoveryPending.Hit("PieAttack.Explode");
	}

	[DebuggerHidden]
	private IEnumerator ExplodeCoroutine()
	{
		RecoveryPending.Hit("PieAttack.ExplodeCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("PieAttack.Start");
	}

	private void OnCollisionEnter(Collision col)
	{
		RecoveryPending.Hit("PieAttack.OnCollisionEnter");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("PieAttack.OnTriggerEnter");
	}
}
