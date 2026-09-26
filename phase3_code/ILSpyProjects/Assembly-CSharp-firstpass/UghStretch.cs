using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(UghSprite), typeof(UghSprite))]
public class UghStretch : MonoBehaviour
{
	public enum StretchType
	{
		AnchorToPoint,
		PointToPoint
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public static event MPDirtyAlignHandler HandleMPDirtyAlign
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

	private void DoSignalDirtyAlign()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void Start()
	{
	}

	public void Align()
	{
	}

	private void Update()
	{
	}
}
