using System.Collections;
using System.Diagnostics;

public class PickupCoinsPerRaceAchievementListener : AchievementListener
{
	public int numCoins;

	private void Start()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.Prerace");
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckCarMetrics()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.CheckCarMetrics");
		return default(bool);
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("PickupCoinsPerRaceAchievementListener.Reward");
	}
}
