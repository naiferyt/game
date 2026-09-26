using System;
using System.Collections;
using System.Collections.Generic;
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
			return default(string);
		}
		set
		{
		}
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Start()
	{
		return default(IEnumerator);
	}

	private void Update()
	{
	}

	private void ShowCircuitBanner()
	{
	}

	public override void SetContent(AchievementListener listener)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadCircuitTextures()
	{
		return default(IEnumerator);
	}
}
