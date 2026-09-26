using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TutorialLauncherPublisher : UghPublisher
{
	public GameObject settings;

	private void Start()
	{
		RecoveryPending.Hit("TutorialLauncherPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("TutorialLauncherPublisher.Update");
	}

	private void PressedYes()
	{
		RecoveryPending.Hit("TutorialLauncherPublisher.PressedYes");
	}

	[DebuggerHidden]
	private IEnumerator StartTutLoad()
	{
		RecoveryPending.Hit("TutorialLauncherPublisher.StartTutLoad");
		yield break;
	}

	private void PressedNo()
	{
		RecoveryPending.Hit("TutorialLauncherPublisher.PressedNo");
	}
}
