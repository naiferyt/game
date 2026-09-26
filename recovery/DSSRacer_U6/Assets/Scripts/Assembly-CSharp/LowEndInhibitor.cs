using UnityEngine;

// Destroyed objects on slow iPhones (by iPhone.generation), then removes itself.
// Source listing: recovery/aot_listings/Assembly-CSharp/LowEndInhibitor.txt
public class LowEndInhibitor : MonoBehaviour
{
	// RECUPERADO-AOT LowEndInhibitor::.ctor token 0x0600043c @0x000ffc80 (field initializer: generations 7, 3, 6)
	public UnityEngine.iOS.DeviceGeneration[] inhibitPlatforms = new UnityEngine.iOS.DeviceGeneration[3]
	{
		(UnityEngine.iOS.DeviceGeneration)7,
		(UnityEngine.iOS.DeviceGeneration)3,
		(UnityEngine.iOS.DeviceGeneration)6
	}; // ADAPTADO-U6: iPhoneGeneration -> iOS.DeviceGeneration (mismos valores)

	public GameObject[] destroyList;

	// RECUPERADO-AOT LowEndInhibitor::Start token 0x0600043d @0x000ffd20
	// ADAPTADO-U6 (calidad fija para PC, RECOVERY_REPORT.md 11.2): the inhibition only ran when
	// Application.platform == IPhonePlayer (8) and iPhone.generation was listed in inhibitPlatforms, so on PC
	// nothing is destroyed; the component still removes its own GameObject, as in the original.
	private void Start()
	{
		Object.Destroy(base.gameObject);
	}
}
