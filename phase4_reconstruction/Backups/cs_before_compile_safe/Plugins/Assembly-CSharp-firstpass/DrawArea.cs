using UnityEngine;

public class DrawArea
{
	public Vector3 min;

	public Vector3 max;

	public Vector3 canvasMin;

	public Vector3 canvasMax;

	public DrawArea(Vector3 min, Vector3 max)
	{
	}

	public virtual Vector3 Point(Vector3 p)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void DrawLine(Vector3 a, Vector3 b, Color c)
	{
	}

	public void DrawRect(Vector3 a, Vector3 b, Color c)
	{
	}

	public void DrawDiamond(Vector3 a, Vector3 b, Color c)
	{
	}
}
