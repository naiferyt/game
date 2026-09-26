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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator BlinkWarningCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
