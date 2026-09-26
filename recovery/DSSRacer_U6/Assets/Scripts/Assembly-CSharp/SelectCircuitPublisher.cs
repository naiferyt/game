using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// "Circuit Select" menu: Newbie / Pro / Master circuit cards with banners, trophies and locks, the tutorial button
// and the Pranksgiving race.
// Source listing: recovery/aot_listings/Assembly-CSharp/SelectCircuitPublisher.txt
public class SelectCircuitPublisher : UghPublisher
{
	[Serializable]
	public class CircuitBanner
	{
		public string name;

		public LocalizedString resourcePath;

		public LocalizedString webPath;

		[HideInInspector]
		public Texture2D texture;
	}

	[Serializable]
	public class TrophyAssets
	{
		public string name;

		public UghSpritePrototype proto;
	}

	// RECUPERADO-AOT SelectCircuitPublisher::.ctor token 0x060006e5 @0x001324a8 (field initializers)
	private Vector3 originOffset = new Vector3(-7.3f, 0f, 0f);

	private float transitionTimer = 1f;

	private float transitionSpeed = 4f;

	public LocalizedString message;

	public GameObject popupPrefab;

	public GameObject tutorialSettings;

	private TrackUnlockHelper tuh;

	public List<CircuitBanner> banners;

	public List<TrophyAssets> trophies;

	public GameObject pranksgivingRaceSettingsPrefab;

	// RECUPERADO-AOT SelectCircuitPublisher::LoadCircuitTextures token 0x060006e6 @0x001325b4
	// (iterator <LoadCircuitTextures>c__Iterator6D MoveNext token 0x06000a64 @0x0015b8bc)
	// ADAPTADO-U6: the Application.isWebPlayer branch (WWW download of every banner's webPath through
	// StreamManager.PrependRootFileLocation, then banner.texture = www.texture) is gone with the web player.
	[DebuggerHidden]
	private IEnumerator LoadCircuitTextures()
	{
		UnityEngine.Debug.Log("Loading resources");
		foreach (CircuitBanner banner in banners)
		{
			UnityEngine.Object @object = Resources.Load(banner.resourcePath.Text);
			if (@object == null)
			{
				UnityEngine.Debug.LogError("Failed to load circuit banner resource at path: " + banner.resourcePath.Text);
			}
			else
			{
				banner.texture = @object as Texture2D;
			}
		}
		yield break;
	}

	// RECUPERADO-AOT SelectCircuitPublisher::OnEnable token 0x060006e7 @0x001325fc
	// ELIMINADO (servicio iOS/externo): BurstlyBinding.ShowBanner("0559142059127234080", ...) (banner de anuncios,
	// rect (-160,5,320,53) o (-364,40,728,90) si Screen.height >= 768).
	private void OnEnable()
	{
	}

	// RECUPERADO-AOT SelectCircuitPublisher::OnDisable token 0x060006e8 @0x00132804
	// ELIMINADO (servicio iOS/externo): BurstlyBinding.HideBanner().
	private void OnDisable()
	{
	}

