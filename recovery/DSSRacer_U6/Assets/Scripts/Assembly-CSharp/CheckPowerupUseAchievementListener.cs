using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Lifetime achievement: every power-up type in typesToCheck (or its double form) has been used at least once.
// Source listing: recovery/aot_listings/Assembly-CSharp/CheckPowerupUseAchievementListener.txt
public class CheckPowerupUseAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes[] typesToCheck;

	public bool doublesOnly;

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::Start token 0x060000c8 @0x000d0bd8
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(PowerupUseCheckPump());
	}

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::Update token 0x060000c9 @0x000d0c30 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::PowerupUseCheckPump token 0x060000ca @0x000d0c5c
	// RECUPERADO-AOT CheckPowerupUseAchievementListener/<PowerupUseCheckPump>c__Iterator5::MoveNext token 0x060007ee @0x00141c94
	[DebuggerHidden]
	private IEnumerator PowerupUseCheckPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(10f);
		}
		Achieve();
	}

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::CheckMetrics token 0x060000cb @0x000d0ca4
	private bool CheckMetrics()
	{
		for (int i = 0; i < typesToCheck.Length; i++)
		{
			string text = "Used ";
			if (doublesOnly)
			{
				text += "Double ";
			}
			string key = text + typesToCheck[i];
			if (!DataUtility.Instance.lifeTimeMetrics.ContainsKey(key) || DataUtility.Instance.lifeTimeMetrics[key] <= 0f)
			{
				return false;
			}
		}
		return true;
	}

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::IsAvailable token 0x060000cc @0x000d0e00
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::Prerace token 0x060000cd @0x000d0e48 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::Postrace token 0x060000ce @0x000d0e74
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT CheckPowerupUseAchievementListener::Reward token 0x060000cf @0x000d0ec8
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: Triggered CheckPowerupUse Achievement");
	}
}
