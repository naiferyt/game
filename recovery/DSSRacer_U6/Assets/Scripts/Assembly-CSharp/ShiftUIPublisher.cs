using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Garage gear-shift menu bar: the stick slides between Trophy/Cart/Play/Character/Options.
// Source listing: recovery/aot_listings/Assembly-CSharp/ShiftUIPublisher.txt
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

		// RECUPERADO-AOT ShiftUIPublisher/ShifterPosition::.ctor token 0x06000719 @0x00135f40
		public ShifterPosition(float _zRot, Vector3 _pos)
		{
			zRotation = _zRot;
			position = _pos;
		}

		// RECUPERADO-AOT ShiftUIPublisher/ShifterPosition::Lerp token 0x0600071a @0x00135fb0
		public static ShifterPosition Lerp(ShifterPosition from, ShifterPosition to, float delta)
		{
			float zRot = Mathf.Lerp(from.zRotation, to.zRotation, delta);
			Vector3 pos = Vector3.Lerp(from.position, to.position, delta);
			return new ShifterPosition(zRot, pos);
		}
	}

	private class ShifterSlot
	{
		public ShifterPosition slot;

		public ShifterPosition approach;

		// RECUPERADO-AOT ShiftUIPublisher/ShifterSlot::.ctor token 0x0600071b @0x00136104
		public ShifterSlot(ShifterPosition _slot, ShifterPosition _approach)
		{
			slot = _slot;
			approach = _approach;
		}
	}

	private class ShiftKeyframe
	{
		public float duration;

		public ShifterPosition target;

		// RECUPERADO-AOT ShiftUIPublisher/ShiftKeyframe::.ctor token 0x0600071c @0x0013614c
		public ShiftKeyframe(float _dur, ShifterPosition _pos)
		{
			duration = _dur;
			target = _pos;
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

	// RECUPERADO-AOT ShiftUIPublisher::.ctor token 0x06000704 @0x00133f4c (field initializers)
	private UISlot currentSlot = UISlot.PLAY;

	private List<ShiftKeyframe> transitionQueue = new List<ShiftKeyframe>();

	private float transitionTimer;

	private ShifterPosition lastShifterPosition;

	// RECUPERADO-AOT ShiftUIPublisher::add_ChangedShifterSlot token 0x06000705 @0x00133fb8
	// RECUPERADO-AOT ShiftUIPublisher::remove_ChangedShifterSlot token 0x06000706 @0x00134058
	public static event Action ChangedShifterSlot;

	// RECUPERADO-AOT ShiftUIPublisher::SetStickPosition token 0x06000707 @0x001340f8
	private void SetStickPosition(float zRot, Vector3 pos)
	{
		base.transforms["ShifterAnchor"].localRotation = Quaternion.Euler(0f, 0f, zRot);
		base.transforms["ShifterStick"].localPosition = pos;
	}

	// RECUPERADO-AOT ShiftUIPublisher::SwitchSlot token 0x06000708 @0x0013421c
	private void SwitchSlot(UISlot newSlot)
	{
		if (newSlot != currentSlot && transitionQueue.Count < 12)
		{
			if (ShiftUIPublisher.ChangedShifterSlot != null)
			{
				ShiftUIPublisher.ChangedShifterSlot();
			}
			transitionQueue.Add(new ShiftKeyframe(0.05f, uiSlots[(int)currentSlot].approach));
			int num = ((currentSlot <= newSlot) ? 1 : (-1));
			for (int i = (int)(currentSlot + num); i != (int)newSlot; i += num)
			{
				transitionQueue.Add(new ShiftKeyframe(0.25f, uiSlots[i].approach));
			}
			transitionQueue.Add(new ShiftKeyframe(0.25f, uiSlots[(int)newSlot].approach));
			transitionQueue.Add(new ShiftKeyframe(0.05f, uiSlots[(int)newSlot].slot));
			currentSlot = newSlot;
			PlayRandomShiftSound();
			// ELIMINADO (servicio iOS/externo): GDMOManager.SendWithContext("game_action", {"player_id",
			// "context": "UI", "action": "view", "type": newSlot.ToString()}) (analitica).
		}
	}

	// RECUPERADO-AOT ShiftUIPublisher::PlayRandomShiftSound token 0x06000709 @0x00134660
	public static void PlayRandomShiftSound()
	{
		SoundLibrary.ButtonClickPlay("Shifter " + UnityEngine.Random.Range(1, 3));
	}

	// RECUPERADO-AOT ShiftUIPublisher::Awake token 0x0600070a @0x001346cc
	// Each slot's "approach" position equals its "slot" position, as compiled.
	private new void Awake()
	{
		base.Awake();
		uiSlots = new ShifterSlot[Enum.GetValues(typeof(UISlot)).Length];
		uiSlots[0] = new ShifterSlot(new ShifterPosition(20f, new Vector3(0f, 15.5f, 0f)), new ShifterPosition(20f, new Vector3(0f, 15.5f, 0f)));
		uiSlots[1] = new ShifterSlot(new ShifterPosition(10.1f, new Vector3(0f, 15.25f, 0f)), new ShifterPosition(10.1f, new Vector3(0f, 15.25f, 0f)));
		uiSlots[2] = new ShifterSlot(new ShifterPosition(0f, new Vector3(0f, 15f, 0f)), new ShifterPosition(0f, new Vector3(0f, 15f, 0f)));
		uiSlots[3] = new ShifterSlot(new ShifterPosition(-10.1f, new Vector3(0f, 15.25f, 0f)), new ShifterPosition(-10.1f, new Vector3(0f, 15.25f, 0f)));
		uiSlots[4] = new ShifterSlot(new ShifterPosition(-20f, new Vector3(0f, 15.5f, 0f)), new ShifterPosition(-20f, new Vector3(0f, 15.5f, 0f)));
		lastShifterPosition = new ShifterPosition(base.transforms["ShifterAnchor"].localRotation.eulerAngles.z, base.transforms["ShifterStick"].localPosition);
		base.ughButtons["More Coins"].gameObject.SetActive(false);
		// ADAPTADO-U6: the Application.isWebPlayer branch (hid "More Disney" and "More Coins") is gone.
		// ELIMINADO (servicio iOS/externo): promo "More Disney" (escena MoreDisney quitada del build).
		base.ughButtons["More Disney"].gameObject.SetActive(false);
	}

	// RECUPERADO-AOT ShiftUIPublisher::Start token 0x0600070b @0x001352ac
	private void Start()
	{
		shifterButtons = new UghControl[5];
		shifterButtons[0] = base.ughButtons["PlayButton"];
		shifterButtons[1] = base.ughButtons["CartCustomizer"];
		shifterButtons[2] = base.ughButtons["Trophy"];
		shifterButtons[3] = base.ughButtons["Character"];
		shifterButtons[4] = base.ughButtons["Options"];
		UpdateCharacterIcon(PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot.UIName.baseText);
	}

	// RECUPERADO-AOT ShiftUIPublisher::Update token 0x0600070c @0x00135488
	private void Update()
	{
		if (transitionQueue.Count > 0)
		{
			ShiftKeyframe shiftKeyframe = transitionQueue[0];
			transitionTimer += Time.deltaTime;
			if (transitionTimer >= shiftKeyframe.duration)
			{
				SetStickPosition(shiftKeyframe.target.zRotation, shiftKeyframe.target.position);
				lastShifterPosition = shiftKeyframe.target;
				transitionTimer = 0f;
				transitionQueue.RemoveAt(0);
			}
			else
			{
				ShifterPosition shifterPosition = ShifterPosition.Lerp(lastShifterPosition, shiftKeyframe.target, transitionTimer / shiftKeyframe.duration);
				SetStickPosition(shifterPosition.zRotation, shifterPosition.position);
			}
		}
	}

	// RECUPERADO-AOT ShiftUIPublisher::PressedPlayButton token 0x0600070d @0x0013563c
	public void PressedPlayButton()
	{
		SwitchSlot(UISlot.PLAY);
		FrontEndLogic.RequestMenuChange("Circuit Select");
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT ShiftUIPublisher::PressedCartCustomizer token 0x0600070e @0x0013569c
	public void PressedCartCustomizer()
	{
		SwitchSlot(UISlot.CART_CUSTOMIZER);
		FrontEndLogic.RequestMenuChange("CartCustomizer");
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT ShiftUIPublisher::PressedTrophy token 0x0600070f @0x001356fc
	private void PressedTrophy()
	{
		SwitchSlot(UISlot.TROPHY);
		FrontEndLogic.RequestMenuChange("Achievement Categories");
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT ShiftUIPublisher::PressedCharacter token 0x06000710 @0x0013575c
	private void PressedCharacter()
	{
		SwitchSlot(UISlot.CHARACTER);
		FrontEndLogic.RequestMenuChange("CharacterSelect");
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT ShiftUIPublisher::PressedOptions token 0x06000711 @0x001357bc
	private void PressedOptions()
	{
		SwitchSlot(UISlot.OPTIONS);
		SoundLibrary.ButtonClickPlay("menuButton1");
		FrontEndLogic.RequestMenuChange("Settings");
	}

	// RECUPERADO-AOT ShiftUIPublisher::PressedMoreDisney token 0x06000712 @0x0013581c
	// ELIMINADO (servicio iOS/externo): ScreenFader.Instance.LoadLevel("MoreDisney") (promo Disney);
	// el boton se oculta en Awake.
	private void PressedMoreDisney()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT ShiftUIPublisher::PressedMoreCoins token 0x06000713 @0x00135880
	// ADAPTADO-U6: Application.isWebPlayer dropped (always false). The button is hidden in Awake.
	private void PressedMoreCoins()
	{
		FrontEndLogic.NeedMoreCoins(Localize.Get("Purchasing Off"), 0, false);
	}

	// RECUPERADO-AOT ShiftUIPublisher::ShiftSurfaceCoroutine token 0x06000714 @0x001358d8
	// (iterator <ShiftSurfaceCoroutine>c__Iterator72 MoveNext token 0x06000a87 @0x0015d7c0)
	[DebuggerHidden]
	private IEnumerator ShiftSurfaceCoroutine(Vector3 targetPos, float duration)
	{
		Transform surface = base.transforms["Surface"];
		Vector3 startPos = surface.localPosition;
		float timer = 0f;
		while (timer < duration)
		{
			Vector3 newPos = Vector3.Lerp(startPos, targetPos, timer / duration);
			surface.localPosition = newPos;
			yield return new WaitForSeconds(Time.deltaTime);
			timer += Time.deltaTime;
		}
		surface.localPosition = targetPos;
	}

	// RECUPERADO-AOT ShiftUIPublisher::Hide token 0x06000715 @0x0013598c
	public void Hide(bool immediate)
	{
		if (!immediate)
		{
			StartCoroutine(ShiftSurfaceCoroutine(new Vector3(0f, -2.5f, 0f), 0.35f));
		}
		else
		{
			base.transforms["Surface"].localPosition = new Vector3(0f, -2.5f, 0f);
		}
	}

	// RECUPERADO-AOT ShiftUIPublisher::Show token 0x06000716 @0x00135b5c
	public void Show(bool immediate)
	{
		if (!immediate)
		{
			StartCoroutine(ShiftSurfaceCoroutine(new Vector3(0f, 0f, 0f), 0.35f));
		}
		else
		{
			base.transforms["Surface"].localPosition = new Vector3(0f, 0f, 0f);
		}
	}

	// RECUPERADO-AOT ShiftUIPublisher::UpdateCharacterIcon token 0x06000717 @0x00135d2c
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void UpdateCharacterIcon(string charName)
	{
		ShiftUIPublisher shiftUIPublisher = (ShiftUIPublisher)U4Compat.FindObjectOfType(typeof(ShiftUIPublisher));
		UghSprite sprite = shiftUIPublisher.GetSprite("Character Button");
		foreach (Icon charIcon in shiftUIPublisher.charIcons)
		{
			if (charIcon.name == charName)
			{
				sprite.normal = charIcon.proto;
				sprite.UpdateMesh();
				break;
			}
		}
	}
}
