using UnityEngine;

public class DrawArea3D : DrawArea
{
	public Matrix4x4 matrix;

	// RECUPERADO-AOT DrawArea3D..ctor token 0x060001e1 @0x00027d24
	public DrawArea3D(Vector3 min, Vector3 max, Matrix4x4 matrix)
		: base(min, max)
	{
		this.matrix = matrix;
	}

	public override Vector3 Point(Vector3 p)
	{
		RecoveryPending.Hit("DrawArea3D.Point");
		return default(Vector3);
	}
}
