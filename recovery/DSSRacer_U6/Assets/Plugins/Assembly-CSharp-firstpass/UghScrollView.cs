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
			RecoveryPending.Hit("UghScrollView.get_HorizontalContents");
			return default(Transform);
		}
		set
		{
			RecoveryPending.Hit("UghScrollView.set_HorizontalContents");
		}
	}

	public Transform VerticalContents
	{
		get
		{
			RecoveryPending.Hit("UghScrollView.get_VerticalContents");
			return default(Transform);
		}
		set
		{
			RecoveryPending.Hit("UghScrollView.set_VerticalContents");
		}
	}

	public Vector3 SnapSpacing
	{
		get
		{
			RecoveryPending.Hit("UghScrollView.get_SnapSpacing");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("UghScrollView.set_SnapSpacing");
		}
	}

	public Vector3 ScrollPosition
	{
		get
		{
			RecoveryPending.Hit("UghScrollView.get_ScrollPosition");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("UghScrollView.set_ScrollPosition");
		}
	}

	public Vector3 ViewSize
	{
		get
		{
			RecoveryPending.Hit("UghScrollView.get_ViewSize");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("UghScrollView.set_ViewSize");
		}
	}

	public event ScrollSnappedHandler ScrollSnapped
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			RecoveryPending.Hit("UghScrollView.add_ScrollSnapped");
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			RecoveryPending.Hit("UghScrollView.remove_ScrollSnapped");
		}
	}

	public event ScrollSoftSnappedHandler ScrollSoftSnapped
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			RecoveryPending.Hit("UghScrollView.add_ScrollSoftSnapped");
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			RecoveryPending.Hit("UghScrollView.remove_ScrollSoftSnapped");
		}
	}

	public void SnapScrollToIndex(int xIndex, int yIndex)
	{
		RecoveryPending.Hit("UghScrollView.SnapScrollToIndex");
	}

	public void SnapScrollByShift(int xShift, int yShift)
	{
		RecoveryPending.Hit("UghScrollView.SnapScrollByShift");
	}

	public void ScrollToPosition(float xPos, float yPos)
	{
		RecoveryPending.Hit("UghScrollView.ScrollToPosition");
	}

	private void Awake()
	{
		RecoveryPending.Hit("UghScrollView.Awake");
	}

	[DebuggerHidden]
	public override IEnumerator OnUghInputDown()
	{
		RecoveryPending.Hit("UghScrollView.OnUghInputDown");
		yield break;
	}

	private void UpdateRealDeltaTime()
	{
		RecoveryPending.Hit("UghScrollView.UpdateRealDeltaTime");
	}

	[DebuggerHidden]
	private IEnumerator HandleExplicitScrolling()
	{
		RecoveryPending.Hit("UghScrollView.HandleExplicitScrolling");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator HandleVelocityScrolling()
	{
		RecoveryPending.Hit("UghScrollView.HandleVelocityScrolling");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator HandleSnapScrolling()
	{
		RecoveryPending.Hit("UghScrollView.HandleSnapScrolling");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator ForceSnapScrolling(Vector3 goalScrollPosition)
	{
		RecoveryPending.Hit("UghScrollView.ForceSnapScrolling");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator SnapScroll(Vector3 goalScrollPosition)
	{
		RecoveryPending.Hit("UghScrollView.SnapScroll");
		yield break;
	}

	private void OnScrollPositionChanged()
	{
		RecoveryPending.Hit("UghScrollView.OnScrollPositionChanged");
	}
}
