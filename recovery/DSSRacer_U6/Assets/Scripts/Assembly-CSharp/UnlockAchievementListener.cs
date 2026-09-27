using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: every kart part in thingsToUnlock (all for slotToUnlock) has been unlocked.
// Source listing: recovery/aot_listings/Assembly-CSharp/UnlockAchievementListener.txt
public class UnlockAchievementListener : AchievementListener
{
	public CartSlot.Slots slotToUnlock;

	public GameObject[] thingsToUnlock;

	// RECUPERADO-AOT UnlockAchievementListener::Start token 0x06000178 @0x000d4738
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckUnlocks());
	}

	// RECUPERADO-AOT UnlockAchievementListener::Update token 0x06000179 @0x000d4790 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT UnlockAchievementListener::IsAvailable token 0x0600017a @0x000d47bc
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT UnlockAchievementListener::CheckUnlocks token 0x0600017b @0x000d4804
	// RECUPERADO-AOT UnlockAchievementListener/<CheckUnlocks>c__Iterator17::MoveNext token 0x0600085a @0x00144650
	[DebuggerHidden]
	private IEnumerator CheckUnlocks()
	{
		while (!UnlockCheck())
		{
			yield return new WaitForSeconds(1f);
		}
		Achieve();
	}

	// RECUPERADO-AOT UnlockAchievementListener::UnlockCheck token 0x0600017c @0x000d484c
	private bool UnlockCheck()
	{
		for (int i = 0; i < thingsToUnlock.Length; i++)
		{
			CartPart component = thingsToUnlock[i].GetComponent<CartPart>();
			if (component == null || component.cartSlot != slotToUnlock)
			{
				UnityEngine.Debug.Log("Trying to check an object to unlock that is null or does not match the slot for unlocked stuff. Be sure you have added the right part to the array!");
			}
			else if (!DataUtility.Instance.IsUnlocked(component.UIName.baseText))
			{
				return false;
			}
		}
		return true;
	}

	// RECUPERADO-AOT UnlockAchievementListener::Prerace token 0x0600017d @0x000d4954 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT UnlockAchievementListener::Postrace token 0x0600017e @0x000d4980 (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT UnlockAchievementListener::Reward token 0x0600017f @0x000d49ac
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: Triggered the Unlock Achievement: " + slotToUnlock);
	}
}
