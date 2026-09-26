using System.Collections;
using System.Diagnostics;

public class GenericPopupPublisher : UghPublisher
{
	private void Start()
	{
		RecoveryPending.Hit("GenericPopupPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("GenericPopupPublisher.Update");
	}

	public void SetText(string text)
	{
		RecoveryPending.Hit("GenericPopupPublisher.SetText");
	}

	private void PressedBacking()
	{
		RecoveryPending.Hit("GenericPopupPublisher.PressedBacking");
	}

	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		RecoveryPending.Hit("GenericPopupPublisher.DestroyThis");
		yield break;
	}
}
