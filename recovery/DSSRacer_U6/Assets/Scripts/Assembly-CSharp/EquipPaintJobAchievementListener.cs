using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: have numPaintsToEquip kart parts wearing a paint job other than their default one.
// Source listing: recovery/aot_listings/Assembly-CSharp/EquipPaintJobAchievementListener.txt
public class EquipPaintJobAchievementListener : AchievementListener
{
	// RECUPERADO-AOT EquipPaintJobAchievementListener::.ctor token 0x060000e4 (field initializer)
	public int numPaintsToEquip = 1;

	// RECUPERADO-AOT EquipPaintJobAchievementListener::Start token 0x060000e5 @0x000d14b0
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckPaintJobs());
	}

	// RECUPERADO-AOT EquipPaintJobAchievementListener::Update token 0x060000e6 @0x000d1508 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT EquipPaintJobAchievementListener::IsAvailable token 0x060000e7 @0x000d1534
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT EquipPaintJobAchievementListener::CheckPaintJobs token 0x060000e8 @0x000d157c
	// RECUPERADO-AOT EquipPaintJobAchievementListener/<CheckPaintJobs>c__Iterator8::MoveNext token 0x06000800 @0x001424c4
	[DebuggerHidden]
	private IEnumerator CheckPaintJobs()
	{
		while (true)
		{
			int count = 0;
			CartSlot[] cartSlots = PlayerInstance.Instance.cartSlots;
			foreach (CartSlot slot in cartSlots)
			{
				if (slot.slot == CartSlot.Slots.character || !(slot.partInSlot != null) || !(slot.slotPaint != null))
				{
					continue;
				}
				PaintJob def = slot.partInSlot.validPaintJobs[0];
				PaintJob current = slot.slotPaint;
				if (def != current && DataUtility.Instance.IsCurrentPaint(slot))
				{
					count++;
				}
				if (count >= numPaintsToEquip)
				{
					Achieve();
					yield break;
				}
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	// RECUPERADO-AOT EquipPaintJobAchievementListener::Postrace token 0x060000e9 @0x000d15c4 (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT EquipPaintJobAchievementListener::Prerace token 0x060000ea @0x000d15f0 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT EquipPaintJobAchievementListener::Reward token 0x060000eb @0x000d161c
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: Triggered Equip Paintjob Achievement");
	}
}
