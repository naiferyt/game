using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: totalTimeRequired seconds in the air over all races.
// Source listing: recovery/aot_listings/Assembly-CSharp/LifetimeInAirAchievementListener.txt
public class LifetimeInAirAchievementListener : AchievementListener
{
	public float totalTimeRequired;

	// RECUPERADO-AOT LifetimeInAirAchievementListener::IsAvailable token 0x0600011a @0x000d2808
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT LifetimeInAirAchievementListener::Prerace token 0x0600011b @0x000d2848 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT LifetimeInAirAchievementListener::Postrace token 0x0600011c @0x000d2874 (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT LifetimeInAirAchievementListener::Reward token 0x0600011d @0x000d28a0
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for LifetimeInAirAchievementListener");
	}

	// RECUPERADO-AOT LifetimeInAirAchievementListener::CheckAirTimeCoroutine token 0x0600011e @0x000d28e0
	// RECUPERADO-AOT LifetimeInAirAchievementListener/<CheckAirTimeCoroutine>c__IteratorD::MoveNext token 0x0600081e @0x001430d8
	[DebuggerHidden]
	private IEnumerator CheckAirTimeCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			LifetimeMetrics metrics = DataUtility.Instance.lifeTimeMetrics;
			if (metrics != null && metrics["Total Time In Air"] >= totalTimeRequired)
			{
				break;
			}
		}
		Achieve();
	}

	// RECUPERADO-AOT LifetimeInAirAchievementListener::Start token 0x0600011f @0x000d2928
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckAirTimeCoroutine());
	}
}
