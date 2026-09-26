using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class UghSprite : MonoBehaviour
{
	public enum Anchor
	{
		LowerLeft,
		MiddleLeft,
		UpperLeft,
		LowerCenter,
		MiddleCenter,
		UpperCenter,
		LowerRight,
		MiddleRight,
		UpperRight,
		Custom
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public UghSpritePrototype Prototype
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public Vector3 GetLocalCenter()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Vector3 GetLocalOrigin()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static Anchor TextAnchorToAnchor(TextAnchor anchor)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static Vector3 GetOffsetForAnchor(Anchor anchor, Vector3 customAnchorOffset)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private Vector2[] GetUVArray(UghSpritePrototype sprite)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private int MeshRowCount()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private int MeshColumnCount()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private int MeshVertexCount()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public UghPublisher GetParentPublisher()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
