using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: hit an airborne opponent with a power-up numTimes in one race.
// Source listing: recovery/aot_listings/Assembly-CSharp/PowerupHitInAirAchievementListener.txt
public class PowerupHitInAirAchievementListener : AchievementListener
{
	// RECUPERADO-AOT PowerupHitInAirAchievementListener::.ctor token 0x06000160 (field initializer)
	public int numTimes = 1;

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::Start token 0x06000161 @0x000d40b0
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::Update token 0x06000162 @0x000d4108 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::IsAvailable token 0x06000163 @0x000d4134
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::CheckMetricsPump token 0x06000164 @0x000d417c
	// RECUPERADO-AOT PowerupHitInAirAchievementListener/<CheckMetricsPump>c__Iterator14::MoveNext token 0x06000848 @0x00143fd8
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(2f);
		}
		Achieve();
	}

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::CheckMetrics token 0x06000165 @0x000d41c4
	private bool CheckMetrics()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			CarMetrics component = playerCar.GetComponent<CarMetrics>();
			if (component != null)
			{
				int num = -1;
				if (component.otherMetrics.ContainsKey("Powerup hit in air"))
				{
					num = (int)component.otherMetrics["Powerup hit in air"];
				}
				return num >= numTimes;
			}
		}
		return false;
	}

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::Prerace token 0x06000166 @0x000d42ac (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::Postrace token 0x06000167 @0x000d42d8
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT PowerupHitInAirAchievementListener::Reward token 0x06000168 @0x000d432c
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: triggered hit someone with powerup in the air");
	}
}
