using System;

[Serializable]
public class Rangef
{
	public float min;

	public float max;

	public float Range
	{
		get
		{
			return default(float);
		}
	}

	public float random
	{
		get
		{
			return default(float);
		}
	}

	public Rangef()
	{
	}

	public Rangef(float min, float max)
	{
	}

	public float Clamp(float value)
	{
		return default(float);
	}

	public float Lerp(float value)
	{
		return default(float);
	}

	public float InverseLerp(float value)
	{
		return default(float);
	}
}
