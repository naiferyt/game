using UnityEngine;

public class UghAlign : MonoBehaviour
{
	public UghSprite alignTo;

	public UghSprite.Anchor pointToAnchorTo;

	public Vector3 customAnchorOffset;

	public bool useWorldSpace;

	public bool alignX;

	public bool alignY;

	private UghStretch stretchOwner;

	private bool isDirty;

	public bool IsDirty
	{
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public void Align()
	{
	}

	public static void AlignToSprite(Transform transform, UghSprite alignTo, UghSprite.Anchor anchor, Vector3 customOffset)
	{
	}

	public static void AlignToScreen(Transform transform, UghSprite.Anchor anchor, Vector3 customOffset)
	{
	}

	private void OnDisable()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void OnEnable()
	{
	}

	private void OnMPDirtyAlign(UghStretch theStretcher)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
