using System;
using System.Collections.Generic;
using UnityEngine;

// "Track Select" menu: the three tracks of the chosen circuit (one per world), their snapshots and trophies.
// A circuit with its race options still locked goes straight to the race; otherwise to "Play Summary".
// Source listing: recovery/aot_listings/Assembly-CSharp/TrackSelectPublisher.txt
public class TrackSelectPublisher : UghPublisher
{
	[Serializable]
	public class TrackIcon
	{
		public string name;

		public UghSpritePrototype proto;
	}

	private GameObject[] trackList;

	private TrackUnlockHelper tuh;

	// RECUPERADO-AOT TrackSelectPublisher::.ctor token 0x0600071d @0x0013619c (field initializers)
	private Vector3 originOffset = new Vector3(7.3f, 0f, 0f);

	private float transitionTimer = 1f;

	private float transitionSpeed = 4f;

	private bool oneClickEnter;

	public List<TrackIcon> trackIcons;

	// RECUPERADO-AOT TrackSelectPublisher::GetTrackIconsList token 0x0600071e @0x001362a8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static List<TrackIcon> GetTrackIconsList()
	{
		TrackSelectPublisher trackSelectPublisher = (TrackSelectPublisher)U4Compat.FindObjectOfType(typeof(TrackSelectPublisher));
		return trackSelectPublisher.trackIcons;
	}

	// RECUPERADO-AOT TrackSelectPublisher::Refresh token 0x0600071f @0x0013633c
	private void Refresh()
	{
		if (trackList != null)
		{
			for (int i = 0; i < trackList.Length; i++)
			{
				GameObject gameObject = trackList[i];
				base.ughTexts["Track Name " + (i + 1)].Text = gameObject.name;
			}
			UpdateTrackSnapshots();
			oneClickEnter = !tuh.CheckForPreraceSetupUnlock(DataUtility.Instance.localOptions.circuitName);
		}
	}

	// RECUPERADO-AOT TrackSelectPublisher::RaceOrSummary token 0x06000720 @0x00136480
	private void RaceOrSummary()
	{
		if (oneClickEnter)
		{
			DataUtility.Instance.CurSettings.lapNumber = -1;
			PreviewCart.StartDriveout();
			base.gameObject.SetActive(false);
		}
		else
		{
			FrontEndLogic.RequestMenuChange("Play Summary");
		}
	}

	// RECUPERADO-AOT TrackSelectPublisher::Start token 0x06000721 @0x00136508
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	private void Start()
	{
		tuh = (TrackUnlockHelper)U4Compat.FindObjectOfType(typeof(TrackUnlockHelper));
		trackList = DataUtility.Instance.localOptions.selectedCircuitTracks;
		Refresh();
		base.transforms["Track Panels"].position = base.transforms["OriginPoint"].position + originOffset;
		DetermineTrophies(trackList);
	}

	// RECUPERADO-AOT TrackSelectPublisher::DetermineTrophies token 0x06000722 @0x00136688
	// Hides every "Track<n> <medal>" object, then shows the one for each track's best place. The slot n is the
	// track's world: Kick Buttowski 1, Phineas and Ferb 2, Fish Hooks 3 (string switch <>f__switch$map3).
	private void DetermineTrophies(GameObject[] trackList)
	{
		for (int i = 1; i < 4; i++)
		{
			base.transforms["Track" + i + " Gold"].gameObject.SetActive(false);
			base.transforms["Track" + i + " Silver"].gameObject.SetActive(false);
			base.transforms["Track" + i + " Bronze"].gameObject.SetActive(false);
			base.transforms["Track" + i + " Silouette"].gameObject.SetActive(false);
		}
		foreach (GameObject gameObject in trackList)
		{
			string text = "Track";
			switch (gameObject.name)
			{
			case "Kick Butt!":
			case "Bus Jumper":
			case "Dirt Devils":
				text += "1";
				break;
			case "Doof's Tower":
			case "Danville River":
			case "Danville Arena":
				text += "2";
				break;
			case "Freshwater High":
			case "Hokey Poke":
			case "Fishtankia":
				text += "3";
				break;
			}
			if (tuh != null)
			{
				switch (tuh.GetHighestTrackPlace(gameObject.name))
				{
				case 0:
					text += " Gold";
					break;
				case 1:
					text += " Silver";
					break;
				case 2:
					text += " Bronze";
					break;
				default:
					text += " Silouette";
					break;
				}
			}
			base.transforms[text].gameObject.SetActive(true);
		}
	}

