using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Test entry point placed in every track scene: when the scene is opened directly (no RaceSettings from the
// menu), it installs its own race settings and kart and goes through "Loading" back to this track.
// Source listing: recovery/aot_listings/Assembly-CSharp/DebugTrackStrapper.txt
public class DebugTrackStrapper : MonoBehaviour
{
	public RaceSettings debugSettings;

	public CartSlot[] cartSlots;

	// RECUPERADO-AOT DebugTrackStrapper::.ctor token 0x06000518 @0x0010dbb0 (field initializer; CartSlot ctor inlined)
	public DebugTrackStrapper()
	{
		Array values = Enum.GetValues(typeof(CartSlot.Slots));
		cartSlots = new CartSlot[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			cartSlots[i] = new CartSlot((CartSlot.Slots)(int)values.GetValue(i));
		}
	}

	// RECUPERADO-AOT DebugTrackStrapper::Start token 0x06000519 @0x0010dcbc
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat; Application.loadedLevelName -> SceneManager.GetActiveScene().name;
	//     Application.LoadLevel -> SceneManager.LoadScene.
	private void Start()
	{
		UnityEngine.Object[] array = U4Compat.FindObjectsOfType(typeof(RaceSettings));
		if (array != null && array.Length > 0)
		{
			Debug.Log("DebugTrackStrapper found another settings object--skipping debug strap.");
			return;
		}
		Debug.Log("Executing debug strap.");
		if (ScreenFader.Instance == null)
		{
			ScreenFader.CreateScreenFader();
		}
		RaceSettings curSettings = UnityEngine.Object.Instantiate(debugSettings) as RaceSettings;
		DataUtility.Instance.CurSettings = curSettings;
		DataUtility.Instance.CurSettings.lapNumber = -1;
		PlayerInstance.Instance.cartSlots = cartSlots;
		DataUtility.Instance.CurSettings.levelName.baseText = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Loading");
	}
}
