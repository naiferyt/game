using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

	[DebuggerHidden]
	private IEnumerator LoadCircuitTextures()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.LoadCircuitTextures");
		yield break;
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.OnDisable");
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.Start");
		yield break;
	}

	private void DetermineTrophies(string circuitName)
	{
		RecoveryPending.Hit("SelectCircuitPublisher.DetermineTrophies");
	}

	[DebuggerHidden]
	private IEnumerator AnimateIn()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.AnimateIn");
		yield break;
	}

	private void PressedCircuitButton1()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.PressedCircuitButton1");
	}

	private void PressedCircuitButton2()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.PressedCircuitButton2");
	}

	private void PressedCircuitButton3()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.PressedCircuitButton3");
	}

	[DebuggerHidden]
	private IEnumerator StartTutLoad()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.StartTutLoad");
		yield break;
	}

	private void PressedTutorial()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.PressedTutorial");
	}

	private void PressedPranksgiving()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.PressedPranksgiving");
	}

	private void ShowPopupDialog()
	{
		RecoveryPending.Hit("SelectCircuitPublisher.ShowPopupDialog");
	}
}
