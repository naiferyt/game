using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShiftUIPublisher : UghPublisher
{
	[Serializable]
	public class Icon
	{
		public UghSpritePrototype proto;

		public string name;
	}

	private class ShifterPosition
	{
		public float zRotation;

		public Vector3 position;

		public ShifterPosition(float _zRot, Vector3 _pos)
		{
		}

		public static ShifterPosition Lerp(ShifterPosition from, ShifterPosition to, float delta)
		{
			return default(ShifterPosition);
		}
	}

	private class ShifterSlot
	{
		public ShifterPosition slot;

		public ShifterPosition approach;

		public ShifterSlot(ShifterPosition _slot, ShifterPosition _approach)
		{
		}
	}

	private class ShiftKeyframe
	{
		public float duration;

		public ShifterPosition target;

		public ShiftKeyframe(float _dur, ShifterPosition _pos)
		{
		}
	}

	private enum UISlot
	{
		TROPHY = 0,
		CART_CUSTOMIZER = 1,
		PLAY = 2,
		CHARACTER = 3,
		OPTIONS = 4
	}

	private const float APPROACH_DURATION = 0.05f;

	private const float SLOT_DURATION = 0.25f;

	public List<Icon> charIcons;

	public static UghControl[] shifterButtons;

	private ShifterSlot[] uiSlots;

	private UISlot currentSlot;

	private List<ShiftKeyframe> transitionQueue;

	private float transitionTimer;

	private ShifterPosition lastShifterPosition;

	public AgeGatePopup ageGatePopupPrefab;

	public static event Action ChangedShifterSlot
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	private void SetStickPosition(float zRot, Vector3 pos)
	{
	}

	private void SwitchSlot(UISlot newSlot)
	{
	}

	public static void PlayRandomShiftSound()
	{
	}

	private new void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void PressedPlayButton()
	{
	}

	public void PressedCartCustomizer()
	{
	}

	private void PressedTrophy()
	{
	}

	private void PressedCharacter()
	{
	}

	private void PressedOptions()
	{
	}

	private void PressedMoreDisney()
	{
	}

	private void PressedMoreCoins()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ShiftSurfaceCoroutine(Vector3 targetPos, float duration)
	{
		return default(IEnumerator);
	}

	public void Hide(bool immediate)
	{
	}

	public void Show(bool immediate)
	{
	}

	public static void UpdateCharacterIcon(string charName)
	{
	}
}
