using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class AchievementWindowPublisher : UghPublisher
{
	private bool animatingOut;

	private GameObject nextWindow;

	private new void Awake()
	{
		RecoveryPending.Hit("AchievementWindowPublisher.Awake");
	}

	private void PressedWindow()
	{
		RecoveryPending.Hit("AchievementWindowPublisher.PressedWindow");
	}

	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		RecoveryPending.Hit("AchievementWindowPublisher.DestroyThis");
		yield break;
	}

	public void TriggerAnimIn()
	{
		RecoveryPending.Hit("AchievementWindowPublisher.TriggerAnimIn");
	}

	[DebuggerHidden]
	private IEnumerator AnimInHelper()
	{
		RecoveryPending.Hit("AchievementWindowPublisher.AnimInHelper");
		yield break;
	}

	public virtual void SetContent(AchievementListener listener)
	{
		RecoveryPending.Hit("AchievementWindowPublisher.SetContent");
	}

	public void SetNextWindow(GameObject window)
	{
		RecoveryPending.Hit("AchievementWindowPublisher.SetNextWindow");
	}
}
