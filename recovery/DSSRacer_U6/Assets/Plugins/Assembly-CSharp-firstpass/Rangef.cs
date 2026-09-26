using System;
using UnityEngine;

// Float interval [min, max] with lerp / inverse lerp / clamp helpers.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/Rangef.txt
[Serializable]
public class Rangef
{
	public float min;

	public float max;

	public float Range
	{
		// RECUPERADO-AOT Rangef.get_Range token 0x0600018c @0x00020eec
		get
		{
			return max - min;
		}
	}

	public float random
	{
		// RECUPERADO-AOT Rangef.get_random token 0x0600018d @0x00020f38
		get
		{
			return UnityEngine.Random.Range(min, max);
		}
	}

	// RECUPERADO-AOT Rangef..ctor token 0x0600018a @0x00020e34
	public Rangef()
	{
		min = 0f;
		max = 1f;
	}

	// RECUPERADO-AOT Rangef..ctor token 0x0600018b @0x00020e94
	public Rangef(float min, float max)
	{
		this.min = min;
		this.max = max;
	}

	// RECUPERADO-AOT Rangef.Clamp token 0x0600018e @0x00020fa4
	public float Clamp(float value)
	{
		return Mathf.Clamp(value, min, max);
	}

	// RECUPERADO-AOT Rangef.Lerp token 0x0600018f @0x00021028
	public float Lerp(float value)
	{
		return Mathf.Lerp(min, max, value);
	}

	// RECUPERADO-AOT Rangef.InverseLerp token 0x06000190 @0x000210ac
	public float InverseLerp(float value)
	{
		return Mathf.InverseLerp(min, max, value);
	}
}
