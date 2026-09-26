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
			RecoveryPending.Hit("UghToggle.get_State");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("UghToggle.set_State");
		}
	}

	public bool HighlightState
	{
		get
		{
			RecoveryPending.Hit("UghToggle.get_HighlightState");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("UghToggle.set_HighlightState");
		}
	}

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		RecoveryPending.Hit("UghToggle.OnUghInputDown");
		yield break;
	}

	public override void OnUghInputUp()
	{
		RecoveryPending.Hit("UghToggle.OnUghInputUp");
	}

	public override void OnUghInputUpAsButton()
	{
		RecoveryPending.Hit("UghToggle.OnUghInputUpAsButton");
	}

	private UghSpritePrototype GetUghSpritePrototypeForCurrentState()
	{
		RecoveryPending.Hit("UghToggle.GetUghSpritePrototypeForCurrentState");
		return default(UghSpritePrototype);
	}

	private void UpdateMeshForCurrentState()
	{
		RecoveryPending.Hit("UghToggle.UpdateMeshForCurrentState");
	}

	private void SendOnChanged()
	{
		RecoveryPending.Hit("UghToggle.SendOnChanged");
	}

	private void OnMouseExit()
	{
		RecoveryPending.Hit("UghToggle.OnMouseExit");
	}
}
