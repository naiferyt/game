using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: have at least `balance` coins.
// Source listing: recovery/aot_listings/Assembly-CSharp/CoinBalanceAchievementListener.txt
public class CoinBalanceAchievementListener : AchievementListener
{
	public int balance;

	// RECUPERADO-AOT CoinBalanceAchievementListener::IsAvailable token 0x060000d1 @0x000d0f3c
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT CoinBalanceAchievementListener::Prerace token 0x060000d2 @0x000d0f7c (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT CoinBalanceAchievementListener::Postrace token 0x060000d3 @0x000d0fa8 (empty)
	public override void Postrace()
	{
	}

	// RECUPERADO-AOT CoinBalanceAchievementListener::Reward token 0x060000d4 @0x000d0fd4
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: reward for CoinBalanceAchievementListener");
	}

	// RECUPERADO-AOT CoinBalanceAchievementListener::CheckCoinBalanceCoroutine token 0x060000d5 @0x000d1014
	// RECUPERADO-AOT CoinBalanceAchievementListener/<CheckCoinBalanceCoroutine>c__Iterator6::MoveNext token 0x060007f4 @0x00141e80
	[DebuggerHidden]
	private IEnumerator CheckCoinBalanceCoroutine()
	{
		do
		{
			yield return new WaitForSeconds(0.5f);
		}
		while (DataUtility.Instance.cloudData.playerMoney < balance);
		Achieve();
	}

	// RECUPERADO-AOT CoinBalanceAchievementListener::Start token 0x060000d6 @0x000d105c
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckCoinBalanceCoroutine());
	}
}
