using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Turkey hazard: every timeBetweenGoo (+ random extra) seconds shoots emitCount puffs of goo particles.
// Source listing: recovery/aot_listings/Assembly-CSharp/TurkeyGooShooter.txt
public class TurkeyGooShooter : MonoBehaviour
{
	public ParticleSystem gooParticleSystem;

	// RECUPERADO-AOT TurkeyGooShooter::.ctor token 0x06000502 @0x0010caac (field initializers)
	public float timeBetweenGoo = 2.5f;

	public float variableTimeBetweenGoo = 2.5f;

	public int emitCount = 20;

	public int particlesPerEmit = 3;

	// RECUPERADO-AOT TurkeyGooShooter::Start token 0x06000503 @0x0010cb20
	// RECUPERADO-AOT TurkeyGooShooter/<Start>c__Iterator3D::MoveNext token 0x06000942 @0x0014de04
	[DebuggerHidden]
	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSeconds(timeBetweenGoo + Random.Range(0f, variableTimeBetweenGoo));
			for (int loop = 0; loop < emitCount; loop++)
			{
				while (RaceManager.isPaused)
				{
					yield return new WaitForEndOfFrame();
				}
				gooParticleSystem.Emit(particlesPerEmit);
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
