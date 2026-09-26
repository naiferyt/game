using System.Collections;

public class CheckPowerupUseAchievementListener : AchievementListener
{
	public BaseEffect.EffectTypes[] typesToCheck;

	public bool doublesOnly;

	private void Start()
	{
	}

	private void Update()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator PowerupUseCheckPump()
	{
		return default(IEnumerator);
	}

	private bool CheckMetrics()
	{
		return default(bool);
	}

	public override bool IsAvailable()
	{
		return default(bool);
	}

	public override void Prerace()
	{
	}

	public override void Postrace()
	{
	}

	public override void Reward()
	{
	}
}
