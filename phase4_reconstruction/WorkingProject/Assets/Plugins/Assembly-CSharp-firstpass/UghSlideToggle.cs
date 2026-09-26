using System;
using System.Collections;
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
			return default(bool);
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
		return default(Vector3);
	}

	private void SendOnChanged()
	{
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

	protected override void UpdateMeshWithSpritePrototype(UghSpritePrototype sprite)
	{
	}

	private void Update()
	{
	}
}
