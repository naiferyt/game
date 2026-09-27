using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: every achievement in achievementPrefabGroup has been achieved.
// Source listing: recovery/aot_listings/Assembly-CSharp/MetaMissionGroupAchievementListener.txt
public class MetaMissionGroupAchievementListener : AchievementListener
{
	public AchievementListener[] achievementPrefabGroup;

	// RECUPERADO-AOT MetaMissionGroupAchievementListener::IsAvailable token 0x06000140 @0x000d34dc
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT MetaMissionGroupAchievementListener::Prerace token 0x06000141 @0x000d351c (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT MetaMissionGroupAchievementListener::Postrace token 0x06000142 @0x000d3548 (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT MetaMissionGroupAchievementListener::Reward token 0x06000143 @0x000d3574
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for MetaMissionGroupAchievementListener");
	}

	// RECUPERADO-AOT MetaMissionGroupAchievementListener::CheckCompletionCoroutine token 0x06000144 @0x000d35b4
	// RECUPERADO-AOT MetaMissionGroupAchievementListener/<CheckCompletionCoroutine>c__Iterator11::MoveNext token 0x06000836 @0x00143980
	[DebuggerHidden]
	private IEnumerator CheckCompletionCoroutine()
	{
		bool pass;
		do
		{
			yield return new WaitForSeconds(0.5f);
			pass = true;
			AchievementListener[] array = achievementPrefabGroup;
			foreach (AchievementListener listener in array)
			{
				if (!listener.HasAchieved())
				{
					pass = false;
					break;
				}
			}
		}
		while (!pass);
		Achieve();
	}

	// RECUPERADO-AOT MetaMissionGroupAchievementListener::Start token 0x06000145 @0x000d35fc
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckCompletionCoroutine());
	}
}
