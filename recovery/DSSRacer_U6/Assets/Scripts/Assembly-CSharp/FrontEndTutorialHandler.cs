using System;
using UnityEngine;

public class FrontEndTutorialHandler : MonoBehaviour
{
	[Serializable]
	public class TutorialSettings
	{
		public string name;

		public LocalizedString tutorialText;

		public Transform targetTransform;

		public Vector3 targetTransformOffset;

		public UghControl[] targetControls;

		public bool anyTouchDismissesTutorialStep;
	}

	public GameObject popupPrefab;

	public TutorialSettings[] popupList;

	public bool autoLaunch;

	private bool activeTutorial;

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

	private TutorialSettings GetNextTutorial()
	{
		RecoveryPending.Hit("FrontEndTutorialHandler.GetNextTutorial");
		return default(TutorialSettings);
	}

	private void TriggerNext()
	{
		RecoveryPending.Hit("FrontEndTutorialHandler.TriggerNext");
	}

	private void Update()
	{
		RecoveryPending.Hit("FrontEndTutorialHandler.Update");
	}

	private void Start()
	{
		RecoveryPending.Hit("FrontEndTutorialHandler.Start");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("FrontEndTutorialHandler.OnDisable");
	}

	private void ChangedShifterUISlot()
	{
		RecoveryPending.Hit("FrontEndTutorialHandler.ChangedShifterUISlot");
	}
}
