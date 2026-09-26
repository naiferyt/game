using System.Collections;
using System.Diagnostics;

public class LifetimePowerupCollectionAchievementListener : AchievementListener
{
	public int numTimes;

	public bool purchased;

	private void Start()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.Postrace");
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.CheckMetrics");
		return default(bool);
	}

	public override void Reward()
	{
		RecoveryPending.Hit("LifetimePowerupCollectionAchievementListener.Reward");
	}
}
