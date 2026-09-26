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
			RecoveryPending.Hit("Rangef.get_Range");
			return default(float);
		}
	}

	public float random
	{
		get
		{
			RecoveryPending.Hit("Rangef.get_random");
			return default(float);
		}
	}

	public Rangef()
	{
		RecoveryPending.Hit("Rangef..ctor");
	}

	public Rangef(float min, float max)
	{
		RecoveryPending.Hit("Rangef..ctor");
	}

	public float Clamp(float value)
	{
		RecoveryPending.Hit("Rangef.Clamp");
		return default(float);
	}

	public float Lerp(float value)
	{
		RecoveryPending.Hit("Rangef.Lerp");
		return default(float);
	}

	public float InverseLerp(float value)
	{
		RecoveryPending.Hit("Rangef.InverseLerp");
		return default(float);
	}
}
