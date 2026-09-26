using UnityEngine;

public class DifficultyMenuPublisher : UghPublisher
{
	public MetaMissionGroupAchievementListener easyMetaAchievement;

	public MetaMissionGroupAchievementListener mediumMetaAchievement;

	public UghSpritePrototype disabledButtonSpritePrototype;

	public GameObject popoverPrefab;

	private GameObject activePopover;

	private float CalculateCompletion(MetaMissionGroupAchievementListener listener)
	{
		return default(float);
	}

	private void ShowPopover(string text)
	{
	}

	private void Start()
	{
	}

	private void PushedEasy()
	{
	}

	private void PushedMedium()
	{
	}

	private void PushedHard()
	{
	}
}
