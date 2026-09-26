public class UghHeldButton : UghButton
{
	private bool isDownState;

	public bool isDown
	{
		get
		{
			RecoveryPending.Hit("UghHeldButton.get_isDown");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("UghHeldButton.set_isDown");
		}
	}

	private void SetButtonVisualState(bool state)
	{
		RecoveryPending.Hit("UghHeldButton.SetButtonVisualState");
	}

	private void Update()
	{
		RecoveryPending.Hit("UghHeldButton.Update");
	}

	public virtual void OnButtonDown()
	{
		RecoveryPending.Hit("UghHeldButton.OnButtonDown");
	}

	public virtual void OnButtonUp()
	{
		RecoveryPending.Hit("UghHeldButton.OnButtonUp");
	}

	public virtual void OnButtonHeld()
	{
		RecoveryPending.Hit("UghHeldButton.OnButtonHeld");
	}
}
