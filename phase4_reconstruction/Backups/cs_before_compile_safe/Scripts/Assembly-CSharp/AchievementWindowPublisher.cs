using System.Collections;
using System.Diagnostics;
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

	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void TriggerAnimIn()
	{
	}

	[DebuggerHidden]
	private IEnumerator AnimInHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public virtual void SetContent(AchievementListener listener)
	{
	}

	public void SetNextWindow(GameObject window)
	{
	}
}
