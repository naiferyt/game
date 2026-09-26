using System.Collections;
using UnityEngine;

public class FrontEndTutorialPublisher : UghPublisher
{
	private Transform anchor;

	private Vector3 anchorTarget;

	private UghControl[] targetControls;

	public bool anyTouchDismissesTutorialStep;

	public GameObject inputBlockerPrefab;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator PulseArrowCoroutine()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator FadeInCoroutine()
	{
		return default(IEnumerator);
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

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator StartHelper()
	{
		return default(IEnumerator);
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
