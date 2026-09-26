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
			return default(Vector3);
		}
	}

	public UghSpritePrototype Prototype
	{
		get
		{
			return default(UghSpritePrototype);
		}
		set
		{
		}
	}

	public Vector3 GetLocalCenter()
	{
		return default(Vector3);
	}

	public Vector3 GetLocalOrigin()
	{
		return default(Vector3);
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDrawGizmos()
	{
	}

	public void UpdateMesh()
	{
	}

	protected virtual void UpdateMeshWithSpritePrototype(UghSpritePrototype sprite)
	{
	}

	public static TextAnchor AnchorToTextAnchor(Anchor anchor)
	{
		return default(TextAnchor);
	}

	public static Anchor TextAnchorToAnchor(TextAnchor anchor)
	{
		return default(Anchor);
	}

	public static Vector3 GetOffsetForAnchor(Anchor anchor, Vector3 customAnchorOffset)
	{
		return default(Vector3);
	}

	private Vector2[] GetUVArray(UghSpritePrototype sprite)
	{
		return default(Vector2[]);
	}

	private int MeshRowCount()
	{
		return default(int);
	}

	private int MeshColumnCount()
	{
		return default(int);
	}

	private int MeshVertexCount()
	{
		return default(int);
	}

	public UghPublisher GetParentPublisher()
	{
		return default(UghPublisher);
	}
}
