public class LastPlaceAchievementListener : AchievementListener
{
	public UnlocalizedString trackName;

	private void Start()
	{
		RecoveryPending.Hit("LastPlaceAchievementListener.Start");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("LastPlaceAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("LastPlaceAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("LastPlaceAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("LastPlaceAchievementListener.Reward");
	}

	private void Update()
	{
		RecoveryPending.Hit("LastPlaceAchievementListener.Update");
	}
}
