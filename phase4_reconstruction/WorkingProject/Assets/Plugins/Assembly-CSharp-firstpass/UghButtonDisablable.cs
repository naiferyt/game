using System.Collections;

public class UghButtonDisablable : UghButton
{
	public UghSpritePrototype unlocked;

	private UghSpritePrototype locked;

	public void Start()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		return default(IEnumerator);
	}

	public override void OnUghInputUpAsButton()
	{
	}

	public void SetLock(bool b)
	{
	}

	public void ToggleLock()
	{
	}
}
