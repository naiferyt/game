using UnityEngine;

public class DebugRaceResultPublisher : UghPublisher
{
	public GameObject rewindLapDialogTemplate;

	private void Start()
	{
		RecoveryPending.Hit("DebugRaceResultPublisher.Start");
	}

	private void PressedDoneButton()
	{
		RecoveryPending.Hit("DebugRaceResultPublisher.PressedDoneButton");
	}

	private void PressedRewindButton()
	{
		RecoveryPending.Hit("DebugRaceResultPublisher.PressedRewindButton");
	}
}
