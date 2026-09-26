public class CharacterButtonPublisher : UghPublisher
{
	public CartPart cartPart;

	private void OnPressedButton()
	{
		RecoveryPending.Hit("CharacterButtonPublisher.OnPressedButton");
	}
}
