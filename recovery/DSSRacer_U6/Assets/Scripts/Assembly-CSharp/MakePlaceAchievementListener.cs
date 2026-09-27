using UnityEngine;

// In-race achievement: finish in zeroBasedPlace+1 or better on trackName at the given difficulty.
// Source listing: recovery/aot_listings/Assembly-CSharp/MakePlaceAchievementListener.txt
public class MakePlaceAchievementListener : AchievementListener
{
	public UnlocalizedString trackName;

	public RaceManager.RaceDifficultyLevel difficulty;

	// RECUPERADO-AOT MakePlaceAchievementListener::.ctor token 0x06000132 (field initializer)
	public int zeroBasedPlace = 2;

	// RECUPERADO-AOT MakePlaceAchievementListener::Start token 0x06000133 @0x000d2f8c
	private void Start()
	{
		state = AchievementState.ACTIVE;
	}

	// RECUPERADO-AOT MakePlaceAchievementListener::IsAvailable token 0x06000134 @0x000d2fc4
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
			return difficulty == DataUtility.Instance.localOptions.raceDifficulty;
		}
		return false;
	}

	// RECUPERADO-AOT MakePlaceAchievementListener::Prerace token 0x06000135 @0x000d3094 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT MakePlaceAchievementListener::Postrace token 0x06000136 @0x000d30c0
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public override void Postrace()
	{
		if (DataUtility.Instance.CurSettings.levelName.baseText != trackName.baseText || difficulty != DataUtility.Instance.localOptions.raceDifficulty)
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
		if (num <= zeroBasedPlace + 1)
		{
			Achieve();
		}
		else if (num == -1)
		{
			UnityEngine.Debug.LogError("Could not find player position!");
		}
	}

	// RECUPERADO-AOT MakePlaceAchievementListener::Reward token 0x06000137 @0x000d32bc
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: fired MakePlaceAchievementListener reward");
	}
}
