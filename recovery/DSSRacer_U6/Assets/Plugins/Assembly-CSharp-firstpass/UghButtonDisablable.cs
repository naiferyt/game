using System.Collections;
using System.Diagnostics;

public class UghButtonDisablable : UghButton
{
	public UghSpritePrototype unlocked;

	private UghSpritePrototype locked;

	public void Start()
	{
		RecoveryPending.Hit("UghButtonDisablable.Start");
	}

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		RecoveryPending.Hit("UghButtonDisablable.OnUghInputDown");
		yield break;
	}

	public override void OnUghInputUpAsButton()
	{
		RecoveryPending.Hit("UghButtonDisablable.OnUghInputUpAsButton");
	}

	public void SetLock(bool b)
	{
		RecoveryPending.Hit("UghButtonDisablable.SetLock");
	}

	public void ToggleLock()
	{
		RecoveryPending.Hit("UghButtonDisablable.ToggleLock");
	}
}
