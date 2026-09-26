using UnityEngine;

public class SmoothRandom
{
	private static FractalNoise s_Noise;

	public static Vector3 GetVector3(float speed)
	{
		RecoveryPending.Hit("SmoothRandom.GetVector3");
		return default(Vector3);
	}

	public static float Get(float speed)
	{
		RecoveryPending.Hit("SmoothRandom.Get");
		return default(float);
	}

	private static FractalNoise Get()
	{
		RecoveryPending.Hit("SmoothRandom.Get");
		return default(FractalNoise);
	}
}
