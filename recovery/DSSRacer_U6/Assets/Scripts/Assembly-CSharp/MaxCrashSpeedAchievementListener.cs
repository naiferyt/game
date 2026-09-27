using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: crash at targetSpeed or faster.
// Source listing: recovery/aot_listings/Assembly-CSharp/MaxCrashSpeedAchievementListener.txt
public class MaxCrashSpeedAchievementListener : AchievementListener
{
	public float targetSpeed;

	// RECUPERADO-AOT MaxCrashSpeedAchievementListener::IsAvailable token 0x06000139 @0x000d3330
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT MaxCrashSpeedAchievementListener::Prerace token 0x0600013a (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT MaxCrashSpeedAchievementListener::Postrace token 0x0600013b (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT MaxCrashSpeedAchievementListener::Reward token 0x0600013c @0x000d33c8
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for MaxCrashSpeedAchievementListener");
	}

	// RECUPERADO-AOT MaxCrashSpeedAchievementListener::CheckMaxCrashSpeedCoroutine token 0x0600013d @0x000d3408
	// RECUPERADO-AOT MaxCrashSpeedAchievementListener/<CheckMaxCrashSpeedCoroutine>c__Iterator10::MoveNext token 0x06000830 @0x001436e4
	[DebuggerHidden]
	private IEnumerator CheckMaxCrashSpeedCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			GameObject player = RaceManager.GetPlayerCar();
			if (player != null)
			{
				CarMetrics metrics = player.GetComponent<CarMetrics>();
				if (metrics != null && metrics.otherMetrics.ContainsKey("Max Crash Speed") && metrics.otherMetrics["Max Crash Speed"] >= targetSpeed)
				{
					break;
				}
			}
		}
		Achieve();
	}

	// RECUPERADO-AOT MaxCrashSpeedAchievementListener::Start token 0x0600013e @0x000d3450
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMaxCrashSpeedCoroutine());
	}
}
