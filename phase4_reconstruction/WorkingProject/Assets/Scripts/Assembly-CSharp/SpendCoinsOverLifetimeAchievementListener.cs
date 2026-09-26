using System.Collections;

public class SpendCoinsOverLifetimeAchievementListener : AchievementListener
{
	public int numberOfCoins;

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
	private IEnumerator CheckSpentCoinsCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}
}
