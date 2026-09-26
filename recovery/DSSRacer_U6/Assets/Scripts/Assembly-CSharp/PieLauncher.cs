using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PieLauncher : MonoBehaviour
{
	public PieAttack piePrefab;

	public Transform shotStart;

	public Transform shotEnd;

	public float rateOfFire;

	public float durationOfFlight;

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("PieLauncher.Start");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator ShootPieCoroutine()
	{
		RecoveryPending.Hit("PieLauncher.ShootPieCoroutine");
		yield break;
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("PieLauncher.OnDrawGizmos");
	}
}
