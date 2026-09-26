using System;

[Serializable]
public class EdgePixels
{
	public float top;

	public float bottom;

	public float right;

	public float left;

	public float xSum
	{
		get
		{
			RecoveryPending.Hit("EdgePixels.get_xSum");
			return default(float);
		}
	}

	public float ySum
	{
		get
		{
			RecoveryPending.Hit("EdgePixels.get_ySum");
			return default(float);
		}
	}

	public EdgePixels DeepCopy()
	{
		RecoveryPending.Hit("EdgePixels.DeepCopy");
		return default(EdgePixels);
	}
}
