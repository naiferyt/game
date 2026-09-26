using System;
using System.Collections;
using UnityEngine;

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
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public bool HighlightState
	{
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	[System.Diagnostics.DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		return default(IEnumerator);
	}

	public override void OnUghInputUp()
	{
	}

	public override void OnUghInputUpAsButton()
	{
	}

	private UghSpritePrototype GetUghSpritePrototypeForCurrentState()
	{
		return default(UghSpritePrototype);
	}

	private void UpdateMeshForCurrentState()
	{
	}

	private void SendOnChanged()
	{
	}

	private void OnMouseExit()
	{
	}
}
