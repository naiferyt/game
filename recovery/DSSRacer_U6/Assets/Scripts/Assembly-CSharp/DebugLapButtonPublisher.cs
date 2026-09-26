public class DebugLapButtonPublisher : UghPublisher
{
	private void Start()
	{
		RecoveryPending.Hit("DebugLapButtonPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("DebugLapButtonPublisher.Update");
	}

	private void OnButtonPressed()
	{
		RecoveryPending.Hit("DebugLapButtonPublisher.OnButtonPressed");
	}
}
