using UnityEngine;

public class DrawArea3D : DrawArea
{
	public Matrix4x4 matrix;

	public DrawArea3D(Vector3 min, Vector3 max, Matrix4x4 matrix)
		: base(min, max)
	{
		this.matrix = matrix;
	}

	public override Vector3 Point(Vector3 p)
	{
		return default(Vector3);
	}
}
