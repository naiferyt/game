using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class UghControl : UghSprite
{
	public bool autoSizeCollider;

	public bool passThrough;

	public static UghControl[] theOnlyLegalControls;

	public int HotFingerID
	{
		[CompilerGenerated]
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public bool isLegalControl
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[DebuggerHidden]
	public virtual IEnumerator OnUghInputDown()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public virtual void OnUghInputUp()
	{
	}

	public virtual void OnUghInputDrag()
	{
	}

	public virtual void OnUghInputUpAsButton()
	{
	}

	public virtual void OnUghInputUpLate()
	{
	}

	[ContextMenu("Autosize Collider")]
	public virtual void AutoSizeCollider()
	{
	}

	protected override void OnDrawGizmos()
	{
	}

	protected virtual void Reset()
	{
	}
}
