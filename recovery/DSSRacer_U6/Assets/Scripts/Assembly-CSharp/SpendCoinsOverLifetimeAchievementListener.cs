using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: spend numberOfCoins tokens over all time.
// Source listing: recovery/aot_listings/Assembly-CSharp/SpendCoinsOverLifetimeAchievementListener.txt
public class SpendCoinsOverLifetimeAchievementListener : AchievementListener
{
	public int numberOfCoins;

	// RECUPERADO-AOT SpendCoinsOverLifetimeAchievementListener::IsAvailable token 0x0600016a @0x000d43a0
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT SpendCoinsOverLifetimeAchievementListener::Prerace token 0x0600016b @0x000d43e0 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT SpendCoinsOverLifetimeAchievementListener::Postrace token 0x0600016c @0x000d440c (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT SpendCoinsOverLifetimeAchievementListener::Reward token 0x0600016d @0x000d4438
	public override void Reward()
	{
		UnityEngine.Debug.Log("Give reward for spending " + numberOfCoins + " Tokens over lifetime.");
	}

	// RECUPERADO-AOT SpendCoinsOverLifetimeAchievementListener::CheckSpentCoinsCoroutine token 0x0600016e @0x000d44c0
	// RECUPERADO-AOT SpendCoinsOverLifetimeAchievementListener/<CheckSpentCoinsCoroutine>c__Iterator15::MoveNext token 0x0600084e @0x001441c4
	[DebuggerHidden]
	private IEnumerator CheckSpentCoinsCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			LifetimeMetrics metrics = DataUtility.Instance.lifeTimeMetrics;
			if (metrics != null && metrics["Tokens Spent"] >= (float)numberOfCoins)
			{
				break;
			}
		}
		Achieve();
	}

	// RECUPERADO-AOT SpendCoinsOverLifetimeAchievementListener::Start token 0x0600016f @0x000d4508
	// Note (original): unlike the other listeners, Start does not set the state to ACTIVE.
	private void Start()
	{
		StartCoroutine(CheckSpentCoinsCoroutine());
	}
}
