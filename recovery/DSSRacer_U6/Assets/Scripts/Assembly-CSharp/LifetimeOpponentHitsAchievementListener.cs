using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: hit opponents numTimes with a power-up type over all races.
// Source listing: recovery/aot_listings/Assembly-CSharp/LifetimeOpponentHitsAchievementListener.txt
public class LifetimeOpponentHitsAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes type;

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::.ctor token 0x06000120 (field initializer)
	public int numTimes = 1;

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::Start token 0x06000121 @0x000d29bc
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::Update token 0x06000122 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::IsAvailable token 0x06000123 @0x000d2a40
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::Prerace token 0x06000124 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::Postrace token 0x06000125 @0x000d2ab4
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::CheckMetricsPump token 0x06000126 @0x000d2b08
	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener/<CheckMetricsPump>c__IteratorE::MoveNext token 0x06000824 @0x0014330c
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(5f);
		}
		Achieve();
	}

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::CheckMetrics token 0x06000127 @0x000d2b50
	private bool CheckMetrics()
	{
		string key = "Lifetime " + type + " success";
		return (int)DataUtility.Instance.lifeTimeMetrics[key] >= numTimes;
	}

	// RECUPERADO-AOT LifetimeOpponentHitsAchievementListener::Reward token 0x06000128 @0x000d2c30
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: triggered the lifetime hit opponents achievement");
	}
}
