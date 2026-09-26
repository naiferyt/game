using System.Collections;

public class CoinBalanceAchievementListener : AchievementListener
{
	public int balance;

	public override bool IsAvailable()
	{
		return default(bool);
	}

	public override void Prerace()
	{
	}

	public override void Postrace()
	{
	}

	public override void Reward()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CheckCoinBalanceCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}
}
