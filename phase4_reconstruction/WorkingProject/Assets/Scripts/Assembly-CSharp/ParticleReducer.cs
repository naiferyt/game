using System;
using UnityEngine;

public class ParticleReducer : MonoBehaviour
{
	[Serializable]
	public class PlatformProfile
	{
		public iPhoneGeneration generation;

		public float minEmission;

		public float maxEmission;
	}

	public PlatformProfile[] platformProfiles;

	private void Start()
	{
	}
}
