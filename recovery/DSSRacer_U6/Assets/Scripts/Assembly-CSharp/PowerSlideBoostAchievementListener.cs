using System.Collections;
using System.Diagnostics;

public class PowerSlideBoostAchievementListener : AchievementListener
{
	public int numTimes;

	private CarMetrics metrics;

	private void Start()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.IsAvailable");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.CheckMetrics");
		return default(bool);
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.Postrace");
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.Prerace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("PowerSlideBoostAchievementListener.Reward");
	}
}
