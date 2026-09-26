using System;
using System.Collections;
using System.Diagnostics;
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

	[DebuggerHidden]
	private IEnumerator AnimateScreenCoroutine(RaceResults results)
	{
		RecoveryPending.Hit("RaceResultsPublisher.AnimateScreenCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator CheckForRewindTutorial(RaceResults results)
	{
		RecoveryPending.Hit("RaceResultsPublisher.CheckForRewindTutorial");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator AnimatePlaceResultsCoroutine(RaceResults results)
	{
		RecoveryPending.Hit("RaceResultsPublisher.AnimatePlaceResultsCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator AnimateCoinsCoroutine(RaceResults results)
	{
		RecoveryPending.Hit("RaceResultsPublisher.AnimateCoinsCoroutine");
		yield break;
	}

	private void FillRank(UghText nameText, UghText timeText, UghSprite iconSlot, CarProgress prog)
	{
		RecoveryPending.Hit("RaceResultsPublisher.FillRank");
	}

	private void FillRanks(RaceResults results)
	{
		RecoveryPending.Hit("RaceResultsPublisher.FillRanks");
	}

	private void Start()
	{
		RecoveryPending.Hit("RaceResultsPublisher.Start");
	}

	private void PressedRewind()
	{
		RecoveryPending.Hit("RaceResultsPublisher.PressedRewind");
	}

	private void PressedDone()
	{
		RecoveryPending.Hit("RaceResultsPublisher.PressedDone");
	}

	private void PressedRetry()
	{
		RecoveryPending.Hit("RaceResultsPublisher.PressedRetry");
	}

	public static void NeedMoreCoins(string id, int cost)
	{
		RecoveryPending.Hit("RaceResultsPublisher.NeedMoreCoins");
	}
}
