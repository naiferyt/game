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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public GameObject GetPrefab(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
