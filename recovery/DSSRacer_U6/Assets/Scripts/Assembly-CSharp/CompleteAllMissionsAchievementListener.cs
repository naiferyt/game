using System.Collections;
using System.Diagnostics;

public class CompleteAllMissionsAchievementListener : AchievementListener
{
	public override bool IsAvailable()
	{
		RecoveryPending.Hit("CompleteAllMissionsAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("CompleteAllMissionsAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("CompleteAllMissionsAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("CompleteAllMissionsAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckAllMissionsCoroutine()
	{
		RecoveryPending.Hit("CompleteAllMissionsAchievementListener.CheckAllMissionsCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("CompleteAllMissionsAchievementListener.Start");
	}
}
