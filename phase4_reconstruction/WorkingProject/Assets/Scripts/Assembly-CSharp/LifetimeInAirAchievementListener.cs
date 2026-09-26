using System.Collections;

public class LifetimeInAirAchievementListener : AchievementListener
{
	public float totalTimeRequired;

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
	private IEnumerator CheckAirTimeCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}
}
