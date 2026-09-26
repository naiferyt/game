using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class UnlockedCircuitPublisher : AchievementWindowPublisher
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

	public List<CircuitBanner> banners;

	private bool bannerShown;

	private bool loadingResources;

	private string circuit;

	public string Circuit
	{
		get
		{
			RecoveryPending.Hit("UnlockedCircuitPublisher.get_Circuit");
			return default(string);
		}
		set
		{
			RecoveryPending.Hit("UnlockedCircuitPublisher.set_Circuit");
		}
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("UnlockedCircuitPublisher.Start");
		yield break;
	}

	private void Update()
	{
		RecoveryPending.Hit("UnlockedCircuitPublisher.Update");
	}

	private void ShowCircuitBanner()
	{
		RecoveryPending.Hit("UnlockedCircuitPublisher.ShowCircuitBanner");
	}

	public override void SetContent(AchievementListener listener)
	{
		RecoveryPending.Hit("UnlockedCircuitPublisher.SetContent");
	}

	[DebuggerHidden]
	private IEnumerator LoadCircuitTextures()
	{
		RecoveryPending.Hit("UnlockedCircuitPublisher.LoadCircuitTextures");
		yield break;
	}
}
