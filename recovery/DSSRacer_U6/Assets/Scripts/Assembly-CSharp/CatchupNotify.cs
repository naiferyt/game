using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class CatchupNotify : MonoBehaviour
{
	[DebuggerHidden]
	private IEnumerator DeathCount()
	{
		RecoveryPending.Hit("CatchupNotify.DeathCount");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("CatchupNotify.Start");
	}
}
