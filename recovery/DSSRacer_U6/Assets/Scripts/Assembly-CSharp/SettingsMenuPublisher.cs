using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class SettingsMenuPublisher : UghPublisher
{
	public GameObject confirmPrefab;

	public GameObject gameCenterNote;

	private void Start()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.Update");
	}

	public void PressedBuyCoins()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.PressedBuyCoins");
	}

	private void PressedCredits()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.PressedCredits");
	}

	public void PressedGameCenter()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.PressedGameCenter");
	}

	private void PressedMoreDisney()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.PressedMoreDisney");
	}

	public void OnAppPurchaseToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("SettingsMenuPublisher.OnAppPurchaseToggleChanged");
	}

	public void OnMusicVolumeChanged(VolumeSlider slider)
	{
		RecoveryPending.Hit("SettingsMenuPublisher.OnMusicVolumeChanged");
	}

	public void OnSFXVolumeChanged(VolumeSlider slider)
	{
		RecoveryPending.Hit("SettingsMenuPublisher.OnSFXVolumeChanged");
	}

	private void PressedResetData()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.PressedResetData");
	}

	public void OnDebugUnlockPressed()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.OnDebugUnlockPressed");
	}

	public void OnDebugCoinPressed()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.OnDebugCoinPressed");
	}

	private void UnlockAll()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.UnlockAll");
	}

	[DebuggerHidden]
	private IEnumerator CheckResetConfirm()
	{
		RecoveryPending.Hit("SettingsMenuPublisher.CheckResetConfirm");
		yield break;
	}
}
