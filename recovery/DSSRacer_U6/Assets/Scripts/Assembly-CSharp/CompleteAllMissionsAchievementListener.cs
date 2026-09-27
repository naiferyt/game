using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: every other achievement (linear, random and front-end lists) has been achieved.
// Source listing: recovery/aot_listings/Assembly-CSharp/CompleteAllMissionsAchievementListener.txt
public class CompleteAllMissionsAchievementListener : AchievementListener
{
	// RECUPERADO-AOT CompleteAllMissionsAchievementListener::IsAvailable token 0x060000d8 @0x000d10e8
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT CompleteAllMissionsAchievementListener::Prerace token 0x060000d9 @0x000d1128 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT CompleteAllMissionsAchievementListener::Postrace token 0x060000da @0x000d1154 (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT CompleteAllMissionsAchievementListener::Reward token 0x060000db @0x000d1180
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for CompleteAllMissionsAchievementListener");
	}

	// RECUPERADO-AOT CompleteAllMissionsAchievementListener::CheckAllMissionsCoroutine token 0x060000dc @0x000d11c0
	// RECUPERADO-AOT CompleteAllMissionsAchievementListener/<CheckAllMissionsCoroutine>c__Iterator7::MoveNext token 0x060007fa @0x00142080
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	[DebuggerHidden]
	private IEnumerator CheckAllMissionsCoroutine()
	{
		AchievementManager am = U4Compat.FindObjectOfType(typeof(AchievementManager)) as AchievementManager;
		if (am == null)
		{
			UnityEngine.Debug.LogError("This scene requires AchievementManager");
			yield break;
		}
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			bool pass = true;
			AchievementListener[] linearAchievements = am.linearAchievements;
			foreach (AchievementListener prefab in linearAchievements)
			{
				if (!prefab.HasAchieved())
				{
					pass = false;
					break;
				}
			}
			if (!pass)
			{
				continue;
			}
			AchievementListener[] randomAchievements = am.randomAchievements;
			foreach (AchievementListener prefab2 in randomAchievements)
			{
				if (!prefab2.HasAchieved())
				{
					pass = false;
					break;
				}
			}
			if (!pass)
			{
				continue;
			}
			AchievementListener[] frontEndAchievements = am.frontEndAchievements;
			foreach (AchievementListener prefab3 in frontEndAchievements)
			{
				if (prefab3.GetType() != typeof(CompleteAllMissionsAchievementListener) && !prefab3.HasAchieved())
				{
					pass = false;
					break;
				}
			}
			if (pass)
			{
				break;
			}
		}
		Achieve();
	}

	// RECUPERADO-AOT CompleteAllMissionsAchievementListener::Start token 0x060000dd @0x000d1208
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckAllMissionsCoroutine());
	}
}
