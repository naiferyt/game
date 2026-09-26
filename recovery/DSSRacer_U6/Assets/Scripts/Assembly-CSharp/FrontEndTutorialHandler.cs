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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	private TutorialSettings GetNextTutorial()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
