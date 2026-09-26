using System.Collections;

public class LifetimeOpponentHitsAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes type;

	public int numTimes;

	private void Start()
	{
	}

	private void Update()
	{
	}

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

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		return default(IEnumerator);
	}

	private bool CheckMetrics()
	{
		return default(bool);
	}

	public override void Reward()
	{
	}
}
