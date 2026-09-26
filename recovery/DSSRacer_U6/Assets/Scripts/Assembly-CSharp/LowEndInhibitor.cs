using UnityEngine;

public class LowEndInhibitor : MonoBehaviour
{
	public UnityEngine.iOS.DeviceGeneration[] inhibitPlatforms; // ADAPTADO-U6: iPhoneGeneration -> iOS.DeviceGeneration (mismos valores)

	public GameObject[] destroyList;

	private void Start()
	{
		RecoveryPending.Hit("LowEndInhibitor.Start");
	}
}
