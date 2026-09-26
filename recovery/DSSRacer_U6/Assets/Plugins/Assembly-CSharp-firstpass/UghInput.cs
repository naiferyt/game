using System;
using System.Collections.Generic;
using UnityEngine;

// Routes touches (and the mouse as finger 0) to the Ugh controls under them: raycast on the GUI layer, nearest
// first, stopping at the first control that is not passThrough. Down/Drag/Up/UpAsButton/UpLate callbacks.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghInput.txt
public class UghInput : MonoBehaviour
{
	private static UghInput instance;

	private bool useTouchInput;

	private Vector3 inputPosition;

	private bool isInputDown;

	// RECUPERADO-AOT UghInput..ctor token 0x0600042a @0x000420f0 (field initializer)
	private List<UghControl> hotControls = new List<UghControl>();

	private bool lastMouseState;

	// RECONSTRUIDO (test tooling): release a simulated click where it was pressed.
	private bool testPressActive;

	public static UghInput Instance
	{
		// RECUPERADO-AOT UghInput.get_Instance token 0x0600042b @0x00042158
		get
		{
			if ((bool)instance)
			{
				return instance;
			}
			// ADAPTADO-U6: Object.FindObjectsOfType -> U4Compat (FindObjectsByType)
			UnityEngine.Object[] inputs = U4Compat.FindObjectsOfType(typeof(UghInput));
			if (inputs.Length > 1)
			{
				throw new Exception("More than one UghInput in the scene");
			}
			if (inputs.Length == 1)
			{
				instance = inputs[0] as UghInput;
				return instance;
			}
			GameObject go = new GameObject("+UghInput", typeof(UghInput));
			instance = go.GetComponent<UghInput>();
			return instance;
		}
	}

	public static bool UseTouchInput
	{
		// RECUPERADO-AOT UghInput.get_UseTouchInput token 0x0600042c @0x0004235c
		get
		{
			return Instance.useTouchInput;
		}
	}

	public static Vector3 InputPosition
	{
		// RECUPERADO-AOT UghInput.get_InputPosition token 0x0600042d @0x00042388
		get
		{
			if (instance.useTouchInput)
			{
				return Instance.inputPosition;
			}
			return Input.mousePosition;
		}
	}

	public static Vector3 InputPositionInWorldSpace
	{
		// RECUPERADO-AOT UghInput.get_InputPositionInWorldSpace token 0x0600042e @0x00042438
		get
		{
			// ADAPTADO-U6: Component.camera -> GetComponent<Camera>()
			return UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(InputPosition);
		}
	}

	public static bool IsInputDown
	{
		// RECUPERADO-AOT UghInput.get_IsInputDown token 0x0600042f @0x000424c8
		get
		{
			if (instance.useTouchInput)
			{
				return Instance.isInputDown;
			}
			return Input.GetMouseButton(0);
		}
	}

	// RECUPERADO-AOT UghInput.InputToWorldPoint token 0x06000430 @0x00042520
	public static Vector3 InputToWorldPoint(Vector3 point)
	{
		return UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(point);
	}

	// RECUPERADO-AOT UghInput.Touch token 0x06000431 @0x000425b0 (empty in the original)
	public void Touch()
	{
	}

	// RECUPERADO-AOT UghInput.TouchBeginEvent token 0x06000432 @0x000425dc
	// RECUPERADO-AOT UghInput.<TouchBeginEvent>m__6 token 0x06000438 @0x00043354
	private void TouchBeginEvent(Vector2 touch, int fingerId)
	{
		isInputDown = true;
		inputPosition = touch;
		UghCamera uiCamera = UghCamera.Instance;
		Ray ray = uiCamera.GetComponent<Camera>().ScreenPointToRay(touch);
		RaycastHit[] hits = Physics.RaycastAll(ray, float.PositiveInfinity, 1 << uiCamera.guiLayer);
		Array.Sort(hits, (RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));
		foreach (RaycastHit hit in hits)
		{
			UghControl control = hit.transform.GetComponent<UghControl>();
			if (control != null && !hotControls.Contains(control))
			{
				if (!hotControls.Contains(control))
				{
					hotControls.Add(control);
					control.HotFingerID = fingerId;
					control.StartCoroutine(control.OnUghInputDown());
				}
				if (!control.passThrough)
				{
					break;
				}
			}
		}
	}

