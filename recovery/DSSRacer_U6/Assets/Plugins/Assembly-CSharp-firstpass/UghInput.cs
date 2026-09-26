using System.Collections.Generic;
using UnityEngine;

public class UghInput : MonoBehaviour
{
	private static UghInput instance;

	private bool useTouchInput;

	private Vector3 inputPosition;

	private bool isInputDown;

	private List<UghControl> hotControls;

	private bool lastMouseState;

	public static UghInput Instance
	{
		get
		{
			RecoveryPending.Hit("UghInput.get_Instance");
			return default(UghInput);
		}
	}

	public static bool UseTouchInput
	{
		get
		{
			RecoveryPending.Hit("UghInput.get_UseTouchInput");
			return default(bool);
		}
	}

	public static Vector3 InputPosition
	{
		get
		{
			RecoveryPending.Hit("UghInput.get_InputPosition");
			return default(Vector3);
		}
	}

	public static Vector3 InputPositionInWorldSpace
	{
		get
		{
			RecoveryPending.Hit("UghInput.get_InputPositionInWorldSpace");
			return default(Vector3);
		}
	}

	public static bool IsInputDown
	{
		get
		{
			RecoveryPending.Hit("UghInput.get_IsInputDown");
			return default(bool);
		}
	}

	public static Vector3 InputToWorldPoint(Vector3 point)
	{
		RecoveryPending.Hit("UghInput.InputToWorldPoint");
		return default(Vector3);
	}

	public void Touch()
	{
		RecoveryPending.Hit("UghInput.Touch");
	}

	private void TouchBeginEvent(Vector2 touch, int fingerId)
	{
		RecoveryPending.Hit("UghInput.TouchBeginEvent");
	}

	private void TouchPersistEvent(Vector2 touch, int fingerId)
	{
		RecoveryPending.Hit("UghInput.TouchPersistEvent");
	}

	private void TouchCanceledEvent(Vector2 touch, int fingerId)
	{
		RecoveryPending.Hit("UghInput.TouchCanceledEvent");
	}

	private void TouchEndedEvent(Vector2 touch, int fingerId)
	{
		RecoveryPending.Hit("UghInput.TouchEndedEvent");
	}

	private void Awake()
	{
		RecoveryPending.Hit("UghInput.Awake");
	}

	private void LateUpdate()
	{
		RecoveryPending.Hit("UghInput.LateUpdate");
	}
}
