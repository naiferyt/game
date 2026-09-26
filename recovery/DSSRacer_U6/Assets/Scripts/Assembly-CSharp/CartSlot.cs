using System;
using UnityEngine;

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

	public static string[] SlotNames;

	public static string[] TargetGameObjectName;

	public static bool[] SlotRequired;

	public static Vector3[] customizerCameraTarget;

	public static Vector3[] customizerCameraPosition;

	public Slots slot;

	public CartPart partInSlot;

	public PaintJob slotPaint;

	public string name
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public string targetGameObjectName
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool required
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public CartSlot(Slots _slot)
	{
	}

	public static string GetSlotName(Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static string GetSlotTargetGameObjectName(Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static bool GetIsSlotRequired(Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static Vector3 GetCustomizerCameraTarget(Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static Vector3 GetCustomizerCameraPosition(Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
