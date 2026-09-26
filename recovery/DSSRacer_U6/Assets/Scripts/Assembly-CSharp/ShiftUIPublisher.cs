using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShiftUIPublisher : UghPublisher
{
	// ELIMINADO (servicio iOS/externo, decision del usuario 2026-09-26, RECOVERY_REPORT.md 11.2): control parental (Age Gate) previo a compras y enlaces externos
	//   - public AgeGatePopup ageGatePopupPrefab;

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
			RecoveryPending.Hit("ShiftUIPublisher.ShifterPosition..ctor");
		}

		public static ShifterPosition Lerp(ShifterPosition from, ShifterPosition to, float delta)
		{
			RecoveryPending.Hit("ShiftUIPublisher.ShifterPosition.Lerp");
			return default(ShifterPosition);
		}
	}

	private class ShifterSlot
	{
		public ShifterPosition slot;

		public ShifterPosition approach;

		public ShifterSlot(ShifterPosition _slot, ShifterPosition _approach)
		{
			RecoveryPending.Hit("ShiftUIPublisher.ShifterSlot..ctor");
		}
	}

	private class ShiftKeyframe
	{
		public float duration;

		public ShifterPosition target;

		public ShiftKeyframe(float _dur, ShifterPosition _pos)
		{
			RecoveryPending.Hit("ShiftUIPublisher.ShiftKeyframe..ctor");
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

	public static event Action ChangedShifterSlot
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			RecoveryPending.Hit("ShiftUIPublisher.add_ChangedShifterSlot");
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			RecoveryPending.Hit("ShiftUIPublisher.remove_ChangedShifterSlot");
		}
	}

	private void SetStickPosition(float zRot, Vector3 pos)
	{
		RecoveryPending.Hit("ShiftUIPublisher.SetStickPosition");
	}

	private void SwitchSlot(UISlot newSlot)
	{
		RecoveryPending.Hit("ShiftUIPublisher.SwitchSlot");
	}

	public static void PlayRandomShiftSound()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PlayRandomShiftSound");
	}

	private new void Awake()
	{
		RecoveryPending.Hit("ShiftUIPublisher.Awake");
	}

	private void Start()
	{
		RecoveryPending.Hit("ShiftUIPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("ShiftUIPublisher.Update");
	}

	public void PressedPlayButton()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PressedPlayButton");
	}

	public void PressedCartCustomizer()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PressedCartCustomizer");
	}

	private void PressedTrophy()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PressedTrophy");
	}

	private void PressedCharacter()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PressedCharacter");
	}

	private void PressedOptions()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PressedOptions");
	}

	private void PressedMoreDisney()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PressedMoreDisney");
	}

	private void PressedMoreCoins()
	{
		RecoveryPending.Hit("ShiftUIPublisher.PressedMoreCoins");
	}

	[DebuggerHidden]
	private IEnumerator ShiftSurfaceCoroutine(Vector3 targetPos, float duration)
	{
		RecoveryPending.Hit("ShiftUIPublisher.ShiftSurfaceCoroutine");
		yield break;
	}

	public void Hide(bool immediate)
	{
		RecoveryPending.Hit("ShiftUIPublisher.Hide");
	}

	public void Show(bool immediate)
	{
		RecoveryPending.Hit("ShiftUIPublisher.Show");
	}

	public static void UpdateCharacterIcon(string charName)
	{
		RecoveryPending.Hit("ShiftUIPublisher.UpdateCharacterIcon");
	}
}
