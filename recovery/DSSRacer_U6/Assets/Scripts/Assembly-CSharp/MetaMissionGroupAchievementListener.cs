using System.Collections;
using System.Diagnostics;

public class MetaMissionGroupAchievementListener : AchievementListener
{
	public AchievementListener[] achievementPrefabGroup;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("MetaMissionGroupAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("MetaMissionGroupAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("MetaMissionGroupAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("MetaMissionGroupAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckCompletionCoroutine()
	{
		RecoveryPending.Hit("MetaMissionGroupAchievementListener.CheckCompletionCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("MetaMissionGroupAchievementListener.Start");
	}
}
