using System;
using System.Collections;
using UnityEngine;

public class RaceResultsPublisher : UghPublisher
{
	[Serializable]
	public class CharacterIcon
	{
		public string name;

		public UghSpritePrototype spriteProto;
	}

	public GameObject needMoreCoinsPrefab;

	private GameObject moreCoinsDialog;

	public GameObject rewindLapDialogTemplate;

	public Material blueTextMaterial;

	public CharacterIcon[] iconList;

	private int placementReward;

	private bool canAct;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimateScreenCoroutine(RaceResults results)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CheckForRewindTutorial(RaceResults results)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimatePlaceResultsCoroutine(RaceResults results)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimateCoinsCoroutine(RaceResults results)
	{
		return default(IEnumerator);
	}

	private void FillRank(UghText nameText, UghText timeText, UghSprite iconSlot, CarProgress prog)
	{
	}

	private void FillRanks(RaceResults results)
	{
	}

	private void Start()
	{
	}

	private void PressedRewind()
	{
	}

	private void PressedDone()
	{
	}

	private void PressedRetry()
	{
	}

	public static void NeedMoreCoins(string id, int cost)
	{
	}
}
