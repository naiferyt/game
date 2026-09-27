using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: use a power-up type (optionally its double/combined form) numberOfTimes times in one race.
// Source listing: recovery/aot_listings/Assembly-CSharp/UseAPowerupAchievementListener.txt
public class UseAPowerupAchievementListener : AchievementListener
{
	public int numberOfTimes;

	public BaseEffect.EffectTypes type;

	public bool isDouble;

	// RECUPERADO-AOT UseAPowerupAchievementListener::Start token 0x06000181 @0x000d4a6c
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(PowerupUseCheckPump());
	}

	// RECUPERADO-AOT UseAPowerupAchievementListener::Update token 0x06000182 @0x000d4ac4 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT UseAPowerupAchievementListener::CheckCarMetrics token 0x06000183 @0x000d4af0
	private bool CheckCarMetrics()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			CarMetrics component = playerCar.GetComponent<CarMetrics>();
			if (component != null)
			{
				string text = "Used ";
				if (isDouble)
				{
					text += "Double ";
				}
				string key = text + type;
				int num = -1;
				if (component.otherMetrics.ContainsKey(key))
				{
					num = (int)component.otherMetrics[key];
				}
				return num >= numberOfTimes;
			}
		}
		return false;
	}

	// RECUPERADO-AOT UseAPowerupAchievementListener::PowerupUseCheckPump token 0x06000184 @0x000d4c50
	// RECUPERADO-AOT UseAPowerupAchievementListener/<PowerupUseCheckPump>c__Iterator18::MoveNext token 0x06000860 @0x0014483c
	[DebuggerHidden]
	private IEnumerator PowerupUseCheckPump()
	{
		while (!CheckCarMetrics())
		{
			yield return new WaitForSeconds(1f);
		}
		Achieve();
	}

	// RECUPERADO-AOT UseAPowerupAchievementListener::IsAvailable token 0x06000185 @0x000d4c98
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT UseAPowerupAchievementListener::Prerace token 0x06000186 @0x000d4ce0 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT UseAPowerupAchievementListener::Postrace token 0x06000187 @0x000d4d0c (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT UseAPowerupAchievementListener::Reward token 0x06000188 @0x000d4d38
	public override void Reward()
	{
		UnityEngine.Debug.Log(string.Concat("TODO: Triggered Use a powerup Achievement - ", type, ": ", numberOfTimes));
	}
}
