using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardControl : MonoBehaviour
{
	public enum KeyEvents
	{
		UsePowerup = 0,
		BuyPowerup = 1,
		Pause = 2,
		Drift = 3,
		Accelerate = 4,
		Break = 5,
		TurnLeft = 6,
		TurnRight = 7
	}

	public class KeyEventBinding
	{
		public KeyEvents keyEvent;

		public List<KeyCode> boundKeys;

		public bool KeyDown()
		{
			return default(bool);
		}

		public bool Key()
		{
			return default(bool);
		}
	}

	public static Dictionary<KeyEvents, KeyEventBinding> dynamicKeys;

	private static bool GetKeyDown(KeyEvents keyEvent)
	{
		return default(bool);
	}

	private static bool GetKey(KeyEvents keyEvent)
	{
		return default(bool);
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
