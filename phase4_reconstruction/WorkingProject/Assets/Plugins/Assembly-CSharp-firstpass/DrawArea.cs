using UnityEngine;

public class DrawArea
{
	public Vector3 min;

	public Vector3 max;

	public Vector3 canvasMin;

	public Vector3 canvasMax;

	public DrawArea(Vector3 min, Vector3 max)
	{
		this.min = min;
		this.max = max;
	}

	public virtual Vector3 Point(Vector3 p)
	{
		return default(Vector3);
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
