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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator LoadCircuitTextures()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
