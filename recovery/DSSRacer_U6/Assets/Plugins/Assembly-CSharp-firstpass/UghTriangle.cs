using System;
using System.Collections.Generic;
using UnityEngine;

// One UI mesh triangle; MakeQuad splits an axis-aligned rectangle into two. AddToMeshList appends to the vertex,
// index and UV arrays, reusing an existing vertex when the position is identical.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghTriangle.txt
public class UghTriangle
{
	public Vector3[] points;

	public Vector2[] uvs;

	// RECUPERADO-AOT UghTriangle..ctor token 0x06000486 @0x0004c660
	public UghTriangle(Vector3 point1, Vector3 point2, Vector3 point3, Vector2 uv1, Vector2 uv2, Vector2 uv3)
	{
		points = new Vector3[3];
		points[0] = point1;
		points[1] = point2;
		points[2] = point3;
		uvs = new Vector2[3];
		uvs[0] = uv1;
		uvs[1] = uv2;
		uvs[2] = uv3;
	}

	// RECUPERADO-AOT UghTriangle..ctor token 0x06000487 @0x0004c860
	public UghTriangle(Vector3[] pointList, Vector2[] uvList)
	{
		points = new Vector3[3];
		Array.Copy(pointList, points, 3);
		uvs = new Vector2[3];
		Array.Copy(uvList, uvs, 3);
	}

	// RECUPERADO-AOT UghTriangle.AddToMeshList token 0x06000488 @0x0004c8ec
	public void AddToMeshList(ref Vector3[] vertList, ref int[] triList, ref Vector2[] uvList)
	{
		int[] indices = new int[3] { -1, -1, -1 };
		for (int i = 0; i < 3; i++)
		{
			int index = Array.IndexOf<Vector3>(vertList, points[i]);
			if (index == -1)
			{
				index = vertList.Length;
				Array.Resize<Vector3>(ref vertList, vertList.Length + 1);
				vertList[index] = points[i];
				Array.Resize<Vector2>(ref uvList, vertList.Length);
				uvList[index] = uvs[i];
			}
			indices[i] = index;
		}
		List<int> tris = new List<int>(triList.Length + 3);
		tris.AddRange(triList);
		tris.AddRange(indices);
		triList = tris.ToArray();
	}

	// RECUPERADO-AOT UghTriangle.MakeQuad token 0x06000489 @0x0004cb74
	public static UghTriangle[] MakeQuad(Vector3 topLeft, Vector2 topLeftUV, Vector3 bottomRight, Vector2 bottomRightUV)
	{
		Vector3 topRight = new Vector3(bottomRight.x, topLeft.y, topLeft.z);
		Vector2 topRightUV = new Vector2(bottomRightUV.x, topLeftUV.y);
		Vector3 bottomLeft = new Vector3(topLeft.x, bottomRight.y, bottomRight.z);
		Vector2 bottomLeftUV = new Vector2(topLeftUV.x, bottomRightUV.y);
		return new UghTriangle[2]
		{
			new UghTriangle(topLeft, topRight, bottomLeft, topLeftUV, topRightUV, bottomLeftUV),
			new UghTriangle(topRight, bottomRight, bottomLeft, topRightUV, bottomRightUV, bottomLeftUV)
		};
	}
}
