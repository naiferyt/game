using UnityEngine;

public class DrawArea
{
	public Vector3 min;

	public Vector3 max;

	public Vector3 canvasMin;

	public Vector3 canvasMax;

	public DrawArea(Vector3 min, Vector3 max)
	{
		RecoveryPending.Hit("DrawArea..ctor");
	}

	public virtual Vector3 Point(Vector3 p)
	{
		RecoveryPending.Hit("DrawArea.Point");
		return default(Vector3);
	}

	public void DrawLine(Vector3 a, Vector3 b, Color c)
	{
		RecoveryPending.Hit("DrawArea.DrawLine");
	}

	public void DrawRect(Vector3 a, Vector3 b, Color c)
	{
		RecoveryPending.Hit("DrawArea.DrawRect");
	}

	public void DrawDiamond(Vector3 a, Vector3 b, Color c)
	{
		RecoveryPending.Hit("DrawArea.DrawDiamond");
	}
}
