using UnityEngine;
using UnityEngine.SceneManagement;

// First scene of the build: shows the logo while the save data loads, then opens the garage (FrontEndTest).
// Source listing: recovery/aot_listings/Assembly-CSharp/CloudStrap.txt
public class CloudStrap : MonoBehaviour
{
	// RECUPERADO-AOT CloudStrap.ContinueToFrontEnd token 0x0600063e @0x00128d50
	private void ContinueToFrontEnd()
	{
		// ELIMINADO (servicio iOS): GravCloudPrefs.cloudLoadComplete -= ContinueToFrontEnd (callback de iCloud).
		// ADAPTADO-U6: Application.LoadLevel("FrontEndTest") -> SceneManager.LoadScene
		SceneManager.LoadScene("FrontEndTest");
	}

	// RECUPERADO-AOT CloudStrap.Start token 0x0600063f @0x00128e64
	private void Start()
	{
		Screen.orientation = ScreenOrientation.AutoRotation;
		// ELIMINADO (servicio iOS): GravCloudPrefs.cloudLoadComplete += ContinueToFrontEnd; GravCloudPrefs.Load()
		// pedía las preferencias a iCloud y continuaba al recibirlas. El guardado es local (DataUtility.Load, que
		// FrontEndLogic.Start ya llama), así que se continúa directamente.
		ContinueToFrontEnd();
	}
}
