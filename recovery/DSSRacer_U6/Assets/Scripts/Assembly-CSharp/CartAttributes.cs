using System;

// Driving attributes of a kart; each part adds its modifiers. Ratings (0.1..1) feed the stat bars of the menus.
// Source listing: recovery/aot_listings/Assembly-CSharp/CartAttributes.txt
[Serializable]
public class CartAttributes
{
	// RECUPERADO-AOT CartAttributes::.ctor token 0x0600020d @0x000e103c (field initializers)
	public float groundHeight = 0.65f;

	public float maxSpeed = 40f;

	public float acceleration = 10f;

	public float turnRate = 30f;

	public float coastDown = 0.4f;

	public float handling = 2f;

	public float mass = 10f;

	public float driftTurnMult = 2f;

	public float driftTireDragMult = 0.1f;

	public float powerSlideAngle = 25f;

	public float secondsToPowerSlide = 0.5f;

	public float driftTooLong = 2.5f;

	public float powerSlidePower = 15f;

	public float powerSlideDuration = 1f;

	public string engineSoundString = string.Empty;

	// RECUPERADO-AOT CartAttributes::get_MaxAttributes token 0x06000216 @0x000e1754
	// (driftTooLong is not set: it keeps the constructor value)
	public static CartAttributes MaxAttributes
	{
		get
		{
			CartAttributes cartAttributes = new CartAttributes();
			cartAttributes.groundHeight = 0.65f;
			cartAttributes.maxSpeed = 60f;
			cartAttributes.acceleration = 22f;
			cartAttributes.turnRate = 110f;
			cartAttributes.coastDown = 0.4f;
			cartAttributes.handling = 12f;
			cartAttributes.mass = 10f;
			cartAttributes.driftTurnMult = 1.7f;
			cartAttributes.driftTireDragMult = 0.15f;
			cartAttributes.powerSlideAngle = 24f;
			cartAttributes.secondsToPowerSlide = 1.5f;
			cartAttributes.powerSlidePower = 61f;
			cartAttributes.powerSlideDuration = 4.6f;
			return cartAttributes;
		}
	}

	// RECUPERADO-AOT CartAttributes::get_MinAttributes token 0x06000217 @0x000e18d8
	// (driftTooLong is not set: it keeps the constructor value)
	public static CartAttributes MinAttributes
	{
		get
		{
			CartAttributes cartAttributes = new CartAttributes();
			cartAttributes.groundHeight = 0.65f;
			cartAttributes.maxSpeed = 40f;
			cartAttributes.acceleration = 0f;
			cartAttributes.turnRate = 70f;
			cartAttributes.coastDown = 0.4f;
			cartAttributes.handling = -3f;
			cartAttributes.mass = 10f;
			cartAttributes.driftTurnMult = 1.4f;
			cartAttributes.driftTireDragMult = 0.01f;
			cartAttributes.powerSlideAngle = 22f;
			cartAttributes.secondsToPowerSlide = 0.4f;
			cartAttributes.powerSlidePower = 33f;
			cartAttributes.powerSlideDuration = 0.3f;
			return cartAttributes;
		}
	}

	// RECUPERADO-AOT CartAttributes::GetSpeedRating token 0x0600020e @0x000e11d0
	public float GetSpeedRating()
	{
		float num = MinAttributes.maxSpeed;
		float num2 = (maxSpeed - num) / (MaxAttributes.maxSpeed - num);
		if (num2 < 0.1f)
		{
			num2 = 0.1f;
		}
		return num2;
	}

	// RECUPERADO-AOT CartAttributes::CompareSpeed token 0x0600020f @0x000e12a4
	public float CompareSpeed(CartAttributes other)
	{
		return GetSpeedRating() - other.GetSpeedRating();
	}

	// RECUPERADO-AOT CartAttributes::GetAccelerationRating token 0x06000210 @0x000e130c
	public float GetAccelerationRating()
	{
		float num = MinAttributes.acceleration;
		float num2 = (acceleration - num) / (MaxAttributes.acceleration - num);
		if (num2 < 0.1f)
		{
			num2 = 0.1f;
		}
		return num2;
	}

	// RECUPERADO-AOT CartAttributes::CompareAcceleration token 0x06000211 @0x000e13e0
	public float CompareAcceleration(CartAttributes other)
	{
		return GetAccelerationRating() - other.GetAccelerationRating();
	}

	// RECUPERADO-AOT CartAttributes::GetHandlingRating token 0x06000212 @0x000e1448
	public float GetHandlingRating()
	{
		CartAttributes maxAttributes = MaxAttributes;
		CartAttributes minAttributes = MinAttributes;
		float num = (handling - minAttributes.handling) / (maxAttributes.handling - minAttributes.handling);
		num += (turnRate - minAttributes.turnRate) / (maxAttributes.turnRate - minAttributes.turnRate);
		num /= 2f;
		if (num < 0.1f)
		{
			num = 0.1f;
		}
		return num;
	}

