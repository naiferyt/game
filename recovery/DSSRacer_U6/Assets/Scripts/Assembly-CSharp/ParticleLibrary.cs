using System;
using System.Collections.Generic;
using UnityEngine;

// Global (EnsureGlobals) lookup of particle effect prefabs by name.
// Source listing: recovery/aot_listings/Assembly-CSharp/ParticleLibrary.txt
public class ParticleLibrary : MonoBehaviour
{
	[Serializable]
	public class ParticlePrefab
	{
		public string name;

		public GameObject prefab;
	}

	private static ParticleLibrary s_Instance;

	public List<ParticlePrefab> particlePrefabs;

	// RECUPERADO-AOT ParticleLibrary::get_Instance token 0x0600038d @0x000f4eb8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static ParticleLibrary Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(ParticleLibrary)) as ParticleLibrary;
				if (s_Instance == null)
				{
					Debug.LogWarning("There needs to be a ParticleLibrary in the scene!");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT ParticleLibrary::GetPrefab token 0x0600038e @0x000f4fb0
	public GameObject GetPrefab(string name)
	{
		foreach (ParticlePrefab particlePrefab in particlePrefabs)
		{
			if (particlePrefab.name == name)
			{
				return particlePrefab.prefab;
			}
		}
		Debug.LogWarning("Returning null because you were looking for the wrong name: " + name);
		return null;
	}

	// RECUPERADO-AOT ParticleLibrary::Awake token 0x0600038f @0x000f5134
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// RECUPERADO-AOT ParticleLibrary::Start token 0x06000390 @0x000f516c
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	private void Start()
	{
		if (U4Compat.FindObjectsOfType(typeof(ParticleLibrary)).Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT ParticleLibrary::Update token 0x06000391 @0x000f51c4 (empty in the original)
	private void Update()
	{
	}
}
