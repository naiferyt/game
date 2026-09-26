using System.Collections;
using System.Diagnostics;

public class HitMaxSpeedAchievementListener : AchievementListener
{
	public float targetSpeed;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("HitMaxSpeedAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("HitMaxSpeedAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("HitMaxSpeedAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("HitMaxSpeedAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckMaxSpeedCoroutine()
	{
		RecoveryPending.Hit("HitMaxSpeedAchievementListener.CheckMaxSpeedCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("HitMaxSpeedAchievementListener.Start");
	}
}
