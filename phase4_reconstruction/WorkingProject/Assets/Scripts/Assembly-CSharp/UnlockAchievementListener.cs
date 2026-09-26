using System.Collections;
using UnityEngine;

public class UnlockAchievementListener : AchievementListener
{
	public CartSlot.Slots slotToUnlock;

	public GameObject[] thingsToUnlock;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public override bool IsAvailable()
	{
		return default(bool);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CheckUnlocks()
	{
		return default(IEnumerator);
	}

	private bool UnlockCheck()
	{
		return default(bool);
	}

	public override void Prerace()
	{
	}

	public override void Postrace()
	{
	}

	public override void Reward()
	{
	}
}
