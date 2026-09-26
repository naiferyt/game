using System.Collections;
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
			return default(bool);
		}
	}

	public void Awake()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Start()
	{
		return default(IEnumerator);
	}

	public void Activate()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ActivateHelper()
	{
		return default(IEnumerator);
	}

	protected virtual void OnActivateUpdate()
	{
	}

	public void Deactivate()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	public IEnumerator DeactivateHelper()
	{
		return default(IEnumerator);
	}

	protected virtual void OnDeactivateUpdate()
	{
	}

	private void OnGUI()
	{
	}

	public void RenderGUI()
	{
	}

	protected virtual void OnStart()
	{
	}

	protected virtual void OnDrawUnderlay()
	{
	}

	protected virtual void OnDraw()
	{
	}

	protected virtual void DoWindow(int id)
	{
	}

	protected virtual void OnActivating()
	{
	}

	protected virtual void OnActivated()
	{
	}

	protected virtual void OnDeactivating()
	{
	}

	protected virtual void OnDeactivated()
	{
	}
}
