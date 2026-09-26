using System;

[Serializable]
public class CartAttributes
{
	public float groundHeight;

	public float maxSpeed;

	public float acceleration;

	public float turnRate;

	public float coastDown;

	public float handling;

	public float mass;

	public float driftTurnMult;

	public float driftTireDragMult;

	public float powerSlideAngle;

	public float secondsToPowerSlide;

	public float driftTooLong;

	public float powerSlidePower;

	public float powerSlideDuration;

	public string engineSoundString;

	public static CartAttributes MaxAttributes
	{
		get
		{
			return default(CartAttributes);
		}
	}

	public static CartAttributes MinAttributes
	{
		get
		{
			return default(CartAttributes);
		}
	}

	public float GetSpeedRating()
	{
		return default(float);
	}

	public float CompareSpeed(CartAttributes other)
	{
		return default(float);
	}

	public float GetAccelerationRating()
	{
		return default(float);
	}

	public float CompareAcceleration(CartAttributes other)
	{
		return default(float);
	}

	public float GetHandlingRating()
	{
		return default(float);
	}

	public float CompareHandlingRating(CartAttributes other)
	{
		return default(float);
	}

	public float GetPowerSlideRating()
	{
		return default(float);
	}

	public float ComparePowerSlide(CartAttributes other)
	{
		return default(float);
	}

	public static CartAttributes operator +(CartAttributes a, CartAttributes b)
	{
		return default(CartAttributes);
	}

	public static CartAttributes operator -(CartAttributes a, CartAttributes b)
	{
		return default(CartAttributes);
	}
}