	// RECUPERADO-AOT CartAttributes::CompareHandlingRating token 0x06000213 @0x000e1570
	public float CompareHandlingRating(CartAttributes other)
	{
		return GetHandlingRating() - other.GetHandlingRating();
	}

	// RECUPERADO-AOT CartAttributes::GetPowerSlideRating token 0x06000214 @0x000e15d8
	public float GetPowerSlideRating()
	{
		CartAttributes maxAttributes = MaxAttributes;
		CartAttributes minAttributes = MinAttributes;
		float num = (maxAttributes.powerSlidePower - minAttributes.powerSlidePower) * (maxAttributes.powerSlideDuration - minAttributes.powerSlideDuration);
		float num2 = (powerSlidePower - minAttributes.powerSlidePower) * (powerSlideDuration - minAttributes.powerSlideDuration);
		float num3 = num2 / num;
		if (num3 < 0.1f)
		{
			num3 = 0.1f;
		}
		return num3;
	}

	// RECUPERADO-AOT CartAttributes::ComparePowerSlide token 0x06000215 @0x000e16ec
	public float ComparePowerSlide(CartAttributes other)
	{
		return GetPowerSlideRating() - other.GetPowerSlideRating();
	}

	// RECUPERADO-AOT CartAttributes::op_Addition token 0x06000218 @0x000e1a5c
	// (driftTooLong is not combined: the result keeps the constructor value)
	public static CartAttributes operator +(CartAttributes a, CartAttributes b)
	{
		CartAttributes cartAttributes = new CartAttributes();
		cartAttributes.groundHeight = a.groundHeight + b.groundHeight;
		cartAttributes.maxSpeed = a.maxSpeed + b.maxSpeed;
		cartAttributes.acceleration = a.acceleration + b.acceleration;
		cartAttributes.turnRate = a.turnRate + b.turnRate;
		cartAttributes.coastDown = a.coastDown + b.coastDown;
		cartAttributes.handling = a.handling + b.handling;
		cartAttributes.mass = a.mass + b.mass;
		cartAttributes.driftTurnMult = a.driftTurnMult + b.driftTurnMult;
		cartAttributes.driftTireDragMult = a.driftTireDragMult + b.driftTireDragMult;
		cartAttributes.powerSlideAngle = a.powerSlideAngle + b.powerSlideAngle;
		cartAttributes.secondsToPowerSlide = a.secondsToPowerSlide + b.secondsToPowerSlide;
		cartAttributes.powerSlidePower = a.powerSlidePower + b.powerSlidePower;
		cartAttributes.powerSlideDuration = a.powerSlideDuration + b.powerSlideDuration;
		cartAttributes.engineSoundString = ((!(a.engineSoundString != string.Empty)) ? b.engineSoundString : a.engineSoundString);
		return cartAttributes;
	}

	// RECUPERADO-AOT CartAttributes::op_Subtraction token 0x06000219 @0x000e1c5c
	// (driftTooLong is not combined: the result keeps the constructor value)
	public static CartAttributes operator -(CartAttributes a, CartAttributes b)
	{
		CartAttributes cartAttributes = new CartAttributes();
		cartAttributes.groundHeight = a.groundHeight - b.groundHeight;
		cartAttributes.maxSpeed = a.maxSpeed - b.maxSpeed;
		cartAttributes.acceleration = a.acceleration - b.acceleration;
		cartAttributes.turnRate = a.turnRate - b.turnRate;
		cartAttributes.coastDown = a.coastDown - b.coastDown;
		cartAttributes.handling = a.handling - b.handling;
		cartAttributes.mass = a.mass - b.mass;
		cartAttributes.driftTurnMult = a.driftTurnMult - b.driftTurnMult;
		cartAttributes.driftTireDragMult = a.driftTireDragMult - b.driftTireDragMult;
		cartAttributes.powerSlideAngle = a.powerSlideAngle - b.powerSlideAngle;
		cartAttributes.secondsToPowerSlide = a.secondsToPowerSlide - b.secondsToPowerSlide;
		cartAttributes.powerSlidePower = a.powerSlidePower - b.powerSlidePower;
		cartAttributes.powerSlideDuration = a.powerSlideDuration - b.powerSlideDuration;
		cartAttributes.engineSoundString = ((!(a.engineSoundString != string.Empty)) ? b.engineSoundString : a.engineSoundString);
		return cartAttributes;
	}
}
