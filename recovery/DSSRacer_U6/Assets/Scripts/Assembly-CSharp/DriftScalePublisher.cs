using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class DriftScalePublisher : UghPublisher
{
	private CarCollider carCollider;

	private Transform fill;

	private Transform full;

	private Transform wipeout;

	private float fillMaxScale;

	private float wipeoutMaxScale;

	private bool blinkingWarning;

	[DebuggerHidden]
	private IEnumerator BlinkLabelCoroutine()
	{
		RecoveryPending.Hit("DriftScalePublisher.BlinkLabelCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator BlinkWarningCoroutine()
	{
		RecoveryPending.Hit("DriftScalePublisher.BlinkWarningCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("DriftScalePublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("DriftScalePublisher.Update");
	}
}
