public class ReverseButton : UghHeldButton
{
	private void ApplyReverse(bool state)
	{
		RecoveryPending.Hit("ReverseButton.ApplyReverse");
	}

	public override void OnButtonDown()
	{
		RecoveryPending.Hit("ReverseButton.OnButtonDown");
	}

	public override void OnButtonUp()
	{
		RecoveryPending.Hit("ReverseButton.OnButtonUp");
	}

	public override void OnButtonHeld()
	{
		RecoveryPending.Hit("ReverseButton.OnButtonHeld");
	}
}
