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
			RecoveryPending.Hit("CartSlot.get_name");
			return default(string);
		}
	}

	public string targetGameObjectName
	{
		get
		{
			RecoveryPending.Hit("CartSlot.get_targetGameObjectName");
			return default(string);
		}
	}

	public bool required
	{
		get
		{
			RecoveryPending.Hit("CartSlot.get_required");
			return default(bool);
		}
	}

	public CartSlot(Slots _slot)
	{
		RecoveryPending.Hit("CartSlot..ctor");
	}

	public static string GetSlotName(Slots slot)
	{
		RecoveryPending.Hit("CartSlot.GetSlotName");
		return default(string);
	}

	public static string GetSlotTargetGameObjectName(Slots slot)
	{
		RecoveryPending.Hit("CartSlot.GetSlotTargetGameObjectName");
		return default(string);
	}

	public static bool GetIsSlotRequired(Slots slot)
	{
		RecoveryPending.Hit("CartSlot.GetIsSlotRequired");
		return default(bool);
	}

	public static Vector3 GetCustomizerCameraTarget(Slots slot)
	{
		RecoveryPending.Hit("CartSlot.GetCustomizerCameraTarget");
		return default(Vector3);
	}

	public static Vector3 GetCustomizerCameraPosition(Slots slot)
	{
		RecoveryPending.Hit("CartSlot.GetCustomizerCameraPosition");
		return default(Vector3);
	}
}
