using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TurkeyGooShooter : MonoBehaviour
{
	public ParticleSystem gooParticleSystem;

	public float timeBetweenGoo;

	public float variableTimeBetweenGoo;

	public int emitCount;

	public int particlesPerEmit;

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("TurkeyGooShooter.Start");
		yield break;
	}
}
