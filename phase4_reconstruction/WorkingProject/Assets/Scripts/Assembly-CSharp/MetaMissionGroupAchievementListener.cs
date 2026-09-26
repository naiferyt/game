using System.Collections;

public class MetaMissionGroupAchievementListener : AchievementListener
{
	public AchievementListener[] achievementPrefabGroup;

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
	private IEnumerator CheckCompletionCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}
}
