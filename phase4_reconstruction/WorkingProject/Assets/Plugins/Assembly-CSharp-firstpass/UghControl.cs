using System.Collections;
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
			return default(int);
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
			return default(bool);
		}
	}

	[System.Diagnostics.DebuggerHidden]
	public virtual IEnumerator OnUghInputDown()
	{
		return default(IEnumerator);
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
