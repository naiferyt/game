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
			return default(ParticleLibrary);
		}
	}

	public GameObject GetPrefab(string name)
	{
		return default(GameObject);
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