	// RECUPERADO-AOT SelectCircuitPublisher::Start token 0x060006e9 @0x00132834
	// (iterator <Start>c__Iterator6E MoveNext token 0x06000a6a @0x0015c094;
	//  banner predicates <>m__2C token 0x06000a6d, <>m__2D 0x06000a6e, <>m__2E 0x06000a6f, <>m__2F 0x06000a70, <>m__30 0x06000a71)
	// ADAPTADO-U6: FindObjectOfType<T> -> U4Compat.
	[DebuggerHidden]
	private IEnumerator Start()
	{
		Vector3 pos = base.transforms["OriginPoint"].position + originOffset;
		base.transforms["Slide In"].position = pos;
		yield return StartCoroutine(LoadCircuitTextures());
		tuh = U4Compat.FindObjectOfType<TrackUnlockHelper>();
		DetermineTrophies("Goofy");
		if (tuh != null)
		{
			CircuitBanner newb = banners.Find((CircuitBanner b) => b.name.Equals("Newbie Unlocked"));
			base.transforms["Newbie Banner"].GetComponent<Renderer>().material.mainTexture = newb.texture;
			if (tuh.IsCircuitUnlocked("Goofy"))
			{
				base.transforms["Donald Trophies"].gameObject.SetActive(true);
				base.transforms["Donald Lock"].gameObject.SetActive(false);
				CircuitBanner donald = banners.Find((CircuitBanner b) => b.name.Equals("Pro Unlocked"));
				base.transforms["Pro Banner"].GetComponent<Renderer>().material.mainTexture = donald.texture;
				DetermineTrophies("Donald");
			}
			else
			{
				base.transforms["Donald Trophies"].gameObject.SetActive(false);
				base.transforms["Donald Lock"].gameObject.SetActive(true);
				CircuitBanner donald2 = banners.Find((CircuitBanner b) => b.name.Equals("Pro Locked"));
				base.transforms["Pro Banner"].GetComponent<Renderer>().material.mainTexture = donald2.texture;
			}
			if (tuh.IsCircuitUnlocked("Donald"))
			{
				base.transforms["Mickey Trophies"].gameObject.SetActive(true);
				base.transforms["Mickey Lock"].gameObject.SetActive(false);
				CircuitBanner mickey = banners.Find((CircuitBanner b) => b.name.Equals("Master Unlocked"));
				base.transforms["Master Banner"].GetComponent<Renderer>().material.mainTexture = mickey.texture;
				DetermineTrophies("Mickey");
			}
			else
			{
				base.transforms["Mickey Trophies"].gameObject.SetActive(false);
				base.transforms["Mickey Lock"].gameObject.SetActive(true);
				CircuitBanner mickey2 = banners.Find((CircuitBanner b) => b.name.Equals("Master Locked"));
				base.transforms["Master Banner"].GetComponent<Renderer>().material.mainTexture = mickey2.texture;
			}
			base.ughButtons["Pranksgiving"].gameObject.SetActive(tuh.CanPranksgiving);
			base.ughButtons["Turkey"].gameObject.SetActive(tuh.CanPranksgiving);
			// ELIMINADO (servicio iOS/externo): if (tuh.CanPranksgiving) BurstlyBinding.HideBanner();
		}
		StartCoroutine(AnimateIn());
	}

	// RECUPERADO-AOT SelectCircuitPublisher::DetermineTrophies token 0x060006ea @0x0013287c
	// Sets each "<circuit> Trophy <track>" sprite to gold/silver/bronze by best place, or the silhouette.
	// ADAPTADO-U6: FindObjectOfType<T> -> U4Compat.
	private void DetermineTrophies(string circuitName)
	{
		if (tuh == null)
		{
			tuh = U4Compat.FindObjectOfType<TrackUnlockHelper>();
		}
		if (!(tuh != null))
		{
			return;
		}
		GameObject[] circuitTracks = tuh.GetCircuitTracks(circuitName);
		for (int i = 0; i < circuitTracks.Length; i++)
		{
			GameObject gameObject = circuitTracks[i];
			string text = string.Empty;
			switch (tuh.GetHighestTrackPlace(gameObject.name))
			{
			case 0:
				text = "Trophy Gold";
				break;
			case 1:
				text = "Trophy Silver";
				break;
			case 2:
				text = "Trophy Bronze";
				break;
			default:
				text = "Trophy Silouette";
				break;
			}
			UghSprite sprite = GetSprite(circuitName + " Trophy " + gameObject.name);
			if (!(sprite != null))
			{
				continue;
			}
			foreach (TrophyAssets trophy in trophies)
			{
				if (trophy.name == text)
				{
					sprite.normal = trophy.proto;
					sprite.UpdateMesh();
					break;
				}
			}
		}
	}

	// RECUPERADO-AOT SelectCircuitPublisher::AnimateIn token 0x060006eb @0x00132bb8
	// (iterator <AnimateIn>c__Iterator6F MoveNext token 0x06000a75 @0x0015cdc4)
	[DebuggerHidden]
	private IEnumerator AnimateIn()
	{
		while (transitionTimer > 0f)
		{
			transitionTimer -= 0.016666668f * transitionSpeed;
			if (transitionTimer < 0f)
			{
				transitionTimer = 0f;
			}
			Vector3 pos = Vector3.Lerp(base.transforms["OriginPoint"].position + originOffset, base.transforms["TargetPoint"].position, 1f - transitionTimer);
			base.transforms["Slide In"].position = pos;
			yield return new WaitForSeconds(0.016666668f);
		}
	}

	// RECUPERADO-AOT SelectCircuitPublisher::PressedCircuitButton1 token 0x060006ec @0x00132c00
	// ADAPTADO-U6: FindObjectOfType<T> -> U4Compat.
	private void PressedCircuitButton1()
	{
		if (tuh == null)
		{
			tuh = U4Compat.FindObjectOfType<TrackUnlockHelper>();
		}
		if (tuh != null)
		{
			DataUtility.Instance.localOptions.raceDifficulty = RaceManager.RaceDifficultyLevel.EASY;
			DataUtility.Instance.localOptions.selectedCircuitTracks = tuh.GetCircuitTracks("Goofy");
			DataUtility.Instance.localOptions.circuitName = "Goofy";
			FrontEndLogic.RequestMenuChange("Track Select");
			SoundLibrary.ButtonClickPlay("menuButton1");
		}
	}

