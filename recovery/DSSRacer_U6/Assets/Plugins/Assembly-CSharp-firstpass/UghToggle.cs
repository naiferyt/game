using System;
using System.Collections;
using UnityEngine;

// On/off button with separate normal / pressed / on / on-pressed prototypes.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghToggle.txt
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghToggle : UghControl
{
	public UghSpritePrototype normalPressed;

	public UghSpritePrototype on;

	public UghSpritePrototype onPressed;

	public Action<UghToggle, bool> OnDown;

	public Action<UghToggle> OnChanged;

	private bool state;

	private bool pressed;

	private bool wasDown;

	public bool State
	{
		// RECUPERADO-AOT UghToggle.get_State token 0x060003d7 @0x0003e5a4
		get
		{
			return state;
		}
		// RECUPERADO-AOT UghToggle.set_State token 0x060003d8 @0x0003e5d8
		set
		{
			state = value;
			UpdateMeshForCurrentState();
			SendOnChanged();
		}
	}

	public bool HighlightState
	{
		// RECUPERADO-AOT UghToggle.get_HighlightState token 0x060003d9 @0x0003e620
		get
		{
			return state;
		}
		// RECUPERADO-AOT UghToggle.set_HighlightState token 0x060003da @0x0003e654
		set
		{
			state = value;
			UpdateMeshForCurrentState();
		}
	}

	// RECUPERADO-AOT UghToggle.OnUghInputDown token 0x060003db @0x0003e694
	// (body: <OnUghInputDown>c__Iterator25.MoveNext token 0x060005f4 @0x0005da40)
	public override IEnumerator OnUghInputDown()
	{
		if (isLegalControl)
		{
			pressed = true;
			UpdateMeshForCurrentState();
			if (OnDown != null)
			{
				wasDown = true;
				OnDown(this, true);
			}
		}
		yield break;
	}

	// RECUPERADO-AOT UghToggle.OnUghInputUp token 0x060003dc @0x0003e6dc
	public override void OnUghInputUp()
	{
		pressed = false;
		UpdateMeshForCurrentState();
		if (OnDown != null && wasDown)
		{
			wasDown = false;
			OnDown(this, false);
		}
	}

	// RECUPERADO-AOT UghToggle.OnUghInputUpAsButton token 0x060003dd @0x0003e750
	public override void OnUghInputUpAsButton()
	{
		if (!isLegalControl)
		{
			return;
		}
		pressed = false;
		State = !state;
		if (OnDown != null && wasDown)
		{
			wasDown = false;
			OnDown(this, false);
		}
	}

	// RECUPERADO-AOT UghToggle.GetUghSpritePrototypeForCurrentState token 0x060003de @0x0003e7e4
	private UghSpritePrototype GetUghSpritePrototypeForCurrentState()
	{
		if (state)
		{
			return pressed ? onPressed : on;
		}
		return pressed ? normalPressed : normal;
	}

	// RECUPERADO-AOT UghToggle.UpdateMeshForCurrentState token 0x060003df @0x0003e850
	private void UpdateMeshForCurrentState()
	{
		UpdateMeshWithSpritePrototype(GetUghSpritePrototypeForCurrentState());
	}

	// RECUPERADO-AOT UghToggle.SendOnChanged token 0x060003e0 @0x0003e898
	private void SendOnChanged()
	{
		if (OnChanged != null)
		{
			OnChanged(this);
		}
	}

	// RECUPERADO-AOT UghToggle.OnMouseExit token 0x060003e1 @0x0003e8e4
	private void OnMouseExit()
	{
		if (OnDown != null && wasDown)
		{
			wasDown = false;
			OnDown(this, false);
		}
	}
}
