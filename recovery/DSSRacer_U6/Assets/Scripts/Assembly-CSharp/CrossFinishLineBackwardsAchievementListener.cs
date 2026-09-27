using UnityEngine;

// In-race achievement: cross the finish line backwards (checked when the race ends).
// Source listing: recovery/aot_listings/Assembly-CSharp/CrossFinishLineBackwardsAchievementListener.txt
public class CrossFinishLineBackwardsAchievementListener : AchievementListener
{
	// RECUPERADO-AOT CrossFinishLineBackwardsAchievementListener::IsAvailable token 0x060000df @0x000d1294
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT CrossFinishLineBackwardsAchievementListener::Prerace token 0x060000e0 @0x000d12d4 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT CrossFinishLineBackwardsAchievementListener::Postrace token 0x060000e1 @0x000d1300
	public override void Postrace()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			CarMetrics component = playerCar.GetComponent<CarMetrics>();
			if (component != null && component.otherMetrics.ContainsKey("Crossed Finish Line Backwards") && component.otherMetrics["Crossed Finish Line Backwards"] > 0f)
			{
				Achieve();
				return;
			}
		}
		Fail();
	}

	// RECUPERADO-AOT CrossFinishLineBackwardsAchievementListener::Reward token 0x060000e2 @0x000d13fc
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for CrossFinishLineBackwardsAchievementListener");
	}

	// RECUPERADO-AOT CrossFinishLineBackwardsAchievementListener::Start token 0x060000e3 @0x000d143c
	private void Start()
	{
		state = AchievementState.ACTIVE;
	}
}
