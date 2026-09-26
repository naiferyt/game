using System.Collections;
using UnityEngine;

public class TurkeyGooShooter : MonoBehaviour
{
	public ParticleSystem gooParticleSystem;

	public float timeBetweenGoo;

	public float variableTimeBetweenGoo;

	public int emitCount;

	public int particlesPerEmit;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Start()
	{
		return default(IEnumerator);
	}
}
