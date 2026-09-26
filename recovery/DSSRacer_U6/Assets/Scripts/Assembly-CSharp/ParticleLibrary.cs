using System;
using System.Collections.Generic;
using UnityEngine;

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

	public static ParticleLibrary Instance
	{
		get
		{
			RecoveryPending.Hit("ParticleLibrary.get_Instance");
			return default(ParticleLibrary);
		}
	}

	public GameObject GetPrefab(string name)
	{
		RecoveryPending.Hit("ParticleLibrary.GetPrefab");
		return default(GameObject);
	}

	private void Awake()
	{
		RecoveryPending.Hit("ParticleLibrary.Awake");
	}

	private void Start()
	{
		RecoveryPending.Hit("ParticleLibrary.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("ParticleLibrary.Update");
	}
}
