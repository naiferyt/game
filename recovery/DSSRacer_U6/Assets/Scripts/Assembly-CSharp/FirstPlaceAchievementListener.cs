using UnityEngine;

// In-race achievement: finish 1st on trackName (any track when empty) in the given race mode.
// Source listing: recovery/aot_listings/Assembly-CSharp/FirstPlaceAchievementListener.txt
public class FirstPlaceAchievementListener : AchievementListener
{
	public UnlocalizedString trackName;

	public RaceSettings.RaceModes mode;

	// RECUPERADO-AOT FirstPlaceAchievementListener::Start token 0x060000f4 @0x000d183c
	private void Start()
	{
		state = AchievementState.ACTIVE;
	}

	// RECUPERADO-AOT FirstPlaceAchievementListener::IsAvailable token 0x060000f5 @0x000d1874
	public override bool IsAvailable()
	{
		if (HasAchieved())
		{
			return false;
		}
		RaceSettings curSettings = DataUtility.Instance.CurSettings;
		if (curSettings == null)
		{
			return false;
		}
		if (curSettings.levelName.baseText == trackName.baseText)
		{
			return true;
		}
		if (trackName.baseText == string.Empty)
		{
			return curSettings.raceType == mode;
		}
		return false;
	}

	// RECUPERADO-AOT FirstPlaceAchievementListener::Prerace token 0x060000f6 @0x000d196c (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT FirstPlaceAchievementListener::Postrace token 0x060000f7 @0x000d1998
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public override void Postrace()
	{
		if (DataUtility.Instance.CurSettings.raceType != mode || (DataUtility.Instance.CurSettings.levelName.baseText != trackName.baseText && mode == RaceSettings.RaceModes.Campaign))
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
		if (num == 1)
		{
			Achieve();
		}
		else if (num == -1)
		{
			UnityEngine.Debug.LogError("Could not find player position!");
		}
	}

	// RECUPERADO-AOT FirstPlaceAchievementListener::Reward token 0x060000f8 @0x000d1b9c
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: fired FirstPlaceAchievementListener reward");
	}
}
