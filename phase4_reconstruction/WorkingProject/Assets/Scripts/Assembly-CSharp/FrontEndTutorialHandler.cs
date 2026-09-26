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
			return default(bool);
		}
		set
		{
		}
	}

	private TutorialSettings GetNextTutorial()
	{
		return default(TutorialSettings);
	}

	private void TriggerNext()
	{
	}

	private void Update()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void ChangedShifterUISlot()
	{
	}
}
