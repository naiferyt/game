using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	private void Start()
	{
		RecoveryPending.Hit("Explosion.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("Explosion.Update");
	}

	[DebuggerHidden]
	private IEnumerator ExplosionDeath()
	{
		RecoveryPending.Hit("Explosion.ExplosionDeath");
		yield break;
	}
}
