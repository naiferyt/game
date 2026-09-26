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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool UseTouchInput
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static Vector3 InputPosition
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static Vector3 InputPositionInWorldSpace
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool IsInputDown
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static Vector3 InputToWorldPoint(Vector3 point)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
