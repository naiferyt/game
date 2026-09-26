using System;
using UnityEngine;

// One slot of the player's kart (part + paint) and the per-slot static tables (names, target objects, customizer camera).
// Source listing: recovery/aot_listings/Assembly-CSharp/CartSlot.txt
[Serializable]
public class CartSlot
{
	public enum Slots
	{
		body = 0,
		thrusters = 1,
		wheels = 2,
		spoiler = 3,
		scoop = 4,
		character = 5
	}

	// RECUPERADO-AOT CartSlot::.cctor token 0x06000236 @0x000e3c68 (static tables below)
	public static string[] SlotNames = new string[6] { "Body", "Thrusters", "Wheels", "Spoiler", "Scoop", "Character" };

	public static string[] TargetGameObjectName = new string[6] { "BodySlot", "ThrustersSlot", "WheelsSlot", "SpoilerSlot", "ScoopSlot", "CharacterSlot" };

	public static bool[] SlotRequired = new bool[6] { true, false, true, false, false, true };

	public static Vector3[] customizerCameraTarget = new Vector3[6]
	{
		new Vector3(3.5f, 2f, -15f),
		new Vector3(0.8079053f, 3.400898f, -11.89371f),
		new Vector3(3.5f, 2f, -15f),
		new Vector3(1.598494f, 3.314931f, -12.29548f),
		new Vector3(3.736758f, 2.552534f, -9.473418f),
		new Vector3(3.5f, 2f, -15f)
	};

	public static Vector3[] customizerCameraPosition = new Vector3[6]
	{
		new Vector3(0f, 3.5f, -4.5f),
		new Vector3(-0.59f, 4f, -7.7f),
		new Vector3(1.5f, 1.25f, -4f),
		new Vector3(0f, 4f, -7.5f),
		new Vector3(3.17f, 2.34f, -6.356249f),
		new Vector3(0f, 0f, 0f)
	};

	public Slots slot;

	public CartPart partInSlot;

	public PaintJob slotPaint;

	// RECUPERADO-AOT CartSlot::get_name token 0x06000237 @0x000e498c
	public string name
	{
		get
		{
			return SlotNames[(int)slot];
		}
	}

	// RECUPERADO-AOT CartSlot::get_targetGameObjectName token 0x06000238 @0x000e4a00
	public string targetGameObjectName
	{
		get
		{
			return TargetGameObjectName[(int)slot];
		}
	}

	// RECUPERADO-AOT CartSlot::get_required token 0x06000239 @0x000e4a74
	public bool required
	{
		get
		{
			return SlotRequired[(int)slot];
		}
	}

	// RECUPERADO-AOT CartSlot::.ctor token 0x06000235 @0x000e3c2c
	public CartSlot(Slots _slot)
	{
		slot = _slot;
	}

	// RECUPERADO-AOT CartSlot::GetSlotName token 0x0600023a @0x000e4ae4
	public static string GetSlotName(Slots slot)
	{
		return SlotNames[(int)slot];
	}

	// RECUPERADO-AOT CartSlot::GetSlotTargetGameObjectName token 0x0600023b @0x000e4b54
	public static string GetSlotTargetGameObjectName(Slots slot)
	{
		return TargetGameObjectName[(int)slot];
	}

	// RECUPERADO-AOT CartSlot::GetIsSlotRequired token 0x0600023c @0x000e4bc4
	public static bool GetIsSlotRequired(Slots slot)
	{
		return SlotRequired[(int)slot];
	}

	// RECUPERADO-AOT CartSlot::GetCustomizerCameraTarget token 0x0600023d @0x000e4c30
	public static Vector3 GetCustomizerCameraTarget(Slots slot)
	{
		return customizerCameraTarget[(int)slot];
	}

	// RECUPERADO-AOT CartSlot::GetCustomizerCameraPosition token 0x0600023e @0x000e4cd8
	public static Vector3 GetCustomizerCameraPosition(Slots slot)
	{
		return customizerCameraPosition[(int)slot];
	}
}
