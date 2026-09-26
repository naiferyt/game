using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CartCustomizerPublisher : UghPublisher
{
	private const float paintMenuTransitionDuration = 0.25f;

	public GameObject paintSlotPublisherPrefab;

	public GameObject poofPrefab;

	private FrontEndCamera menuCamera;

	private CartSlot.Slots currentSlot;

	private int viewingIndex;

	private CartPart previousPart;

	private PaintJob previousPaint;

	private CartPart[] partList;

	private int viewingPaintIndex;

	private PaintJob[] paintList;

	private GameObject[] paintSlots;

	private Vector3 paintMenuTransitionStart;

	private Vector3 paintLockedTransitionStart;

	private float paintMenuTransitionTimer;

	private float paintLockedTransitionTimer;

	private bool paintMenuIsOut;

	private bool lockedMenuIsOut;

	private bool isBodyBoxAnimating;

	private bool isShowingBodyBox;

	public GameObject ownedNavBlipPrefab;

	public GameObject lockedNavBlipPrefab;

	public List<GameObject> navBlipList;

	public CartSlot.Slots CurrentSlot
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool GetPaintMenuIsOut()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void PopulatePaintMenu()
	{
	}

	[DebuggerHidden]
	private IEnumerator CameraWaitAndRefresh(CartSlot.Slots newSlot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void SetCameraToSlot(CartSlot.Slots newSlot)
	{
	}

	private void ResetPreviewSlot()
	{
	}

	public void ResetPaintInSlot(CartSlot previewSlot)
	{
	}

	private void SetToSpecificPart(CartPart selectedPart)
	{
	}

	private void SwitchFormType(AlternateForm.BodyForm newForm)
	{
	}

	private void SwitchSlot(CartSlot.Slots newSlot)
	{
	}

	private void SetStatBar(Transform stat, Transform positive, Transform negative, float currentRating, float newRating, float ratingDelta)
	{
	}

	private void RefreshStatBars(CartPart curPart, CartPart prevPart)
	{
	}

	public void PressedBuyPaint()
	{
	}

	public void PressedOkPaint()
	{
	}

	public void OpenBuyPaint()
	{
	}

	public void OpenPaintIsLocked()
	{
	}

	private void RefreshToggles()
	{
	}

	private void RefreshFormToggles()
	{
	}

	[DebuggerHidden]
	private IEnumerator SlideBodyFormBox(bool inOut)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void RefreshNavBlips()
	{
	}

	private void RefreshDisplay()
	{
	}

	[DebuggerHidden]
	private IEnumerator InitialWaitForLoadCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Update()
	{
	}

	private void PressedBodySlot()
	{
	}

	private void PressedScoopSlot()
	{
	}

	private void PressedSpoilerSlot()
	{
	}

	private void PressedThrusterSlot()
	{
	}

	private void PressedWheelsSlot()
	{
	}

	private void PressedBikeForm()
	{
	}

	private void PressedTrikeForm()
	{
	}

	private void PressedTruckForm()
	{
	}

	private void PressedRightArrow()
	{
	}

	private void PressedLeftArrow()
	{
	}

	private void PressedUpArrow()
	{
	}

	private void PressedDownArrow()
	{
	}

	private void PressedAction()
	{
	}

	private bool BuyPart(CartPart selectedPart)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void EquipPart(CartPart selectedPart)
	{
	}

	private void CloseLockedMenu()
	{
	}

	private void PressedPaint()
	{
	}

	private void PressedClosePaint()
	{
	}

	private void OnDisable()
	{
	}

	public static void Refresh()
	{
	}

	public static void SetViewingPaintIndex(int index)
	{
	}

	public static bool IsTemporaryInSlot(CartSlot.Slots slot)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnBodyToggleChanged(UghToggle toggle)
	{
	}

	private void OnScoopToggleChanged(UghToggle toggle)
	{
	}

	private void OnSpoilerToggleChanged(UghToggle toggle)
	{
	}

	private void OnThrusterToggleChanged(UghToggle toggle)
	{
	}

	private void OnWheelToggleChanged(UghToggle toggle)
	{
	}

	private void OnBikeToggleChanged(UghToggle toggle)
	{
	}

	private void OnTrikeToggleChanged(UghToggle toggle)
	{
	}

	private void OnTruckToggleChanged(UghToggle toggle)
	{
	}
}
