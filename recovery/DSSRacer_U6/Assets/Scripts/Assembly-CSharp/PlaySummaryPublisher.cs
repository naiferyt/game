using System;
using System.Collections.Generic;
using UnityEngine;

// Pre-race summary for tracks with race options: track name and snapshot, race mode and difficulty pickers.
// Source listing: recovery/aot_listings/Assembly-CSharp/PlaySummaryPublisher.txt
public class PlaySummaryPublisher : UghPublisher
{
	public GameObject popoverPrefab;

	// RECUPERADO-AOT PlaySummaryPublisher::.ctor token 0x060006b7 @0x0012f414 (field initializers)
	private float transitionTimer = 1f;

	private float transitionSpeed = 4f;

	public List<TrackSelectPublisher.TrackIcon> trackIcons;

	// RECUPERADO-AOT PlaySummaryPublisher::Refresh token 0x060006b8 @0x0012f478
	// Mode texts follow RaceModes: Campaign -> "Race", Mission -> "Tutorial", Elimination -> "Elimination".
	private void Refresh()
	{
		string text = "ERROR";
		string text2 = "ERROR";
		switch (DataUtility.Instance.CurSettings.raceType)
		{
		case RaceSettings.RaceModes.Campaign:
			text = Localize.Get("Race");
			text2 = Localize.Get("Be the first to cross the finish line.");
			break;
		case RaceSettings.RaceModes.Elimination:
			text = Localize.Get("Elimination");
			text2 = Localize.Get("Each lap the last-place cart gets knocked out.");
			break;
		case RaceSettings.RaceModes.Mission:
			text = Localize.Get("Tutorial");
			text2 = Localize.Get("Follow your mission to complete the race.");
			break;
		}
		base.ughTexts["Mode Text"].Text = text;
		base.ughTexts["Mode Description"].Text = text2;
		string text3 = "ERROR";
		string text4 = "ERROR";
		switch (DataUtility.Instance.localOptions.raceDifficulty)
		{
		case RaceManager.RaceDifficultyLevel.EASY:
			text3 = Localize.Get("Easy");
			text4 = Localize.Get("Score x1 tokens.");
			break;
		case RaceManager.RaceDifficultyLevel.MEDIUM:
			text3 = Localize.Get("Medium");
			text4 = Localize.Get("Score x2 tokens.");
			break;
		case RaceManager.RaceDifficultyLevel.HARD:
			text3 = Localize.Get("Hard");
			text4 = Localize.Get("Score x4 tokens.");
			break;
		case RaceManager.RaceDifficultyLevel.NINTENDO_HARD:
			text3 = Localize.Get("Ultra Hard");
			text4 = Localize.Get("Score x6 tokens.");
			break;
		}
		base.ughTexts["Difficulty"].Text = text3;
		base.ughTexts["Difficulty Description"].Text = text4;
		UpdateTrackIcon();
	}

	// RECUPERADO-AOT PlaySummaryPublisher::Start token 0x060006b9 @0x0012f798
	private void Start()
	{
		base.ughTexts["Track Name"].Text = DataUtility.Instance.CurSettings.UIName.Text;
		Refresh();
		base.transforms["Left Side Collection"].localPosition = base.transforms["Top Left"].localPosition + new Vector3(-7.4f, 0f, 0f);
		base.transforms["Right Side Collection"].localPosition = base.transforms["Top Right"].localPosition + new Vector3(7.4f, 0f, 0f);
	}

	// RECUPERADO-AOT PlaySummaryPublisher::FixedUpdate token 0x060006ba @0x0012fa70
	private void FixedUpdate()
	{
		if (transitionTimer > 0f)
		{
			transitionTimer -= Time.deltaTime * transitionSpeed;
			if (transitionTimer < 0f)
			{
				transitionTimer = 0f;
				FrontEndTutorialHandler component = GetComponent<FrontEndTutorialHandler>();
				if (component != null)
				{
					component.ActiveTutorial = true;
				}
			}
			base.transforms["Left Side Collection"].localPosition = Vector3.Lerp(base.transforms["Top Left"].localPosition + new Vector3(-7.4f, 0f, 0f), Vector3.zero, 1f - transitionTimer);
			base.transforms["Right Side Collection"].localPosition = Vector3.Lerp(base.transforms["Top Right"].localPosition + new Vector3(7.4f, 0f, 0f), Vector3.zero, 1f - transitionTimer);
		}
	}

