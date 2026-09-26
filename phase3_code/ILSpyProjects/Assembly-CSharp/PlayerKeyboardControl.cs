using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardControl : MonoBehaviour
{
	public enum KeyEvents
	{
		UsePowerup,
		BuyPowerup,
		Pause,
		Drift,
		Accelerate,
		Break,
		TurnLeft,
		TurnRight
	}

	public class KeyEventBinding
	{
		public KeyEvents keyEvent;

		public List<KeyCode> boundKeys;

		public bool KeyDown()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Key()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static Dictionary<KeyEvents, KeyEventBinding> dynamicKeys;

	private static bool GetKeyDown(KeyEvents keyEvent)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private static bool GetKey(KeyEvents keyEvent)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}
}
