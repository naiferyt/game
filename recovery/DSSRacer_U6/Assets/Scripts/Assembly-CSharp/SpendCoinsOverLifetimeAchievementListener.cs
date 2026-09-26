using System.Collections;
using System.Diagnostics;

public class SpendCoinsOverLifetimeAchievementListener : AchievementListener
{
	public int numberOfCoins;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("SpendCoinsOverLifetimeAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("SpendCoinsOverLifetimeAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("SpendCoinsOverLifetimeAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("SpendCoinsOverLifetimeAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckSpentCoinsCoroutine()
	{
		RecoveryPending.Hit("SpendCoinsOverLifetimeAchievementListener.CheckSpentCoinsCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("SpendCoinsOverLifetimeAchievementListener.Start");
	}
}
