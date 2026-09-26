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
		get
		{
			RecoveryPending.Hit("FrontEndTutorialHandler.get_ActiveTutorial");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("FrontEndTutorialHandler.set_ActiveTutorial");
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
