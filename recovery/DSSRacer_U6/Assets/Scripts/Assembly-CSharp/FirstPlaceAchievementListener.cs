public class FirstPlaceAchievementListener : AchievementListener
{
	public UnlocalizedString trackName;

	public RaceSettings.RaceModes mode;

	private void Start()
	{
		RecoveryPending.Hit("FirstPlaceAchievementListener.Start");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("FirstPlaceAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("FirstPlaceAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("FirstPlaceAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("FirstPlaceAchievementListener.Reward");
	}
}
