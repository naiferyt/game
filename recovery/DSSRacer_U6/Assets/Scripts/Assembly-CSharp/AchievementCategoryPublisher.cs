public class AchievementCategoryPublisher : UghPublisher
{
	private void Start()
	{
		RecoveryPending.Hit("AchievementCategoryPublisher.Start");
	}

	private void OnPressedTracks()
	{
		RecoveryPending.Hit("AchievementCategoryPublisher.OnPressedTracks");
	}

	private void OnPressedCoins()
	{
		RecoveryPending.Hit("AchievementCategoryPublisher.OnPressedCoins");
	}

	private void OnPressedStunts()
	{
		RecoveryPending.Hit("AchievementCategoryPublisher.OnPressedStunts");
	}

	private void OnPressedPowerups()
	{
		RecoveryPending.Hit("AchievementCategoryPublisher.OnPressedPowerups");
	}
}
