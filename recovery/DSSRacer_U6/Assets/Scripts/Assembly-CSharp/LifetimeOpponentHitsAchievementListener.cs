using System.Collections;
using System.Diagnostics;

public class LifetimeOpponentHitsAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes type;

	public int numTimes;

	private void Start()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.Postrace");
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.CheckMetrics");
		return default(bool);
	}

	public override void Reward()
	{
		RecoveryPending.Hit("LifetimeOpponentHitsAchievementListener.Reward");
	}
}
