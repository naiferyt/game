using System.Collections;
using System.Diagnostics;

public class MineNotifyPublisher : UghPublisher
{
	private const float LIFE_TIME = 1f;

	[DebuggerHidden]
	private IEnumerator Lifetime()
	{
		RecoveryPending.Hit("MineNotifyPublisher.Lifetime");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator FadeIn()
	{
		RecoveryPending.Hit("MineNotifyPublisher.FadeIn");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator FadeOut()
	{
		RecoveryPending.Hit("MineNotifyPublisher.FadeOut");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("MineNotifyPublisher.Start");
	}

	public void SetDisplayName(string text)
	{
		RecoveryPending.Hit("MineNotifyPublisher.SetDisplayName");
	}
}
