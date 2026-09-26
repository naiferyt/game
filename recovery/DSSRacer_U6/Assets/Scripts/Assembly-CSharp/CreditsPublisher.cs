// Credits screen: back to Settings (the external Disney links are removed).
// Source listing: recovery/aot_listings/Assembly-CSharp/CreditsPublisher.txt
public class CreditsPublisher : UghPublisher
{
	// RECUPERADO-AOT CreditsPublisher::Start token 0x06000648 @0x00129174 (empty in the original)
	// ELIMINADO (servicio externo, RECOVERY_REPORT.md 11.2): the four Application.OpenURL link buttons
	// ("Customer Suppoer", "Privacy", "Terms of Use", "Web Link") are hidden.
	private void Start()
	{
		base.ughButtons["Customer Suppoer"].gameObject.SetActive(false);
		base.ughButtons["Privacy"].gameObject.SetActive(false);
		base.ughButtons["Terms of Use"].gameObject.SetActive(false);
		base.ughButtons["Web Link"].gameObject.SetActive(false);
	}

	// RECUPERADO-AOT CreditsPublisher::Update token 0x06000649 @0x001291a0 (empty in the original)
	private void Update()
	{
	}

	// RECUPERADO-AOT CreditsPublisher::PressedBackButton token 0x0600064a @0x001291cc
	public void PressedBackButton()
	{
		FrontEndLogic.RequestMenuChange("Settings");
	}

	// RECUPERADO-AOT CreditsPublisher::PressedCustomerSupport token 0x0600064b @0x0012920c
	// ELIMINADO (servicio externo): Application.OpenURL(Localize.Get("http://disneyinteractivestudios.custhelp.com")).
	private void PressedCustomerSupport()
	{
	}

	// RECUPERADO-AOT CreditsPublisher::PressedPrivacyButton token 0x0600064c @0x00129250
	// ELIMINADO (servicio externo): Application.OpenURL(Localize.Get("http://corporate.disney.go.com/corporate/pp.html")).
	private void PressedPrivacyButton()
	{
	}

	// RECUPERADO-AOT CreditsPublisher::PressedTermsOfUseButton token 0x0600064d @0x00129294
	// ELIMINADO (servicio externo): Application.OpenURL(Localize.Get("http://corporate.disney.go.com/corporate/terms-appapp.html")).
	private void PressedTermsOfUseButton()
	{
	}

	// RECUPERADO-AOT CreditsPublisher::PressedLinkButton token 0x0600064e @0x001292d8
	// ELIMINADO (servicio externo): Application.OpenURL(Localize.Get("http://disney.com")).
	private void PressedLinkButton()
	{
	}
}
