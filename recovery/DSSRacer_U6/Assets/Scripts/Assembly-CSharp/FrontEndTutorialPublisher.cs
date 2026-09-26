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
		RecoveryPending.Hit("FrontEndTutorialPublisher.PulseArrowCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator FadeInCoroutine()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.FadeInCoroutine");
		yield break;
	}

	private void Resize()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.Resize");
	}

	private void RegisterControlListeners()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.RegisterControlListeners");
	}

	private void UnregisterControlListeners()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.UnregisterControlListeners");
	}

	private void Start()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.Start");
	}

	[DebuggerHidden]
	private IEnumerator StartHelper()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.StartHelper");
		yield break;
	}

	public void OnPressedDismiss()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.OnPressedDismiss");
	}

	private void OnTargetButtonPressed(UghButton btn)
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.OnTargetButtonPressed");
	}

	private void OnTargetTogglePressed(UghToggle tgl)
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.OnTargetTogglePressed");
	}

	private void OnEnabled()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.OnEnabled");
	}

	private void OnDisabled()
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.OnDisabled");
	}

	public void SetText(string text)
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.SetText");
	}

	public void SetAnchorPoint(Transform newAnchor, Vector3 newAnchorOffset)
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.SetAnchorPoint");
	}

	public void SetTargetControls(UghControl[] ctrls)
	{
		RecoveryPending.Hit("FrontEndTutorialPublisher.SetTargetControls");
	}
}
