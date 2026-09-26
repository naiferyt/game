public class Perlin
{
	private static int[] p;

	public static float NoiseNormalized(float x, float y)
	{
		RecoveryPending.Hit("Perlin.NoiseNormalized");
		return default(float);
	}

	public static float Noise(float x, float y)
	{
		RecoveryPending.Hit("Perlin.Noise");
		return default(float);
	}

	public static float Noise(float x, float y, float z)
	{
		RecoveryPending.Hit("Perlin.Noise");
		return default(float);
	}

	private static float fade(float t)
	{
		RecoveryPending.Hit("Perlin.fade");
		return default(float);
	}

	private static float lerp(float t, float a, float b)
	{
		RecoveryPending.Hit("Perlin.lerp");
		return default(float);
	}

	private static float grad(int hash, float x, float y, float z)
	{
		RecoveryPending.Hit("Perlin.grad");
		return default(float);
	}

	private static float grad2(int hash, float x, float y)
	{
		RecoveryPending.Hit("Perlin.grad2");
		return default(float);
	}
}
