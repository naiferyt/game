using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Settings menu: music/SFX volume, credits, data reset (store, Game Center and promo buttons removed).
// Source listing: recovery/aot_listings/Assembly-CSharp/SettingsMenuPublisher.txt
public class SettingsMenuPublisher : UghPublisher
{
	public GameObject confirmPrefab;

	public GameObject gameCenterNote;

	// RECUPERADO-AOT SettingsMenuPublisher::Start token 0x060006f6 @0x001332ac
	private void Start()
	{
		UghToggle component = base.transforms["App Purchase Toggle"].GetComponent<UghToggle>();
		component.State = DataUtility.Instance.localOptions.appPurchases;
		component.OnChanged = (Action<UghToggle>)Delegate.Combine(component.OnChanged, new Action<UghToggle>(OnAppPurchaseToggleChanged));
		if (component.State)
		{
			base.ughTexts["IAPOnOff"].Text = "ON";
		}
		else
		{
			base.ughTexts["IAPOnOff"].Text = "OFF";
		}
		base.ughButtons["BuyCoins"].gameObject.SetActive(component.State);
		VolumeSlider component2 = base.transforms["Music Volume Thumb"].GetComponent<VolumeSlider>();
		component2.percent = DataUtility.Instance.localOptions.musicVolumeLevel;
		component2.OnVolumeChanged = (Action<VolumeSlider>)Delegate.Combine(component2.OnVolumeChanged, new Action<VolumeSlider>(OnMusicVolumeChanged));
		VolumeSlider component3 = base.transforms["SFX Volume Thumb"].GetComponent<VolumeSlider>();
		component3.percent = DataUtility.Instance.localOptions.sfxVolumeLevel;
		component3.OnVolumeChanged = (Action<VolumeSlider>)Delegate.Combine(component3.OnVolumeChanged, new Action<VolumeSlider>(OnSFXVolumeChanged));
		base.transforms["App Purchase Toggle"].gameObject.SetActive(false);
		// ADAPTADO-U6: Application.isWebPlayer dropped (always false).
		if (DataUtility.Instance.forceWebPlayer)
		{
			DataUtility.Instance.localOptions.appPurchases = false;
			base.ughButtons["GameCenter"].gameObject.SetActive(false);
			base.transforms["App Purchase Toggle"].gameObject.SetActive(false);
			base.ughButtons["BuyCoins"].gameObject.SetActive(false);
			base.ughButtons["Credits"].gameObject.SetActive(false);
		}
		// ELIMINADO (servicio iOS/externo): GDMOManager.SendWithContext("ad_action", {"placement": "More_Disney",
		// "creative": "Main_Button", "type": "Impression"}) (analitica).
		// ELIMINADO (servicio iOS/externo): botones de tienda StoreKit ("BuyCoins"), Game Center ("GameCenter")
		// y promo "More Disney"; quedan ocultos.
		base.ughButtons["BuyCoins"].gameObject.SetActive(false);
		base.ughButtons["GameCenter"].gameObject.SetActive(false);
		base.ughButtons["More Disney"].gameObject.SetActive(false);
	}

	// RECUPERADO-AOT SettingsMenuPublisher::Update token 0x060006f7 @0x00133924
	// ELIMINADO (servicio iOS): showed the "BuyCoins" store button while localOptions.appPurchases was on
	// and hid it otherwise; the store is gone, so it always stays hidden.
	private void Update()
	{
		base.ughButtons["BuyCoins"].gameObject.SetActive(false);
	}

	// RECUPERADO-AOT SettingsMenuPublisher::PressedBuyCoins token 0x060006f8 @0x001339e8
	public void PressedBuyCoins()
	{
		FrontEndLogic.NeedMoreCoins(Localize.Get("Buy Tokens!"), -1, true);
	}

	// RECUPERADO-AOT SettingsMenuPublisher::PressedCredits token 0x060006f9 @0x00133a34
	private void PressedCredits()
	{
		FrontEndLogic.RequestMenuChange("Credits");
	}

	// RECUPERADO-AOT SettingsMenuPublisher::PressedGameCenter token 0x060006fa @0x00133a74
	// ELIMINADO (servicio iOS): if GameCenterBinding.isPlayerAuthenticated() showAchievements(), else
	// Script.Instantiate(gameCenterNote). The button is hidden in Start.
	public void PressedGameCenter()
	{
	}

	// RECUPERADO-AOT SettingsMenuPublisher::PressedMoreDisney token 0x060006fb @0x00133ad0
	// ELIMINADO (servicio iOS/externo): ScreenFader.Instance.LoadLevel("MoreDisney"). The button is hidden in Start.
	private void PressedMoreDisney()
	{
	}

