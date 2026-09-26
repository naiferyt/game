public class CreditsPublisher : UghPublisher
{
	private void Start()
	{
		RecoveryPending.Hit("CreditsPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("CreditsPublisher.Update");
	}

	public void PressedBackButton()
	{
		RecoveryPending.Hit("CreditsPublisher.PressedBackButton");
	}

	private void PressedCustomerSupport()
	{
		RecoveryPending.Hit("CreditsPublisher.PressedCustomerSupport");
	}

	private void PressedPrivacyButton()
	{
		RecoveryPending.Hit("CreditsPublisher.PressedPrivacyButton");
	}

	private void PressedTermsOfUseButton()
	{
		RecoveryPending.Hit("CreditsPublisher.PressedTermsOfUseButton");
	}

	private void PressedLinkButton()
	{
		RecoveryPending.Hit("CreditsPublisher.PressedLinkButton");
	}
}
