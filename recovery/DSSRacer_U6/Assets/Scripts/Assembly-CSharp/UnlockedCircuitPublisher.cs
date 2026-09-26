using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// "Circuit unlocked" achievement window: shows the banner of the newly unlocked circuit (Pro or Master).
// Source listing: recovery/aot_listings/Assembly-CSharp/UnlockedCircuitPublisher.txt
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

	// RECUPERADO-AOT UnlockedCircuitPublisher::.ctor token 0x06000730 @0x00137950 (field initializer)
	private string circuit = string.Empty;

	public string Circuit
	{
		// RECUPERADO-AOT UnlockedCircuitPublisher::get_Circuit token 0x06000731 @0x0013799c
		get
		{
			return circuit;
		}
		// RECUPERADO-AOT UnlockedCircuitPublisher::set_Circuit token 0x06000732 @0x001379d0
		set
		{
			circuit = value;
		}
	}

	// RECUPERADO-AOT UnlockedCircuitPublisher::Start token 0x06000733 @0x00137a0c
	// (iterator <Start>c__Iterator74 MoveNext token 0x06000a93 @0x0015dd30)
	[DebuggerHidden]
	private IEnumerator Start()
	{
		yield return StartCoroutine(LoadCircuitTextures());
	}

	// RECUPERADO-AOT UnlockedCircuitPublisher::Update token 0x06000734 @0x00137a54
	private void Update()
	{
		if (!bannerShown)
		{
			ShowCircuitBanner();
		}
	}

	// RECUPERADO-AOT UnlockedCircuitPublisher::ShowCircuitBanner token 0x06000735 @0x00137a98
	private void ShowCircuitBanner()
	{
		if (loadingResources || !(circuit != string.Empty))
		{
			return;
		}
		Material material = base.transforms["Banner"].GetComponent<Renderer>().material;
		foreach (CircuitBanner banner in banners)
		{
			if (banner.name == circuit)
			{
				material.mainTexture = banner.texture;
				bannerShown = true;
				break;
			}
		}
	}

	// RECUPERADO-AOT UnlockedCircuitPublisher::SetContent token 0x06000736 @0x00137c74
	// The unlocked circuit follows from the achievement: "Newbie..." unlocks Pro, "Pro..." unlocks Master.
	public override void SetContent(AchievementListener listener)
	{
		UnityEngine.Debug.Log("Inside UnlockedCircuitPublisher:SetContent()");
		if (listener.name.Contains("Newbie"))
		{
			circuit = "Pro";
		}
		else if (listener.name.Contains("Pro"))
		{
			circuit = "Master";
		}
	}

	// RECUPERADO-AOT UnlockedCircuitPublisher::LoadCircuitTextures token 0x06000737 @0x00137d54
	// (iterator <LoadCircuitTextures>c__Iterator75 MoveNext token 0x06000a99 @0x0015df00)
	// ADAPTADO-U6: Application.isWebPlayer (always false) dropped with its branch, which downloaded every
	//     banner from PrependRootFileLocation(webPath) with WWW, waited for all and copied the textures.
	[DebuggerHidden]
	private IEnumerator LoadCircuitTextures()
	{
		loadingResources = true;
		UnityEngine.Debug.Log("Loading resources");
		foreach (CircuitBanner banner in banners)
		{
			UnityEngine.Object @object = Resources.Load(banner.resourcePath.Text);
			if (@object == null)
			{
				UnityEngine.Debug.LogError("Failed to load circuit banner resource at path: " + banner.resourcePath.Text);
			}
			else
			{
				banner.texture = @object as Texture2D;
			}
		}
		loadingResources = false;
		yield break;
	}
}