	// RECUPERADO-AOT SettingsMenuPublisher::OnAppPurchaseToggleChanged token 0x060006fc @0x00133b20
	public void OnAppPurchaseToggleChanged(UghToggle toggle)
	{
		DataUtility.Instance.localOptions.appPurchases = toggle.State;
		if (DataUtility.Instance.localOptions.appPurchases)
		{
			base.ughTexts["IAPOnOff"].Text = "ON";
			return;
		}
		base.ughTexts["IAPOnOff"].Text = "OFF";
		FrontEndLogic.NeedMoreCoins(Localize.Get("Purchasing Off"), 0, false);
	}

	// RECUPERADO-AOT SettingsMenuPublisher::OnMusicVolumeChanged token 0x060006fd @0x00133c24
	public void OnMusicVolumeChanged(VolumeSlider slider)
	{
		DataUtility.Instance.localOptions.musicVolumeLevel = slider.percent;
		if ((bool)MusicPlayer.Instance)
		{
			MusicPlayer.Instance.UpdateVolume();
		}
	}

	// RECUPERADO-AOT SettingsMenuPublisher::OnSFXVolumeChanged token 0x060006fe @0x00133ca0
	public void OnSFXVolumeChanged(VolumeSlider slider)
	{
		DataUtility.Instance.localOptions.sfxVolumeLevel = slider.percent;
	}

	// RECUPERADO-AOT SettingsMenuPublisher::PressedResetData token 0x060006ff @0x00133cfc
	private void PressedResetData()
	{
		StartCoroutine(CheckResetConfirm());
	}

	// RECUPERADO-AOT SettingsMenuPublisher::OnDebugUnlockPressed token 0x06000700 @0x00133d4c
	public void OnDebugUnlockPressed()
	{
		UnlockAll();
	}

	// RECUPERADO-AOT SettingsMenuPublisher::OnDebugCoinPressed token 0x06000701 @0x00133d80
	public void OnDebugCoinPressed()
	{
		DataUtility.Instance.AddPlayerMoney(100000);
	}

	// RECUPERADO-AOT SettingsMenuPublisher::UnlockAll token 0x06000702 @0x00133dc8
	private void UnlockAll()
	{
		UnityEngine.Debug.Log("Unlocking Everything for the tracks");
		DataUtility.Instance.Unlock("Goofy Mode Toggle");
		DataUtility.Instance.Unlock("Donald Mode Toggle");
		DataUtility.Instance.Unlock("Mickey Mode Toggle");
		DataUtility.Instance.Unlock("Goofy Difficulty Toggle");
		DataUtility.Instance.Unlock("Donald Difficulty Toggle");
		DataUtility.Instance.Unlock("Mickey Difficulty Toggle");
		U4Compat.FindObjectOfType<TrackUnlockHelper>().DebugUnlock = true;
	}

	// RECUPERADO-AOT SettingsMenuPublisher::CheckResetConfirm token 0x06000703 @0x00133f04
	// (iterator <CheckResetConfirm>c__Iterator71 MoveNext token 0x06000a81 @0x0015d398)
	[DebuggerHidden]
	private IEnumerator CheckResetConfirm()
	{
		if (confirmPrefab == null)
		{
			UnityEngine.Debug.Log("The Confirmation Prefab is not set and you're trying to reset data!");
			yield break;
		}
		bool confirm = false;
		GameObject pop = Script.Instantiate(confirmPrefab);
		ConfirmationPublisher pub = pop.GetComponent<ConfirmationPublisher>();
		if (pub != null)
		{
			while (pub != null)
			{
				confirm = pub.confirm;
				yield return 0;
			}
			yield return new WaitForSeconds(0.1f);
			if (confirm)
			{
				UnityEngine.Debug.Log("Resetting Data!!");
				DataUtility.Instance.Relock("Goofy Mode Toggle");
				DataUtility.Instance.Relock("Donald Mode Toggle");
				DataUtility.Instance.Relock("Mickey Mode Toggle");
				DataUtility.Instance.Relock("Goofy Difficulty Toggle");
				DataUtility.Instance.Relock("Donald Difficulty Toggle");
				DataUtility.Instance.Relock("Mickey Difficulty Toggle");
				TrackUnlockHelper tuh = U4Compat.FindObjectOfType<TrackUnlockHelper>();
				tuh.DebugUnlock = false;
				tuh.RelockEverything();
			}
			else
			{
				UnityEngine.Debug.Log("Cancelled Reset!");
			}
		}
		yield return 0;
	}
}
