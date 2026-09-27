using UnityEngine;

// One achievement row: name, description (reward description once achieved), coin prize and check mark.
// Source listing: recovery/aot_listings/Assembly-CSharp/AchievementPanelPublisher.txt
public class AchievementPanelPublisher : UghPublisher
{
	public GameObject achievementWindowPrefab;

	private AchievementListener listener;

	public AchievementListener Achievement
	{
		// RECUPERADO-AOT AchievementPanelPublisher::get_Achievement token 0x060005c6 @0x0011d7a4
		get
		{
			return listener;
		}
		// RECUPERADO-AOT AchievementPanelPublisher::set_Achievement token 0x060005c7 @0x0011d7d8
		set
		{
			listener = value;
			Refresh();
		}
	}

	// RECUPERADO-AOT AchievementPanelPublisher::Refresh token 0x060005c8 @0x0011d818
	private void Refresh()
	{
		if (listener != null)
		{
			base.ughTexts["Name"].Text = listener.UIName.Text;
			base.ughTexts["Text"].Text = listener.description.Text;
			base.transforms["Prize"].gameObject.SetActive(true);
			if (listener.rewardCoins > 0)
			{
				base.ughTexts["Reward"].Text = listener.rewardCoins.ToString();
			}
			if (listener.HasAchieved())
			{
				base.transforms["CheckMark"].gameObject.SetActive(true);
				if (listener.rewardDescription.Text != null && listener.rewardDescription.Text.Length > 0)
				{
					base.ughTexts["Text"].Text = listener.rewardDescription.Text;
				}
			}
			else
			{
				base.transforms["CheckMark"].gameObject.SetActive(false);
			}
		}
		else
		{
			base.ughTexts["Name"].Text = string.Empty;
			base.ughTexts["Text"].Text = string.Empty;
			base.transforms["Prize"].gameObject.SetActive(false);
			base.transforms["CheckMark"].gameObject.SetActive(false);
		}
	}
}
