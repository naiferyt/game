using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class FrontEndTutorialPublisher : UghPublisher
{
	private Transform anchor;

	private Vector3 anchorTarget;

	private UghControl[] targetControls;

	public bool anyTouchDismissesTutorialStep;

	public GameObject inputBlockerPrefab;

	[DebuggerHidden]
	private IEnumerator PulseArrowCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator FadeInCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Resize()
	{
	}

	private void RegisterControlListeners()
	{
	}

	private void UnregisterControlListeners()
	{
	}

	private void Start()
	{
	}

	[DebuggerHidden]
	private IEnumerator StartHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void OnPressedDismiss()
	{
	}

	private void OnTargetButtonPressed(UghButton btn)
	{
	}

	private void OnTargetTogglePressed(UghToggle tgl)
	{
	}

	private void OnEnabled()
	{
	}

	private void OnDisabled()
	{
	}

	public void SetText(string text)
	{
	}

	public void SetAnchorPoint(Transform newAnchor, Vector3 newAnchorOffset)
	{
	}

	public void SetTargetControls(UghControl[] ctrls)
	{
	}
}