	// RECUPERADO-AOT PlaySummaryPublisher::PressedPlayButton token 0x060006bb @0x0012fe98
	private void PressedPlayButton()
	{
		DataUtility.Instance.CurSettings.lapNumber = -1;
		PreviewCart.StartDriveout();
		base.gameObject.SetActive(false);
	}

	// RECUPERADO-AOT PlaySummaryPublisher::PressedModeArrowLeft token 0x060006bc @0x0012fef8
	// Mission (tutorial) mode is skipped.
	private void PressedModeArrowLeft()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		int num = (int)(DataUtility.Instance.CurSettings.raceType - 1);
		if (num == 1)
		{
			num--;
		}
		if (num < 0)
		{
			num = Enum.GetValues(typeof(RaceSettings.RaceModes)).Length - 1;
		}
		DataUtility.Instance.CurSettings.raceType = (RaceSettings.RaceModes)num;
		Refresh();
	}

	// RECUPERADO-AOT PlaySummaryPublisher::PressedModeArrowRight token 0x060006bd @0x0012ffb0
	private void PressedModeArrowRight()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		int num = (int)(DataUtility.Instance.CurSettings.raceType + 1);
		if (num == 1)
		{
			num++;
		}
		if (num >= Enum.GetValues(typeof(RaceSettings.RaceModes)).Length)
		{
			num = 0;
		}
		DataUtility.Instance.CurSettings.raceType = (RaceSettings.RaceModes)num;
		Refresh();
	}

	// RECUPERADO-AOT PlaySummaryPublisher::PressedDifficultyArrowLeft token 0x060006be @0x00130068
	// Ultra Hard (3) is only offered once TestForUltraHard passes.
	private void PressedDifficultyArrowLeft()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		Array values = Enum.GetValues(typeof(RaceManager.RaceDifficultyLevel));
		int num = (int)DataUtility.Instance.localOptions.raceDifficulty;
		while (true)
		{
			num--;
			if (num < 0)
			{
				num = values.Length - 1;
			}
			if ((num != 3) ? (num >= 0) : TestForUltraHard())
			{
				break;
			}
		}
		DataUtility.Instance.localOptions.raceDifficulty = (RaceManager.RaceDifficultyLevel)num;
		Refresh();
	}

	// RECUPERADO-AOT PlaySummaryPublisher::PressedDifficultyArrowRight token 0x060006bf @0x0013011c
	private void PressedDifficultyArrowRight()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		Array values = Enum.GetValues(typeof(RaceManager.RaceDifficultyLevel));
		int num = (int)DataUtility.Instance.localOptions.raceDifficulty;
		while (true)
		{
			num++;
			if (num == values.Length)
			{
				num = 0;
			}
			if ((num != 3) ? (num >= 0) : TestForUltraHard())
			{
				break;
			}
		}
		DataUtility.Instance.localOptions.raceDifficulty = (RaceManager.RaceDifficultyLevel)num;
		Refresh();
	}

	// RECUPERADO-AOT PlaySummaryPublisher::TestForUltraHard token 0x060006c0 @0x001301d0
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	private bool TestForUltraHard()
	{
		TrackUnlockHelper trackUnlockHelper = (TrackUnlockHelper)U4Compat.FindObjectOfType(typeof(TrackUnlockHelper));
		if (trackUnlockHelper != null && trackUnlockHelper.TestForUltraHard())
		{
			return true;
		}
		return false;
	}

	// RECUPERADO-AOT PlaySummaryPublisher::PressedBackButton token 0x060006c1 @0x0013028c
	private void PressedBackButton()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		FrontEndLogic.RequestMenuChange("Track Select");
	}

	// RECUPERADO-AOT PlaySummaryPublisher::UpdateTrackIcon token 0x060006c2 @0x001302e0
	private void UpdateTrackIcon()
	{
		UghSprite sprite = GetSprite("Snapshot");
		if (!(sprite != null))
		{
			return;
		}
		foreach (TrackSelectPublisher.TrackIcon trackIcon in trackIcons)
		{
			if (trackIcon.name == base.ughTexts["Track Name"].Text)
			{
				sprite.normal = trackIcon.proto;
				sprite.UpdateMesh();
				break;
			}
		}
	}
}
