using UnityEngine;

public class Vector3x
{
	public static Vector3 tiny;

	public static Vector3 Sinerp(Vector3 start, Vector3 end, float value)
	{
		RecoveryPending.Hit("Vector3x.Sinerp");
		return default(Vector3);
	}

	public static Vector3 Coserp(Vector3 start, Vector3 end, float value)
	{
		RecoveryPending.Hit("Vector3x.Coserp");
		return default(Vector3);
	}

	public static Vector3 Hermite(Vector3 start, Vector3 end, float value)
	{
		RecoveryPending.Hit("Vector3x.Hermite");
		return default(Vector3);
	}

	public static Vector3 Berp(Vector3 start, Vector3 end, float value)
	{
		RecoveryPending.Hit("Vector3x.Berp");
		return default(Vector3);
	}

	public static Vector3 Inverse(Vector3 a)
	{
		RecoveryPending.Hit("Vector3x.Inverse");
		return default(Vector3);
	}

	public static Vector3 FromString(string vectorString)
	{
		RecoveryPending.Hit("Vector3x.FromString");
		return default(Vector3);
	}
}
