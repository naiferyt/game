public class FractalNoise
{
	private float[] m_Exponent;

	private int m_IntOctaves;

	private float m_Octaves;

	private float m_Lacunarity;

	private float m_XScale;

	private float m_YScale;

	private float m_ValueScale;

	public FractalNoise(FractalNoiseParams para)
	{
		RecoveryPending.Hit("FractalNoise..ctor");
	}

	public FractalNoise(float inH, float inLacunarity, float inOctaves)
	{
		RecoveryPending.Hit("FractalNoise..ctor");
	}

	public FractalNoise(float inH, float inLacunarity, float inOctaves, Perlin noise)
	{
		RecoveryPending.Hit("FractalNoise..ctor");
	}

	private void PrecalculateNOoise()
	{
		RecoveryPending.Hit("FractalNoise.PrecalculateNOoise");
	}

	public float HybridMultifractal(float x, float y, float offset)
	{
		RecoveryPending.Hit("FractalNoise.HybridMultifractal");
		return default(float);
	}

	public float RidgedMultifractal(float x, float y, float offset, float gain)
	{
		RecoveryPending.Hit("FractalNoise.RidgedMultifractal");
		return default(float);
	}

	public float BrownianMotion(float x, float y)
	{
		RecoveryPending.Hit("FractalNoise.BrownianMotion");
		return default(float);
	}
}
