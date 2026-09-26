using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(UghSprite), typeof(UghSprite))]
public class UghStretch : MonoBehaviour
{
	public enum StretchType
	{
		AnchorToPoint = 0,
		PointToPoint = 1
	}

	public delegate void MPDirtyAlignHandler(UghStretch theStretcher);

	public bool stretchX;

	public bool stretchY;

	public UghSprite stretchToPoint1;

	public UghSprite.Anchor point1Anchor;

	public Vector3 point1AnchorOffset;

	public UghSprite stretchToPoint2;

	public UghSprite.Anchor point2Anchor;

	public Vector3 point2AnchorOffset;

	private Vector3 cachedPreStretchSize;

	private bool isDirty;

	public bool IsDirty
	{
		get
		{
			RecoveryPending.Hit("UghStretch.get_IsDirty");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("UghStretch.set_IsDirty");
		}
	}

	public static event MPDirtyAlignHandler HandleMPDirtyAlign
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			RecoveryPending.Hit("UghStretch.add_HandleMPDirtyAlign");
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			RecoveryPending.Hit("UghStretch.remove_HandleMPDirtyAlign");
		}
	}

	private void DoSignalDirtyAlign()
	{
		RecoveryPending.Hit("UghStretch.DoSignalDirtyAlign");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("UghStretch.OnDrawGizmos");
	}

	private void Start()
	{
		RecoveryPending.Hit("UghStretch.Start");
	}

	public void Align()
	{
		RecoveryPending.Hit("UghStretch.Align");
	}

	private void Update()
	{
		RecoveryPending.Hit("UghStretch.Update");
	}
}
