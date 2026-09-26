using UnityEngine;

// "Difficulty Select" menu: Easy / Medium / Hard with completion bars; locked levels show a popover.
// Source listing: recovery/aot_listings/Assembly-CSharp/DifficultyMenuPublisher.txt
public class DifficultyMenuPublisher : UghPublisher
{
	public MetaMissionGroupAchievementListener easyMetaAchievement;

	public MetaMissionGroupAchievementListener mediumMetaAchievement;

	public UghSpritePrototype disabledButtonSpritePrototype;

	public GameObject popoverPrefab;

	private GameObject activePopover;

	// RECUPERADO-AOT DifficultyMenuPublisher::CalculateCompletion token 0x06000655 @0x00129478
	private float CalculateCompletion(MetaMissionGroupAchievementListener listener)
	{
		float num = 0f;
		AchievementListener[] achievementPrefabGroup = listener.achievementPrefabGroup;
		foreach (AchievementListener achievementListener in achievementPrefabGroup)
		{
			if (achievementListener.HasAchieved())
			{
				num += 1f;
			}
		}
		return num / (float)listener.achievementPrefabGroup.Length;
	}

	// RECUPERADO-AOT DifficultyMenuPublisher::ShowPopover token 0x06000656 @0x00129574
	private void ShowPopover(string text)
	{
		if (!(activePopover != null))
		{
			activePopover = Script.Instantiate(popoverPrefab);
			PopoverPublisher component = activePopover.GetComponent<PopoverPublisher>();
			component.SetText(text);
		}
	}

	// RECUPERADO-AOT DifficultyMenuPublisher::Start token 0x06000657 @0x00129604
	private void Start()
	{
		Vector3 localScale = base.ughSprites[0].transform.localScale;
		localScale.x *= CalculateCompletion(easyMetaAchievement);
		base.ughSprites[0].transform.localScale = localScale;
		base.ughSprites[0].UpdateMesh();
		localScale = base.ughSprites[1].transform.localScale;
		localScale.x *= CalculateCompletion(mediumMetaAchievement);
		base.ughSprites[1].transform.localScale = localScale;
		base.ughSprites[1].UpdateMesh();
		if (!DataUtility.Instance.IsUnlocked("Medium Difficulty"))
		{
			base.ughButtons["MediumButton"].normal = disabledButtonSpritePrototype;
			base.ughButtons["MediumButton"].pressed = null;
			base.ughButtons["MediumButton"].UpdateMesh();
		}
		if (!DataUtility.Instance.IsUnlocked("Hard Difficulty"))
		{
			base.ughButtons["HardButton"].normal = disabledButtonSpritePrototype;
			base.ughButtons["HardButton"].pressed = null;
			base.ughButtons["HardButton"].UpdateMesh();
		}
	}

	// RECUPERADO-AOT DifficultyMenuPublisher::PushedEasy token 0x06000658 @0x00129948
	private void PushedEasy()
	{
		DataUtility.Instance.localOptions.raceDifficulty = RaceManager.RaceDifficultyLevel.EASY;
		FrontEndLogic.RequestMenuChange("Circuit Select");
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT DifficultyMenuPublisher::PushedMedium token 0x06000659 @0x001299ac
	private void PushedMedium()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		if (!DataUtility.Instance.IsUnlocked("Medium Difficulty"))
		{
			ShowPopover(Localize.Get("Unlock Medium difficulty by placing 3rd or better on all tracks with Easy difficulty."));
			return;
		}
		DataUtility.Instance.localOptions.raceDifficulty = RaceManager.RaceDifficultyLevel.MEDIUM;
		FrontEndLogic.RequestMenuChange("Circuit Select");
	}

	// RECUPERADO-AOT DifficultyMenuPublisher::PushedHard token 0x0600065a @0x00129a60
	private void PushedHard()
	{
		if (!DataUtility.Instance.IsUnlocked("Hard Difficulty"))
		{
			ShowPopover(Localize.Get("Unlock Hard difficulty by placing 3rd or better on all tracks with Medium difficulty."));
			return;
		}
		DataUtility.Instance.localOptions.raceDifficulty = RaceManager.RaceDifficultyLevel.HARD;
		FrontEndLogic.RequestMenuChange("Circuit Select");
		SoundLibrary.ButtonClickPlay("menuButton1");
	}
}
