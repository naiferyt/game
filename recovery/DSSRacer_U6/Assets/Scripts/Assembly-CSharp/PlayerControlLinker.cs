using UnityEngine;

// Adds the platform's driving control to the player's kart: tilt on iOS, keyboard elsewhere.
// Source listing: recovery/aot_listings/Assembly-CSharp/PlayerControlLinker.txt
public class PlayerControlLinker : MonoBehaviour
{
	// RECUPERADO-AOT PlayerControlLinker::Start token 0x0600045c @0x001013a8
	// ADAPTADO-U6: AddComponent(Type) -> AddComponent<T>(). (Android gets the keyboard control here, as any
	// non-iOS platform did in the original; the Android touch/tilt control is decided in the Android stage.)
	private void Start()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			base.gameObject.AddComponent<PlayerAccelControl>();
		}
		else
		{
			base.gameObject.AddComponent<PlayerKeyboardControl>();
		}
	}
}
