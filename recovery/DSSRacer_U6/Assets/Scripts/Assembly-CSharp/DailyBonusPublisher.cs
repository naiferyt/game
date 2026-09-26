using System.Collections;
using System.Diagnostics;

public class DailyBonusPublisher : UghPublisher
{
	private void Start()
	{
		RecoveryPending.Hit("DailyBonusPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("DailyBonusPublisher.Update");
	}

	private void OnPressed()
	{
		RecoveryPending.Hit("DailyBonusPublisher.OnPressed");
	}

	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		RecoveryPending.Hit("DailyBonusPublisher.DestroyThis");
		yield break;
	}
}
