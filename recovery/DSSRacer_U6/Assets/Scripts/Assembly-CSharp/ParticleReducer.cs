using System;
using UnityEngine;

public class ParticleReducer : MonoBehaviour
{
	[Serializable]
	public class PlatformProfile
	{
		public U4iPhoneGeneration generation; // ADAPTADO-U6: iPhoneGeneration -> U4iPhoneGeneration (mismos valores)

		public float minEmission;

		public float maxEmission;
	}

	public PlatformProfile[] platformProfiles;

	private void Start()
	{
		RecoveryPending.Hit("ParticleReducer.Start");
	}
}
