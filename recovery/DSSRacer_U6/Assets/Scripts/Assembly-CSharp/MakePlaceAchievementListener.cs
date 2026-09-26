public class MakePlaceAchievementListener : AchievementListener
{
	public UnlocalizedString trackName;

	public RaceManager.RaceDifficultyLevel difficulty;

	public int zeroBasedPlace;

	private void Start()
	{
		RecoveryPending.Hit("MakePlaceAchievementListener.Start");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("MakePlaceAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("MakePlaceAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("MakePlaceAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("MakePlaceAchievementListener.Reward");
	}
}
