using System.Collections;
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
			return default(Transform);
		}
		set
		{
		}
	}

	public Transform VerticalContents
	{
		get
		{
			return default(Transform);
		}
		set
		{
		}
	}

	public Vector3 SnapSpacing
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 ScrollPosition
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 ViewSize
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public event ScrollSnappedHandler ScrollSnapped
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public event ScrollSoftSnappedHandler ScrollSoftSnapped
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
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

	[System.Diagnostics.DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		return default(IEnumerator);
	}

	private void UpdateRealDeltaTime()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator HandleExplicitScrolling()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator HandleVelocityScrolling()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator HandleSnapScrolling()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ForceSnapScrolling(Vector3 goalScrollPosition)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator SnapScroll(Vector3 goalScrollPosition)
	{
		return default(IEnumerator);
	}

	private void OnScrollPositionChanged()
	{
	}
}
