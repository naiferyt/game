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
			RecoveryPending.Hit("CartAttributes.get_MaxAttributes");
			return default(CartAttributes);
		}
	}

	public static CartAttributes MinAttributes
	{
		get
		{
			RecoveryPending.Hit("CartAttributes.get_MinAttributes");
			return default(CartAttributes);
		}
	}

	public float GetSpeedRating()
	{
		RecoveryPending.Hit("CartAttributes.GetSpeedRating");
		return default(float);
	}

	public float CompareSpeed(CartAttributes other)
	{
		RecoveryPending.Hit("CartAttributes.CompareSpeed");
		return default(float);
	}

	public float GetAccelerationRating()
	{
		RecoveryPending.Hit("CartAttributes.GetAccelerationRating");
		return default(float);
	}

	public float CompareAcceleration(CartAttributes other)
	{
		RecoveryPending.Hit("CartAttributes.CompareAcceleration");
		return default(float);
	}

	public float GetHandlingRating()
	{
		RecoveryPending.Hit("CartAttributes.GetHandlingRating");
		return default(float);
	}

	public float CompareHandlingRating(CartAttributes other)
	{
		RecoveryPending.Hit("CartAttributes.CompareHandlingRating");
		return default(float);
	}

	public float GetPowerSlideRating()
	{
		RecoveryPending.Hit("CartAttributes.GetPowerSlideRating");
		return default(float);
	}

	public float ComparePowerSlide(CartAttributes other)
	{
		RecoveryPending.Hit("CartAttributes.ComparePowerSlide");
		return default(float);
	}

	public static CartAttributes operator +(CartAttributes a, CartAttributes b)
	{
		RecoveryPending.Hit("CartAttributes.op_+");
		return default(CartAttributes);
	}

	public static CartAttributes operator -(CartAttributes a, CartAttributes b)
	{
		RecoveryPending.Hit("CartAttributes.op_-");
		return default(CartAttributes);
	}
}
