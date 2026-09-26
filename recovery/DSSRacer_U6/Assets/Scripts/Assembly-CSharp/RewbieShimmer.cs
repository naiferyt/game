using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class RewbieShimmer : MonoBehaviour
{
	private int shimmerFrame;

	private float shimmerTimer;

	private void Update()
	{
		RecoveryPending.Hit("RewbieShimmer.Update");
	}

	[DebuggerHidden]
	public IEnumerator Shimmer()
	{
		RecoveryPending.Hit("RewbieShimmer.Shimmer");
		yield break;
	}
}
