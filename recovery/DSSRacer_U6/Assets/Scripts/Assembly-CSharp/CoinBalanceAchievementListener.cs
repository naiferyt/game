using System.Collections;
using System.Diagnostics;

public class CoinBalanceAchievementListener : AchievementListener
{
	public int balance;

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("CoinBalanceAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("CoinBalanceAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("CoinBalanceAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("CoinBalanceAchievementListener.Reward");
	}

	[DebuggerHidden]
	private IEnumerator CheckCoinBalanceCoroutine()
	{
		RecoveryPending.Hit("CoinBalanceAchievementListener.CheckCoinBalanceCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("CoinBalanceAchievementListener.Start");
	}
}
