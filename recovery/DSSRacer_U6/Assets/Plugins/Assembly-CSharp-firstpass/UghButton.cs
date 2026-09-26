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
		RecoveryPending.Hit("UghButton.OnUghInputDown");
		yield break;
	}

	public override void OnUghInputUp()
	{
		RecoveryPending.Hit("UghButton.OnUghInputUp");
	}

	public override void OnUghInputUpAsButton()
	{
		RecoveryPending.Hit("UghButton.OnUghInputUpAsButton");
	}

	private void OnMouseEnter()
	{
		RecoveryPending.Hit("UghButton.OnMouseEnter");
	}

	private void OnMouseExit()
	{
		RecoveryPending.Hit("UghButton.OnMouseExit");
	}
}
