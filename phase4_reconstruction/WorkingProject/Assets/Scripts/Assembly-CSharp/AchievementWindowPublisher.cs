using System.Collections;
using UnityEngine;

public class AchievementWindowPublisher : UghPublisher
{
	private bool animatingOut;

	private GameObject nextWindow;

	private new void Awake()
	{
	}

	private void PressedWindow()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		return default(IEnumerator);
	}

	public void TriggerAnimIn()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimInHelper()
	{
		return default(IEnumerator);
	}

	public virtual void SetContent(AchievementListener listener)
	{
	}

	public void SetNextWindow(GameObject window)
	{
	}
}
