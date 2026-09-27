using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Track hazard: every rateOfFire seconds throws a pie along an arc from shotStart to shotEnd (durationOfFlight seconds).
// Source listing: recovery/aot_listings/Assembly-CSharp/PieLauncher.txt
public class PieLauncher : MonoBehaviour
{
	public PieAttack piePrefab;

	public Transform shotStart;

	public Transform shotEnd;

	// RECUPERADO-AOT PieLauncher::.ctor token 0x060004f0 @0x0010bdac (field initializers)
	public float rateOfFire = 1f;

	public float durationOfFlight = 1f;

	// RECUPERADO-AOT PieLauncher::Start token 0x060004f1 @0x0010be10
	// RECUPERADO-AOT PieLauncher/<Start>c__Iterator3B::MoveNext token 0x06000936 @0x0014d784
	[DebuggerHidden]
	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSeconds(rateOfFire);
			StartCoroutine(ShootPieCoroutine());
		}
	}

	// RECUPERADO-AOT PieLauncher::ShootPieCoroutine token 0x060004f2 @0x0010be58
	// RECUPERADO-AOT PieLauncher/<ShootPieCoroutine>c__Iterator3C::MoveNext token 0x0600093c @0x0014d990
	[DebuggerHidden]
	private IEnumerator ShootPieCoroutine()
	{
		PieAttack pieLogic = Object.Instantiate(piePrefab) as PieAttack;
		pieLogic.stationary = true;
		Transform pie = pieLogic.transform;
		pie.position = shotStart.position;
		pie.up = (shotEnd.position - shotStart.position).normalized;
		float frequency = 1f / 60f;
		for (float t = 0f; t <= durationOfFlight; t += frequency)
		{
			float delta = t / durationOfFlight;
			if (!(pie != null))
			{
				break;
			}
			pie.position = Vector3.Slerp(shotStart.position, shotEnd.position, delta);
			yield return new WaitForSeconds(frequency);
		}
		if (pieLogic != null)
		{
			pieLogic.Explode();
		}
	}

	// RECUPERADO-AOT PieLauncher::OnDrawGizmos token 0x060004f3 @0x0010bea0
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(shotStart.position, shotEnd.position);
	}
}
