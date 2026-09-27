using UnityEngine;

// In-race achievement: finish in zeroBasedPlace+1 or better (1st when firstOnly) without using any power-up.
// Source listing: recovery/aot_listings/Assembly-CSharp/PlaceWithNoPowerupsAchievementListener.txt
public class PlaceWithNoPowerupsAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes[] typesToAvoid;

	public bool firstOnly;

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::.ctor token 0x0600014f (field initializer)
	public int zeroBasedPlace = 2;

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::Start token 0x06000150 @0x000d3988
	private void Start()
	{
		state = AchievementState.ACTIVE;
	}

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::IsAvailable token 0x06000151 @0x000d39c0
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::Update token 0x06000152 @0x000d3a08 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::Prerace token 0x06000153 @0x000d3a34 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::Postrace token 0x06000154 @0x000d3a60
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	// Note (original): firstOnly overwrites the zeroBasedPlace field itself.
	public override void Postrace()
	{
		RaceResults raceResults = (RaceResults)U4Compat.FindObjectOfType(typeof(RaceResults));
		if (raceResults == null)
		{
			UnityEngine.Debug.LogError("Could not find a RaceResults!");
			return;
		}
		GameObject playerCar = RaceManager.GetPlayerCar();
		int num = -1;
		CarProgress[] ordredResultList = raceResults.ordredResultList;
		foreach (CarProgress carProgress in ordredResultList)
		{
			if (carProgress.carName == playerCar.name)
			{
				num = carProgress.finalPlace;
				break;
			}
		}
		if (firstOnly)
		{
			zeroBasedPlace = 0;
		}
		if (num <= zeroBasedPlace + 1 && CheckPowerupPass())
		{
			Achieve();
		}
		else if (num == -1)
		{
			UnityEngine.Debug.LogError("Could not find player position!");
		}
	}

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::Reward token 0x06000155 @0x000d3c20
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: Triggered Place with no powerups collected achievement");
	}

	// RECUPERADO-AOT PlaceWithNoPowerupsAchievementListener::CheckPowerupPass token 0x06000156 @0x000d3c60
	private bool CheckPowerupPass()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar == null)
		{
			return false;
		}
		CarMetrics component = playerCar.GetComponent<CarMetrics>();
		if (component != null && component.otherMetrics.ContainsKey("Powerup Used") && component.otherMetrics["Powerup Used"] > 0f)
		{
			return false;
		}
		return true;
	}
}
