using System;
using System.Collections.Generic;
using UnityEngine;

// Per-kart AI tuning: one weight per CarAI state (how eager the kart is to go for pickups, terrain, powerups...)
// and the radius within which it notices things.
// Source listing: recovery/aot_listings/Assembly-CSharp/CarAIPersonality.txt
public class CarAIPersonality : MonoBehaviour
{
	[Serializable]
	public class PersonalityTrait
	{
		// RECUPERADO-AOT CarAIPersonality/PersonalityTrait::.ctor token 0x0600002a @0x000c4a94 (field initializer)
		public string name = "ERROR";

		public float weight;
	}

	public float AIVersion;

	// RECUPERADO-AOT CarAIPersonality::.ctor token 0x06000027 @0x000c458c (field initializer + constructor body)
	public float awarenessRadius = 120f;

	public PersonalityTrait[] traits;

	public Dictionary<CarAI.AIStates, float> stateWeightMap
	{
		// RECUPERADO-AOT CarAIPersonality::get_stateWeightMap token 0x06000028 @0x000c4704
		get
		{
			Array values = Enum.GetValues(typeof(CarAI.AIStates));
			Dictionary<CarAI.AIStates, float> dictionary = new Dictionary<CarAI.AIStates, float>(values.Length);
			foreach (int item in values)
			{
				dictionary[(CarAI.AIStates)item] = traits[item].weight;
			}
			return dictionary;
		}
	}

	// Default traits: one per AI state, named after it, weight 1 (serialized values replace them on load).
	public CarAIPersonality()
	{
		string[] names = Enum.GetNames(typeof(CarAI.AIStates));
		traits = new PersonalityTrait[names.Length];
		for (int i = 0; i < names.Length; i++)
		{
			traits[i] = new PersonalityTrait();
			traits[i].name = names[i];
			traits[i].weight = 1f;
		}
		AIVersion = 0.6f;
	}

	// RECUPERADO-AOT CarAIPersonality::Start token 0x06000029 @0x000c4a04
	private void Start()
	{
		if (AIVersion != 0.6f)
		{
			Debug.LogError("CarAIPersonality for '" + base.name + "' operating off of a different AI version");
		}
	}
}
