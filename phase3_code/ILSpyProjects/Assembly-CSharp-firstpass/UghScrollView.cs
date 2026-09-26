using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UghScrollView : UghControl
{
	public delegate void ScrollSnappedHandler();

	public delegate void ScrollSoftSnappedHandler();

	public Transform initialHorizontalContents;

	public Transform initialVerticalContents;

	public Vector3 initialSnapSpacing;

	public Vector3 initialViewSize;

	public bool canScrollInMultipleDirectionsSimultaneously;

	public bool limitToSingleSnap;

	public float snapSpeedThreshold;

	public float snapScrollDrag;

	private Transform horizontalContents;

	private Transform verticalContents;

	private Vector3 startScrollPosition;

	private Vector3 previousStartScrollPosition;

	private Vector3 scrollPosition;

	private Vector3 snapSpacing;

	private Vector3 viewSize;

	private Vector3 scrollDirection;

	private bool hot;

	private bool isInterrupting;

	private bool notInterruptable;

	private Vector3 velocityFromExplicitScrolling;

	private float realDeltaTime;

	private float lastRealtimeSinceStartup;

	private int lastRealtimeSinceStartupFrame;

	private bool canPassThroughInput;

	private bool isPassingThroughInput;

	private float passThroughTimer;

	private UghControl subHotControl;

	public Transform HorizontalContents
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public Transform VerticalContents
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public Vector3 SnapSpacing
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public Vector3 ScrollPosition
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public Vector3 ViewSize
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public event ScrollSnappedHandler ScrollSnapped
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public event ScrollSoftSnappedHandler ScrollSoftSnapped
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public void SnapScrollToIndex(int xIndex, int yIndex)
	{
	}

	public void SnapScrollByShift(int xShift, int yShift)
	{
	}

	public void ScrollToPosition(float xPos, float yPos)
	{
	}

	private void Awake()
	{
	}

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void UpdateRealDeltaTime()
	{
	}

	[DebuggerHidden]
	private IEnumerator HandleExplicitScrolling()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator HandleVelocityScrolling()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator HandleSnapScrolling()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator ForceSnapScrolling(Vector3 goalScrollPosition)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator SnapScroll(Vector3 goalScrollPosition)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnScrollPositionChanged()
	{
	}
}
