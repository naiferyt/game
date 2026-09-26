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
			return default(float);
		}
	}

	public float ySum
	{
		get
		{
			return default(float);
		}
	}

	public EdgePixels DeepCopy()
	{
		return default(EdgePixels);
	}
}
