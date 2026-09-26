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
			RecoveryPending.Hit("PlayerKeyboardControl.KeyEventBinding.KeyDown");
			return default(bool);
		}

		public bool Key()
		{
			RecoveryPending.Hit("PlayerKeyboardControl.KeyEventBinding.Key");
			return default(bool);
		}
	}

	public static Dictionary<KeyEvents, KeyEventBinding> dynamicKeys;

	private static bool GetKeyDown(KeyEvents keyEvent)
	{
		RecoveryPending.Hit("PlayerKeyboardControl.GetKeyDown");
		return default(bool);
	}

	private static bool GetKey(KeyEvents keyEvent)
	{
		RecoveryPending.Hit("PlayerKeyboardControl.GetKey");
		return default(bool);
	}

	private void Awake()
	{
		RecoveryPending.Hit("PlayerKeyboardControl.Awake");
	}

	private void Update()
	{
		RecoveryPending.Hit("PlayerKeyboardControl.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("PlayerKeyboardControl.FixedUpdate");
	}
}
