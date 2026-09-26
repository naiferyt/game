public class DebugRewindDialogPublisher : UghPublisher
{
	public UghPublisher lapbuttonPrefab;

	private UghPublisher[] lapButtons;

	private void Start()
	{
		RecoveryPending.Hit("DebugRewindDialogPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("DebugRewindDialogPublisher.Update");
	}

	public static void OnRewindPressed(int lapNum)
	{
		RecoveryPending.Hit("DebugRewindDialogPublisher.OnRewindPressed");
	}

	public void OnCancelPressed()
	{
		RecoveryPending.Hit("DebugRewindDialogPublisher.OnCancelPressed");
	}
}
