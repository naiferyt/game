using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PlayMenuPublisher : UghPublisher
{
	public GameObject settings;

	private void Update()
	{
		RecoveryPending.Hit("PlayMenuPublisher.Update");
	}

	private void Start()
	{
		RecoveryPending.Hit("PlayMenuPublisher.Start");
	}

	private void PressedPlayButton()
	{
		RecoveryPending.Hit("PlayMenuPublisher.PressedPlayButton");
	}

	private void PressedMoreDisney()
	{
		RecoveryPending.Hit("PlayMenuPublisher.PressedMoreDisney");
	}

	private void PressedSettings()
	{
		RecoveryPending.Hit("PlayMenuPublisher.PressedSettings");
	}

	private void PressedInfo()
	{
		RecoveryPending.Hit("PlayMenuPublisher.PressedInfo");
	}

	private void StartTutorial()
	{
		RecoveryPending.Hit("PlayMenuPublisher.StartTutorial");
	}

	[DebuggerHidden]
	private IEnumerator StartTutLoad()
	{
		RecoveryPending.Hit("PlayMenuPublisher.StartTutLoad");
		yield break;
	}
}
