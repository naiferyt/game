using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: get hit numTimes by the track hazard hazardType on trackName.
// Source listing: recovery/aot_listings/Assembly-CSharp/GetHitByTrackHazardAchievementListener.txt
public class GetHitByTrackHazardAchievementListener : AchievementListener
{
	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::.ctor token 0x060000f9 (field initializer)
	public int numTimes = 1;

	public UnlocalizedString hazardType;

	public UnlocalizedString trackName;

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::Start token 0x060000fa @0x000d1c18
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::Update token 0x060000fb @0x000d1c70 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::IsAvailable token 0x060000fc @0x000d1c9c
	public override bool IsAvailable()
	{
		if (HasAchieved())
		{
			return false;
		}
		if (DataUtility.Instance.CurSettings.levelName.baseText != trackName.baseText)
		{
			return false;
		}
		return true;
	}

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::CheckMetricsPump token 0x060000fd @0x000d1d30
	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener/<CheckMetricsPump>c__IteratorA::MoveNext token 0x0600080c @0x00142ab0
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(2f);
		}
		Achieve();
	}

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::CheckMetrics token 0x060000fe @0x000d1d78
	private bool CheckMetrics()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			CarMetrics component = playerCar.GetComponent<CarMetrics>();
			if (component != null)
			{
				string key = hazardType.baseText + " collision";
				int num = -1;
				if (component.otherMetrics.ContainsKey(key))
				{
					num = (int)component.otherMetrics[key];
				}
				return num >= numTimes;
			}
		}
		return false;
	}

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::Prerace token 0x060000ff @0x000d1e6c (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::Postrace token 0x06000100 @0x000d1e98
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT GetHitByTrackHazardAchievementListener::Reward token 0x06000101 @0x000d1eec
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: triggered hit by track hazard achievement");
	}
}
