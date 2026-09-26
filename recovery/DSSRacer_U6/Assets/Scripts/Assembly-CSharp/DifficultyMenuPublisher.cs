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
		RecoveryPending.Hit("DifficultyMenuPublisher.CalculateCompletion");
		return default(float);
	}

	private void ShowPopover(string text)
	{
		RecoveryPending.Hit("DifficultyMenuPublisher.ShowPopover");
	}

	private void Start()
	{
		RecoveryPending.Hit("DifficultyMenuPublisher.Start");
	}

	private void PushedEasy()
	{
		RecoveryPending.Hit("DifficultyMenuPublisher.PushedEasy");
	}

	private void PushedMedium()
	{
		RecoveryPending.Hit("DifficultyMenuPublisher.PushedMedium");
	}

	private void PushedHard()
	{
		RecoveryPending.Hit("DifficultyMenuPublisher.PushedHard");
	}
}