	// RECUPERADO-AOT TrackSelectPublisher::FixedUpdate token 0x06000723 @0x00136cdc
	private void FixedUpdate()
	{
		if (transitionTimer > 0f)
		{
			transitionTimer -= Time.deltaTime * transitionSpeed;
			if (transitionTimer < 0f)
			{
				transitionTimer = 0f;
			}
			base.transforms["Track Panels"].position = Vector3.Lerp(base.transforms["OriginPoint"].position + originOffset, base.transforms["TargetPoint"].position, 1f - transitionTimer);
		}
	}

	// RECUPERADO-AOT TrackSelectPublisher::PressedTrackButton1 token 0x06000724 @0x00136ef4
	private void PressedTrackButton1()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		GameObject gameObject = Script.Instantiate(trackList[0]);
		DataUtility.Instance.CurSettings = gameObject.GetComponent<RaceSettings>();
		RaceOrSummary();
	}

	// RECUPERADO-AOT TrackSelectPublisher::PressedTrackButton2 token 0x06000725 @0x00136fbc
	private void PressedTrackButton2()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		GameObject gameObject = Script.Instantiate(trackList[1]);
		DataUtility.Instance.CurSettings = gameObject.GetComponent<RaceSettings>();
		RaceOrSummary();
	}

	// RECUPERADO-AOT TrackSelectPublisher::PressedTrackButton3 token 0x06000726 @0x00137084
	private void PressedTrackButton3()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		GameObject gameObject = Script.Instantiate(trackList[2]);
		DataUtility.Instance.CurSettings = gameObject.GetComponent<RaceSettings>();
		RaceOrSummary();
	}

	// RECUPERADO-AOT TrackSelectPublisher::PressedBackButton token 0x06000727 @0x0013714c
	private void PressedBackButton()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		FrontEndLogic.RequestMenuChange("Circuit Select");
	}

	// RECUPERADO-AOT TrackSelectPublisher::UpdateTrackSnapshots token 0x06000728 @0x001371a0
	// Puts each track's icon on the panel of its world (string switch <>f__switch$map4).
	private void UpdateTrackSnapshots()
	{
		UghSprite sprite = GetSprite("Panel 1 Snapshot");
		UghSprite sprite2 = GetSprite("Panel 2 Snapshot");
		UghSprite sprite3 = GetSprite("Panel 3 Snapshot");
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		if (sprite == null || sprite2 == null || sprite3 == null)
		{
			return;
		}
		GameObject[] array = trackList;
		foreach (GameObject gameObject in array)
		{
			switch (gameObject.name)
			{
			case "Kick Butt!":
			case "Bus Jumper":
			case "Dirt Devils":
				text = gameObject.name;
				break;
			case "Doof's Tower":
			case "Danville River":
			case "Danville Arena":
				text2 = gameObject.name;
				break;
			case "Freshwater High":
			case "Hokey Poke":
			case "Fishtankia":
				text3 = gameObject.name;
				break;
			default:
				Debug.Log("You are doing something wrong in the track select snapshots!");
				break;
			}
		}
		foreach (TrackIcon trackIcon in trackIcons)
		{
			if (trackIcon.name == text)
			{
				sprite.normal = trackIcon.proto;
				sprite.UpdateMesh();
			}
			else if (trackIcon.name == text2)
			{
				sprite2.normal = trackIcon.proto;
				sprite2.UpdateMesh();
			}
			else if (trackIcon.name == text3)
			{
				sprite3.normal = trackIcon.proto;
				sprite3.UpdateMesh();
			}
		}
	}
}
