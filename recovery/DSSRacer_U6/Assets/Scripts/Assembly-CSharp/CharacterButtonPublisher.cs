// A character button of the character select grid: seats that character in the player's kart.
// Source listing: recovery/aot_listings/Assembly-CSharp/CharacterButtonPublisher.txt
public class CharacterButtonPublisher : UghPublisher
{
	public CartPart cartPart;

	// RECUPERADO-AOT CharacterButtonPublisher::OnPressedButton token 0x06000620 @0x00125a6c
	private void OnPressedButton()
	{
		PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot = cartPart;
		DataUtility.Instance.SetCartPart(CartSlot.Slots.character, cartPart.UIName.baseText);
		CharacterPreview.Refresh(false);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}
}
