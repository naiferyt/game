using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class UnlockAchievementListener : AchievementListener
{
	public CartSlot.Slots slotToUnlock;

	public GameObject[] thingsToUnlock;

	private void Start()
	{
		RecoveryPending.Hit("UnlockAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("UnlockAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("UnlockAchievementListener.IsAvailable");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator CheckUnlocks()
	{
		RecoveryPending.Hit("UnlockAchievementListener.CheckUnlocks");
		yield break;
	}

	private bool UnlockCheck()
	{
		RecoveryPending.Hit("UnlockAchievementListener.UnlockCheck");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("UnlockAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("UnlockAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("UnlockAchievementListener.Reward");
	}
}
