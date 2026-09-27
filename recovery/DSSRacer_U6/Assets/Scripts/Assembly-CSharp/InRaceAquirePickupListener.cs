using System.Collections;
using System.Diagnostics;
using UnityEngine;

// In-race achievement: collect a given power-up type (pickup) or buy power-ups numTimes times in one race.
// Source listing: recovery/aot_listings/Assembly-CSharp/InRaceAquirePickupListener.txt
public class InRaceAquirePickupListener : AchievementListener
{
	// RECUPERADO-AOT InRaceAquirePickupListener::.ctor token 0x06000109 @0x000d20d8 (field initializer)
	public int numTimes = 1;

	public bool pickup;

	public BaseEffect.EffectTypes typeIfPickup;

	// RECUPERADO-AOT InRaceAquirePickupListener::Start token 0x0600010a @0x000d2114
	private void Start()
	{
		state = AchievementState.ACTIVE;
		StartCoroutine(CheckMetricsPump());
	}

	// RECUPERADO-AOT InRaceAquirePickupListener::Update token 0x0600010b @0x000d216c (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT InRaceAquirePickupListener::IsAvailable token 0x0600010c @0x000d2198
	public override bool IsAvailable()
	{
		return !HasAchieved();
	}

	// RECUPERADO-AOT InRaceAquirePickupListener::CheckMetricsPump token 0x0600010d @0x000d21e0
	// RECUPERADO-AOT InRaceAquirePickupListener/<CheckMetricsPump>c__IteratorC::MoveNext token 0x06000818 @0x00142eec
	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		while (!CheckMetrics())
		{
			yield return new WaitForSeconds(1f);
		}
		Achieve();
	}

	// RECUPERADO-AOT InRaceAquirePickupListener::CheckMetrics token 0x0600010e @0x000d2228
	private bool CheckMetrics()
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			CarMetrics component = playerCar.GetComponent<CarMetrics>();
			if (component != null)
			{
				string empty = string.Empty;
				empty = ((!pickup) ? "Purchased Powerup" : ("Collected " + typeIfPickup));
				int num = -1;
				if (component.otherMetrics.ContainsKey(empty))
				{
					num = (int)component.otherMetrics[empty];
				}
				return num >= numTimes;
			}
		}
		return false;
	}

	// RECUPERADO-AOT InRaceAquirePickupListener::Prerace token 0x0600010f @0x000d2398 (empty)
	public override void Prerace()
	{
	}

	// RECUPERADO-AOT InRaceAquirePickupListener::Postrace token 0x06000110 @0x000d23c4
	public override void Postrace()
	{
		if (!HasAchieved() && CheckMetrics())
		{
			Achieve();
		}
	}

	// RECUPERADO-AOT InRaceAquirePickupListener::Reward token 0x06000111 @0x000d2418
	public override void Reward()
	{
		UnityEngine.Debug.Log("TODO: triggered in race powerup purchase achievement");
	}
}
