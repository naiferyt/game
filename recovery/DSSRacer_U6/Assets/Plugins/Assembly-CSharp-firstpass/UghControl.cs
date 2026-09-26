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
			RecoveryPending.Hit("UghControl.get_HotFingerID");
			return default(int);
		}
		[CompilerGenerated]
		set
		{
			RecoveryPending.Hit("UghControl.set_HotFingerID");
		}
	}

	public bool isLegalControl
	{
		get
		{
			RecoveryPending.Hit("UghControl.get_isLegalControl");
			return default(bool);
		}
	}

	[DebuggerHidden]
	public virtual IEnumerator OnUghInputDown()
	{
		RecoveryPending.Hit("UghControl.OnUghInputDown");
		yield break;
	}

	public virtual void OnUghInputUp()
	{
		RecoveryPending.Hit("UghControl.OnUghInputUp");
	}

	public virtual void OnUghInputDrag()
	{
		RecoveryPending.Hit("UghControl.OnUghInputDrag");
	}

	public virtual void OnUghInputUpAsButton()
	{
		RecoveryPending.Hit("UghControl.OnUghInputUpAsButton");
	}

	public virtual void OnUghInputUpLate()
	{
		RecoveryPending.Hit("UghControl.OnUghInputUpLate");
	}

	[ContextMenu("Autosize Collider")]
	public virtual void AutoSizeCollider()
	{
		RecoveryPending.Hit("UghControl.AutoSizeCollider");
	}

	protected override void OnDrawGizmos()
	{
		RecoveryPending.Hit("UghControl.OnDrawGizmos");
	}

	protected virtual void Reset()
	{
		RecoveryPending.Hit("UghControl.Reset");
	}
}
