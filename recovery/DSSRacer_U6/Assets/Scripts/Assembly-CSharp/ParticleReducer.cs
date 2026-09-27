using System;
using UnityEngine;

// Scales the emission of every particle system below it by the profile matching the device generation.
// Source listing: recovery/aot_listings/Assembly-CSharp/ParticleReducer.txt
// RECUPERADO-AOT ParticleReducer::.ctor token 0x0600043e @0x000ffdec (trivial constructor)
// RECUPERADO-AOT ParticleReducer/PlatformProfile::.ctor token 0x06000440 @0x0010005c (trivial constructor)
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

	// RECUPERADO-AOT ParticleReducer::Start token 0x0600043f @0x000ffe20
	// RECUPERADO-AOT ParticleReducer/<Start>c__AnonStorey93::<>m__E token 0x06000b3a @0x00166784
	// ADAPTADO-U6: iPhone.generation -> U4Compat.IPhoneGeneration (off iOS it matches no iPhone profile).
	// ADAPTADO-U6: ParticleEmitter min/maxEmission -> ParticleSystem emission (see ScaleEmission).
	private void Start()
	{
		U4iPhoneGeneration gen = U4Compat.IPhoneGeneration;
		PlatformProfile platformProfile = null;
		if (platformProfiles != null)
		{
			platformProfile = Array.Find(platformProfiles, (PlatformProfile x) => x.generation == gen);
		}
		else
		{
			Debug.LogWarning("Platform profiles in the particleReducer not filled out on: " + base.gameObject.name);
		}
		if (platformProfile != null)
		{
			ParticleSystem[] componentsInChildren = base.gameObject.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ScaleEmission(componentsInChildren[i], platformProfile.minEmission, platformProfile.maxEmission);
			}
		}
	}

	// ADAPTADO-U6: the legacy emitters were converted to ParticleSystems whose rate (or burst) is a
	// MinMaxCurve(minEmission, maxEmission); scale its min by minScale and its max by maxScale.
	private static void ScaleEmission(ParticleSystem ps, float minScale, float maxScale)
	{
		ParticleSystem.EmissionModule emission = ps.emission;
		emission.rateOverTime = ScaleCurve(emission.rateOverTime, minScale, maxScale);
		for (int i = 0; i < emission.burstCount; i++)
		{
			ParticleSystem.Burst burst = emission.GetBurst(i);
			burst.count = ScaleCurve(burst.count, minScale, maxScale);
			emission.SetBurst(i, burst);
		}
	}

	private static ParticleSystem.MinMaxCurve ScaleCurve(ParticleSystem.MinMaxCurve curve, float minScale, float maxScale)
	{
		if (curve.mode == ParticleSystemCurveMode.TwoConstants)
		{
			curve.constantMin *= minScale;
			curve.constantMax *= maxScale;
		}
		else if (curve.mode == ParticleSystemCurveMode.Constant)
		{
			curve.constant *= maxScale;
		}
		return curve;
	}
}
