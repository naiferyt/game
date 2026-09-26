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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void DetermineTrophies(string circuitName)
	{
	}

	[DebuggerHidden]
	private IEnumerator AnimateIn()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator StartTutLoad()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
