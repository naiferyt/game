using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterSelectPublisher : UghPublisher
{
	[Serializable]
	public class Logo
	{
		[HideInInspector]
		public Texture2D texture;

		public string name;

		public LocalizedString resourcePath;

		public LocalizedString webPath;
	}

	private const float SAMPLE_DURATION = 10f;

	public Material blackoutMatrial;

	private int viewingIndex;

	private CartPart previousPart;

	private CartPart[] characterList;

	public GameObject debugPopoverPrefab;

	public List<Logo> logos;

	private bool loadingInLocalizedAssets;

	private new void Awake()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.Awake");
	}

	[DebuggerHidden]
	private IEnumerator LoadInLocalizedAssets(bool web)
	{
		RecoveryPending.Hit("CharacterSelectPublisher.LoadInLocalizedAssets");
		yield break;
	}

	private void SetCharacter()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.SetCharacter");
	}

	private void RefreshCharacter(bool force)
	{
		RecoveryPending.Hit("CharacterSelectPublisher.RefreshCharacter");
	}

	private void SetStatBar(Transform stat, Transform positive, Transform negative, float currentRating)
	{
		RecoveryPending.Hit("CharacterSelectPublisher.SetStatBar");
	}

	private void RefreshStatBars(CartPart curPart, CartPart prevPart)
	{
		RecoveryPending.Hit("CharacterSelectPublisher.RefreshStatBars");
	}

	private void RefreshDisplay()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.RefreshDisplay");
	}

	private void Start()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.Update");
	}

	private void OnDestroy()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.OnDestroy");
	}

	private void PressedRightArrow()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.PressedRightArrow");
	}

	private void PressedLeftArrow()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.PressedLeftArrow");
	}

	private void PressedAction()
	{
		RecoveryPending.Hit("CharacterSelectPublisher.PressedAction");
	}

	public static bool IsTemporary(CartSlot.Slots slot)
	{
		RecoveryPending.Hit("CharacterSelectPublisher.IsTemporary");
		return default(bool);
	}

	private void UpdateLogo(string character)
	{
		RecoveryPending.Hit("CharacterSelectPublisher.UpdateLogo");
	}
}
