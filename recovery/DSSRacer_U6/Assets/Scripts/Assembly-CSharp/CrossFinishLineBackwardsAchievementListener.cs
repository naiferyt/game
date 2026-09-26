public class CrossFinishLineBackwardsAchievementListener : AchievementListener
{
	public override bool IsAvailable()
	{
		RecoveryPending.Hit("CrossFinishLineBackwardsAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("CrossFinishLineBackwardsAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("CrossFinishLineBackwardsAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("CrossFinishLineBackwardsAchievementListener.Reward");
	}

	private void Start()
	{
		RecoveryPending.Hit("CrossFinishLineBackwardsAchievementListener.Start");
	}
}
