using UnityEngine;

public class AchievementPanelPublisher : UghPublisher
{
	public GameObject achievementWindowPrefab;

	private AchievementListener listener;

	public AchievementListener Achievement
	{
		get
		{
			RecoveryPending.Hit("AchievementPanelPublisher.get_Achievement");
			return default(AchievementListener);
		}
		set
		{
			RecoveryPending.Hit("AchievementPanelPublisher.set_Achievement");
		}
	}

	private void Refresh()
	{
		RecoveryPending.Hit("AchievementPanelPublisher.Refresh");
	}
}
