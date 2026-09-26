using System.Collections;
using System.Diagnostics;

public class PowerupHitInAirAchievementListener : AchievementListener
{
	public int numTimes;

	private void Start()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.IsAvailable");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.CheckMetrics");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("PowerupHitInAirAchievementListener.Reward");
	}
}
