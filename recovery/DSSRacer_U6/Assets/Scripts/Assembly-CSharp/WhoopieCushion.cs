using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class WhoopieCushion : MonoBehaviour
{
	public ParticleSystem whoopieBurst;

	private void Start()
	{
		RecoveryPending.Hit("WhoopieCushion.Start");
	}

	[DebuggerHidden]
	private IEnumerator Explode()
	{
		RecoveryPending.Hit("WhoopieCushion.Explode");
		yield break;
	}

	private void OnCollisionEnter(Collision col)
	{
		RecoveryPending.Hit("WhoopieCushion.OnCollisionEnter");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("WhoopieCushion.OnTriggerEnter");
	}
}
