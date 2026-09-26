using System.Collections;

public class LifetimePowerupCollectionAchievementListener : AchievementListener
{
	public int numTimes;

	public bool purchased;

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
