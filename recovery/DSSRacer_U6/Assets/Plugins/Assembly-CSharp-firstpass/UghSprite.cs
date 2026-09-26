using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class UghSprite : MonoBehaviour
{
	public enum Anchor
	{
		LowerLeft = 0,
		MiddleLeft = 1,
		UpperLeft = 2,
		LowerCenter = 3,
		MiddleCenter = 4,
		UpperCenter = 5,
		LowerRight = 6,
		MiddleRight = 7,
		UpperRight = 8,
		Custom = 9
	}

	public Anchor anchor;

	public Vector3 customAnchorOffset;

	public bool flippedHorizontal;

	public bool flippedVertical;

	public UghSpritePrototype normal;

	private Vector3 offset;

	public Vector3 Offset
	{
		get
		{
			RecoveryPending.Hit("UghSprite.get_Offset");
			return default(Vector3);
		}
	}

	public UghSpritePrototype Prototype
	{
		get
		{
			RecoveryPending.Hit("UghSprite.get_Prototype");
			return default(UghSpritePrototype);
		}
		set
		{
			RecoveryPending.Hit("UghSprite.set_Prototype");
		}
	}

	public Vector3 GetLocalCenter()
	{
		RecoveryPending.Hit("UghSprite.GetLocalCenter");
		return default(Vector3);
	}

	public Vector3 GetLocalOrigin()
	{
		RecoveryPending.Hit("UghSprite.GetLocalOrigin");
		return default(Vector3);
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("UghSprite.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("UghSprite.OnDisable");
	}

	protected virtual void OnDrawGizmos()
	{
		RecoveryPending.Hit("UghSprite.OnDrawGizmos");
	}

	public void UpdateMesh()
	{
		RecoveryPending.Hit("UghSprite.UpdateMesh");
	}

	protected virtual void UpdateMeshWithSpritePrototype(UghSpritePrototype sprite)
	{
		RecoveryPending.Hit("UghSprite.UpdateMeshWithSpritePrototype");
	}

	public static TextAnchor AnchorToTextAnchor(Anchor anchor)
	{
		RecoveryPending.Hit("UghSprite.AnchorToTextAnchor");
		return default(TextAnchor);
	}

	public static Anchor TextAnchorToAnchor(TextAnchor anchor)
	{
		RecoveryPending.Hit("UghSprite.TextAnchorToAnchor");
		return default(Anchor);
	}

	public static Vector3 GetOffsetForAnchor(Anchor anchor, Vector3 customAnchorOffset)
	{
		RecoveryPending.Hit("UghSprite.GetOffsetForAnchor");
		return default(Vector3);
	}

	private Vector2[] GetUVArray(UghSpritePrototype sprite)
	{
		RecoveryPending.Hit("UghSprite.GetUVArray");
		return default(Vector2[]);
	}

	private int MeshRowCount()
	{
		RecoveryPending.Hit("UghSprite.MeshRowCount");
		return default(int);
	}

	private int MeshColumnCount()
	{
		RecoveryPending.Hit("UghSprite.MeshColumnCount");
		return default(int);
	}

	private int MeshVertexCount()
	{
		RecoveryPending.Hit("UghSprite.MeshVertexCount");
		return default(int);
	}

	public UghPublisher GetParentPublisher()
	{
		RecoveryPending.Hit("UghSprite.GetParentPublisher");
		return default(UghPublisher);
	}
}
