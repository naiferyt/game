using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PreFrontEndHoop : MonoBehaviour
{
	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("PreFrontEndHoop.Start");
		yield break;
	}
}
