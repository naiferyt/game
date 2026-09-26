using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class InputBlocker : MonoBehaviour
{
	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("InputBlocker.Start");
		yield break;
	}

	public void FadeOut()
	{
		RecoveryPending.Hit("InputBlocker.FadeOut");
	}

	[DebuggerHidden]
	private IEnumerator FadeOutHelper()
	{
		RecoveryPending.Hit("InputBlocker.FadeOutHelper");
		yield break;
	}
}
