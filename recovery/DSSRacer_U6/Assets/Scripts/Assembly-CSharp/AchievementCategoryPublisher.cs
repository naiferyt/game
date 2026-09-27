// Achievements menu: "achieved/total" per category and buttons that open the filtered list.
// Source listing: recovery/aot_listings/Assembly-CSharp/AchievementCategoryPublisher.txt
public class AchievementCategoryPublisher : UghPublisher
{
	// RECUPERADO-AOT AchievementCategoryPublisher::Start token 0x060005c0 @0x0011d1c4
	// Note (original): the counters are indexed by category and sized by the achievement count; the power-ups
	// line reads category 0 (UNKNOWN), matching OnPressedPowerups.
	private void Start()
	{
		AchievementListener[] allAchievements = AchievementManager.Instance.AllAchievements;
		int[] array = new int[allAchievements.Length];
		int[] array2 = new int[allAchievements.Length];
		for (int i = 0; i < allAchievements.Length; i++)
		{
			array2[i] = 0;
			array[i] = 0;
		}
		for (int j = 0; j < allAchievements.Length; j++)
		{
			array[(int)allAchievements[j].categoryFilter]++;
			if (allAchievements[j].HasAchieved())
			{
				array2[(int)allAchievements[j].categoryFilter]++;
			}
		}
		base.ughTexts["Tracks Complete"].Text = array2[1].ToString() + "/" + array[1].ToString();
		base.ughTexts["Coins Complete"].Text = array2[2].ToString() + "/" + array[2].ToString();
		base.ughTexts["Stunts Complete"].Text = array2[4].ToString() + "/" + array[4].ToString();
		base.ughTexts["Powerups Complete"].Text = array2[0].ToString() + "/" + array[0].ToString();
	}

	// RECUPERADO-AOT AchievementCategoryPublisher::OnPressedTracks token 0x060005c1 @0x0011d5c0
	private void OnPressedTracks()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		AchievementManager.achievementUIFilter = AchievementListener.AchievementFilterCategory.TRACKS;
		FrontEndLogic.RequestMenuChange("Achievements");
	}

	// RECUPERADO-AOT AchievementCategoryPublisher::OnPressedCoins token 0x060005c2 @0x0011d62c
	private void OnPressedCoins()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		AchievementManager.achievementUIFilter = AchievementListener.AchievementFilterCategory.COINS;
		FrontEndLogic.RequestMenuChange("Achievements");
	}

	// RECUPERADO-AOT AchievementCategoryPublisher::OnPressedStunts token 0x060005c3 @0x0011d698
	private void OnPressedStunts()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		AchievementManager.achievementUIFilter = AchievementListener.AchievementFilterCategory.STUNTS;
		FrontEndLogic.RequestMenuChange("Achievements");
	}

	// RECUPERADO-AOT AchievementCategoryPublisher::OnPressedPowerups token 0x060005c4 @0x0011d704
	private void OnPressedPowerups()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		AchievementManager.achievementUIFilter = AchievementListener.AchievementFilterCategory.UNKNOWN;
		FrontEndLogic.RequestMenuChange("Achievements");
	}
}
