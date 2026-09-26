using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Race results screen: finishing order with times and character icons, then the coin tally (collected tokens,
// placement bonus, difficulty multiplier), the coin and rewind tutorials, and the Done / Retry / Rewind buttons.
// Source listing: recovery/aot_listings/Assembly-CSharp/RaceResultsPublisher.txt
public class RaceResultsPublisher : UghPublisher
{
	[Serializable]
	public class CharacterIcon
	{
		public string name;

		public UghSpritePrototype spriteProto;
	}

	// Row labels in finishing order; ughSprites[i] is the character icon of row i.
	private static readonly string[] RankNames = { "1st", "2nd", "3rd", "4th", "5th", "6th" };

	public GameObject needMoreCoinsPrefab;

	private GameObject moreCoinsDialog;

	public GameObject rewindLapDialogTemplate;

	public Material blueTextMaterial;

	public CharacterIcon[] iconList;

	private int placementReward;

	// RECUPERADO-AOT RaceResultsPublisher::.ctor token 0x0600079a @0x0013e358 (field initializer)
	private bool canAct = true;

	private void SetRankRowActive(int index, bool nameActive, bool timeActive, bool iconActive)
	{
		ughTexts[RankNames[index] + " Name"].gameObject.SetActive(nameActive);
		ughTexts[RankNames[index] + " Time"].gameObject.SetActive(timeActive);
		ughSprites[index].gameObject.SetActive(iconActive);
	}

	// RECUPERADO-AOT RaceResultsPublisher::AnimateScreenCoroutine token 0x0600079b @0x0013e394
	// RECUPERADO-AOT RaceResultsPublisher/<AnimateScreenCoroutine>c__Iterator87::MoveNext token 0x06000b06 @0x00163b14
	[DebuggerHidden]
	private IEnumerator AnimateScreenCoroutine(RaceResults results)
	{
		for (int i = 0; i < RankNames.Length; i++)
		{
			SetRankRowActive(i, false, false, false);
		}
		ughTexts["Collected Coins"].Text = string.Empty;
		ughTexts["Place Bonus"].Text = string.Empty;
		ughTexts["Place Number"].Text = string.Empty;
		ughTexts["Difficulty Mult"].Text = string.Empty;
		ughTexts["Difficulty Setting"].Text = string.Empty;
		ughTexts["Coins"].Text = string.Empty;
		yield return StartCoroutine(AnimatePlaceResultsCoroutine(results));
		yield return StartCoroutine(AnimateCoinsCoroutine(results));
	}

	// RECUPERADO-AOT RaceResultsPublisher::CheckForRewindTutorial token 0x0600079c @0x0013e3ec
	// RECUPERADO-AOT RaceResultsPublisher/<CheckForRewindTutorial>c__Iterator88::MoveNext token 0x06000b0c @0x001642dc
	// Below 3rd place, the first time: runs the rewind tutorial popup and waits until it is dismissed.
	[DebuggerHidden]
	private IEnumerator CheckForRewindTutorial(RaceResults results)
	{
		if (results.playerCarIndex > 2 && !DataUtility.Instance.IsUnlocked("Rewind Tutorial"))
		{
			GameObject obj = base.transform.Find("Rewind Tutorial Popup Handler").gameObject;
			if (obj != null)
			{
				FrontEndTutorialHandler handler = obj.GetComponent<FrontEndTutorialHandler>();
				if (handler != null)
				{
					handler.ActiveTutorial = true;
					while (handler.ActiveTutorial)
					{
						yield return 0;
					}
				}
			}
		}
		yield return 0;
	}

	// RECUPERADO-AOT RaceResultsPublisher::AnimatePlaceResultsCoroutine token 0x0600079d @0x0013e444
	// RECUPERADO-AOT RaceResultsPublisher/<AnimatePlaceResultsCoroutine>c__Iterator89::MoveNext token 0x06000b12 @0x001645a0
	// Reveals one finishing row every 0.25 s (times are hidden in Elimination races).
	[DebuggerHidden]
	private IEnumerator AnimatePlaceResultsCoroutine(RaceResults results)
	{
		FillRanks(results);
		yield return new WaitForSeconds(1f);
		bool showTimes = DataUtility.Instance.CurSettings.raceType != RaceSettings.RaceModes.Elimination;
		for (int index = 0; index < results.ordredResultList.Length; index++)
		{
			if (index < RankNames.Length)
			{
				SetRankRowActive(index, true, showTimes, true);
			}
			SoundLibrary.ButtonClickPlay("guiBeep");
			yield return new WaitForSeconds(0.25f);
		}
	}

	// RECUPERADO-AOT RaceResultsPublisher::AnimateCoinsCoroutine token 0x0600079e @0x0013e49c
	// RECUPERADO-AOT RaceResultsPublisher/<AnimateCoinsCoroutine>c__Iterator8A::MoveNext token 0x06000b18 @0x00164ce0
	// Counts up collected tokens (x10), then the base placement bonus, then the difficulty-multiplied reward,
	// each over one second in 0.0333 s steps; then the coin tutorial, the rewind tutorial and the mission roll.
	[DebuggerHidden]
	private IEnumerator AnimateCoinsCoroutine(RaceResults results)
	{
		int collectedCoins = 0;
		if (results.playerMetrics.otherMetrics.ContainsKey("Tokens Collected"))
		{
			collectedCoins = (int)results.playerMetrics.otherMetrics["Tokens Collected"];
		}
		int baseReward = (int)results.playerMetrics.otherMetrics["Base Placement Reward"];
		int diffMult = (int)results.playerMetrics.otherMetrics["Reward Difficulty Multiplier"];
		if (diffMult == 0)
		{
			diffMult = 1;
		}
		int placeReward = (int)results.playerMetrics.otherMetrics["Placement Reward"];
		int totalCoins = 0;
		collectedCoins *= 10;
		placementReward = placeReward;
		string placeNum = (results.playerCarIndex + 1).ToString();
		switch (Convert.ToInt32(placeNum))
		{
		case 1:
			placeNum += "st";
			break;
		case 2:
			placeNum += "nd";
			break;
		case 3:
			placeNum += "rd";
			break;
		default:
			placeNum += "th";
			break;
		}
		ughTexts["Place Number"].Text = placeNum;
		switch ((int)DataUtility.Instance.localOptions.raceDifficulty)
		{
		case 0:
			ughTexts["Difficulty Setting"].Text = Localize.Get("Easy");
			break;
		case 1:
			ughTexts["Difficulty Setting"].Text = Localize.Get("Medium");
			break;
		case 2:
			ughTexts["Difficulty Setting"].Text = Localize.Get("Hard");
			break;
		case 3:
			ughTexts["Difficulty Setting"].Text = Localize.Get("Ultra");
			break;
		}
		int prevValue = 0;
		for (float timer = 0f; timer < 1f; timer += 0.0333f)
		{
			int newVal = (int)((float)collectedCoins * timer);
			if (newVal > prevValue)
			{
				ughTexts["Collected Coins"].Text = newVal.ToString();
				totalCoins += newVal - prevValue;
				ughTexts["Coins"].Text = totalCoins.ToString();
				prevValue = newVal;
				SoundLibrary.ButtonClickPlay("buyCoins");
			}
			yield return new WaitForSeconds(0.0333f);
		}
		if (prevValue != collectedCoins || collectedCoins == 0)
		{
			ughTexts["Collected Coins"].Text = collectedCoins.ToString();
			totalCoins += collectedCoins - prevValue;
			ughTexts["Coins"].Text = totalCoins.ToString();
		}
		yield return new WaitForSeconds(0.25f);
		prevValue = 0;
		if (baseReward > 0)
		{
			for (float timer = 0f; timer < 1f; timer += 0.0333f)
			{
				int newVal = (int)((float)baseReward * timer);
				if (newVal > prevValue)
				{
					ughTexts["Place Bonus"].Text = newVal.ToString();
					totalCoins += newVal - prevValue;
					ughTexts["Coins"].Text = totalCoins.ToString();
					prevValue = newVal;
					SoundLibrary.ButtonClickPlay("buyCoins");
				}
				yield return new WaitForSeconds(0.0333f);
			}
		}
		if (prevValue != baseReward || baseReward == 0)
		{
			ughTexts["Place Bonus"].Text = baseReward.ToString();
			totalCoins += baseReward - prevValue;
			ughTexts["Coins"].Text = totalCoins.ToString();
		}
		yield return new WaitForSeconds(0.25f);
		ughTexts["Difficulty Mult"].Text = "x" + diffMult.ToString();
		prevValue = baseReward;
		for (float timer = 0f; timer < 1f; timer += 0.0333f)
		{
			int newVal = (int)((float)(placeReward - baseReward) * timer) + baseReward;
			if (newVal > prevValue)
			{
				totalCoins += newVal - prevValue;
				ughTexts["Coins"].Text = totalCoins.ToString();
				prevValue = newVal;
				SoundLibrary.ButtonClickPlay("buyCoins");
			}
			yield return new WaitForSeconds(0.0333f);
		}
		if (prevValue != placeReward || placeReward == 0)
		{
			totalCoins += placeReward - prevValue;
			ughTexts["Coins"].Text = totalCoins.ToString();
		}
		GameObject coinTut = base.transform.Find("Coin Tutorial Popup Handler").gameObject;
		if (coinTut != null)
		{
			FrontEndTutorialHandler tut = coinTut.GetComponent<FrontEndTutorialHandler>();
			while (tut != null && tut.ActiveTutorial)
			{
				yield return 0;
			}
		}
		yield return StartCoroutine(CheckForRewindTutorial(results));
		yield return new WaitForSeconds(0.25f);
		MissionDialogPublisher mdp = (MissionDialogPublisher)U4Compat.FindObjectOfType(typeof(MissionDialogPublisher));
		if (mdp != null)
		{
			mdp.SetRollState(true);
		}
	}

	// RECUPERADO-AOT RaceResultsPublisher::FillRank token 0x0600079f @0x0013e4f4
	// RECUPERADO-AOT RaceResultsPublisher/<FillRank>c__AnonStoreyA6::<>m__35 token 0x06000b62 @0x001671cc (predicate)
	private void FillRank(UghText nameText, UghText timeText, UghSprite iconSlot, CarProgress prog)
	{
		string actualName = (prog.carName == "LocalPlayer") ? PlayerInstance.Instance.cartSlots[(int)CartSlot.Slots.character].partInSlot.UIName.Text : prog.carName;
		nameText.Text = actualName;
		if (prog.finishTime > 0)
		{
			int minutes = prog.finishTime / 60;
			int seconds = prog.finishTime % 60;
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("(");
			if (minutes < 10)
			{
				stringBuilder.Append("0" + minutes);
			}
			else
			{
				stringBuilder.Append(minutes);
			}
			stringBuilder.Append(":");
			if (seconds < 10)
			{
				stringBuilder.Append("0" + seconds);
			}
			else
			{
				stringBuilder.Append(seconds);
			}
			stringBuilder.Append(")");
			timeText.Text = stringBuilder.ToString();
		}
		else
		{
			timeText.Text = "(--:--)";
		}
		CharacterIcon characterIcon = Array.Find(iconList, (CharacterIcon x) => x.name.Equals(actualName));
		if (characterIcon == null)
		{
			iconSlot.gameObject.SetActive(false);
			return;
		}
		iconSlot.Prototype = characterIcon.spriteProto;
		iconSlot.UpdateMesh();
	}

	// RECUPERADO-AOT RaceResultsPublisher::FillRanks token 0x060007a0 @0x0013e88c
	private void FillRanks(RaceResults results)
	{
		for (int i = 0; i < RankNames.Length; i++)
		{
			// The original tests Length > 3 for the 5th and 6th rows as well (not > 4 / > 5); kept as compiled
			// (with 4 or 5 entries it would index past the end of the list, as the original did).
			int threshold = Math.Min(i, 3);
			if (results.ordredResultList.Length > threshold)
			{
				FillRank(ughTexts[RankNames[i] + " Name"], ughTexts[RankNames[i] + " Time"], ughSprites[i], results.ordredResultList[i]);
			}
			else
			{
				SetRankRowActive(i, false, false, false);
			}
		}
		int index = results.playerCarIndex;
		if ((uint)index < (uint)RankNames.Length)
		{
			Renderer nameRenderer = ughTexts[RankNames[index] + " Name"].GetComponent<Renderer>();
			Renderer timeRenderer = ughTexts[RankNames[index] + " Time"].GetComponent<Renderer>();
			timeRenderer.material = blueTextMaterial;
			nameRenderer.material = blueTextMaterial;
		}
		else
		{
			UnityEngine.Debug.Log("Odd player placement at " + index);
		}
	}

	// RECUPERADO-AOT RaceResultsPublisher::Start token 0x060007a1 @0x0013f408
	private void Start()
	{
		ScreenTimeoutController.AllowSleep();
		RaceResults raceResults = U4Compat.FindObjectOfType(typeof(RaceResults)) as RaceResults;
		if (raceResults == null)
		{
			UnityEngine.Debug.LogError("Could not find race results!");
			return;
		}
		StartCoroutine(AnimateScreenCoroutine(raceResults));
		if (DataUtility.Instance.CurSettings.numLaps < 2 || DataUtility.Instance.CurSettings.raceType == RaceSettings.RaceModes.Elimination)
		{
			ughButtons["Rewind"].gameObject.SetActive(false);
		}
		if (DataUtility.Instance.CurSettings.raceType == RaceSettings.RaceModes.Elimination)
		{
			return;
		}
		LifetimeMetrics lifeTimeMetrics = DataUtility.Instance.lifeTimeMetrics;
		string key = Localize.Get("Highest Place ") + Localize.Get(DataUtility.Instance.CurSettings.UIName.baseText);
		if (lifeTimeMetrics.ContainsKey(key))
		{
			int best = (int)lifeTimeMetrics[key];
			if (raceResults.playerCarIndex < best || best < 0)
			{
				LifetimeMetrics.SetMetric(key, raceResults.playerCarIndex);
			}
		}
		else
		{
			LifetimeMetrics.SetMetric(key, raceResults.playerCarIndex);
		}
	}

	// RECUPERADO-AOT RaceResultsPublisher::PressedRewind token 0x060007a2 @0x0013f674
	private void PressedRewind()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		if (U4Compat.FindObjectOfType(typeof(RewindDialogPublisher)) == null)
		{
			GameObject gameObject = Script.Instantiate(rewindLapDialogTemplate);
			RewindDialogPublisher component = gameObject.GetComponent<RewindDialogPublisher>();
			if ((bool)component)
			{
				component.amountToDeduct = placementReward;
			}
		}
	}

	// RECUPERADO-AOT RaceResultsPublisher::PressedDone token 0x060007a3 @0x0013f730
	private void PressedDone()
	{
		if (!canAct)
		{
			return;
		}
		canAct = false;
		RaceResults raceResults = (RaceResults)U4Compat.FindObjectOfType(typeof(RaceResults));
		UnityEngine.Debug.Log("Results: " + raceResults);
		// ELIMINADO (servicio iOS/externo): GDMOManager.SendWithContext("timing", {"player_id": deviceUniqueIdentifier,
		// "location": <pista actual>, "elapsed_time": finishTime del jugador o "error_no_time_found"}) (analitica).
		// The flag object tells the front end (PreFrontEnd) that it is coming back from a race.
		UnityEngine.Object.DontDestroyOnLoad(new GameObject("Race Results Flag Object"));
		SoundLibrary.ButtonClickPlay("menuButton1");
		ScreenFader.Instance.LoadLevel("PreFrontEnd");
		CarMetrics.CleanupCopiedMetrics();
		UnityEngine.Object.Destroy(raceResults.gameObject);
	}

	// RECUPERADO-AOT RaceResultsPublisher::PressedRetry token 0x060007a4 @0x0013f9f0
	private void PressedRetry()
	{
		if (canAct)
		{
			canAct = false;
			SoundLibrary.ButtonClickPlay("menuButton1");
			DataUtility.Instance.CurSettings.lapNumber = -1;
			ScreenFader.Instance.LoadLevel("Loading");
			CarMetrics.CleanupCopiedMetrics();
		}
	}

	// RECUPERADO-AOT RaceResultsPublisher::NeedMoreCoins token 0x060007a5 @0x0013fa8c
	// ELIMINADO (servicio iOS): instanciaba needMoreCoinsPrefab (DebugMoreCoinsPublisher, tienda StoreKit) en
	// moreCoinsDialog con "Need More Tokens" + appPurchasesOffMessage, solo el boton OK y los paquetes de monedas
	// y "Panels" ocultos. Igual que FrontEndLogic.NeedMoreCoins, queda como aviso en el log.
	public static void NeedMoreCoins(string id, int cost)
	{
		RaceResultsPublisher raceResultsPublisher = U4Compat.FindObjectOfType(typeof(RaceResultsPublisher)) as RaceResultsPublisher;
		if (raceResultsPublisher == null)
		{
			UnityEngine.Debug.LogError("This scene requires a RaceResultsPublisher object!");
		}
		UnityEngine.Debug.Log("NeedMoreCoins(" + id + ", " + cost + "): coin store removed (StoreKit).");
	}
}
