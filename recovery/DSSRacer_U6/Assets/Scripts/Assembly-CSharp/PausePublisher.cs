using UnityEngine;

// Pause screen: resume, restart (reloads through Loading) or quit to the garage; lists the race's missions.
// Source listing: recovery/aot_listings/Assembly-CSharp/PausePublisher.txt
public class PausePublisher : UghPublisher
{
	// RECUPERADO-AOT PausePublisher::Start token 0x0600078c @0x0013d0e8
	private void Start()
	{
		ScreenTimeoutController.AllowSleep();
		// ELIMINADO (servicio iOS/externo): GDMOManager.SendWithContext("game_action", {"player_id",
		// "context": <pista actual>, "action": "pause", ...}) (analitica).
		SetupMissionText();
	}

	// RECUPERADO-AOT PausePublisher::PressedResumeButton token 0x0600078d @0x0013d254
	private void PressedResumeButton()
	{
		RaceManager.PauseRace(false);
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT PausePublisher::PressedQuitButton token 0x0600078e @0x0013d294
	private void PressedQuitButton()
	{
		// ELIMINADO (servicio iOS/externo): GDMOManager.SendWithContext("game_action", {..., "action": "quit"}).
		RaceManager.CleanupRace();
		ScreenFader.Instance.LoadLevel("PreFrontEnd");
	}

	// RECUPERADO-AOT PausePublisher::PressedRestartButton token 0x0600078f @0x0013d41c
	private void PressedRestartButton()
	{
		RaceManager.CleanupRace();
		ScreenFader.Instance.LoadLevel("Loading");
	}

	// RECUPERADO-AOT PausePublisher::SetupMissionText token 0x06000790 @0x0013d470
	public void SetupMissionText()
	{
		AchievementManager instance = AchievementManager.Instance;
		if (instance.activeListeners == null || instance.activeListeners.Length <= 0 || DataUtility.Instance.CurSettings.UIName.baseText.Contains("Tutorial"))
		{
			base.transforms["Mission 1 Panel"].gameObject.SetActive(false);
			base.transforms["Mission 2 Panel"].gameObject.SetActive(false);
			base.transforms["Mission 3 Panel"].gameObject.SetActive(false);
			base.ughTexts["Text"].Text = string.Empty;
			base.transforms["Tutorial Logo"].gameObject.SetActive(true);
			return;
		}
		base.transforms["Tutorial Logo"].gameObject.SetActive(false);
		base.transforms["Mission 1 Prize"].gameObject.SetActive(true);
		base.transforms["Mission 2 Prize"].gameObject.SetActive(true);
		base.transforms["Mission 3 Prize"].gameObject.SetActive(true);
		for (int i = 0; i < Mathf.Min(3, instance.activeListeners.Length); i++)
		{
			AchievementListener achievementListener = instance.activeListeners[i];
			base.ughTexts["Mission " + (i + 1) + " Name"].Text = achievementListener.UIName.Text;
			base.ughTexts["Mission " + (i + 1) + " Text"].Text = achievementListener.description.Text;
			base.ughTexts["Mission " + (i + 1) + " Prize"].Text = achievementListener.rewardCoins.ToString();
			if (achievementListener.HasAchieved())
			{
				base.transforms["Mission " + (i + 1) + " Check"].gameObject.SetActive(true);
				continue;
			}
			if (achievementListener.rewardCoins > 0)
			{
				base.transforms["Mission " + (i + 1) + " Prize"].gameObject.SetActive(true);
			}
			else
			{
				base.transforms["Mission " + (i + 1) + " Prize"].gameObject.SetActive(false);
			}
			base.transforms["Mission " + (i + 1) + " Check"].gameObject.SetActive(false);
		}
	}

	// RECUPERADO-AOT PausePublisher::OnDestroy token 0x06000791 @0x0013dc08
	private void OnDestroy()
	{
		ScreenTimeoutController.SupressSleep(600f);
	}
}
