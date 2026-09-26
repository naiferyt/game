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
			RecoveryPending.Hit("UghSlideToggle.get_State");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("UghSlideToggle.set_State");
		}
	}

	[ContextMenu("Autosize Collider")]
	public override void AutoSizeCollider()
	{
		RecoveryPending.Hit("UghSlideToggle.AutoSizeCollider");
	}

	private void UpdateRealDeltaTime()
	{
		RecoveryPending.Hit("UghSlideToggle.UpdateRealDeltaTime");
	}

	private void Awake()
	{
		RecoveryPending.Hit("UghSlideToggle.Awake");
	}

	private Vector3 LocalPositionForInput(Vector3 input)
	{
		RecoveryPending.Hit("UghSlideToggle.LocalPositionForInput");
		return default(Vector3);
	}

	private void SendOnChanged()
	{
		RecoveryPending.Hit("UghSlideToggle.SendOnChanged");
	}

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		RecoveryPending.Hit("UghSlideToggle.OnUghInputDown");
		yield break;
	}

	public override void OnUghInputUp()
	{
		RecoveryPending.Hit("UghSlideToggle.OnUghInputUp");
	}

	public override void OnUghInputUpAsButton()
	{
		RecoveryPending.Hit("UghSlideToggle.OnUghInputUpAsButton");
	}

	protected override void UpdateMeshWithSpritePrototype(UghSpritePrototype sprite)
	{
		RecoveryPending.Hit("UghSlideToggle.UpdateMeshWithSpritePrototype");
	}

	private void Update()
	{
		RecoveryPending.Hit("UghSlideToggle.Update");
	}
}
