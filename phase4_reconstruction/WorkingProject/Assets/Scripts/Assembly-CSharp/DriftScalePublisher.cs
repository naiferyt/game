using System.Collections;
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

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator BlinkLabelCoroutine()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator BlinkWarningCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
