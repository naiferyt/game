using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Achievement: collect (or buy, when purchased) numTimes power-ups over all races.
// Source listing: recovery/aot_listings/Assembly-CSharp/LifetimePowerupCollectionAchievementListener.txt
public class LifetimePowerupCollectionAchievementListener : AchievementListener
{
	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::.ctor token 0x06000129 (field initializer)
	public int numTimes = 1;

	public bool purchased;

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::Start token 0x0600012a @0x000d2cac
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::Update token 0x0600012b (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::IsAvailable token 0x0600012c @0x000d2d30
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::Prerace token 0x0600012d (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::Postrace token 0x0600012e @0x000d2da4
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::CheckMetricsPump token 0x0600012f @0x000d2df8
	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener/<CheckMetricsPump>c__IteratorF::MoveNext token 0x0600082a @0x001434f8
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(10f);
		}
		Achieve();
	}

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::CheckMetrics token 0x06000130 @0x000d2e40
	private bool CheckMetrics()
	{
		string text = "Lifetime Powerup ";
		text = ((!purchased) ? (text + "Collection") : (text + "Purchased"));
		return (int)DataUtility.Instance.lifeTimeMetrics[text] >= numTimes;
	}

	// RECUPERADO-AOT LifetimePowerupCollectionAchievementListener::Reward token 0x06000131 @0x000d2f10
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: triggered the Lifetime powerup collection achievement");
	}
}
