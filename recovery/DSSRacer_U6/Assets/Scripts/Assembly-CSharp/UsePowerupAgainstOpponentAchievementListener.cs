using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: hit opponents numHits times with a power-up type in one race.
// Source listing: recovery/aot_listings/Assembly-CSharp/UsePowerupAgainstOpponentAchievementListener.txt
public class UsePowerupAgainstOpponentAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes type;

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::.ctor token 0x06000189 (field initializer)
	public int numHits = 1;

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::Start token 0x0600018a @0x000d4ea4
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::Update token 0x0600018b @0x000d4efc (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::CheckMetricsPump token 0x0600018c @0x000d4f28
	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener/<CheckMetricsPump>c__Iterator19::MoveNext token 0x06000866 @0x00144a28
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(2f);
		}
		Achieve();
	}

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::CheckMetrics token 0x0600018d @0x000d4f70
	private bool CheckMetrics()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			CarMetrics component = playerCar.GetComponent<CarMetrics>();
			if (component != null)
			{
				string key = type + " success";
				int num = -1;
				if (component.otherMetrics.ContainsKey(key))
				{
					num = (int)component.otherMetrics[key];
				}
				return num >= numHits;
			}
		}
		return false;
	}

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::IsAvailable token 0x0600018e @0x000d509c
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::Prerace token 0x0600018f @0x000d50e4 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::Postrace token 0x06000190 @0x000d5110
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT UsePowerupAgainstOpponentAchievementListener::Reward token 0x06000191 @0x000d5164
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: triggered use powerup against opponent achievement");
	}
}
