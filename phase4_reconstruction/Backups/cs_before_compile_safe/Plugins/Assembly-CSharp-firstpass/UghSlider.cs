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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public float CurrentNormalized
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	private void UpdatePosition()
	{
	}
}
