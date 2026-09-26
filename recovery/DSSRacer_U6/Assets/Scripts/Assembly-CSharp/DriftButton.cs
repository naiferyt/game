using UnityEngine;

// On-screen drift button: forwards its held state to the player's kart ("ApplyDrift" message).
// Source listing: recovery/aot_listings/Assembly-CSharp/DriftButton.txt
public class DriftButton : UghHeldButton
{
	// RECUPERADO-AOT DriftButton::ApplyDrift token 0x06000749 @0x00139230
	private void ApplyDrift(bool state)
	{
		GameObject playerCar = HUDLogic.playerCar;
		if (playerCar != null)
		{
			playerCar.SendMessage("ApplyDrift", state);
		}
	}

	// RECUPERADO-AOT DriftButton::OnButtonDown token 0x0600074a @0x001392bc
	public override void OnButtonDown()
	{
		ApplyDrift(true);
	}

	// RECUPERADO-AOT DriftButton::OnButtonUp token 0x0600074b @0x001392f4
	public override void OnButtonUp()
	{
		ApplyDrift(false);
	}

	// RECUPERADO-AOT DriftButton::OnButtonHeld token 0x0600074c @0x0013932c
	public override void OnButtonHeld()
	{
		ApplyDrift(true);
	}
}
