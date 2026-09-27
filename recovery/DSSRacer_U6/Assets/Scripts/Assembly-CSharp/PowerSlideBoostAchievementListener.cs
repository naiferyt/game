using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: get numTimes power-slide boosts in one race.
// Source listing: recovery/aot_listings/Assembly-CSharp/PowerSlideBoostAchievementListener.txt
public class PowerSlideBoostAchievementListener : AchievementListener
{
	// RECUPERADO-AOT PowerSlideBoostAchievementListener::.ctor token 0x06000157 (field initializer)
	public int numTimes = 1;

	private CarMetrics metrics;

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::Start token 0x06000158 @0x000d3d90
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::Update token 0x06000159 @0x000d3de8
	private void Update()
	{
		if (metrics == null && RaceManager.GetPlayerCar() != null)
		{
			metrics = RaceManager.GetPlayerCar().GetComponent<CarMetrics>();
		}
	}

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::IsAvailable token 0x0600015a @0x000d3e70
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::CheckMetricsPump token 0x0600015b @0x000d3eb0
	// RECUPERADO-AOT PowerSlideBoostAchievementListener/<CheckMetricsPump>c__Iterator13::MoveNext token 0x06000842 @0x00143dec
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(1f);
		}
		Achieve();
	}

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::CheckMetrics token 0x0600015c @0x000d3ef8
	private bool CheckMetrics()
	{
		if (metrics != null && metrics.otherMetrics.ContainsKey("PowerSlide Boost") && (int)metrics.otherMetrics["PowerSlide Boost"] >= numTimes)
		{
			return true;
		}
		return false;
	}

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::Postrace token 0x0600015d @0x000d3fb4
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::Prerace token 0x0600015e @0x000d4008 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT PowerSlideBoostAchievementListener::Reward token 0x0600015f @0x000d4034
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: Triggered Powerslide Boost Achievement");
	}
}
