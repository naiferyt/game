using System.Collections;
using System.Diagnostics;

public class GetHitByTrackHazardAchievementListener : AchievementListener
{
	public int numTimes;

	public UnlocalizedString hazardType;

	public UnlocalizedString trackName;

	private void Start()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.IsAvailable");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.CheckMetrics");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("GetHitByTrackHazardAchievementListener.Reward");
	}
}
