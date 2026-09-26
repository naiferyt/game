using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class LoadSpin : MonoBehaviour
{
	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("LoadSpin.Start");
		yield break;
	}

	public void FadeOut()
	{
		RecoveryPending.Hit("LoadSpin.FadeOut");
	}

	public void FadeOut(float fadeDuration)
	{
		RecoveryPending.Hit("LoadSpin.FadeOut");
	}

	[DebuggerHidden]
	private IEnumerator FadeHelper(float fadeDuration)
	{
		RecoveryPending.Hit("LoadSpin.FadeHelper");
		yield break;
	}
}
