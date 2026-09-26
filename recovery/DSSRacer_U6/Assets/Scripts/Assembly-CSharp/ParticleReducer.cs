using System;
using UnityEngine;

public class ParticleReducer : MonoBehaviour
{
	[Serializable]
	public class PlatformProfile
	{
		public UnityEngine.iOS.DeviceGeneration generation; // ADAPTADO-U6: iPhoneGeneration -> iOS.DeviceGeneration (mismos valores)

		public float minEmission;

		public float maxEmission;
	}

	public PlatformProfile[] platformProfiles;

	private void Start()
	{
		RecoveryPending.Hit("ParticleReducer.Start");
	}
}
