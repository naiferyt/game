using System.Collections;
using System.Diagnostics;
using UnityEngine;

// "Redo the last lap" dialog on the results screen: costs REWIND_COST (+ amountToDeduct) coins.
// Source listing: recovery/aot_listings/Assembly-CSharp/RewindDialogPublisher.txt
public class RewindDialogPublisher : UghPublisher
{
	public const int REWIND_COST = 500;

	public int amountToDeduct;

	public static int RewindCost
	{
		// RECUPERADO-AOT RewindDialogPublisher::get_RewindCost token 0x060007a8 @0x0013fe3c
		get
		{
			return 500;
		}
	}

	// RECUPERADO-AOT RewindDialogPublisher::Start token 0x060007a9 @0x0013fe64
	private void Start()
	{
		float num = 0f;
		float num2 = 0f;
		num = DataUtility.Instance.cloudData.playerMoney;
		if (num > 999999f)
		{
			num2 = num / 1000000f;
			base.ughTexts["Coins"].Text = num2.ToString("F1") + Localize.Get(" M");
		}
		else
		{
			base.ughTexts["Coins"].Text = num.ToString();
		}
		SoundLibrary.PlayRandomWhoosh();
	}

	// RECUPERADO-AOT RewindDialogPublisher::PressedExit token 0x060007aa @0x0013fff0
	private void PressedExit()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		StartCoroutine(DestroyThis());
	}

	// RECUPERADO-AOT RewindDialogPublisher::PressedBuy token 0x060007ab @0x00140054
	// ELIMINADO (analitica): after paying, the original sent GDMOManager.SendWithContext("game_action",
	// {player_id: SystemInfo.deviceUniqueIdentifier, context: "race", action: "buy rewind", type: ...}).
	private void PressedBuy()
	{
		if (MoneyCheck())
		{
			DataUtility.Instance.AddPlayerMoney(-(amountToDeduct + 500));
			FinalizedRewind();
		}
		else
		{
			NeedMoreCoins();
		}
	}

	// RECUPERADO-AOT RewindDialogPublisher::MoneyCheck token 0x060007ac @0x001401e8
	private bool MoneyCheck()
	{
		return DataUtility.Instance.cloudData.playerMoney >= 500;
	}

	// RECUPERADO-AOT RewindDialogPublisher::NeedMoreCoins token 0x060007ad @0x0014023c
	private void NeedMoreCoins()
	{
		RaceResultsPublisher.NeedMoreCoins(Localize.Get("You have ") + DataUtility.Instance.cloudData.playerMoney + Localize.Get(", and need "), 500);
	}

	// RECUPERADO-AOT RewindDialogPublisher::FinalizedRewind token 0x060007ae @0x001402e4
	private void FinalizedRewind()
	{
		DataUtility.Instance.CurSettings.lapNumber = DataUtility.Instance.CurSettings.numLaps;
		ScreenFader.Instance.LoadLevel("Loading");
	}

	// RECUPERADO-AOT RewindDialogPublisher::DestroyThis token 0x060007af @0x00140368
	// RECUPERADO-AOT RewindDialogPublisher/<DestroyThis>c__Iterator8B::MoveNext token 0x06000b1e @0x00165c0c
	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		Animation anim = GetComponentInChildren<Animation>();
		if (anim != null)
		{
			anim.Play("AchievementOUT");
		}
		SoundLibrary.PlayRandomWhoosh();
		base.gameObject.BroadcastMessage("FadeOut");
		yield return new WaitForSeconds(0.5f);
		Object.Destroy(base.gameObject);
	}
}
