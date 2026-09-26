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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator CheckForRewindTutorial(RaceResults results)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator AnimatePlaceResultsCoroutine(RaceResults results)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator AnimateCoinsCoroutine(RaceResults results)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
