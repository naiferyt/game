using System.Collections;
using System.Diagnostics;

public class UghButtonDisablable : UghButton
{
	public UghSpritePrototype unlocked;

	private UghSpritePrototype locked;

	public void Start()
	{
	}

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
