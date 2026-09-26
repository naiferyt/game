using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghSlideToggle : UghControl
{
	private const float slideSpeed = 2f;

	public Action<UghSlideToggle> OnChanged;

	private bool state;

	private bool hot;

	private float slideFactor;

	private float realDeltaTime;

	private float lastRealtimeSinceStartup;

	private int lastRealtimeSinceStartupFrame;

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

	[ContextMenu("Autosize Collider")]
	public override void AutoSizeCollider()
	{
	}

	private void UpdateRealDeltaTime()
	{
	}

	private void Awake()
	{
	}

	private Vector3 LocalPositionForInput(Vector3 input)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void SendOnChanged()
	{
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

	protected override void UpdateMeshWithSpritePrototype(UghSpritePrototype sprite)
	{
	}

	private void Update()
	{
	}
}
