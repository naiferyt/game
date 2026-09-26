using System.Collections.Generic;
using UnityEngine;

// Base of every Ugh UI element: builds this object's mesh from an UghSpritePrototype (a plain quad, or a
// nine-slice when the prototype has edge insets) anchored at the chosen point.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghSprite.txt
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

	// RECUPERADO-AOT UghSprite..ctor token 0x06000457 @0x000440e0 (field initializer)
	public Anchor anchor = Anchor.MiddleCenter;

	public Vector3 customAnchorOffset;

	public bool flippedHorizontal;

	public bool flippedVertical;

	public UghSpritePrototype normal;

	private Vector3 offset;

	public Vector3 Offset
	{
		// RECUPERADO-AOT UghSprite.get_Offset token 0x06000458 @0x0004411c
		get
		{
			return offset;
		}
	}

	public UghSpritePrototype Prototype
	{
		// RECUPERADO-AOT UghSprite.get_Prototype token 0x06000459 @0x00044188
		get
		{
			return normal;
		}
		// RECUPERADO-AOT UghSprite.set_Prototype token 0x0600045a @0x000441bc
		set
		{
			normal = value;
			UpdateMeshWithSpritePrototype(value);
			gameObject.layer = UghCamera.Instance.guiLayer;
		}
	}

	// RECUPERADO-AOT UghSprite.GetLocalCenter token 0x0600045b @0x0004422c
	public Vector3 GetLocalCenter()
	{
		return Vector3.Scale(new Vector3(0.5f, 0.5f, 0f) + offset, normal.size);
	}

	// RECUPERADO-AOT UghSprite.GetLocalOrigin token 0x0600045c @0x000443a0
	public Vector3 GetLocalOrigin()
	{
		return Vector3.Scale(offset, normal.size);
	}

	// RECUPERADO-AOT UghSprite.OnEnable token 0x0600045d @0x00044458
	private void OnEnable()
	{
		if ((bool)normal)
		{
			UpdateMeshWithSpritePrototype(normal);
		}
	}

	// RECUPERADO-AOT UghSprite.OnDisable token 0x0600045e @0x000444a8
	private void OnDisable()
	{
		if (Application.isPlaying)
		{
			Object.Destroy(GetComponent<MeshFilter>().sharedMesh);
		}
		else
		{
			Object.DestroyImmediate(GetComponent<MeshFilter>().sharedMesh, true);
		}
		GetComponent<MeshFilter>().sharedMesh = null;
	}

	// RECUPERADO-AOT UghSprite.OnDrawGizmos token 0x0600045f @0x00044560
	protected virtual void OnDrawGizmos()
	{
		if (!Application.isPlaying && enabled)
		{
			UpdateMesh();
			if (normal != null)
			{
				normal.UpdatePrototype();
			}
		}
	}

	// RECUPERADO-AOT UghSprite.UpdateMesh token 0x06000460 @0x000445d4
	public void UpdateMesh()
	{
		if ((bool)normal)
		{
			UpdateMeshWithSpritePrototype(normal);
		}
		gameObject.layer = UghCamera.Instance.guiLayer;
	}

	// RECUPERADO-AOT UghSprite.UpdateMeshWithSpritePrototype token 0x06000461 @0x00044648
	protected virtual void UpdateMeshWithSpritePrototype(UghSpritePrototype sprite)
	{
		if (!sprite)
		{
			return;
		}
		MeshFilter filter = GetComponent<MeshFilter>();
		Mesh mesh = Application.isPlaying ? filter.mesh : filter.sharedMesh;
		if (!filter.sharedMesh)
		{
			mesh = new Mesh();
		}
		EdgePixels insets = new EdgePixels();
		insets.top = sprite.edgeInsets.top;
		insets.bottom = sprite.edgeInsets.bottom;
		insets.right = sprite.edgeInsets.right;
		insets.left = sprite.edgeInsets.left;
		if (flippedVertical)
		{
			float top = insets.top;
			insets.top = insets.bottom;
			insets.bottom = top;
		}
		if (flippedHorizontal)
		{
			float right = insets.right;
			insets.right = insets.left;
			insets.left = right;
		}
		offset = GetOffsetForAnchor(anchor, customAnchorOffset);
		// Inset scaling compensates the transform scale so the slice borders keep their size (uses this.normal).
		Vector2 insetScale;
		switch (normal.insetScaling)
		{
		case UghSpritePrototype.InsetScaling.XAxis:
			insetScale = new Vector2(transform.lossyScale.x, transform.lossyScale.x);
			break;
		case UghSpritePrototype.InsetScaling.YAxis:
			insetScale = new Vector2(transform.lossyScale.y, transform.lossyScale.y);
			break;
		default:
			insetScale = new Vector2(1f, 1f);
			break;
		}
		Rect outer = new Rect(offset.x * sprite.size.x, offset.y * sprite.size.y, sprite.size.x, sprite.size.y);
		Rect inner = new Rect((offset.x + insets.left / transform.lossyScale.x * insetScale.x) * sprite.size.x, (offset.y + insets.bottom / transform.lossyScale.y * insetScale.y) * sprite.size.y, outer.width - (insets.left + insets.right) / transform.lossyScale.x * insetScale.x * sprite.size.x, outer.height - (insets.top + insets.bottom) / transform.lossyScale.y * insetScale.y * sprite.size.y);
		Rect uvInner = new Rect((flippedHorizontal ? sprite.edgePixelInsets.right : sprite.edgePixelInsets.left) / (float)sprite.pixelWidth, (flippedVertical ? sprite.edgePixelInsets.top : sprite.edgePixelInsets.bottom) / (float)sprite.pixelHeight, ((float)sprite.pixelWidth - (sprite.edgePixelInsets.left + sprite.edgePixelInsets.right)) / (float)sprite.pixelWidth, ((float)sprite.pixelHeight - (sprite.edgePixelInsets.top + sprite.edgePixelInsets.bottom)) / (float)sprite.pixelHeight);
		List<UghTriangle> triangles = null;
		if (insets.top == 0f && insets.bottom == 0f && insets.left == 0f && insets.right == 0f)
		{
			triangles = new List<UghTriangle>(2);
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(outer.x, outer.height + outer.y, 0f), new Vector2(0f, 1f), new Vector3(outer.width + outer.x, outer.y, 0f), new Vector2(1f, 0f)));
		}
		else if (insets.top == 0f || insets.bottom == 0f || insets.right == 0f || insets.left == 0f)
		{
			// Some borders only: centre piece plus the strips/corners that exist.
			triangles = new List<UghTriangle>();
			Vector3 centerTL = new Vector3(outer.x, outer.height + outer.y, 0f);
			Vector2 centerTLUV = new Vector2(0f, 1f);
			Vector3 centerBR = new Vector3(outer.width + outer.x, outer.y, 0f);
			Vector2 centerBRUV = new Vector2(1f, 0f);
			if (insets.top != 0f)
			{
				centerTL.y = inner.height + inner.y;
				centerTLUV.y = uvInner.height + uvInner.y;
				Vector3 topTL = new Vector3(outer.x, outer.height + outer.y, 0f);
				Vector2 topTLUV = new Vector2(0f, 1f);
				Vector3 topBR = new Vector3(outer.width + outer.x, inner.height + inner.y, 0f);
				Vector2 topBRUV = new Vector2(1f, uvInner.height + uvInner.y);
				if (insets.left != 0f)
				{
					topTL.x = inner.x;
					topTLUV.x = uvInner.x;
					triangles.AddRange(UghTriangle.MakeQuad(new Vector3(outer.x, outer.height + outer.y, 0f), new Vector2(0f, 1f), new Vector3(inner.x, inner.height + inner.y, 0f), new Vector2(uvInner.x, uvInner.height + uvInner.y)));
				}
				if (insets.right != 0f)
				{
					topBR.x = inner.width + inner.x;
					topBRUV.x = uvInner.width + uvInner.x;
					triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.width + inner.x, outer.height + outer.y, 0f), new Vector2(uvInner.width + uvInner.x, 1f), new Vector3(outer.width + outer.x, inner.height + inner.y, 0f), new Vector2(1f, uvInner.height + uvInner.y)));
				}
				triangles.AddRange(UghTriangle.MakeQuad(topTL, topTLUV, topBR, topBRUV));
			}
			if (insets.bottom != 0f)
			{
				centerBR.y = inner.y;
				centerBRUV.y = uvInner.y;
				Vector3 bottomTL = new Vector3(outer.x, inner.y, 0f);
				Vector2 bottomTLUV = new Vector2(0f, uvInner.y);
				Vector3 bottomBR = new Vector3(outer.width + outer.x, outer.y, 0f);
				Vector2 bottomBRUV = new Vector2(1f, 0f);
				if (insets.left != 0f)
				{
					bottomTL.x = inner.x;
					bottomTLUV.x = uvInner.x;
					triangles.AddRange(UghTriangle.MakeQuad(new Vector3(outer.x, inner.y, 0f), new Vector2(0f, uvInner.y), new Vector3(inner.x, outer.y, 0f), new Vector2(uvInner.x, 0f)));
				}
				if (insets.right != 0f)
				{
					bottomBR.x = inner.width + inner.x;
					bottomBRUV.x = uvInner.width + uvInner.x;
					triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.width + inner.x, inner.y, 0f), new Vector2(uvInner.width + uvInner.x, uvInner.y), new Vector3(outer.width + outer.x, outer.y, 0f), new Vector2(1f, 0f)));
				}
				triangles.AddRange(UghTriangle.MakeQuad(bottomTL, bottomTLUV, bottomBR, bottomBRUV));
			}
			if (insets.left != 0f)
			{
				centerTL.x = inner.x;
				centerTLUV.x = uvInner.x;
				Vector3 leftTL = new Vector3(outer.x, outer.height + outer.y, 0f);
				Vector2 leftTLUV = new Vector2(0f, 1f);
				Vector3 leftBR = new Vector3(inner.x, outer.y, 0f);
				Vector2 leftBRUV = new Vector2(uvInner.x, 0f);
				if (insets.top != 0f)
				{
					leftTL.y = inner.height + inner.y;
					leftTLUV.y = uvInner.height + uvInner.y;
				}
				if (insets.bottom != 0f)
				{
					leftBR.y = inner.y;
					leftBRUV.y = uvInner.y;
				}
				triangles.AddRange(UghTriangle.MakeQuad(leftTL, leftTLUV, leftBR, leftBRUV));
			}
			if (insets.right != 0f)
			{
				centerBR.x = inner.width + inner.x;
				centerBRUV.x = uvInner.width + uvInner.x;
				Vector3 rightTL = new Vector3(inner.width + inner.x, outer.height + outer.y, 0f);
				Vector2 rightTLUV = new Vector2(uvInner.width + uvInner.x, 1f);
				Vector3 rightBR = new Vector3(outer.width + outer.x, outer.y, 0f);
				Vector2 rightBRUV = new Vector2(1f, 0f);
				if (insets.top != 0f)
				{
					rightTL.y = inner.height + inner.y;
					rightTLUV.y = uvInner.height + uvInner.y;
				}
				if (insets.bottom != 0f)
				{
					rightBR.y = inner.y;
					rightBRUV.y = uvInner.y;
				}
				triangles.AddRange(UghTriangle.MakeQuad(rightTL, rightTLUV, rightBR, rightBRUV));
			}
			triangles.AddRange(UghTriangle.MakeQuad(centerTL, centerTLUV, centerBR, centerBRUV));
		}
		else
		{
			// Full nine-slice: 3 x 3 quads, top row first.
			triangles = new List<UghTriangle>(18);
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(outer.x, outer.height + outer.y, 0f), new Vector2(0f, 1f), new Vector3(inner.x, inner.height + inner.y, 0f), new Vector2(uvInner.x, uvInner.height + uvInner.y)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.x, outer.height + outer.y, 0f), new Vector2(uvInner.x, 1f), new Vector3(inner.width + inner.x, inner.height + inner.y, 0f), new Vector2(uvInner.width + uvInner.x, uvInner.height + uvInner.y)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.width + inner.x, outer.height + outer.y, 0f), new Vector2(uvInner.width + uvInner.x, 1f), new Vector3(outer.width + outer.x, inner.height + inner.y, 0f), new Vector2(1f, uvInner.height + uvInner.y)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(outer.x, inner.height + inner.y, 0f), new Vector2(0f, uvInner.height + uvInner.y), new Vector3(inner.x, inner.y, 0f), new Vector2(uvInner.x, uvInner.y)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.x, inner.height + inner.y, 0f), new Vector2(uvInner.x, uvInner.height + uvInner.y), new Vector3(inner.width + inner.x, inner.y, 0f), new Vector2(uvInner.width + uvInner.x, uvInner.y)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.width + inner.x, inner.height + inner.y, 0f), new Vector2(uvInner.width + uvInner.x, uvInner.height + uvInner.y), new Vector3(outer.width + outer.x, inner.y, 0f), new Vector2(1f, uvInner.y)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(outer.x, inner.y, 0f), new Vector2(0f, uvInner.y), new Vector3(inner.x, outer.y, 0f), new Vector2(uvInner.x, 0f)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.x, inner.y, 0f), new Vector2(uvInner.x, uvInner.y), new Vector3(inner.width + inner.x, outer.y, 0f), new Vector2(uvInner.width + uvInner.x, 0f)));
			triangles.AddRange(UghTriangle.MakeQuad(new Vector3(inner.width + inner.x, inner.y, 0f), new Vector2(uvInner.width + uvInner.x, uvInner.y), new Vector3(outer.width + outer.x, outer.y, 0f), new Vector2(1f, 0f)));
		}
		Vector3[] vertices = new Vector3[0];
		int[] indices = new int[0];
		Vector2[] uvs = new Vector2[0];
		foreach (UghTriangle triangle in triangles)
		{
			triangle.AddToMeshList(ref vertices, ref indices, ref uvs);
		}
		// Map the 0..1 slice UVs into the prototype's rectangle of the atlas.
		for (int i = 0; i < uvs.Length; i++)
		{
			Vector2 uv = uvs[i];
			if (flippedVertical)
			{
				uv.y = 1f - uv.y;
			}
			if (flippedHorizontal)
			{
				uv.x = 1f - uv.x;
			}
			uv.x = sprite.sourceUVRect.x + uv.x * sprite.sourceUVRect.width;
			uv.y = sprite.sourceUVRect.y + uv.y * sprite.sourceUVRect.height;
			uvs[i] = uv;
		}
		mesh.vertices = vertices;
		mesh.triangles = indices;
		mesh.uv = uvs;
		filter.sharedMesh = mesh;
		// ADAPTADO-U6: Component.renderer -> GetComponent<Renderer>()
		GetComponent<Renderer>().sharedMaterial = sprite.material;
	}

	// RECUPERADO-AOT UghSprite.AnchorToTextAnchor token 0x06000462 @0x000493f8
	public static TextAnchor AnchorToTextAnchor(Anchor anchor)
	{
		switch (anchor)
		{
		case Anchor.LowerLeft:
			return TextAnchor.LowerLeft;
		case Anchor.MiddleLeft:
			return TextAnchor.MiddleLeft;
		case Anchor.UpperLeft:
			return TextAnchor.UpperLeft;
		case Anchor.LowerCenter:
			return TextAnchor.LowerCenter;
		case Anchor.MiddleCenter:
			return TextAnchor.MiddleCenter;
		case Anchor.UpperCenter:
			return TextAnchor.UpperCenter;
		case Anchor.LowerRight:
			return TextAnchor.LowerRight;
		case Anchor.MiddleRight:
			return TextAnchor.MiddleRight;
		case Anchor.UpperRight:
			return TextAnchor.UpperRight;
		default:
			return TextAnchor.MiddleCenter;
		}
	}

	// RECUPERADO-AOT UghSprite.TextAnchorToAnchor token 0x06000463 @0x000494a8
	public static Anchor TextAnchorToAnchor(TextAnchor anchor)
	{
		switch (anchor)
		{
		case TextAnchor.UpperLeft:
			return Anchor.UpperLeft;
		case TextAnchor.UpperCenter:
			return Anchor.UpperCenter;
		case TextAnchor.UpperRight:
			return Anchor.UpperRight;
		case TextAnchor.MiddleLeft:
			return Anchor.MiddleLeft;
		case TextAnchor.MiddleCenter:
			return Anchor.MiddleCenter;
		case TextAnchor.MiddleRight:
			return Anchor.MiddleRight;
		case TextAnchor.LowerLeft:
			return Anchor.LowerLeft;
		case TextAnchor.LowerCenter:
			return Anchor.LowerCenter;
		case TextAnchor.LowerRight:
			return Anchor.LowerRight;
		default:
			return Anchor.MiddleCenter;
		}
	}

	// RECUPERADO-AOT UghSprite.GetOffsetForAnchor token 0x06000464 @0x00049558
	// (offset of the mesh origin, in sprite sizes, so that the anchor point sits on the transform position)
	public static Vector3 GetOffsetForAnchor(Anchor anchor, Vector3 customAnchorOffset)
	{
		switch (anchor)
		{
		case Anchor.UpperLeft:
			return new Vector3(0f, -1f, 0f);
		case Anchor.MiddleLeft:
			return new Vector3(0f, -0.5f, 0f);
		case Anchor.LowerLeft:
			return Vector3.zero;
		case Anchor.UpperCenter:
			return new Vector3(-0.5f, -1f, 0f);
		case Anchor.MiddleCenter:
			return new Vector3(-0.5f, -0.5f, 0f);
		case Anchor.LowerCenter:
			return new Vector3(-0.5f, 0f, 0f);
		case Anchor.UpperRight:
			return new Vector3(-1f, -1f, 0f);
		case Anchor.MiddleRight:
			return new Vector3(-1f, -0.5f, 0f);
		case Anchor.LowerRight:
			return new Vector3(-1f, 0f, 0f);
		default:
			return customAnchorOffset;
		}
	}

	// RECUPERADO-AOT UghSprite.GetUVArray token 0x06000465 @0x00049b74
	// Per-vertex UVs of the slice grid (columns outer loop, rows inner loop), mapped into sourceUVRect.
	private Vector2[] GetUVArray(UghSpritePrototype sprite)
	{
		EdgePixels pixelInsets = sprite.edgePixelInsets;
		EdgePixels insets = sprite.edgeInsets;
		Vector2[] uvs = new Vector2[MeshVertexCount()];
		int index = 0;
		for (int x = 0; x < 4; x++)
		{
			float u = 0f;
			bool skip = false;
			if (flippedHorizontal)
			{
				if (x == 0)
				{
					u = 1f;
				}
				else if (x == 1 && pixelInsets.right != 0f)
				{
					u = 1f - insets.right;
				}
				else if (x == 2 && pixelInsets.left != 0f)
				{
					u = insets.left;
				}
				else if (x == 3)
				{
					u = 0f;
				}
				else
				{
					skip = true;
				}
			}
			else if (x == 0)
			{
				u = 0f;
			}
			else if (x == 1 && pixelInsets.left != 0f)
			{
				u = insets.left;
			}
			else if (x == 2 && pixelInsets.right != 0f)
			{
				u = 1f - insets.right;
			}
			else if (x == 3)
			{
				u = 1f;
			}
			else
			{
				skip = true;
			}
			if (skip)
			{
				continue;
			}
			for (int y = 0; y < 4; y++)
			{
				float v = 0f;
				bool skipRow = false;
				if (flippedVertical)
				{
					if (y == 0)
					{
						v = 1f;
					}
					else if (y == 1 && pixelInsets.top != 0f)
					{
						v = 1f - insets.top;
					}
					else if (y == 2 && pixelInsets.bottom != 0f)
					{
						v = insets.bottom;
					}
					else if (y == 3)
					{
						v = 0f;
					}
					else
					{
						skipRow = true;
					}
				}
				else if (y == 0)
				{
					v = 0f;
				}
				else if (y == 1 && pixelInsets.bottom != 0f)
				{
					v = insets.bottom;
				}
				else if (y == 2 && pixelInsets.top != 0f)
				{
					v = 1f - insets.top;
				}
				else if (y == 3)
				{
					v = 1f;
				}
				else
				{
					skipRow = true;
				}
				if (!skipRow)
				{
					uvs[index] = new Vector2(sprite.sourceUVRect.x + u * sprite.sourceUVRect.width, sprite.sourceUVRect.y + v * sprite.sourceUVRect.height);
					index++;
				}
			}
		}
		return uvs;
	}

	// RECUPERADO-AOT UghSprite.MeshRowCount token 0x06000466 @0x0004a178
	private int MeshRowCount()
	{
		int rows = 2;
		if (normal.edgePixelInsets.top != 0f)
		{
			rows++;
		}
		if (normal.edgePixelInsets.bottom != 0f)
		{
			rows++;
		}
		return rows;
	}

	// RECUPERADO-AOT UghSprite.MeshColumnCount token 0x06000467 @0x0004a214
	private int MeshColumnCount()
	{
		int columns = 2;
		if (normal.edgePixelInsets.right != 0f)
		{
			columns++;
		}
		if (normal.edgePixelInsets.left != 0f)
		{
			columns++;
		}
		return columns;
	}

	// RECUPERADO-AOT UghSprite.MeshVertexCount token 0x06000468 @0x0004a2b0
	private int MeshVertexCount()
	{
		return MeshRowCount() * MeshColumnCount();
	}

	// RECUPERADO-AOT UghSprite.GetParentPublisher token 0x06000469 @0x0004a2f8
	public UghPublisher GetParentPublisher()
	{
		for (Transform t = transform; t != null; t = t.parent)
		{
			UghPublisher publisher = t.gameObject.GetComponent<UghPublisher>();
			if ((bool)publisher)
			{
				return publisher;
			}
		}
		return null;
	}
}
