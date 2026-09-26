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
	}

	public FractalNoise(float inH, float inLacunarity, float inOctaves)
	{
	}

	public FractalNoise(float inH, float inLacunarity, float inOctaves, Perlin noise)
	{
	}

	private void PrecalculateNOoise()
	{
	}

	public float HybridMultifractal(float x, float y, float offset)
	{
		return default(float);
	}

	public float RidgedMultifractal(float x, float y, float offset, float gain)
	{
		return default(float);
	}

	public float BrownianMotion(float x, float y)
	{
		return default(float);
	}
}
