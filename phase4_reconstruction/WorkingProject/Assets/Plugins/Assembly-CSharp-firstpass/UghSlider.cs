using System;
using System.Collections;
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
			return default(float);
		}
		set
		{
		}
	}

	public float CurrentNormalized
	{
		get
		{
			return default(float);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private Vector3 LocalPositionForInput(Vector3 input)
	{
		return default(Vector3);
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

	private void UpdatePosition()
	{
	}
}
