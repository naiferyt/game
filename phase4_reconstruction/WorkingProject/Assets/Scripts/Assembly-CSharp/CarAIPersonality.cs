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
			return default(Dictionary<CarAI.AIStates, float>);
		}
	}

	private void Start()
	{
	}
}
