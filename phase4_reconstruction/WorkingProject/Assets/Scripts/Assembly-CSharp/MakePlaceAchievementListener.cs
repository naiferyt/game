public class MakePlaceAchievementListener : AchievementListener
{
	public UnlocalizedString trackName;

	public RaceManager.RaceDifficultyLevel difficulty;

	public int zeroBasedPlace;

	private void Start()
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

	public override void Reward()
	{
	}
}
