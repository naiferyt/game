using System;
using System.Collections;
using UnityEngine;

// Push button: swaps to the pressed / mouse-over prototype and reports presses to its UghPublisher.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghButton.txt
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghButton : UghControl
{
	public UghSpritePrototype pressed;

	public UghSpritePrototype mouseOver;

	public Action<UghButton> OnPressed;

	public Action<UghButton, bool> OnDown;

	private bool wasDown;

	// RECUPERADO-AOT UghButton.OnUghInputDown token 0x0600038b @0x0003abd0
	// (body: <OnUghInputDown>c__Iterator1B.MoveNext token 0x060005b8 @0x00057630)
	public override IEnumerator OnUghInputDown()
	{
		if (isLegalControl)
		{
			UghSpritePrototype sprite = pressed;
			if (!sprite)
			{
				sprite = normal;
			}
			if (OnDown != null)
			{
				wasDown = true;
				OnDown(this, true);
			}
			UpdateMeshWithSpritePrototype(sprite);
		}
		yield break;
	}

	// RECUPERADO-AOT UghButton.OnUghInputUp token 0x0600038c @0x0003ac18
	public override void OnUghInputUp()
	{
		UpdateMeshWithSpritePrototype(normal);
		if (OnDown != null && wasDown)
		{
			wasDown = false;
			OnDown(this, false);
		}
	}

	// RECUPERADO-AOT UghButton.OnUghInputUpAsButton token 0x0600038d @0x0003ac90
	public override void OnUghInputUpAsButton()
	{
		if (!isLegalControl)
		{
			return;
		}
		UpdateMeshWithSpritePrototype(normal);
		UghPublisher publisher = GetParentPublisher();
		if ((bool)publisher)
		{
			publisher.OnButtonPressed(this);
		}
		if (OnPressed != null)
		{
			OnPressed(this);
		}
		if (OnDown != null && wasDown)
		{
			wasDown = false;
			OnDown(this, false);
		}
	}

	// RECUPERADO-AOT UghButton.OnMouseEnter token 0x0600038e @0x0003ad5c
	private void OnMouseEnter()
	{
		if (isLegalControl && mouseOver != null)
		{
			UpdateMeshWithSpritePrototype(mouseOver);
		}
	}

	// RECUPERADO-AOT UghButton.OnMouseExit token 0x0600038f @0x0003adc0
	private void OnMouseExit()
	{
		UpdateMeshWithSpritePrototype(normal);
		if (OnDown != null && wasDown)
		{
			wasDown = false;
			OnDown(this, false);
		}
	}
}
