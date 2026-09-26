using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghButton : UghControl
{
	public UghSpritePrototype pressed;

	public UghSpritePrototype mouseOver;

	public Action<UghButton> OnPressed;

	public Action<UghButton, bool> OnDown;

	private bool wasDown;

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
