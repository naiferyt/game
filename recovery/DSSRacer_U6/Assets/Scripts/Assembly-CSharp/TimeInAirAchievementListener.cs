using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: totalTimeRequired seconds in the air in one race.
// Source listing: recovery/aot_listings/Assembly-CSharp/TimeInAirAchievementListener.txt
public class TimeInAirAchievementListener : AchievementListener
{
	public float totalTimeRequired;

	// RECUPERADO-AOT TimeInAirAchievementListener::IsAvailable token 0x06000171 @0x000d458c
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT TimeInAirAchievementListener::Prerace token 0x06000172 @0x000d45cc (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT TimeInAirAchievementListener::Postrace token 0x06000173 @0x000d45f8 (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT TimeInAirAchievementListener::Reward token 0x06000174 @0x000d4624
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for TimeInAirAchievementListener");
	}

	// RECUPERADO-AOT TimeInAirAchievementListener::CheckAirTimeCoroutine token 0x06000175 @0x000d4664
	// RECUPERADO-AOT TimeInAirAchievementListener/<CheckAirTimeCoroutine>c__Iterator16::MoveNext token 0x06000854 @0x00144400
	[DebuggerHidden]
	private IEnumerator CheckAirTimeCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			GameObject player = RaceManager.GetPlayerCar();
			if (player != null)
			{
				CarMetrics metrics = player.GetComponent<CarMetrics>();
				if (metrics != null && metrics.totalTimeInAir >= totalTimeRequired)
				{
					break;
				}
			}
		}
		Achieve();
	}

	// RECUPERADO-AOT TimeInAirAchievementListener::Start token 0x06000176 @0x000d46ac
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckAirTimeCoroutine());
	}
}
