using System.Runtime.CompilerServices;
using UnityEngine;

// Scales this sprite so it spans between two anchor points (of other sprites or of the screen), per axis.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghStretch.txt
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

	// RECUPERADO-AOT UghStretch..ctor token 0x06000472 @0x0004ac8c (field initializer)
	private bool isDirty = true;

	private static MPDirtyAlignHandler handleMPDirtyAlign;

	public bool IsDirty
	{
		// RECUPERADO-AOT UghStretch.get_IsDirty token 0x06000475 @0x0004ae08
		get
		{
			return isDirty;
		}
		// RECUPERADO-AOT UghStretch.set_IsDirty token 0x06000476 @0x0004ae3c
		set
		{
			isDirty = value;
		}
	}

	public static event MPDirtyAlignHandler HandleMPDirtyAlign
	{
		// RECUPERADO-AOT UghStretch.add_HandleMPDirtyAlign token 0x06000473 @0x0004acc8
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			handleMPDirtyAlign = (MPDirtyAlignHandler)System.Delegate.Combine(handleMPDirtyAlign, value);
		}
		// RECUPERADO-AOT UghStretch.remove_HandleMPDirtyAlign token 0x06000474 @0x0004ad68
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			handleMPDirtyAlign = (MPDirtyAlignHandler)System.Delegate.Remove(handleMPDirtyAlign, value);
		}
	}

	// RECUPERADO-AOT UghStretch.DoSignalDirtyAlign token 0x06000477 @0x0004ae78
	private void DoSignalDirtyAlign()
	{
		if (handleMPDirtyAlign != null)
		{
			handleMPDirtyAlign(this);
		}
	}

	// RECUPERADO-AOT UghStretch.OnDrawGizmos token 0x06000478 @0x0004aee4
	private void OnDrawGizmos()
	{
		Align();
	}

	// RECUPERADO-AOT UghStretch.Start token 0x06000479 @0x0004af18
	private void Start()
	{
		Align();
	}

	// RECUPERADO-AOT UghStretch.Align token 0x0600047a @0x0004af4c
	public void Align()
	{
		UghSprite sprite = GetComponent<UghSprite>();
		if (sprite == null || sprite.normal == null)
		{
			return;
		}
		if (stretchToPoint1 != null && stretchToPoint1.normal == null)
		{
			Debug.LogWarning("stretchToPoint1 != null && stretchToPoint1.normal == null");
			return;
		}
		if (stretchToPoint2 != null && stretchToPoint2.normal == null)
		{
			Debug.LogWarning("stretchToPoint2 != null && stretchToPoint2.normal == null");
			return;
		}
		if (!stretchX)
		{
			cachedPreStretchSize.x = transform.localScale.x;
		}
		if (!stretchY)
		{
			cachedPreStretchSize.y = transform.localScale.y;
		}
		Vector3 point1 = UghSprite.GetOffsetForAnchor(point1Anchor, point1AnchorOffset);
		if (point1Anchor == UghSprite.Anchor.Custom)
		{
			point1 *= -1f;
		}
		if ((bool)stretchToPoint1)
		{
			if ((bool)stretchToPoint1.GetComponent<UghAlign>())
			{
				stretchToPoint1.GetComponent<UghAlign>().Align();
			}
			point1 = Vector3.Scale(stretchToPoint1.Offset - point1, stretchToPoint1.normal.size);
			point1 = stretchToPoint1.transform.TransformPoint(point1);
		}
		else
		{
			point1 = UghCamera.Instance.ScreenAnchorToPosition(point1Anchor, point1AnchorOffset);
		}
		Vector3 point2 = UghSprite.GetOffsetForAnchor(point2Anchor, point2AnchorOffset);
		if (point2Anchor == UghSprite.Anchor.Custom)
		{
			point2 *= -1f;
		}
		if ((bool)stretchToPoint2)
		{
			if ((bool)stretchToPoint2.GetComponent<UghAlign>())
			{
				stretchToPoint2.GetComponent<UghAlign>().Align();
			}
			point2 = Vector3.Scale(stretchToPoint2.Offset - point2, stretchToPoint2.normal.size);
			point2 = stretchToPoint2.transform.TransformPoint(point2);
		}
		else
		{
			point2 = UghCamera.Instance.ScreenAnchorToPosition(point2Anchor, point2AnchorOffset);
		}
		float scaleX = stretchX ? (Mathf.Abs(point1.x - point2.x) / sprite.normal.size.x) : cachedPreStretchSize.x;
		float scaleY = stretchY ? (Mathf.Abs(point1.y - point2.y) / sprite.normal.size.y) : cachedPreStretchSize.y;
		transform.localScale = new Vector3(scaleX, scaleY, 1f);
		DoSignalDirtyAlign();
		isDirty = false;
	}

	// RECUPERADO-AOT UghStretch.Update token 0x0600047b @0x0004b77c
	private void Update()
	{
		if (isDirty)
		{
			Align();
		}
	}
}
