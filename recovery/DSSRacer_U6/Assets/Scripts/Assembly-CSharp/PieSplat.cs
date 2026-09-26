using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PieSplat : MonoBehaviour
{
	public Transform innerSplat;

	public Transform outerSplat;

	public float splatDuration;

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("PieSplat.Start");
		yield break;
	}
}
