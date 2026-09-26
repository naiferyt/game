using System.Collections;
using System.Diagnostics;

public class UsePowerupAgainstOpponentAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes type;

	public int numHits;

	private void Start()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.Update");
	}

	[DebuggerHidden]
	private IEnumerator CheckMetricsPump()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.CheckMetricsPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.CheckMetrics");
		return default(bool);
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("UsePowerupAgainstOpponentAchievementListener.Reward");
	}
}
