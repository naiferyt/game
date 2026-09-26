using UnityEngine;

public class AchievementPanelPublisher : UghPublisher
{
	public GameObject achievementWindowPrefab;

	private AchievementListener listener;

	public AchievementListener Achievement
	{
		get
		{
			return default(AchievementListener);
		}
		set
		{
		}
	}

	private void Refresh()
	{
	}
}
