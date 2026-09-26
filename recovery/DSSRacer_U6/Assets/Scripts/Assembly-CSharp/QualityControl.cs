using UnityEngine;

// Quality switches. In the shipped build IsGameHardcore is the constant false and the AOT compiler folded
// every getter to a constant, so only the resulting values are recoverable (the original expressions are not).
// Source listing: recovery/aot_listings/Assembly-CSharp/QualityControl.txt
public static class QualityControl
{
	// RECUPERADO-AOT QualityControl::get_IsGameHardcore token 0x06000472 @0x00103310
	public static bool IsGameHardcore
	{
		get
		{
			return false;
		}
	}

	// RECUPERADO-AOT QualityControl::get_DoPhysicsAt30fps token 0x06000473 @0x00103338 (folded to false)
	public static bool DoPhysicsAt30fps
	{
		get
		{
			return false;
		}
	}

	// RECUPERADO-AOT QualityControl::get_DoPerFrameCollision token 0x06000474 @0x00103368 (folded to true)
	public static bool DoPerFrameCollision
	{
		get
		{
			return true;
		}
	}

	// RECUPERADO-AOT QualityControl::get_DoDummiedPlayerCollision token 0x06000475 @0x00103398 (folded to true)
	public static bool DoDummiedPlayerCollision
	{
		get
		{
			return true;
		}
	}

	// RECUPERADO-AOT QualityControl::get_DoFullTriFoot token 0x06000476 @0x001033c8 (folded to true)
	public static bool DoFullTriFoot
	{
		get
		{
			return true;
		}
	}

	// RECUPERADO-AOT QualityControl::get_DoFullAI token 0x06000477 @0x001033f8 (folded to false)
	public static bool DoFullAI
	{
		get
		{
			return false;
		}
	}

	// RECUPERADO-AOT QualityControl::Apply token 0x06000478 @0x00103428
	public static void Apply()
	{
		if (DoPhysicsAt30fps)
		{
			Time.fixedDeltaTime = 0.0333f;
			Time.maximumDeltaTime = 0.3333f;
		}
	}
}
