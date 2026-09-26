using UnityEngine;

// On-screen reverse button: forwards its held state to the player's kart ("ApplyReverse" message).
// Source listing: recovery/aot_listings/Assembly-CSharp/ReverseButton.txt
public class ReverseButton : UghHeldButton
{
	// RECUPERADO-AOT ReverseButton::ApplyReverse token 0x0600077e @0x0013cb50
	private void ApplyReverse(bool state)
	{
		GameObject playerCar = HUDLogic.playerCar;
		if (playerCar != null)
		{
			playerCar.SendMessage("ApplyReverse", state);
		}
	}

	// RECUPERADO-AOT ReverseButton::OnButtonDown token 0x0600077f @0x0013cbdc
	public override void OnButtonDown()
	{
		ApplyReverse(true);
	}

	// RECUPERADO-AOT ReverseButton::OnButtonUp token 0x06000780 @0x0013cc14
	public override void OnButtonUp()
	{
		ApplyReverse(false);
	}

	// RECUPERADO-AOT ReverseButton::OnButtonHeld token 0x06000781 @0x0013cc4c
	public override void OnButtonHeld()
	{
		ApplyReverse(true);
	}
}
