public class PlaceWithNoPowerupsAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes[] typesToAvoid;

	public bool firstOnly;

	public int zeroBasedPlace;

	private void Start()
	{
	}

	public override bool IsAvailable()
	{
		return default(bool);
	}

	private void Update()
	{
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

	private bool CheckPowerupPass()
	{
		return default(bool);
	}
}
