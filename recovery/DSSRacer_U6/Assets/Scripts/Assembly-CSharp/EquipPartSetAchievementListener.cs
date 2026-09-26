using System.Collections;
using System.Diagnostics;

public class EquipPartSetAchievementListener : AchievementListener
{
	public CartPart[] partSet;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("EquipPartSetAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("EquipPartSetAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("EquipPartSetAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("EquipPartSetAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckCartSet()
	{
		RecoveryPending.Hit("EquipPartSetAchievementListener.CheckCartSet");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("EquipPartSetAchievementListener.Start");
	}
}
