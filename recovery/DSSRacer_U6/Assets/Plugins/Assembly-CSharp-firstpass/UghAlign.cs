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
			RecoveryPending.Hit("UghAlign.get_IsDirty");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("UghAlign.set_IsDirty");
		}
	}

	public void Align()
	{
		RecoveryPending.Hit("UghAlign.Align");
	}

	public static void AlignToSprite(Transform transform, UghSprite alignTo, UghSprite.Anchor anchor, Vector3 customOffset)
	{
		RecoveryPending.Hit("UghAlign.AlignToSprite");
	}

	public static void AlignToScreen(Transform transform, UghSprite.Anchor anchor, Vector3 customOffset)
	{
		RecoveryPending.Hit("UghAlign.AlignToScreen");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("UghAlign.OnDisable");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("UghAlign.OnDrawGizmos");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("UghAlign.OnEnable");
	}

	private void OnMPDirtyAlign(UghStretch theStretcher)
	{
		RecoveryPending.Hit("UghAlign.OnMPDirtyAlign");
	}

	private void Start()
	{
		RecoveryPending.Hit("UghAlign.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("UghAlign.Update");
	}
}
