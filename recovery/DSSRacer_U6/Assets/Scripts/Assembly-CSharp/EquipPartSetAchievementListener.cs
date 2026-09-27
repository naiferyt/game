using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: have every part of partSet equipped (owned, not a temporary try-on).
// Source listing: recovery/aot_listings/Assembly-CSharp/EquipPartSetAchievementListener.txt
public class EquipPartSetAchievementListener : AchievementListener
{
	public CartPart[] partSet;

	// RECUPERADO-AOT EquipPartSetAchievementListener::IsAvailable token 0x060000ed @0x000d1690
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT EquipPartSetAchievementListener::Prerace token 0x060000ee @0x000d16d0 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT EquipPartSetAchievementListener::Postrace token 0x060000ef @0x000d16fc (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT EquipPartSetAchievementListener::Reward token 0x060000f0 @0x000d1728
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for EquipPartSetAchievementListener");
	}

	// RECUPERADO-AOT EquipPartSetAchievementListener::CheckCartSet token 0x060000f1 @0x000d1768
	// RECUPERADO-AOT EquipPartSetAchievementListener/<CheckCartSet>c__Iterator9::MoveNext token 0x06000806 @0x001427d4
	[DebuggerHidden]
	private IEnumerator CheckCartSet()
	{
		bool passes;
		do
		{
			yield return new WaitForSeconds(0.5f);
			passes = true;
			CartPart[] array = partSet;
			foreach (CartPart part in array)
			{
				CartSlot slot = PlayerInstance.GetCartSlot(part.cartSlot);
				if (slot.partInSlot == null || slot.partInSlot.UIName.baseText != part.UIName.baseText || CartCustomizerPublisher.IsTemporaryInSlot(part.cartSlot) || CharacterSelectPublisher.IsTemporary(part.cartSlot))
				{
					passes = false;
					break;
				}
			}
		}
		while (!passes);
		Achieve();
	}

	// RECUPERADO-AOT EquipPartSetAchievementListener::Start token 0x060000f2 @0x000d17b0
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckCartSet());
	}
}
