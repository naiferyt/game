using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: collect numCoins track tokens in one race.
// Source listing: recovery/aot_listings/Assembly-CSharp/PickupCoinsPerRaceAchievementListener.txt
public class PickupCoinsPerRaceAchievementListener : AchievementListener
{
	public int numCoins;

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::Start token 0x06000147 @0x000d3688
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::Update token 0x06000148 @0x000d36e0 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::IsAvailable token 0x06000149 @0x000d370c
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::Prerace token 0x0600014a @0x000d3754 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::CheckMetricsPump token 0x0600014b @0x000d3780
	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener/<CheckMetricsPump>c__Iterator12::MoveNext token 0x0600083c @0x00143c00
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckCarMetrics())
		{
			yield return new WaitForSeconds(2f);
		}
		Achieve();
	}

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::CheckCarMetrics token 0x0600014c @0x000d37c8
	private bool CheckCarMetrics()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			CarMetrics component = playerCar.GetComponent<CarMetrics>();
			if (component != null)
			{
				int num = -1;
				if (component.otherMetrics.ContainsKey("Tokens Collected"))
				{
					num = (int)component.otherMetrics["Tokens Collected"];
				}
				return num >= numCoins;
			}
		}
		return false;
	}

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::Postrace token 0x0600014d @0x000d38b8
	public override void Postrace()
	{
		if (!HasAchieved() && CheckCarMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT PickupCoinsPerRaceAchievementListener::Reward token 0x0600014e @0x000d390c
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: Triggered the Tokens per race achievement");
	}
}
