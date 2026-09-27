using System;
using UnityEngine;

// Menu tutorial: shows the next not-yet-seen tip pop-up of popupList (each tip is remembered as an unlock);
// moving the shifter away cancels the running tip so it shows again later.
// Source listing: recovery/aot_listings/Assembly-CSharp/FrontEndTutorialHandler.txt
public class FrontEndTutorialHandler : MonoBehaviour
{
	[Serializable]
	public class TutorialSettings
	{
		public string name;

		public LocalizedString tutorialText;

		public Transform targetTransform;

		// RECUPERADO-AOT FrontEndTutorialHandler/TutorialSettings::.ctor token 0x06000680 @0x0012c39c (field initializers)
		public Vector3 targetTransformOffset = Vector3.zero;

		public UghControl[] targetControls;

		public bool anyTouchDismissesTutorialStep = true;
	}

	public GameObject popupPrefab;

	public TutorialSettings[] popupList;

	// RECUPERADO-AOT FrontEndTutorialHandler::.ctor token 0x06000677 @0x0012bd58 (field initializers)
	public bool autoLaunch = true;

	private bool activeTutorial = true;

	private GameObject currentPopup;

	public bool ActiveTutorial
	{
		// RECUPERADO-AOT FrontEndTutorialHandler::get_ActiveTutorial token 0x06000678 @0x0012bd9c
		get
		{
			return activeTutorial;
		}
		// RECUPERADO-AOT FrontEndTutorialHandler::set_ActiveTutorial token 0x06000679 @0x0012bdd0
		set
		{
			activeTutorial = value;
		}
	}

	// RECUPERADO-AOT FrontEndTutorialHandler::GetNextTutorial token 0x0600067a @0x0012be0c
	private TutorialSettings GetNextTutorial()
	{
		for (int i = 0; i < popupList.Length; i++)
		{
			if (!DataUtility.Instance.IsUnlocked(popupList[i].name))
			{
				return popupList[i];
			}
		}
		return null;
	}

	// RECUPERADO-AOT FrontEndTutorialHandler::TriggerNext token 0x0600067b @0x0012beac
	private void TriggerNext()
	{
		TutorialSettings nextTutorial = GetNextTutorial();
		if (nextTutorial != null)
		{
			currentPopup = UnityEngine.Object.Instantiate(popupPrefab) as GameObject;
			if (nextTutorial.targetTransform != null)
			{
				currentPopup.GetComponent<FrontEndTutorialPublisher>().SetAnchorPoint(nextTutorial.targetTransform, nextTutorial.targetTransformOffset);
			}
			else
			{
				currentPopup.GetComponent<FrontEndTutorialPublisher>().SetAnchorPoint(nextTutorial.targetTransform, nextTutorial.targetTransformOffset);
			}
			currentPopup.GetComponent<FrontEndTutorialPublisher>().SetText(nextTutorial.tutorialText.Text);
			currentPopup.GetComponent<FrontEndTutorialPublisher>().SetTargetControls(nextTutorial.targetControls);
			currentPopup.GetComponent<FrontEndTutorialPublisher>().anyTouchDismissesTutorialStep = nextTutorial.anyTouchDismissesTutorialStep;
			DataUtility.Instance.Unlock(nextTutorial.name);
		}
		else
		{
			activeTutorial = false;
		}
	}

	// RECUPERADO-AOT FrontEndTutorialHandler::Update token 0x0600067c @0x0012c0f8
	private void Update()
	{
		if (activeTutorial && currentPopup == null)
		{
			TriggerNext();
		}
	}

	// RECUPERADO-AOT FrontEndTutorialHandler::Start token 0x0600067d @0x0012c14c
	private void Start()
	{
		if (!autoLaunch)
		{
			activeTutorial = false;
		}
		ShiftUIPublisher.ChangedShifterSlot += ChangedShifterUISlot;
	}

	// RECUPERADO-AOT FrontEndTutorialHandler::OnDisable token 0x0600067e @0x0012c1e8
	private void OnDisable()
	{
		ShiftUIPublisher.ChangedShifterSlot -= ChangedShifterUISlot;
	}

	// RECUPERADO-AOT FrontEndTutorialHandler::ChangedShifterUISlot token 0x0600067f @0x0012c278
	private void ChangedShifterUISlot()
	{
		if (!activeTutorial)
		{
			return;
		}
		activeTutorial = false;
		int i;
		for (i = 0; i < popupList.Length && popupList[i] != GetNextTutorial(); i++)
		{
		}
		DataUtility.Instance.Relock(popupList[i - 1].name);
		if (currentPopup != null)
		{
			currentPopup.GetComponent<FrontEndTutorialPublisher>().OnPressedDismiss();
		}
	}
}
