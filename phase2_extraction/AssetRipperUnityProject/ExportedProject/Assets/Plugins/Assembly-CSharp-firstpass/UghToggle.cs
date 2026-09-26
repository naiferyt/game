using System;
using System.Collections;
using System.Diagnostics;
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public bool HighlightState
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

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

	private UghSpritePrototype GetUghSpritePrototypeForCurrentState()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