	// RECUPERADO-AOT SelectCircuitPublisher::PressedCircuitButton2 token 0x060006ed @0x00132cf8
	// ADAPTADO-U6: FindObjectOfType<T> -> U4Compat.
	private void PressedCircuitButton2()
	{
		if (tuh == null)
		{
			tuh = U4Compat.FindObjectOfType<TrackUnlockHelper>();
		}
		if (tuh != null)
		{
			if (!tuh.IsCircuitUnlocked("Goofy"))
			{
				ShowPopupDialog();
				return;
			}
			DataUtility.Instance.localOptions.raceDifficulty = RaceManager.RaceDifficultyLevel.MEDIUM;
			DataUtility.Instance.localOptions.selectedCircuitTracks = tuh.GetCircuitTracks("Donald");
			DataUtility.Instance.localOptions.circuitName = "Donald";
			FrontEndLogic.RequestMenuChange("Track Select");
			SoundLibrary.ButtonClickPlay("menuButton1");
		}
	}

	// RECUPERADO-AOT SelectCircuitPublisher::PressedCircuitButton3 token 0x060006ee @0x00132e24
	// ADAPTADO-U6: FindObjectOfType<T> -> U4Compat.
	private void PressedCircuitButton3()
	{
		if (tuh == null)
		{
			tuh = U4Compat.FindObjectOfType<TrackUnlockHelper>();
		}
		if (tuh != null)
		{
			if (!tuh.IsCircuitUnlocked("Donald"))
			{
				ShowPopupDialog();
				return;
			}
			DataUtility.Instance.localOptions.raceDifficulty = RaceManager.RaceDifficultyLevel.HARD;
			DataUtility.Instance.localOptions.selectedCircuitTracks = tuh.GetCircuitTracks("Mickey");
			DataUtility.Instance.localOptions.circuitName = "Mickey";
			FrontEndLogic.RequestMenuChange("Track Select");
			SoundLibrary.ButtonClickPlay("menuButton1");
		}
	}

	// RECUPERADO-AOT SelectCircuitPublisher::StartTutLoad token 0x060006ef @0x00132f50
	// (iterator <StartTutLoad>c__Iterator70 MoveNext token 0x06000a7b @0x0015d1d0)
	[DebuggerHidden]
	private IEnumerator StartTutLoad()
	{
		while (PreviewCart.IsLoading)
		{
			yield return 0;
		}
		FrontEndLogic.HideMenu();
		PreviewCart.StartDriveout();
	}

	// RECUPERADO-AOT SelectCircuitPublisher::PressedTutorial token 0x060006f0 @0x00132f90
	private void PressedTutorial()
	{
		DataUtility.Instance.cloudData.useTutorial = false;
		DataUtility.Instance.Save();
		if (tutorialSettings != null)
		{
			GameObject gameObject = Script.Instantiate(tutorialSettings);
			DataUtility.Instance.CurSettings = gameObject.GetComponent<RaceSettings>();
			StartCoroutine(StartTutLoad());
		}
		else
		{
			UnityEngine.Debug.LogWarning("This menu needs a tutorial settings object!!");
		}
	}

	// RECUPERADO-AOT SelectCircuitPublisher::PressedPranksgiving token 0x060006f1 @0x00133084
	private void PressedPranksgiving()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		GameObject gameObject = Script.Instantiate(pranksgivingRaceSettingsPrefab);
		DataUtility.Instance.CurSettings = gameObject.GetComponent<RaceSettings>();
		DataUtility.Instance.localOptions.raceDifficulty = RaceManager.RaceDifficultyLevel.HARD;
		DataUtility.Instance.CurSettings.lapNumber = -1;
		PreviewCart.StartDriveout();
		base.gameObject.SetActive(false);
	}

	// RECUPERADO-AOT SelectCircuitPublisher::ShowPopupDialog token 0x060006f2 @0x00133168
	private void ShowPopupDialog()
	{
		GameObject gameObject = Script.Instantiate(popupPrefab);
		if (gameObject != null)
		{
			GenericPopupPublisher component = gameObject.GetComponent<GenericPopupPublisher>();
			if (component != null)
			{
				component.SetText(message.Text);
			}
		}
	}
}
