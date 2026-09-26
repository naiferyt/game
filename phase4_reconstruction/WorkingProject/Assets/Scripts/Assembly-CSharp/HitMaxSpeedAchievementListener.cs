using System.Collections;

public class HitMaxSpeedAchievementListener : AchievementListener
{
	public float targetSpeed;

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
	private IEnumerator CheckMaxSpeedCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}
}
