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
			return default(UghInput);
		}
	}

	public static bool UseTouchInput
	{
		get
		{
			return default(bool);
		}
	}

	public static Vector3 InputPosition
	{
		get
		{
			return default(Vector3);
		}
	}

	public static Vector3 InputPositionInWorldSpace
	{
		get
		{
			return default(Vector3);
		}
	}

	public static bool IsInputDown
	{
		get
		{
			return default(bool);
		}
	}

	public static Vector3 InputToWorldPoint(Vector3 point)
	{
		return default(Vector3);
	}

	public void Touch()
	{
	}

	private void TouchBeginEvent(Vector2 touch, int fingerId)
	{
	}

	private void TouchPersistEvent(Vector2 touch, int fingerId)
	{
	}

	private void TouchCanceledEvent(Vector2 touch, int fingerId)
	{
	}

	private void TouchEndedEvent(Vector2 touch, int fingerId)
	{
	}

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}
}
