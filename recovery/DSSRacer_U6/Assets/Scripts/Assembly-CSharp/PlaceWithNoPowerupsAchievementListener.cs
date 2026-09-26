public class PlaceWithNoPowerupsAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes[] typesToAvoid;

	public bool firstOnly;

	public int zeroBasedPlace;

	private void Start()
	{
		RecoveryPending.Hit("PlaceWithNoPowerupsAchievementListener.Start");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("PlaceWithNoPowerupsAchievementListener.IsAvailable");
		return default(bool);
	}

	private void Update()
	{
		RecoveryPending.Hit("PlaceWithNoPowerupsAchievementListener.Update");
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("PlaceWithNoPowerupsAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("PlaceWithNoPowerupsAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("PlaceWithNoPowerupsAchievementListener.Reward");
	}

	private bool CheckPowerupPass()
	{
		RecoveryPending.Hit("PlaceWithNoPowerupsAchievementListener.CheckPowerupPass");
		return default(bool);
	}
}
