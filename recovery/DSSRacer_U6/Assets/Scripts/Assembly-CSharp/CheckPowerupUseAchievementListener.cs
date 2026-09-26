using System.Collections;
using System.Diagnostics;

public class CheckPowerupUseAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes[] typesToCheck;

	public bool doublesOnly;

	private void Start()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.Update");
	}

	[DebuggerHidden]
	private IEnumerator PowerupUseCheckPump()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.PowerupUseCheckPump");
		yield break;
	}

	private bool CheckMetrics()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.CheckMetrics");
		return default(bool);
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("CheckPowerupUseAchievementListener.Reward");
	}
}
