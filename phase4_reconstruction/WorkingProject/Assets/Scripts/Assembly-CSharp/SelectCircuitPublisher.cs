using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private Vector3 originOffset;

	private float transitionTimer;

	private float transitionSpeed;

	public LocalizedString message;

	public GameObject popupPrefab;

	public GameObject tutorialSettings;

	private TrackUnlockHelper tuh;

	public List<CircuitBanner> banners;

	public List<TrophyAssets> trophies;

	public GameObject pranksgivingRaceSettingsPrefab;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadCircuitTextures()
	{
		return default(IEnumerator);
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Start()
	{
		return default(IEnumerator);
	}

	private void DetermineTrophies(string circuitName)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimateIn()
	{
		return default(IEnumerator);
	}

	private void PressedCircuitButton1()
	{
	}

	private void PressedCircuitButton2()
	{
	}

	private void PressedCircuitButton3()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator StartTutLoad()
	{
		return default(IEnumerator);
	}

	private void PressedTutorial()
	{
	}

	private void PressedPranksgiving()
	{
	}

	private void ShowPopupDialog()
	{
	}
}
