using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Title/Play menu shown on the first garage visit: Play (or the tutorial), Settings, Info (credits).
// Source listing: recovery/aot_listings/Assembly-CSharp/PlayMenuPublisher.txt
public class PlayMenuPublisher : UghPublisher
{
	public GameObject settings;

	// RECUPERADO-AOT PlayMenuPublisher::Update token 0x060006af @0x0012eed8
	// ADAPTADO-U6: Application.isWebPlayer dropped (always false); the Space shortcut stays editor-only.
	private void Update()
	{
		if (Application.isEditor && Input.GetKeyDown(KeyCode.Space) && U4Compat.FindObjectOfType(typeof(TutorialLauncherPublisher)) == null)
		{
			PressedPlayButton();
		}
	}

	// RECUPERADO-AOT PlayMenuPublisher::Start token 0x060006b0 @0x0012ef58
	// ADAPTADO-U6: FindObjectOfType<T> -> U4Compat; Application.isWebPlayer dropped (always false).
	private void Start()
	{
		ShiftUIPublisher shiftUIPublisher = U4Compat.FindObjectOfType<ShiftUIPublisher>();
		if (shiftUIPublisher != null)
		{
			shiftUIPublisher.Hide(true);
		}
		if (DataUtility.Instance.forceWebPlayer)
		{
			base.transforms["XD"].gameObject.SetActive(false);
			base.transforms["Channel"].gameObject.SetActive(false);
			base.ughButtons["Info"].gameObject.SetActive(false);
			base.ughButtons["MoreDisney"].gameObject.SetActive(false);
		}
		// ELIMINADO (servicio iOS/externo): promo "More Disney" (escena MoreDisney quitada del build).
		base.ughButtons["MoreDisney"].gameObject.SetActive(false);
	}

	// RECUPERADO-AOT PlayMenuPublisher::PressedPlayButton token 0x060006b1 @0x0012f0c4
	private void PressedPlayButton()
	{
		if (DataUtility.Instance.cloudData.useTutorial)
		{
			StartTutorial();
			return;
		}
		ShiftUIPublisher shiftUIPublisher = U4Compat.FindObjectOfType<ShiftUIPublisher>();
		if (shiftUIPublisher != null)
		{
			shiftUIPublisher.Show(true);
			shiftUIPublisher.SendMessage("PressedPlayButton");
			FrontEndLogic.HideMenu();
		}
	}

	// RECUPERADO-AOT PlayMenuPublisher::PressedMoreDisney token 0x060006b2 @0x0012f168
	// ELIMINADO (servicio iOS/externo): ScreenFader.Instance.LoadLevel("MoreDisney"); el boton se oculta en Start.
	private void PressedMoreDisney()
	{
	}

	// RECUPERADO-AOT PlayMenuPublisher::PressedSettings token 0x060006b3 @0x0012f1b8
	private void PressedSettings()
	{
		ShiftUIPublisher shiftUIPublisher = U4Compat.FindObjectOfType<ShiftUIPublisher>();
		if (shiftUIPublisher != null)
		{
			shiftUIPublisher.Show(true);
			shiftUIPublisher.SendMessage("PressedOptions");
		}
	}

	// RECUPERADO-AOT PlayMenuPublisher::PressedInfo token 0x060006b4 @0x0012f238
	private void PressedInfo()
	{
		ShiftUIPublisher shiftUIPublisher = U4Compat.FindObjectOfType<ShiftUIPublisher>();
		if (shiftUIPublisher != null)
		{
			shiftUIPublisher.Show(true);
			shiftUIPublisher.SendMessage("PressedOptions");
		}
		FrontEndLogic.RequestMenuChange("Credits");
	}

	// RECUPERADO-AOT PlayMenuPublisher::StartTutorial token 0x060006b5 @0x0012f2cc
	private void StartTutorial()
	{
		DataUtility.Instance.cloudData.useTutorial = false;
		DataUtility.Instance.Save();
		if (settings != null)
		{
			GameObject gameObject = Script.Instantiate(settings);
			DataUtility.Instance.CurSettings = gameObject.GetComponent<RaceSettings>();
			DataUtility.Instance.AddPlayerMoney(100);
			StartCoroutine(StartTutLoad());
		}
		else
		{
			UnityEngine.Debug.LogWarning("This tutorial launcher needs a settings object!!");
		}
	}

	// RECUPERADO-AOT PlayMenuPublisher::StartTutLoad token 0x060006b6 @0x0012f3d4
	// (iterator <StartTutLoad>c__Iterator65 MoveNext token 0x06000a32 @0x00157470)
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
}
