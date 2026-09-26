using UnityEngine;

// Interpolation helpers.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/Mathfx.txt
public class Mathfx
{
	// RECUPERADO-AOT Mathfx::Hermite token 0x06000142 @0x0001a9dc
	public static float Hermite(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, value * value * (3f - 2f * value));
	}

	// RECUPERADO-AOT Mathfx::Sinerp token 0x06000143 @0x0001aaa0
	public static float Sinerp(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, Mathf.Sin(value * Mathf.PI * 0.5f));
	}

	// RECUPERADO-AOT Mathfx::Coserp token 0x06000144 @0x0001ab74
	public static float Coserp(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, 1f - Mathf.Cos(value * Mathf.PI * 0.5f));
	}

	// RECUPERADO-AOT Mathfx::Berp token 0x06000145 @0x0001ac64
	public static float Berp(float start, float end, float value)
	{
		value = Mathf.Clamp01(value);
		value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + 1.2f * (1f - value));
		return start + (end - start) * value;
	}

	// RECUPERADO-AOT Mathfx::Lerp token 0x06000146 @0x0001ae30
	public static float Lerp(float start, float end, float value)
	{
		return (1f - value) * start + value * end;
	}

	// RECUPERADO-AOT Mathfx::Exponential token 0x06000147 @0x0001aeac
	public static float Exponential(float start, float end, float value, float power)
	{
		return Mathf.Lerp(start, end, Mathf.Pow(value, power));
	}

	// RECUPERADO-AOT Mathfx::Exponential token 0x06000148 @0x0001af70
	public static float Exponential(float start, float end, float value)
	{
		return Exponential(start, end, value, 2f);
	}

	// RECUPERADO-AOT Mathfx::DragBounce token 0x06000149 @0x0001b010
	public static float DragBounce(float start, float end, float value)
	{
		value = Mathf.Clamp01(value);
		return Mathf.Lerp(start, end, 6.75f * value * (1f - value) * (1f - value));
	}

	// RECUPERADO-AOT Mathfx::ClampAngle token 0x0600014a @0x0001b110
	public static float ClampAngle(float angle, float min, float max)
	{
		while (angle < -360f)
		{
			angle += 360f;
		}
		while (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// RECUPERADO-AOT Mathfx::Parameter token 0x0600014b @0x0001b22c
	// The first half interpolates start->middle with (0.5 - value) * 2, as compiled.
	public static float Parameter(float start, float middle, float end, float value)
	{
		if (value < 0.5f)
		{
			return Mathf.Lerp(start, middle, (0.5f - value) * 2f);
		}
		return Mathf.Lerp(middle, end, (value - 0.5f) * 2f);
	}

	// RECUPERADO-AOT Mathfx::Bounce token 0x0600014c @0x0001b380
	public static float Bounce(float start, float end, float value)
	{
		value = Mathf.Clamp01(value);
		float t = 0f;
		if (value < 0.36363637f)
		{
			t = 7.5625f * value * value;
		}
		else if (value < 0.72727275f)
		{
			value -= 0.54545456f;
			t = 7.5625f * value * value + 0.75f;
		}
		else if (value < 0.9090909f)
		{
			value -= 0.8181818f;
			t = 7.5625f * value * value + 0.9375f;
		}
		else
		{
			value -= 0.95454544f;
			t = 7.5625f * value * value + 0.984375f;
		}
		return Mathf.Lerp(start, end, t);
	}
}
