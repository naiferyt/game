using System.Collections;
using System.Diagnostics;
using UnityEngine;

// First-run "play the tutorial?" prompt: Yes loads the tutorial race (and gives 100 coins), No dismisses it;
// both clear the save's useTutorial flag.
// Source listing: recovery/aot_listings/Assembly-CSharp/TutorialLauncherPublisher.txt
public class TutorialLauncherPublisher : UghPublisher
{
	public GameObject settings;

	// RECUPERADO-AOT TutorialLauncherPublisher::Start token 0x0600072b @0x0013774c (empty)
	private void Start()
	{
	}

	// RECUPERADO-AOT TutorialLauncherPublisher::Update token 0x0600072c @0x00137778 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT TutorialLauncherPublisher::PressedYes token 0x0600072d @0x001377a4
	private void PressedYes()
	{
		DataUtility.Instance.cloudData.useTutorial = false;
		DataUtility.Instance.Save();
		if (settings != null)
		{
			GameObject gameObject = Object.Instantiate(settings);
			DataUtility.Instance.CurSettings = gameObject.GetComponent<RaceSettings>();
			DataUtility.Instance.AddPlayerMoney(100);
			StartCoroutine(StartTutLoad());
		}
		else
		{
			UnityEngine.Debug.LogWarning("This tutorial launcher needs a settings object!!");
		}
	}

	// RECUPERADO-AOT TutorialLauncherPublisher::StartTutLoad token 0x0600072e @0x001378b0
	// RECUPERADO-AOT TutorialLauncherPublisher/<StartTutLoad>c__Iterator73::MoveNext token 0x06000a8d @0x0015db5c
	[DebuggerHidden]
	private IEnumerator StartTutLoad()
	{
		do
		{
			yield return 0;
		}
		while (PreviewCart.IsLoading);
		FrontEndLogic.HideMenu();
		PreviewCart.StartDriveout();
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT TutorialLauncherPublisher::PressedNo token 0x0600072f @0x001378f8
	private void PressedNo()
	{
		DataUtility.Instance.cloudData.useTutorial = false;
		DataUtility.Instance.Save();
		Object.Destroy(base.gameObject);
	}
}
