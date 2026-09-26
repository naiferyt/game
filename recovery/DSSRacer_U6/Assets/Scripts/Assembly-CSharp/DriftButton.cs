public class DriftButton : UghHeldButton
{
	private void ApplyDrift(bool state)
	{
		RecoveryPending.Hit("DriftButton.ApplyDrift");
	}

	public override void OnButtonDown()
	{
		RecoveryPending.Hit("DriftButton.OnButtonDown");
	}

	public override void OnButtonUp()
	{
		RecoveryPending.Hit("DriftButton.OnButtonUp");
	}

	public override void OnButtonHeld()
	{
		RecoveryPending.Hit("DriftButton.OnButtonHeld");
	}
}
