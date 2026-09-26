using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghSlider : UghControl
{
	public UghSpritePrototype pressed;

	public Rangef limits;

	public float visualWidthUnits;

	public Action<UghSlider> OnChanged;

	private float currentNormalized;

	private Vector3 basePosition;

	public float Current
	{
		get
		{
			RecoveryPending.Hit("UghSlider.get_Current");
			return default(float);
		}
		set
		{
			RecoveryPending.Hit("UghSlider.set_Current");
		}
	}

	public float CurrentNormalized
	{
		get
		{
			RecoveryPending.Hit("UghSlider.get_CurrentNormalized");
			return default(float);
		}
		set
		{
			RecoveryPending.Hit("UghSlider.set_CurrentNormalized");
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("UghSlider.Awake");
	}

	private Vector3 LocalPositionForInput(Vector3 input)
	{
		RecoveryPending.Hit("UghSlider.LocalPositionForInput");
		return default(Vector3);
	}

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		RecoveryPending.Hit("UghSlider.OnUghInputDown");
		yield break;
	}

	public override void OnUghInputUp()
	{
		RecoveryPending.Hit("UghSlider.OnUghInputUp");
	}

	public override void OnUghInputUpAsButton()
	{
		RecoveryPending.Hit("UghSlider.OnUghInputUpAsButton");
	}

	private void UpdatePosition()
	{
		RecoveryPending.Hit("UghSlider.UpdatePosition");
	}
}
