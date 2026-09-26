using System.Collections;
using System.Diagnostics;

public class MaxCrashSpeedAchievementListener : AchievementListener
{
	public float targetSpeed;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("MaxCrashSpeedAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("MaxCrashSpeedAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("MaxCrashSpeedAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("MaxCrashSpeedAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckMaxCrashSpeedCoroutine()
	{
		RecoveryPending.Hit("MaxCrashSpeedAchievementListener.CheckMaxCrashSpeedCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("MaxCrashSpeedAchievementListener.Start");
	}
}
