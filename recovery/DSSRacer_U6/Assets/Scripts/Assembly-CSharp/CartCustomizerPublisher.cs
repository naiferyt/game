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
			RecoveryPending.Hit("CartCustomizerPublisher.get_CurrentSlot");
			return default(CartSlot.Slots);
		}
	}

	public bool GetPaintMenuIsOut()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.GetPaintMenuIsOut");
		return default(bool);
	}

	private void PopulatePaintMenu()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PopulatePaintMenu");
	}

	[DebuggerHidden]
	private IEnumerator CameraWaitAndRefresh(CartSlot.Slots newSlot)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.CameraWaitAndRefresh");
		yield break;
	}

	private void SetCameraToSlot(CartSlot.Slots newSlot)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.SetCameraToSlot");
	}

	private void ResetPreviewSlot()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.ResetPreviewSlot");
	}

	public void ResetPaintInSlot(CartSlot previewSlot)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.ResetPaintInSlot");
	}

	private void SetToSpecificPart(CartPart selectedPart)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.SetToSpecificPart");
	}

	private void SwitchFormType(AlternateForm.BodyForm newForm)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.SwitchFormType");
	}

	private void SwitchSlot(CartSlot.Slots newSlot)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.SwitchSlot");
	}

	private void SetStatBar(Transform stat, Transform positive, Transform negative, float currentRating, float newRating, float ratingDelta)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.SetStatBar");
	}

	private void RefreshStatBars(CartPart curPart, CartPart prevPart)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.RefreshStatBars");
	}

	public void PressedBuyPaint()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedBuyPaint");
	}

	public void PressedOkPaint()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedOkPaint");
	}

	public void OpenBuyPaint()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OpenBuyPaint");
	}

	public void OpenPaintIsLocked()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OpenPaintIsLocked");
	}

	private void RefreshToggles()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.RefreshToggles");
	}

	private void RefreshFormToggles()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.RefreshFormToggles");
	}

	[DebuggerHidden]
	private IEnumerator SlideBodyFormBox(bool inOut)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.SlideBodyFormBox");
		yield break;
	}

	private void RefreshNavBlips()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.RefreshNavBlips");
	}

	private void RefreshDisplay()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.RefreshDisplay");
	}

	[DebuggerHidden]
	private IEnumerator InitialWaitForLoadCoroutine()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.InitialWaitForLoadCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.Start");
		yield break;
	}

	private void Update()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.Update");
	}

	private void PressedBodySlot()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedBodySlot");
	}

	private void PressedScoopSlot()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedScoopSlot");
	}

	private void PressedSpoilerSlot()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedSpoilerSlot");
	}

	private void PressedThrusterSlot()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedThrusterSlot");
	}

	private void PressedWheelsSlot()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedWheelsSlot");
	}

	private void PressedBikeForm()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedBikeForm");
	}

	private void PressedTrikeForm()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedTrikeForm");
	}

	private void PressedTruckForm()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedTruckForm");
	}

	private void PressedRightArrow()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedRightArrow");
	}

	private void PressedLeftArrow()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedLeftArrow");
	}

	private void PressedUpArrow()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedUpArrow");
	}

	private void PressedDownArrow()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedDownArrow");
	}

	private void PressedAction()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedAction");
	}

	private bool BuyPart(CartPart selectedPart)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.BuyPart");
		return default(bool);
	}

	private void EquipPart(CartPart selectedPart)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.EquipPart");
	}

	private void CloseLockedMenu()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.CloseLockedMenu");
	}

	private void PressedPaint()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedPaint");
	}

	private void PressedClosePaint()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.PressedClosePaint");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnDisable");
	}

	public static void Refresh()
	{
		RecoveryPending.Hit("CartCustomizerPublisher.Refresh");
	}

	public static void SetViewingPaintIndex(int index)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.SetViewingPaintIndex");
	}

	public static bool IsTemporaryInSlot(CartSlot.Slots slot)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.IsTemporaryInSlot");
		return default(bool);
	}

	private void OnBodyToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnBodyToggleChanged");
	}

	private void OnScoopToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnScoopToggleChanged");
	}

	private void OnSpoilerToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnSpoilerToggleChanged");
	}

	private void OnThrusterToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnThrusterToggleChanged");
	}

	private void OnWheelToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnWheelToggleChanged");
	}

	private void OnBikeToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnBikeToggleChanged");
	}

	private void OnTrikeToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnTrikeToggleChanged");
	}

	private void OnTruckToggleChanged(UghToggle toggle)
	{
		RecoveryPending.Hit("CartCustomizerPublisher.OnTruckToggleChanged");
	}
}