	// RECUPERADO-AOT UghInput.TouchPersistEvent token 0x06000433 @0x000428b0
	private void TouchPersistEvent(Vector2 touch, int fingerId)
	{
		isInputDown = true;
		inputPosition = touch;
		foreach (UghControl control in hotControls)
		{
			if (control != null && control.HotFingerID == fingerId)
			{
				control.OnUghInputDrag();
			}
		}
	}

	// RECUPERADO-AOT UghInput.TouchCanceledEvent token 0x06000434 @0x00042a50
	private void TouchCanceledEvent(Vector2 touch, int fingerId)
	{
		isInputDown = false;
		inputPosition = touch;
		for (int i = 0; i < hotControls.Count; i++)
		{
			UghControl control = hotControls[i];
			if (control != null && control.HotFingerID == fingerId)
			{
				control.OnUghInputUp();
				control.HotFingerID = -1;
				hotControls.RemoveAt(i);
				i--;
			}
		}
	}

	// RECUPERADO-AOT UghInput.TouchEndedEvent token 0x06000435 @0x00042b4c
	// RECUPERADO-AOT UghInput.<TouchEndedEvent>m__7 token 0x06000439 @0x00043438
	private void TouchEndedEvent(Vector2 touch, int fingerId)
	{
		isInputDown = false;
		inputPosition = touch;
		List<UghControl> released = new List<UghControl>();
		UghCamera uiCamera = UghCamera.Instance;
		Ray ray = uiCamera.GetComponent<Camera>().ScreenPointToRay(touch);
		RaycastHit[] hits = Physics.RaycastAll(ray, float.PositiveInfinity, 1 << uiCamera.guiLayer);
		Array.Sort(hits, (RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));
		foreach (RaycastHit hit in hits)
		{
			UghControl control = hit.transform.GetComponent<UghControl>();
			if (control == null)
			{
				continue;
			}
			if (hotControls.Contains(control) && control.HotFingerID == fingerId)
			{
				control.OnUghInputUpAsButton();
				released.Add(control);
				hotControls.Remove(control);
				control.HotFingerID = -1;
			}
			else
			{
				control.OnUghInputUp();
			}
			if (!control.passThrough)
			{
				break;
			}
		}
		for (int i = 0; i < hotControls.Count; i++)
		{
			UghControl control = hotControls[i];
			if (control != null && control.HotFingerID == fingerId)
			{
				control.OnUghInputUp();
				released.Add(control);
				control.HotFingerID = -1;
				hotControls.RemoveAt(i);
				i--;
			}
		}
		foreach (UghControl control in released)
		{
			control.OnUghInputUpLate();
		}
	}

	// RECUPERADO-AOT UghInput.Awake token 0x06000436 @0x0004304c
	private void Awake()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			useTouchInput = true;
		}
	}

	// RECUPERADO-AOT UghInput.LateUpdate token 0x06000437 @0x0004309c
	private void LateUpdate()
	{
		foreach (UnityEngine.Touch touch in Input.touches)
		{
			switch (touch.phase)
			{
			case TouchPhase.Began:
				TouchBeginEvent(touch.position, touch.fingerId);
				break;
			case TouchPhase.Moved:
			case TouchPhase.Stationary:
				TouchPersistEvent(touch.position, touch.fingerId);
				break;
			case TouchPhase.Canceled:
				TouchCanceledEvent(touch.position, touch.fingerId);
				break;
			case TouchPhase.Ended:
				TouchEndedEvent(touch.position, touch.fingerId);
				break;
			default:
				Debug.LogError("This is an unrecognized touch phase!");
				break;
			}
		}
		Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		bool mouseDown = Input.GetMouseButton(0);
		// RECONSTRUIDO (test tooling): simulated clicks from the unattended PlayModeRunner (editor only, no-op in builds).
		Vector3 testPosition;
		if (RecoveryTestInput.Pressed(out testPosition))
		{
			mouse = testPosition;
			mouseDown = true;
			testPressActive = true;
		}
		else if (testPressActive)
		{
			mouse = testPosition;
			testPressActive = false;
		}
		if (mouseDown)
		{
			if (!lastMouseState)
			{
				TouchBeginEvent(mouse, 0);
			}
			else
			{
				TouchPersistEvent(mouse, 0);
			}
			lastMouseState = true;
		}
		else
		{
			if (lastMouseState)
			{
				TouchEndedEvent(mouse, 0);
			}
			lastMouseState = false;
		}
	}
}
