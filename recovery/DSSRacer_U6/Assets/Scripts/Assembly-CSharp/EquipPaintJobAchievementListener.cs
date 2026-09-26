using System.Collections;
using System.Diagnostics;

public class EquipPaintJobAchievementListener : AchievementListener
{
	public int numPaintsToEquip;

	private void Start()
	{
		RecoveryPending.Hit("EquipPaintJobAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("EquipPaintJobAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("EquipPaintJobAchievementListener.IsAvailable");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator CheckPaintJobs()
	{
		RecoveryPending.Hit("EquipPaintJobAchievementListener.CheckPaintJobs");
		yield break;
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("EquipPaintJobAchievementListener.Postrace");
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("EquipPaintJobAchievementListener.Prerace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("EquipPaintJobAchievementListener.Reward");
	}
}
