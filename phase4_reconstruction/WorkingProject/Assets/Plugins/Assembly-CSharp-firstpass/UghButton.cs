using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghButton : UghControl
{
	public UghSpritePrototype pressed;

	public UghSpritePrototype mouseOver;

	public Action<UghButton> OnPressed;

	public Action<UghButton, bool> OnDown;

	private bool wasDown;

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

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}
}
