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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public void Awake()
	{
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void Activate()
	{
	}

	[DebuggerHidden]
	private IEnumerator ActivateHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	protected virtual void OnActivateUpdate()
	{
	}

	public void Deactivate()
	{
	}

	[DebuggerHidden]
	public IEnumerator DeactivateHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
