using UnityEngine;

// Positions this object on an anchor point of another sprite (or of the screen), per axis.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghAlign.txt
public class UghAlign : MonoBehaviour
{
	public UghSprite alignTo;

	public UghSprite.Anchor pointToAnchorTo;

	public Vector3 customAnchorOffset;

	// RECUPERADO-AOT UghAlign..ctor token 0x06000410 @0x0003ff68 (field initializers)
	public bool useWorldSpace = true;

	public bool alignX = true;

	public bool alignY = true;

	private UghStretch stretchOwner;

	private bool isDirty = true;

	public bool IsDirty
	{
		// RECUPERADO-AOT UghAlign.get_IsDirty token 0x06000411 @0x0003ffbc
		get
		{
			return isDirty;
		}
		// RECUPERADO-AOT UghAlign.set_IsDirty token 0x06000412 @0x0003fff0
		set
		{
			isDirty = value;
		}
	}

	// RECUPERADO-AOT UghAlign.Align token 0x06000413 @0x0004002c
	public void Align()
	{
		Vector3 anchorOffset = UghSprite.GetOffsetForAnchor(pointToAnchorTo, customAnchorOffset);
		Vector3 position = transform.position;
		if (alignTo != null && alignTo.normal != null)
		{
			if (pointToAnchorTo == UghSprite.Anchor.Custom)
			{
				anchorOffset *= -1f;
			}
			anchorOffset = Vector3.Scale(alignTo.Offset - anchorOffset, alignTo.normal.size);
			anchorOffset = alignTo.transform.TransformPoint(anchorOffset);
			if (useWorldSpace)
			{
				transform.position = new Vector3(alignX ? anchorOffset.x : position.x, alignY ? anchorOffset.y : position.y, position.z);
			}
			else
			{
				transform.localPosition = new Vector3(alignX ? anchorOffset.x : position.x, alignY ? anchorOffset.y : position.y, position.z);
			}
		}
		else
		{
			Vector3 screenPoint = UghCamera.Instance.ScreenAnchorToPosition(pointToAnchorTo, customAnchorOffset);
			if (useWorldSpace)
			{
				transform.position = new Vector3(alignX ? screenPoint.x : position.x, alignY ? screenPoint.y : position.y, position.z);
			}
			else
			{
				transform.localPosition = new Vector3(alignX ? screenPoint.x : position.x, alignY ? screenPoint.y : position.y, position.z);
			}
		}
		isDirty = false;
	}

	// RECUPERADO-AOT UghAlign.AlignToSprite token 0x06000414 @0x000406f0
	public static void AlignToSprite(Transform transform, UghSprite alignTo, UghSprite.Anchor anchor, Vector3 customOffset)
	{
		Vector3 anchorOffset = UghSprite.GetOffsetForAnchor(anchor, customOffset);
		Vector3 position = transform.position;
		anchorOffset = Vector3.Scale(alignTo.Offset - anchorOffset, alignTo.normal.size);
		anchorOffset = alignTo.transform.TransformPoint(anchorOffset);
		transform.position = new Vector3(anchorOffset.x, anchorOffset.y, position.z);
	}

	// RECUPERADO-AOT UghAlign.AlignToScreen token 0x06000415 @0x00040920
	public static void AlignToScreen(Transform transform, UghSprite.Anchor anchor, Vector3 customOffset)
	{
		Vector3 anchorOffset = UghSprite.GetOffsetForAnchor(anchor, customOffset);
		Vector3 position = transform.position;
		Vector3 screenSize = UghCamera.Instance.ScreenSize;
		screenSize.x *= (float)Screen.width / (screenSize.x * UghCamera.PixelsPerUnit);
		anchorOffset = Vector3.Scale(-anchorOffset, screenSize);
		transform.position = new Vector3(anchorOffset.x, anchorOffset.y, position.z);
	}

	// RECUPERADO-AOT UghAlign.OnDisable token 0x06000416 @0x00040b3c
	private void OnDisable()
	{
		if ((bool)stretchOwner)
		{
			UghStretch.HandleMPDirtyAlign -= OnMPDirtyAlign;
		}
	}

	// RECUPERADO-AOT UghAlign.OnDrawGizmos token 0x06000417 @0x00040bd4
	private void OnDrawGizmos()
	{
		if (!Application.isPlaying && enabled)
		{
			Align();
		}
	}

	// RECUPERADO-AOT UghAlign.OnEnable token 0x06000418 @0x00040c24
	private void OnEnable()
	{
		if (alignTo != null)
		{
			stretchOwner = alignTo.GetComponent<UghStretch>();
			if ((bool)alignTo.GetComponent<UghAlign>())
			{
				alignTo.GetComponent<UghAlign>().Align();
			}
		}
		if ((bool)stretchOwner)
		{
			UghStretch.HandleMPDirtyAlign += OnMPDirtyAlign;
			stretchOwner.IsDirty = true;
		}
	}

	// RECUPERADO-AOT UghAlign.OnMPDirtyAlign token 0x06000419 @0x00040d5c
	private void OnMPDirtyAlign(UghStretch theStretcher)
	{
		if (stretchOwner == theStretcher)
		{
			isDirty = true;
		}
	}

	// RECUPERADO-AOT UghAlign.Start token 0x0600041a @0x00040db0
	private void Start()
	{
		Align();
	}

	// RECUPERADO-AOT UghAlign.Update token 0x0600041b @0x00040de4
	private void Update()
	{
		if (isDirty)
		{
			Align();
		}
	}
}
