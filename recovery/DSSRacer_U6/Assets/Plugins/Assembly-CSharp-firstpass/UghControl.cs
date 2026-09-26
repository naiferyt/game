using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

// Base of the interactive Ugh sprites: box collider sized to the sprite and the input callbacks UghInput sends.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghControl.txt
public abstract class UghControl : UghSprite
{
	// RECUPERADO-AOT UghControl..ctor token 0x06000396 @0x0003b014 (field initializer)
	public bool autoSizeCollider = true;

	public bool passThrough;

	public static UghControl[] theOnlyLegalControls;

	public int HotFingerID
	{
		// RECUPERADO-AOT UghControl.get_HotFingerID token 0x06000398 @0x0003b074
		[CompilerGenerated]
		get;
		// RECUPERADO-AOT UghControl.set_HotFingerID token 0x06000399 @0x0003b0a8
		[CompilerGenerated]
		set;
	}

	public bool isLegalControl
	{
		// RECUPERADO-AOT UghControl.get_isLegalControl token 0x0600039a @0x0003b0e4
		get
		{
			if (theOnlyLegalControls == null)
			{
				return true;
			}
			return Array.IndexOf<UghControl>(theOnlyLegalControls, this) != -1;
		}
	}

	// RECUPERADO-AOT UghControl.OnUghInputDown token 0x0600039b @0x0003b17c
	// (body: <OnUghInputDown>c__Iterator1A.MoveNext token 0x060005b2 @0x000574e0: finishes immediately)
	public virtual IEnumerator OnUghInputDown()
	{
		yield break;
	}

	// RECUPERADO-AOT UghControl.OnUghInputUp token 0x0600039c @0x0003b1bc (empty in the original)
	public virtual void OnUghInputUp()
	{
	}

	// RECUPERADO-AOT UghControl.OnUghInputDrag token 0x0600039d @0x0003b1e8 (empty in the original)
	public virtual void OnUghInputDrag()
	{
	}

	// RECUPERADO-AOT UghControl.OnUghInputUpAsButton token 0x0600039e @0x0003b214 (empty in the original)
	public virtual void OnUghInputUpAsButton()
	{
	}

	// RECUPERADO-AOT UghControl.OnUghInputUpLate token 0x0600039f @0x0003b240 (empty in the original)
	public virtual void OnUghInputUpLate()
	{
	}

	// RECUPERADO-AOT UghControl.AutoSizeCollider token 0x060003a0 @0x0003b26c
	[ContextMenu("Autosize Collider")]
	public virtual void AutoSizeCollider()
	{
		BoxCollider box = GetComponent<BoxCollider>();
		if (box == null)
		{
			return;
		}
		if ((bool)normal)
		{
			box.size = normal.size;
			box.center = GetLocalCenter();
		}
		else
		{
			box.size = new Vector3(1f, 1f, 0f);
			box.center = new Vector3(0.5f, -0.5f, 0f);
		}
	}

	// RECUPERADO-AOT UghControl.OnDrawGizmos token 0x060003a1 @0x0003b47c
	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		if (!Application.isPlaying && enabled && autoSizeCollider)
		{
			AutoSizeCollider();
		}
	}

	// RECUPERADO-AOT UghControl.Reset token 0x060003a2 @0x0003b4e8
	protected virtual void Reset()
	{
		// ADAPTADO-U6: Component.rigidbody -> GetComponent<Rigidbody>()
		if (GetComponent<Rigidbody>() != null)
		{
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().isKinematic = true;
		}
		BoxCollider box = GetComponent<BoxCollider>();
		if (box != null)
		{
			box.isTrigger = true;
		}
		AutoSizeCollider();
	}
}
