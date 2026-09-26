using System.Collections;
using System.Diagnostics;

public class LifetimeInAirAchievementListener : AchievementListener
{
	public float totalTimeRequired;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("LifetimeInAirAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("LifetimeInAirAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("LifetimeInAirAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("LifetimeInAirAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckAirTimeCoroutine()
	{
		RecoveryPending.Hit("LifetimeInAirAchievementListener.CheckAirTimeCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("LifetimeInAirAchievementListener.Start");
	}
}
