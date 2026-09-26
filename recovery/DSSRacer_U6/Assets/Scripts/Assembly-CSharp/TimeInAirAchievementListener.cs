using System.Collections;
using System.Diagnostics;

public class TimeInAirAchievementListener : AchievementListener
{
	public float totalTimeRequired;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("TimeInAirAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("TimeInAirAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("TimeInAirAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("TimeInAirAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckAirTimeCoroutine()
	{
		RecoveryPending.Hit("TimeInAirAchievementListener.CheckAirTimeCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("TimeInAirAchievementListener.Start");
	}
}
