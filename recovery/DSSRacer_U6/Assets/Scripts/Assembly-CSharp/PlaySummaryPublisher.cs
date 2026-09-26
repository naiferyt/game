using System.Collections.Generic;
using UnityEngine;

public class PlaySummaryPublisher : UghPublisher
{
	public GameObject popoverPrefab;

	private float transitionTimer;

	private float transitionSpeed;

	public List<TrackSelectPublisher.TrackIcon> trackIcons;

	private void Refresh()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.Refresh");
	}

	private void Start()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.FixedUpdate");
	}

	private void PressedPlayButton()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.PressedPlayButton");
	}

	private void PressedModeArrowLeft()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.PressedModeArrowLeft");
	}

	private void PressedModeArrowRight()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.PressedModeArrowRight");
	}

	private void PressedDifficultyArrowLeft()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.PressedDifficultyArrowLeft");
	}

	private void PressedDifficultyArrowRight()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.PressedDifficultyArrowRight");
	}

	private bool TestForUltraHard()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.TestForUltraHard");
		return default(bool);
	}

	private void PressedBackButton()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.PressedBackButton");
	}

	private void UpdateTrackIcon()
	{
		RecoveryPending.Hit("PlaySummaryPublisher.UpdateTrackIcon");
	}
}
