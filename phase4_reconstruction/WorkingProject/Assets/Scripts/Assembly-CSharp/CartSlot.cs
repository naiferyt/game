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
			return default(string);
		}
	}

	public string targetGameObjectName
	{
		get
		{
			return default(string);
		}
	}

	public bool required
	{
		get
		{
			return default(bool);
		}
	}

	public CartSlot(Slots _slot)
	{
	}

	public static string GetSlotName(Slots slot)
	{
		return default(string);
	}

	public static string GetSlotTargetGameObjectName(Slots slot)
	{
		return default(string);
	}

	public static bool GetIsSlotRequired(Slots slot)
	{
		return default(bool);
	}

	public static Vector3 GetCustomizerCameraTarget(Slots slot)
	{
		return default(Vector3);
	}

	public static Vector3 GetCustomizerCameraPosition(Slots slot)
	{
		return default(Vector3);
	}
}
