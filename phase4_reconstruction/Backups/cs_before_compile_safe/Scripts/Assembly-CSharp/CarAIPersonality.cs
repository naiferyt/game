using System;
using System.Collections.Generic;
using UnityEngine;

public class CarAIPersonality : MonoBehaviour
{
	[Serializable]
	public class PersonalityTrait
	{
		public string name;

		public float weight;
	}

	public float AIVersion;

	public float awarenessRadius;

	public PersonalityTrait[] traits;

	public Dictionary<CarAI.AIStates, float> stateWeightMap
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void Start()
	{
	}
}
