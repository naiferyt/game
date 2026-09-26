using System.Collections;
using System.Diagnostics;

public class UseAPowerupAchievementListener : AchievementListener
{
	public int numberOfTimes;

	public BaseEffect.EffectTypes type;

	public bool isDouble;

	private void Start()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.Update");
	}

	private bool CheckCarMetrics()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.CheckCarMetrics");
		return default(bool);
	}

	[DebuggerHidden]
	private IEnumerator PowerupUseCheckPump()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.PowerupUseCheckPump");
		yield break;
	}

	public override bool IsAvailable()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.IsAvailable");
		return default(bool);
	}

	public override void Prerace()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.Prerace");
	}

	public override void Postrace()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.Postrace");
	}

	public override void Reward()
	{
		RecoveryPending.Hit("UseAPowerupAchievementListener.Reward");
	}
}
