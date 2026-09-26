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
	}

	[DebuggerHidden]
	private IEnumerator LoadInLocalizedAssets(bool web)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void SetCharacter()
	{
	}

	private void RefreshCharacter(bool force)
	{
	}

	private void SetStatBar(Transform stat, Transform positive, Transform negative, float currentRating)
	{
	}

	private void RefreshStatBars(CartPart curPart, CartPart prevPart)
	{
	}

	private void RefreshDisplay()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void PressedRightArrow()
	{
	}

	private void PressedLeftArrow()
	{
	}

	private void PressedAction()
	{
	}

	public static bool IsTemporary(CartSlot.Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void UpdateLogo(string character)
	{
	}
}
