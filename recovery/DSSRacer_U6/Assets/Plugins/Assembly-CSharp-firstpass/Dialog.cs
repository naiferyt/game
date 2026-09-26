using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Dialog : Script
{
	public GUISkin skin;

	protected Rect windowRect;

	protected int windowID;

	protected string windowTitle;

	protected string windowStyle;

	protected float activateDuration;

	protected float deactivateDuration;

	protected float inFactor;

	protected Vector3 guiScale;

	protected Vector3 guiPosition;

	protected Quaternion guiRotation;

	protected bool keepWindowInFront;

	protected bool activateOnStart;

	public int depth;

	protected bool on;

	[HideInInspector]
	public bool visible;

	public bool On
	{
		get
		{
			RecoveryPending.Hit("Dialog.get_On");
			return default(bool);
		}
	}

	public void Awake()
	{
		RecoveryPending.Hit("Dialog.Awake");
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("Dialog.Start");
		yield break;
	}

	public void Activate()
	{
		RecoveryPending.Hit("Dialog.Activate");
	}

	[DebuggerHidden]
	private IEnumerator ActivateHelper()
	{
		RecoveryPending.Hit("Dialog.ActivateHelper");
		yield break;
	}

	protected virtual void OnActivateUpdate()
	{
		RecoveryPending.Hit("Dialog.OnActivateUpdate");
	}

	public void Deactivate()
	{
		RecoveryPending.Hit("Dialog.Deactivate");
	}

	[DebuggerHidden]
	public IEnumerator DeactivateHelper()
	{
		RecoveryPending.Hit("Dialog.DeactivateHelper");
		yield break;
	}

	protected virtual void OnDeactivateUpdate()
	{
		RecoveryPending.Hit("Dialog.OnDeactivateUpdate");
	}

	private void OnGUI()
	{
		RecoveryPending.Hit("Dialog.OnGUI");
	}

	public void RenderGUI()
	{
		RecoveryPending.Hit("Dialog.RenderGUI");
	}

	protected virtual void OnStart()
	{
		RecoveryPending.Hit("Dialog.OnStart");
	}

	protected virtual void OnDrawUnderlay()
	{
		RecoveryPending.Hit("Dialog.OnDrawUnderlay");
	}

	protected virtual void OnDraw()
	{
		RecoveryPending.Hit("Dialog.OnDraw");
	}

	protected virtual void DoWindow(int id)
	{
		RecoveryPending.Hit("Dialog.DoWindow");
	}

	protected virtual void OnActivating()
	{
		RecoveryPending.Hit("Dialog.OnActivating");
	}

	protected virtual void OnActivated()
	{
		RecoveryPending.Hit("Dialog.OnActivated");
	}

	protected virtual void OnDeactivating()
	{
		RecoveryPending.Hit("Dialog.OnDeactivating");
	}

	protected virtual void OnDeactivated()
	{
		RecoveryPending.Hit("Dialog.OnDeactivated");
	}
}
