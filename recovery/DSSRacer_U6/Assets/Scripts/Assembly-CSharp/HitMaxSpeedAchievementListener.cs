using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: reach targetSpeed.
// Source listing: recovery/aot_listings/Assembly-CSharp/HitMaxSpeedAchievementListener.txt
public class HitMaxSpeedAchievementListener : AchievementListener
{
	public float targetSpeed;

	// RECUPERADO-AOT HitMaxSpeedAchievementListener::IsAvailable token 0x06000103 @0x000d1f60
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT HitMaxSpeedAchievementListener::Prerace token 0x06000104 @0x000d1fa0 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT HitMaxSpeedAchievementListener::Postrace token 0x06000105 @0x000d1fcc (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT HitMaxSpeedAchievementListener::Reward token 0x06000106 @0x000d1ff8
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for HitMaxSpeedAchievementListener");
	}

	// RECUPERADO-AOT HitMaxSpeedAchievementListener::CheckMaxSpeedCoroutine token 0x06000107 @0x000d2038
	// RECUPERADO-AOT HitMaxSpeedAchievementListener/<CheckMaxSpeedCoroutine>c__IteratorB::MoveNext token 0x06000812 @0x00142c9c
	[DebuggerHidden]
	private IEnumerator CheckMaxSpeedCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			GameObject player = RaceManager.GetPlayerCar();
			if (player != null)
			{
				CarMetrics metrics = player.GetComponent<CarMetrics>();
				if (metrics != null && metrics.maxSpeed >= targetSpeed)
				{
					break;
				}
			}
		}
		Achieve();
	}

	// RECUPERADO-AOT HitMaxSpeedAchievementListener::Start token 0x06000108 @0x000d2080
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMaxSpeedCoroutine());
	}
}
