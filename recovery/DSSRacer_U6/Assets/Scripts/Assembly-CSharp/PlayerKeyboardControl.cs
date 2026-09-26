using System;
using System.Collections.Generic;
using UnityEngine;

// Keyboard driving (non-iOS builds). Key bindings come from the language data ("Keys" table:
// UsePowerup Space/Q, BuyPowerup B/E, Pause Escape, Drift LeftShift/RightShift/Z, Accelerate W/Up,
// Break S/Down, TurnLeft A/Left, TurnRight D/Right). The kart always accelerates unless braking.
// Source listing: recovery/aot_listings/Assembly-CSharp/PlayerKeyboardControl.txt
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

		// RECUPERADO-AOT PlayerKeyboardControl/KeyEventBinding::KeyDown token 0x06000465 @0x00101d60
		// RECONSTRUIDO (tooling): the unattended test runner's simulated keys are consulted as well.
		public bool KeyDown()
		{
			foreach (KeyCode boundKey in boundKeys)
			{
				if (Input.GetKeyDown(boundKey) || RecoveryTestInput.KeyDown(boundKey))
				{
					return true;
				}
			}
			return false;
		}

		// RECUPERADO-AOT PlayerKeyboardControl/KeyEventBinding::Key token 0x06000466 @0x00101e9c
		// RECONSTRUIDO (tooling): the unattended test runner's simulated keys are consulted as well.
		public bool Key()
		{
			foreach (KeyCode boundKey in boundKeys)
			{
				if (Input.GetKey(boundKey) || RecoveryTestInput.Key(boundKey))
				{
					return true;
				}
			}
			return false;
		}
	}

	// RECUPERADO-AOT PlayerKeyboardControl::.cctor token 0x0600045e @0x00101468
	public static Dictionary<KeyEvents, KeyEventBinding> dynamicKeys = new Dictionary<KeyEvents, KeyEventBinding>();

	// RECUPERADO-AOT PlayerKeyboardControl::GetKeyDown token 0x0600045f @0x001014c4
	private static bool GetKeyDown(KeyEvents keyEvent)
	{
		if (dynamicKeys.ContainsKey(keyEvent))
		{
			return dynamicKeys[keyEvent].KeyDown();
		}
		return false;
	}

	// RECUPERADO-AOT PlayerKeyboardControl::GetKey token 0x06000460 @0x00101554
	private static bool GetKey(KeyEvents keyEvent)
	{
		if (dynamicKeys.ContainsKey(keyEvent))
		{
			return dynamicKeys[keyEvent].Key();
		}
		return false;
	}

	// RECUPERADO-AOT PlayerKeyboardControl::Awake token 0x06000461 @0x001015e4
	private void Awake()
	{
		dynamicKeys.Clear();
		foreach (KeyEvents value in Enum.GetValues(typeof(KeyEvents)))
		{
			KeyCode[] array = Localize.GetDynamicKeys(value.ToString());
			if (array != null)
			{
				KeyEventBinding keyEventBinding = new KeyEventBinding();
				keyEventBinding.keyEvent = value;
				keyEventBinding.boundKeys = new List<KeyCode>(array);
				dynamicKeys.Add(value, keyEventBinding);
			}
		}
	}

	// RECUPERADO-AOT PlayerKeyboardControl::Update token 0x06000462 @0x00101934
	// Power-up / buy / pause go to the HUD as button presses; drift follows the key being held.
	private void Update()
	{
		if (!RaceManager.isPaused)
		{
			if (GetKeyDown(KeyEvents.UsePowerup))
			{
				HUDLogic.Instance.SendMessage("PressedPower");
			}
			if (GetKeyDown(KeyEvents.BuyPowerup))
			{
				HUDLogic.Instance.SendMessage("PressedBuyButton");
			}
			if (GetKeyDown(KeyEvents.Pause))
			{
				HUDLogic.Instance.SendMessage("PressedPauseButton");
			}
			if (GetKey(KeyEvents.Drift))
			{
				base.gameObject.SendMessage("ApplyDrift", true);
			}
			else
			{
				base.gameObject.SendMessage("ApplyDrift", false);
			}
		}
	}

	// RECUPERADO-AOT PlayerKeyboardControl::FixedUpdate token 0x06000463 @0x00101ac4
	private void FixedUpdate()
	{
		if (!RaceManager.isPaused)
		{
			float num = 0f;
			if (GetKey(KeyEvents.Accelerate))
			{
				num = 1f;
			}
			else if (GetKey(KeyEvents.Break))
			{
				num = -1f;
			}
			if (num < 0f)
			{
				base.gameObject.SendMessage("ApplyAcceleration", num);
			}
			else
			{
				base.gameObject.SendMessage("ApplyAcceleration", 1f);
			}
			float num2 = 0f;
			if (GetKey(KeyEvents.TurnRight))
			{
				num2 = 1f;
			}
			else if (GetKey(KeyEvents.TurnLeft))
			{
				num2 = -1f;
			}
			base.gameObject.SendMessage("ApplyTurning", num2);
		}
	}
}
