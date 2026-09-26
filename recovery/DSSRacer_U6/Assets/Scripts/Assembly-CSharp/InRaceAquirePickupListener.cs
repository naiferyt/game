using System.Collections;
using System.Diagnostics;

public class InRaceAquirePickupListener : AchievementListener
{
	public int numTimes;

	public bool pickup;

	public BaseEffect.EffectTypes typeIfPickup;

	private void Start()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.Update");
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.IsAvailable");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.CheckMetrics");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("InRaceAquirePickupListener.Reward");
	}
}
