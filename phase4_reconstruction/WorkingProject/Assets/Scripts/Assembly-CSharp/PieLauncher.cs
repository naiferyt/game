using System.Collections;
using UnityEngine;

public class PieLauncher : MonoBehaviour
{
	public PieAttack piePrefab;

	public Transform shotStart;

	public Transform shotEnd;

	public float rateOfFire;

	public float durationOfFlight;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Start()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ShootPieCoroutine()
	{
		return default(IEnumerator);
	}

	private void OnDrawGizmos()
	{
	}
}
