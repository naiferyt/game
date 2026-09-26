using UnityEngine;

public class UghTriangle
{
	public Vector3[] points;

	public Vector2[] uvs;

	public UghTriangle(Vector3 point1, Vector3 point2, Vector3 point3, Vector2 uv1, Vector2 uv2, Vector2 uv3)
	{
	}

	public UghTriangle(Vector3[] pointList, Vector2[] uvList)
	{
	}

	public void AddToMeshList(ref Vector3[] vertList, ref int[] triList, ref Vector2[] uvList)
	{
	}

	public static UghTriangle[] MakeQuad(Vector3 topLeft, Vector2 topLeftUV, Vector3 bottomRight, Vector2 bottomRightUV)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
