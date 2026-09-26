public class PausePublisher : UghPublisher
{
	private void Start()
	{
		RecoveryPending.Hit("PausePublisher.Start");
	}

	private void PressedResumeButton()
	{
		RecoveryPending.Hit("PausePublisher.PressedResumeButton");
	}

	private void PressedQuitButton()
	{
		RecoveryPending.Hit("PausePublisher.PressedQuitButton");
	}

	private void PressedRestartButton()
	{
		RecoveryPending.Hit("PausePublisher.PressedRestartButton");
	}

	public void SetupMissionText()
	{
		RecoveryPending.Hit("PausePublisher.SetupMissionText");
	}

	private void OnDestroy()
	{
		RecoveryPending.Hit("PausePublisher.OnDestroy");
	}
}
