using UnityEngine;

// In-race achievement: finish last on trackName.
// Source listing: recovery/aot_listings/Assembly-CSharp/LastPlaceAchievementListener.txt
public class LastPlaceAchievementListener : AchievementListener
{
	public UnlocalizedString trackName;

	// RECUPERADO-AOT LastPlaceAchievementListener::Start token 0x06000113 @0x000d248c
	private void Start()
	{
		state = AchievementState.ACTIVE;
	}

	// RECUPERADO-AOT LastPlaceAchievementListener::IsAvailable token 0x06000114 @0x000d24c4
	public override bool IsAvailable()
	{
		if (HasAchieved())
		{
			return false;
		}
		if (DataUtility.Instance.CurSettings != null)
		{
			return DataUtility.Instance.CurSettings.levelName.baseText == trackName.baseText;
		}
		return false;
	}

	// RECUPERADO-AOT LastPlaceAchievementListener::Prerace token 0x06000115 @0x000d255c (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT LastPlaceAchievementListener::Postrace token 0x06000116 @0x000d2588
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public override void Postrace()
	{
		if (DataUtility.Instance.CurSettings.levelName.baseText != trackName.baseText)
		{
			return;
		}
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
		if (num == DataUtility.Instance.CurSettings.numberAICars + 1)
		{
			Achieve();
		}
		else if (num == -1)
		{
			UnityEngine.Debug.LogError("Could not find player position!");
		}
	}

	// RECUPERADO-AOT LastPlaceAchievementListener::Reward token 0x06000117 @0x000d2768
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: fired LastPlaceAchievementListener reward");
	}

	// RECUPERADO-AOT LastPlaceAchievementListener::Update token 0x06000118 @0x000d27a8 (empty)
	private void Update()
	{
	}
}
