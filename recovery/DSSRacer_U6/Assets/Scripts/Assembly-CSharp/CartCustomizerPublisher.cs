using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Garage kart customizer: pick a slot (body, thrusters, wheels, spoiler, scoop) and body form, browse the parts of
// that slot with the arrows (previewed on the kart), buy / equip them with coins, and open the paint menu to pick,
// buy and apply paint jobs. Shows stat bars comparing the previewed part with the equipped one.
// Source listing: recovery/aot_listings/Assembly-CSharp/CartCustomizerPublisher.txt
public class CartCustomizerPublisher : UghPublisher
{
	private const float paintMenuTransitionDuration = 0.25f;

	public GameObject paintSlotPublisherPrefab;

	public GameObject poofPrefab;

	private FrontEndCamera menuCamera;

	private CartSlot.Slots currentSlot;

	// RECUPERADO-AOT CartCustomizerPublisher::.ctor token 0x060005e8 @0x0011fe08 (field initializers)
	private int viewingIndex = -1;

	private CartPart previousPart;

	private PaintJob previousPaint;

	private CartPart[] partList;

	private int viewingPaintIndex = -1;

	private PaintJob[] paintList;

	private GameObject[] paintSlots;

	private Vector3 paintMenuTransitionStart = Vector3.zero;

	private Vector3 paintLockedTransitionStart = Vector3.zero;

	private float paintMenuTransitionTimer;

	private float paintLockedTransitionTimer;

	private bool paintMenuIsOut;

	private bool lockedMenuIsOut;

	private bool isBodyBoxAnimating;

	private bool isShowingBodyBox = true;

	public GameObject ownedNavBlipPrefab;

	public GameObject lockedNavBlipPrefab;

	public List<GameObject> navBlipList = new List<GameObject>();

	public CartSlot.Slots CurrentSlot
	{
		// RECUPERADO-AOT CartCustomizerPublisher::get_CurrentSlot token 0x060005ea @0x0011ff00
		get
		{
			return currentSlot;
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::GetPaintMenuIsOut token 0x060005e9 @0x0011fecc
	public bool GetPaintMenuIsOut()
	{
		return paintMenuIsOut;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PopulatePaintMenu token 0x060005eb @0x0011ff34
	// Rebuilds the paint swatches: 4 per row under "Paint Menu".
	private void PopulatePaintMenu()
	{
		if (paintSlots != null)
		{
			GameObject[] array = paintSlots;
			foreach (GameObject gameObject in array)
			{
				if (gameObject != null)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
		Vector3 vector = new Vector3(-2.1f, 0.75f, -0.25f);
		Vector3 vector2 = new Vector3(1.45f, -1.5f, 0f);
		paintSlots = new GameObject[paintList.Length];
		for (int j = 0; j < paintList.Length; j++)
		{
			paintSlots[j] = Script.Instantiate(paintSlotPublisherPrefab);
			paintSlots[j].GetComponent<PaintSlotPublisher>().SetPaint(paintList[j], j);
			float x = (float)(j % 4) * vector2.x;
			float y = (float)(j / 4) * vector2.y;
			paintSlots[j].transform.parent = base.transforms["Paint Menu"];
			paintSlots[j].transform.localPosition = vector + new Vector3(x, y, 0f);
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::CameraWaitAndRefresh token 0x060005ec @0x00120354
	// RECUPERADO-AOT CartCustomizerPublisher/<CameraWaitAndRefresh>c__Iterator50::MoveNext token 0x060009b4 @0x00152468
	[DebuggerHidden]
	private IEnumerator CameraWaitAndRefresh(CartSlot.Slots newSlot)
	{
		yield return new WaitForSeconds(1f);
		SetCameraToSlot(newSlot);
	}

	// RECUPERADO-AOT CartCustomizerPublisher::SetCameraToSlot token 0x060005ed @0x001203ac
	// RECUPERADO-AOT CartCustomizerPublisher/<SetCameraToSlot>c__AnonStorey9D::<>m__20 token 0x06000b4e @0x00166c48
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	private void SetCameraToSlot(CartSlot.Slots newSlot)
	{
		FrontEndCameraTarget[] array = (FrontEndCameraTarget[])U4Compat.FindObjectsOfType(typeof(FrontEndCameraTarget));
		FrontEndCameraTarget frontEndCameraTarget = Array.Find(array, (FrontEndCameraTarget x) => x.name == newSlot.ToString());
		if (frontEndCameraTarget != null)
		{
			menuCamera.SendMessage("ForceCameraTarget", frontEndCameraTarget);
		}
		else
		{
			UnityEngine.Debug.LogWarning("Could not find camera target for slot " + newSlot.ToString());
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::ResetPreviewSlot token 0x060005ee @0x00120584
	// Puts the equipped part back into the current slot when leaving a preview.
	private void ResetPreviewSlot()
	{
		CartSlot cartSlot = PlayerInstance.GetCartSlot(currentSlot);
		if (previousPart != null && previousPart.UIName.baseText != cartSlot.partInSlot.UIName.baseText)
		{
			cartSlot.partInSlot = previousPart;
			PreviewCart.SetSlotTransparent(cartSlot.slot, false);
			if (previousPart.cartSlot == CartSlot.Slots.body)
			{
				PlayerInstance.MatchAlternateForms();
			}
		}
		ResetPaintInSlot(cartSlot);
	}

	// RECUPERADO-AOT CartCustomizerPublisher::ResetPaintInSlot token 0x060005ef @0x00120624
	public void ResetPaintInSlot(CartSlot previewSlot)
	{
		if (previewSlot == null)
		{
			return;
		}
		CartPart partInSlot = PlayerInstance.GetCartSlot(currentSlot).partInSlot;
		if (partInSlot.validPaintJobs.Length > 0)
		{
			previewSlot.slotPaint = partInSlot.validPaintJobs[0];
		}
		PaintJob[] validPaintJobs = partInSlot.validPaintJobs;
		foreach (PaintJob paintJob in validPaintJobs)
		{
			if (paintJob == previousPaint)
			{
				previewSlot.slotPaint = previousPaint;
				break;
			}
		}
		PreviewCart.GenerateCartPreview();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::SetToSpecificPart token 0x060005f0 @0x00120718
	// Note (original): the chosen slot's paint is first set to the previous paint and then overwritten with paint 0.
	private void SetToSpecificPart(CartPart selectedPart)
	{
		if (selectedPart == null)
		{
			return;
		}
		ResetPreviewSlot();
		currentSlot = selectedPart.cartSlot;
		partList = CartPartList.GetSlotPartList(currentSlot);
		SetCameraToSlot(currentSlot);
		RefreshFormToggles();
		viewingIndex = Array.IndexOf(partList, selectedPart.GetAlternatePartOfForm(AlternateForm.BodyForm.Normal));
		CartSlot cartSlot = PlayerInstance.Instance.cartSlots[(int)currentSlot];
		previousPart = cartSlot.partInSlot;
		cartSlot.partInSlot = selectedPart;
		PreviewCart.SetSlotTransparent(cartSlot.slot, cartSlot.partInSlot != previousPart);
		paintList = selectedPart.validPaintJobs;
		if (paintList != null && paintList.Length > 0)
		{
			viewingPaintIndex = 0;
			if (cartSlot.partInSlot == previousPart)
			{
				cartSlot.slotPaint = previousPaint;
			}
			else
			{
				cartSlot.slotPaint = paintList[0];
			}
			PlayerInstance.GetCartSlot(selectedPart.cartSlot).slotPaint = paintList[0];
		}
		else
		{
			viewingPaintIndex = -1;
			cartSlot.slotPaint = null;
			PlayerInstance.GetCartSlot(selectedPart.cartSlot).slotPaint = null;
		}
		RefreshDisplay();
		PopulatePaintMenu();
		PlayerInstance.MatchAlternateForms();
		PreviewCart.GenerateCartPreview();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::SwitchFormType token 0x060005f1 @0x001208e0
	private void SwitchFormType(AlternateForm.BodyForm newForm)
	{
		if (PreviewCart.IsLoading)
		{
			RefreshFormToggles();
			return;
		}
		CartPart cartPart = partList[viewingIndex];
		if (cartPart.alternateForms == null)
		{
			return;
		}
		if (paintMenuIsOut)
		{
			PressedClosePaint();
		}
		CartPart cartPart2 = cartPart.alternateForms.FindFirstWithForm(newForm);
		CartSlot cartSlot = PlayerInstance.Instance.cartSlots[(int)currentSlot];
		if (cartPart2.UIName == cartSlot.partInSlot.UIName)
		{
			RefreshFormToggles();
			return;
		}
		cartSlot.partInSlot = cartPart2;
		paintList = cartPart2.validPaintJobs;
		RefreshFormToggles();
		if (paintList != null && paintList.Length > 0)
		{
			viewingPaintIndex = 0;
			if (cartSlot.partInSlot == previousPart)
			{
				cartSlot.slotPaint = previousPaint;
			}
			else
			{
				cartSlot.slotPaint = paintList[0];
			}
		}
		else
		{
			viewingPaintIndex = -1;
		}
		PreviewCart.SetSlotTransparent(cartSlot.slot, cartSlot.partInSlot != previousPart);
		PlayerInstance.MatchAlternateForms();
		PreviewCart.GenerateCartPreview();
		RefreshDisplay();
		PopulatePaintMenu();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::SwitchSlot token 0x060005f2 @0x00120ab4
	// ELIMINADO (analitica): the original then sent GDMOManager.SendWithContext("game_action",
	// {player_id, context: "UI", action: "CART_CUSTOMIZER", type: newSlot}).
	private void SwitchSlot(CartSlot.Slots newSlot)
	{
		if (PreviewCart.IsLoading)
		{
			RefreshToggles();
			return;
		}
		if (newSlot == currentSlot)
		{
			RefreshToggles();
			return;
		}
		if (paintMenuIsOut)
		{
			PressedClosePaint();
		}
		SoundLibrary.PlayRandomWhoosh();
		ResetPreviewSlot();
		currentSlot = newSlot;
		CartSlot cartSlot = PlayerInstance.GetCartSlot(newSlot);
		partList = CartPartList.GetSlotPartList(newSlot);
		RefreshFormToggles();
		RefreshToggles();
		CartPart cartPart = cartSlot.partInSlot;
		if (cartPart == null)
		{
			viewingIndex = 0;
			cartPart = partList[0];
			PlayerInstance.GetCartSlot(newSlot).partInSlot = cartPart;
		}
		else if (cartPart.alternateForms != null)
		{
			viewingIndex = Array.IndexOf(partList, cartPart.alternateForms.FindFirstWithForm(AlternateForm.BodyForm.Normal));
		}
		else
		{
			viewingIndex = Array.IndexOf(partList, cartPart);
		}
		paintList = cartPart.validPaintJobs;
		if (cartSlot.slotPaint == null)
		{
			if (paintList != null && paintList.Length > 0)
			{
				viewingPaintIndex = 0;
				if (cartSlot.partInSlot == previousPart)
				{
					cartSlot.slotPaint = previousPaint;
				}
				else
				{
					cartSlot.slotPaint = paintList[0];
				}
				PlayerInstance.GetCartSlot(newSlot).slotPaint = paintList[0];
			}
			else
			{
				viewingPaintIndex = -1;
				cartSlot.slotPaint = null;
				PlayerInstance.GetCartSlot(newSlot).slotPaint = null;
			}
		}
		else
		{
			viewingPaintIndex = Array.IndexOf(paintList, cartSlot.slotPaint);
		}
		previousPart = cartPart;
		previousPaint = cartSlot.slotPaint;
		RefreshDisplay();
		PopulatePaintMenu();
		SetCameraToSlot(newSlot);
		PlayerInstance.MatchAlternateForms();
		PreviewCart.GenerateCartPreview();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::SetStatBar token 0x060005f3 @0x00120e6c
	// ADAPTADO-U6: Component.GetComponent<UghSprite>() on each bar (same call as the original).
	private void SetStatBar(Transform stat, Transform positive, Transform negative, float currentRating, float newRating, float ratingDelta)
	{
		if (Mathf.Abs(ratingDelta) <= 0.01f)
		{
			Vector3 localScale = stat.localScale;
			localScale.x = currentRating * 1.5f;
			stat.localScale = localScale;
			positive.gameObject.SetActive(false);
			negative.gameObject.SetActive(false);
		}
		else if (ratingDelta < 0f)
		{
			Vector3 localScale2 = stat.localScale;
			localScale2.x = newRating * 1.5f;
			stat.localScale = localScale2;
			positive.gameObject.SetActive(false);
			negative.gameObject.SetActive(true);
			localScale2 = negative.localScale;
			localScale2.x = currentRating * 2f;
			negative.localScale = localScale2;
		}
		else
		{
			Vector3 localScale3 = stat.localScale;
			localScale3.x = currentRating * 1.5f;
			stat.localScale = localScale3;
			positive.gameObject.SetActive(true);
			negative.gameObject.SetActive(false);
			localScale3 = positive.localScale;
			localScale3.x = newRating * 1.9f;
			positive.localScale = localScale3;
		}
		stat.GetComponent<UghSprite>().UpdateMesh();
		positive.GetComponent<UghSprite>().UpdateMesh();
		negative.GetComponent<UghSprite>().UpdateMesh();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::RefreshStatBars token 0x060005f4 @0x00121294
	// Compares the whole kart with the previewed part (curPart) against the kart with the equipped one (prevPart).
	private void RefreshStatBars(CartPart curPart, CartPart prevPart)
	{
		CartAttributes cartAttributes = null;
		CartSlot[] cartSlots = PlayerInstance.Instance.cartSlots;
		foreach (CartSlot cartSlot in cartSlots)
		{
			if (cartSlot.partInSlot != null)
			{
				cartAttributes = ((cartAttributes != null) ? (cartAttributes + cartSlot.partInSlot.cartAttributeMods) : cartSlot.partInSlot.cartAttributeMods);
			}
		}
		float speedRating = (cartAttributes - curPart.cartAttributeMods + prevPart.cartAttributeMods).GetSpeedRating();
		float speedRating2 = cartAttributes.GetSpeedRating();
		SetStatBar(base.transforms["Speed Stat"], base.transforms["Speed Positive"], base.transforms["Speed Negative"], speedRating, speedRating2, speedRating2 - speedRating);
		float accelerationRating = (cartAttributes - curPart.cartAttributeMods + prevPart.cartAttributeMods).GetAccelerationRating();
		float accelerationRating2 = cartAttributes.GetAccelerationRating();
		SetStatBar(base.transforms["Accel Stat"], base.transforms["Accel Positive"], base.transforms["Accel Negative"], accelerationRating, accelerationRating2, accelerationRating2 - accelerationRating);
		float handlingRating = (cartAttributes - curPart.cartAttributeMods + prevPart.cartAttributeMods).GetHandlingRating();
		float handlingRating2 = cartAttributes.GetHandlingRating();
		SetStatBar(base.transforms["Handling Stat"], base.transforms["Handling Positive"], base.transforms["Handling Negative"], handlingRating, handlingRating2, handlingRating2 - handlingRating);
		float powerSlideRating = (cartAttributes - curPart.cartAttributeMods + prevPart.cartAttributeMods).GetPowerSlideRating();
		float powerSlideRating2 = cartAttributes.GetPowerSlideRating();
		SetStatBar(base.transforms["PowerSlide Stat"], base.transforms["PowerSlide Positive"], base.transforms["PowerSlide Negative"], powerSlideRating, powerSlideRating2, powerSlideRating2 - powerSlideRating);
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedBuyPaint token 0x060005f5 @0x001217f8
	// ELIMINADO (analitica): after a purchase the original sent GDMOManager.SendWithContext("in_app_currency_action",
	// {player_id, currency: "coins", amount: -cost, item: {item_id, item_count: 1}, type: "cart part",
	// subtype: "paint", level: 0, balance}).
	public void PressedBuyPaint()
	{
		if (DataUtility.Instance.BuyItem(paintList[viewingPaintIndex].name, paintList[viewingPaintIndex].cost))
		{
			DataUtility.Instance.SetCartPaint(currentSlot, paintList[viewingPaintIndex].name);
			previousPaint = paintList[viewingPaintIndex];
			DataUtility.Instance.Save();
			PopulatePaintMenu();
			SoundLibrary.ButtonClickPlay("menuButton1");
			paintLockedTransitionStart = base.transforms["Paint Purchase"].localPosition;
			paintLockedTransitionTimer = 0.25f;
			lockedMenuIsOut = !lockedMenuIsOut;
			PressedClosePaint();
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedOkPaint token 0x060005f6 @0x00121cf8
	public void PressedOkPaint()
	{
		CartSlot cartSlot = PlayerInstance.GetCartSlot(currentSlot);
		ResetPaintInSlot(cartSlot);
		SoundLibrary.ButtonClickPlay("menuButton1");
		paintLockedTransitionStart = base.transforms["Paint Purchase"].localPosition;
		paintLockedTransitionTimer = 0.25f;
		lockedMenuIsOut = !lockedMenuIsOut;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OpenBuyPaint token 0x060005f7 @0x00121dc8
	public void OpenBuyPaint()
	{
		CartSlot cartSlot = PlayerInstance.GetCartSlot(currentSlot);
		if (cartSlot != null)
		{
			CartPart partInSlot = cartSlot.partInSlot;
			if (partInSlot == null)
			{
				UnityEngine.Debug.LogWarning("Part in slot was null!!");
				return;
			}
			if (partInSlot.cost != 0 && !DataUtility.Instance.IsUnlocked(partInSlot.UIName.baseText))
			{
				base.ughTexts["PaintMessage"].Text = Localize.Get("You don't own this part. Therefore, you can't buy this paint.");
				base.ughButtons["Buy Paint"].gameObject.SetActive(false);
			}
			else
			{
				base.ughTexts["PaintMessage"].Text = paintList[viewingPaintIndex].name;
				base.ughTexts["Paint Cost"].Text = paintList[viewingPaintIndex].cost.ToString();
				base.ughButtons["Buy Paint"].gameObject.SetActive(true);
				base.ughTexts["PaintCancel"].Text = Localize.Get("No");
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("Part Slot Was null!!");
		}
		paintLockedTransitionStart = base.transforms["Paint Purchase"].localPosition;
		paintLockedTransitionTimer = 0.25f;
		lockedMenuIsOut = !lockedMenuIsOut;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OpenPaintIsLocked token 0x060005f8 @0x001220ec
	public void OpenPaintIsLocked()
	{
		base.ughTexts["PaintMessage"].Text = Localize.Get("This paint is currently locked. You will have to do something to unlock it.");
		base.ughButtons["Buy Paint"].gameObject.SetActive(false);
		paintLockedTransitionStart = base.transforms["Paint Purchase"].localPosition;
		paintLockedTransitionTimer = 0.25f;
		lockedMenuIsOut = !lockedMenuIsOut;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::RefreshToggles token 0x060005f9 @0x0012221c
	// ADAPTADO-U6: Transform.FindChild -> Find.
	private void RefreshToggles()
	{
		Transform transform = base.transform.Find("Slots");
		if (transform != null)
		{
			UghToggle[] componentsInChildren = transform.gameObject.GetComponentsInChildren<UghToggle>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].HighlightState = componentsInChildren[i].name.ToLower().Contains(currentSlot.ToString().ToLower());
			}
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::RefreshFormToggles token 0x060005fa @0x00122390
	// ADAPTADO-U6: Transform.FindChild -> Find.
	private void RefreshFormToggles()
	{
		bool flag = currentSlot == CartSlot.Slots.body;
		if (isShowingBodyBox != flag)
		{
			StartCoroutine(SlideBodyFormBox(flag));
		}
		AlternateForm.BodyForm bodyForm = AlternateForm.BodyForm.Normal;
		CartSlot cartSlot = PlayerInstance.GetCartSlot(CartSlot.Slots.body);
		if (cartSlot.partInSlot != null && cartSlot.partInSlot.alternateForms != null)
		{
			bodyForm = cartSlot.partInSlot.alternateForms.GetBodyForm(cartSlot.partInSlot);
		}
		Transform transform = base.transform.Find("BodyTypes");
		if (!(transform != null))
		{
			return;
		}
		string text = "Trike";
		if (bodyForm == AlternateForm.BodyForm.MonsterTruck)
		{
			text = "Truck";
		}
		else if (bodyForm == AlternateForm.BodyForm.Bike)
		{
			text = "Bike";
		}
		UghToggle[] componentsInChildren = transform.gameObject.GetComponentsInChildren<UghToggle>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].HighlightState = componentsInChildren[i].name.ToLower().Contains(text.ToLower());
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::SlideBodyFormBox token 0x060005fb @0x001225b8
	// RECUPERADO-AOT CartCustomizerPublisher/<SlideBodyFormBox>c__Iterator51::MoveNext token 0x060009ba @0x00152650
	[DebuggerHidden]
	private IEnumerator SlideBodyFormBox(bool inOut)
	{
		while (isBodyBoxAnimating)
		{
			yield return null;
		}
		isBodyBoxAnimating = true;
		isShowingBodyBox = inOut;
		Transform bodyBox = base.transforms["Body Type Box"];
		bodyBox.gameObject.SetActive(true);
		Vector3 endPos = bodyBox.localPosition;
		Vector3 startPos = endPos - Vector3.down * 2f;
		float duration = 0.25f;
		float frequency = 1f / 60f;
		for (float t = 0f; t < duration; t += frequency)
		{
			float sequence = t / duration;
			if (!inOut)
			{
				sequence = 1f - sequence;
			}
			bodyBox.localPosition = Vector3x.Sinerp(startPos, endPos, sequence);
			yield return new WaitForSeconds(frequency);
		}
		bodyBox.localPosition = endPos;
		bodyBox.gameObject.SetActive(inOut);
		isBodyBoxAnimating = false;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::RefreshNavBlips token 0x060005fc @0x00122610
	// ADAPTADO-U6: GameObject.renderer -> GetComponent<Renderer>().
	private void RefreshNavBlips()
	{
		foreach (GameObject navBlip in navBlipList)
		{
			UnityEngine.Object.Destroy(navBlip);
		}
		navBlipList.Clear();
		if (partList == null || partList.Length < 1)
		{
			return;
		}
		CartPart[] array = partList;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].AreAllAlternateFormsLocked)
			{
				navBlipList.Add(Script.Instantiate(lockedNavBlipPrefab));
			}
			else
			{
				navBlipList.Add(Script.Instantiate(ownedNavBlipPrefab));
			}
		}
		Transform parent = base.transforms["Nav Blip Anchor"];
		float x = navBlipList[0].GetComponent<Renderer>().bounds.size.x;
		float num = 0.25f;
		float num2 = x * (float)navBlipList.Count + num * (float)(navBlipList.Count - 1);
		float num3 = num2 / -2f;
		foreach (GameObject navBlip2 in navBlipList)
		{
			Vector3 localPosition = new Vector3(num3, 0f, 0f);
			navBlip2.transform.parent = parent;
			navBlip2.transform.localPosition = localPosition;
			num3 += x + num;
		}
		base.transforms["Nav Index"].localPosition = navBlipList[viewingIndex].transform.localPosition + new Vector3(0f, 0f, 0.1f);
	}

	// RECUPERADO-AOT CartCustomizerPublisher::RefreshDisplay token 0x060005fd @0x00122cb4
	// Note (original): the "next part" used for the right arrow is read at viewingIndex, not viewingIndex + 1, and the
	// final alternate-forms length check has no effect.
	private void RefreshDisplay()
	{
		RefreshToggles();
		RefreshNavBlips();
		CartPart partInSlot = PlayerInstance.GetCartSlot(currentSlot).partInSlot;
		if (partInSlot == null || previousPart == null)
		{
			return;
		}
		RefreshStatBars(partInSlot, previousPart);
		base.ughTexts["Object Name"].Text = partInSlot.UIName.Text;
		if (partInSlot.UIName.baseText == previousPart.UIName.baseText)
		{
			PaintJob slotPaint = PlayerInstance.GetCartSlot(currentSlot).slotPaint;
			if ((slotPaint == null || slotPaint.multilayerTexture.layers.Length > 0) && currentSlot != CartSlot.Slots.wheels)
			{
				base.ughButtons["Action Button"].gameObject.SetActive(true);
				base.ughTexts["Action Label"].Text = Localize.Get("Paint");
			}
			else
			{
				base.ughButtons["Action Button"].gameObject.SetActive(false);
				base.ughTexts["Action Label"].Text = string.Empty;
			}
			base.transforms["Cost Box"].gameObject.SetActive(false);
			base.transforms["Equipped"].gameObject.SetActive(true);
			base.ughTexts["Equipped"].Text = Localize.Get("Using");
			base.transforms["Preview Text"].gameObject.SetActive(false);
		}
		else
		{
			base.transforms["Cost Box"].gameObject.SetActive(true);
			base.transforms["Equipped"].gameObject.SetActive(false);
			base.transforms["Preview Text"].gameObject.SetActive(true);
			if (!partInSlot.IsLocked)
			{
				base.ughButtons["Action Button"].gameObject.SetActive(true);
				base.ughTexts["Action Label"].Text = Localize.Get("Use");
				base.transforms["Cost Box"].gameObject.SetActive(false);
				base.transforms["Equipped"].gameObject.SetActive(true);
				base.ughTexts["Equipped"].Text = Localize.Get("Own");
			}
			else if (partInSlot.cost > 0)
			{
				base.ughButtons["Action Button"].gameObject.SetActive(true);
				base.ughTexts["Action Label"].Text = Localize.Get("Buy");
				base.ughTexts["Cost"].Text = partInSlot.cost.ToString();
			}
			else
			{
				base.ughButtons["Action Button"].gameObject.SetActive(false);
				base.ughTexts["Action Label"].Text = string.Empty;
				base.transforms["Equipped"].gameObject.SetActive(true);
				base.ughTexts["Equipped"].Text = Localize.Get("Locked");
			}
		}
		CartPart cartPart = ((viewingIndex + 1 >= partList.Length) ? null : partList[viewingIndex]);
		if (cartPart == null)
		{
			base.ughButtons["Right Arrow"].gameObject.SetActive(false);
			base.transforms["Right Arrow Lock"].gameObject.SetActive(false);
		}
		else if (partInSlot.AreAllAlternateFormsLocked && cartPart.AreAllAlternateFormsLocked)
		{
			base.ughButtons["Right Arrow"].gameObject.SetActive(true);
			base.transforms["Right Arrow Lock"].gameObject.SetActive(true);
		}
		else
		{
			base.ughButtons["Right Arrow"].gameObject.SetActive(true);
			base.transforms["Right Arrow Lock"].gameObject.SetActive(false);
		}
		if (viewingIndex <= 0)
		{
			base.ughButtons["Left Arrow"].gameObject.SetActive(false);
		}
		else
		{
			base.ughButtons["Left Arrow"].gameObject.SetActive(true);
		}
		if (currentSlot == CartSlot.Slots.body && partInSlot.alternateForms != null && partInSlot.alternateForms.forms.Length > 1)
		{
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::InitialWaitForLoadCoroutine token 0x060005fe @0x001236ac
	// RECUPERADO-AOT CartCustomizerPublisher/<InitialWaitForLoadCoroutine>c__Iterator52::MoveNext token 0x060009c0 @0x00152b34
	// Opens on the body slot and previews the most expensive part the player can afford.
	[DebuggerHidden]
	private IEnumerator InitialWaitForLoadCoroutine()
	{
		while (PreviewCart.IsLoading)
		{
			yield return new WaitForSeconds(0.25f);
		}
		currentSlot = CartSlot.Slots.character;
		SwitchSlot(CartSlot.Slots.body);
		CartPart newPart = CartPartList.GetMostExpensiveUnlockableAffordablePart(DataUtility.Instance.cloudData.playerMoney);
		if (newPart != null)
		{
			SetToSpecificPart(newPart.GetAlternatePartOfForm(PlayerInstance.GetCartSlot(CartSlot.Slots.body).partInSlot.bodyFormType));
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::Start token 0x060005ff @0x001236f4
	// RECUPERADO-AOT CartCustomizerPublisher/<Start>c__Iterator53::MoveNext token 0x060009c6 @0x00152da8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	[DebuggerHidden]
	private IEnumerator Start()
	{
		base.ughButtons["Up Arrow"].gameObject.SetActive(false);
		base.ughButtons["Down Arrow"].gameObject.SetActive(false);
		ShiftUIPublisher shifter = U4Compat.FindObjectOfType<ShiftUIPublisher>();
		if (shifter != null)
		{
			shifter.Show(false);
		}
		UghToggle bodyToggle = base.transforms["Body Toggle"].GetComponent<UghToggle>();
		bodyToggle.State = true;
		bodyToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(bodyToggle.OnChanged, new Action<UghToggle>(OnBodyToggleChanged));
		UghToggle scoopToggle = base.transforms["Scoop Toggle"].GetComponent<UghToggle>();
		scoopToggle.State = false;
		scoopToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(scoopToggle.OnChanged, new Action<UghToggle>(OnScoopToggleChanged));
		UghToggle spoilerToggle = base.transforms["Spoiler Toggle"].GetComponent<UghToggle>();
		spoilerToggle.State = false;
		spoilerToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(spoilerToggle.OnChanged, new Action<UghToggle>(OnSpoilerToggleChanged));
		UghToggle thrusterToggle = base.transforms["Thruster Toggle"].GetComponent<UghToggle>();
		thrusterToggle.State = false;
		thrusterToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(thrusterToggle.OnChanged, new Action<UghToggle>(OnThrusterToggleChanged));
		UghToggle wheelToggle = base.transforms["Wheel Toggle"].GetComponent<UghToggle>();
		wheelToggle.State = false;
		wheelToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(wheelToggle.OnChanged, new Action<UghToggle>(OnWheelToggleChanged));
		UghToggle bikeToggle = base.transforms["Bike Toggle"].GetComponent<UghToggle>();
		bikeToggle.State = false;
		bikeToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(bikeToggle.OnChanged, new Action<UghToggle>(OnBikeToggleChanged));
		UghToggle trikeToggle = base.transforms["Trike Toggle"].GetComponent<UghToggle>();
		trikeToggle.State = false;
		trikeToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(trikeToggle.OnChanged, new Action<UghToggle>(OnTrikeToggleChanged));
		UghToggle truckToggle = base.transforms["Truck Toggle"].GetComponent<UghToggle>();
		truckToggle.State = false;
		truckToggle.OnChanged = (Action<UghToggle>)Delegate.Combine(truckToggle.OnChanged, new Action<UghToggle>(OnTruckToggleChanged));
		menuCamera = U4Compat.FindObjectOfType(typeof(FrontEndCamera)) as FrontEndCamera;
		float slotsScale = (UghCamera.Instance.ScreenSize.x - 3.5f) / 10.95f;
		base.transforms["Slots"].localScale = base.transforms["Slots"].localScale * slotsScale;
		StartCoroutine(InitialWaitForLoadCoroutine());
		yield return null;
		base.transforms["Stat Box"].GetComponent<UghAlign>().Align();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::Update token 0x06000600 @0x0012373c
	// Coin counter and the slide-in / slide-out of the paint menu and the paint purchase box.
	private void Update()
	{
		float num = 0f;
		float num2 = 0f;
		num = DataUtility.Instance.cloudData.playerMoney;
		if (num > 999999f)
		{
			num2 = num / 1000000f;
			base.ughTexts["Coins"].Text = num2.ToString("F1") + Localize.Get(" M");
		}
		else
		{
			base.ughTexts["Coins"].Text = num.ToString();
		}
		if (paintMenuTransitionTimer > 0f)
		{
			paintMenuTransitionTimer -= Time.deltaTime;
			if (paintMenuTransitionTimer < 0f)
			{
				paintMenuTransitionTimer = 0f;
			}
			float value = paintMenuTransitionTimer / 0.25f;
			Vector3 localPosition = ((!paintMenuIsOut) ? Vector3x.Sinerp(new Vector3(3.72f, -1.789f, -1f), paintMenuTransitionStart, value) : Vector3x.Coserp(new Vector3(-3.72f, -1.789f, -1f), paintMenuTransitionStart, value));
			base.transforms["Paint Menu"].localPosition = localPosition;
		}
		if (paintLockedTransitionTimer > 0f)
		{
			paintLockedTransitionTimer -= Time.deltaTime;
			if (paintLockedTransitionTimer < 0f)
			{
				paintLockedTransitionTimer = 0f;
			}
			float value2 = paintLockedTransitionTimer / 0.25f;
			Vector3 localPosition2 = ((!lockedMenuIsOut) ? Vector3x.Sinerp(new Vector3(3.72f, -1.789f, paintLockedTransitionStart.z), paintLockedTransitionStart, value2) : Vector3x.Coserp(new Vector3(-3.72f, -1.789f, paintLockedTransitionStart.z), paintLockedTransitionStart, value2));
			base.transforms["Paint Purchase"].localPosition = localPosition2;
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedBodySlot token 0x06000601 @0x00123ea4
	private void PressedBodySlot()
	{
		SwitchSlot(CartSlot.Slots.body);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedScoopSlot token 0x06000602 @0x00123ef0
	private void PressedScoopSlot()
	{
		SwitchSlot(CartSlot.Slots.scoop);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedSpoilerSlot token 0x06000603 @0x00123f3c
	private void PressedSpoilerSlot()
	{
		SwitchSlot(CartSlot.Slots.spoiler);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedThrusterSlot token 0x06000604 @0x00123f88
	private void PressedThrusterSlot()
	{
		SwitchSlot(CartSlot.Slots.thrusters);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedWheelsSlot token 0x06000605 @0x00123fd4
	private void PressedWheelsSlot()
	{
		SwitchSlot(CartSlot.Slots.wheels);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedBikeForm token 0x06000606 @0x00124020
	private void PressedBikeForm()
	{
		SwitchFormType(AlternateForm.BodyForm.Bike);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedTrikeForm token 0x06000607 @0x0012406c
	private void PressedTrikeForm()
	{
		SwitchFormType(AlternateForm.BodyForm.Normal);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedTruckForm token 0x06000608 @0x001240b8
	private void PressedTruckForm()
	{
		SwitchFormType(AlternateForm.BodyForm.MonsterTruck);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedRightArrow token 0x06000609 @0x00124104
	// Note (original): the "next part" is read at viewingIndex, not viewingIndex + 1 (see RefreshDisplay).
	private void PressedRightArrow()
	{
		if (paintMenuIsOut)
		{
			PressedClosePaint();
		}
		SoundLibrary.ButtonClickPlay("menuButton1");
		if (PreviewCart.IsLoading)
		{
			return;
		}
		CartPart cartPart = partList[viewingIndex];
		CartPart cartPart2 = ((viewingIndex + 1 >= partList.Length) ? null : partList[viewingIndex]);
		if (cartPart2 != null && cartPart.AreAllAlternateFormsLocked && cartPart2.AreAllAlternateFormsLocked)
		{
			return;
		}
		CartSlot cartSlot = PlayerInstance.Instance.cartSlots[(int)currentSlot];
		AlternateForm.BodyForm form = AlternateForm.BodyForm.Normal;
		if (cartSlot.partInSlot != null && cartSlot.partInSlot.alternateForms != null)
		{
			form = cartSlot.partInSlot.alternateForms.GetBodyForm(cartSlot.partInSlot);
		}
		viewingIndex++;
		if (viewingIndex >= partList.Length)
		{
			viewingIndex = 0;
		}
		CartPart cartPart3 = partList[viewingIndex];
		if (cartPart3.alternateForms != null)
		{
			cartPart3 = cartPart3.alternateForms.FindFirstWithForm(form);
		}
		cartSlot.partInSlot = cartPart3;
		paintList = cartPart3.validPaintJobs;
		if (paintList != null && paintList.Length > 0)
		{
			viewingPaintIndex = 0;
			if (cartSlot.partInSlot == previousPart)
			{
				cartSlot.slotPaint = previousPaint;
			}
			else
			{
				cartSlot.slotPaint = paintList[0];
			}
		}
		else
		{
			viewingPaintIndex = -1;
		}
		PreviewCart.SetSlotTransparent(cartSlot.slot, cartSlot.partInSlot != previousPart);
		PlayerInstance.MatchAlternateForms();
		PreviewCart.GenerateCartPreview();
		RefreshDisplay();
		PopulatePaintMenu();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedLeftArrow token 0x0600060a @0x001243bc
	private void PressedLeftArrow()
	{
		if (paintMenuIsOut)
		{
			PressedClosePaint();
		}
		SoundLibrary.ButtonClickPlay("menuButton1");
		if (PreviewCart.IsLoading)
		{
			return;
		}
		viewingIndex--;
		if (viewingIndex < 0)
		{
			viewingIndex = partList.Length - 1;
		}
		CartSlot cartSlot = PlayerInstance.Instance.cartSlots[(int)currentSlot];
		AlternateForm.BodyForm form = AlternateForm.BodyForm.Normal;
		if (cartSlot.partInSlot != null && cartSlot.partInSlot.alternateForms != null)
		{
			form = cartSlot.partInSlot.alternateForms.GetBodyForm(cartSlot.partInSlot);
		}
		CartPart cartPart = partList[viewingIndex];
		if (cartPart.alternateForms != null)
		{
			cartPart = cartPart.alternateForms.FindFirstWithForm(form);
		}
		cartSlot.partInSlot = cartPart;
		paintList = cartPart.validPaintJobs;
		if (paintList != null && paintList.Length > 0)
		{
			viewingPaintIndex = 0;
			if (cartSlot.partInSlot == previousPart)
			{
				cartSlot.slotPaint = previousPaint;
			}
			else
			{
				cartSlot.slotPaint = paintList[0];
			}
		}
		else
		{
			viewingPaintIndex = -1;
		}
		PreviewCart.SetSlotTransparent(cartSlot.slot, cartSlot.partInSlot != previousPart);
		PlayerInstance.MatchAlternateForms();
		PreviewCart.GenerateCartPreview();
		RefreshDisplay();
		PopulatePaintMenu();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedUpArrow token 0x0600060b @0x001245c0
	// RECUPERADO-AOT CartCustomizerPublisher/<PressedUpArrow>c__AnonStorey9E::<>m__21 token 0x06000b50 @0x00166cfc
	// Cycles the previewed part to its next alternate body form.
	private void PressedUpArrow()
	{
		if (paintMenuIsOut)
		{
			PressedClosePaint();
		}
		SoundLibrary.ButtonClickPlay("menuButton1");
		if (PreviewCart.IsLoading)
		{
			return;
		}
		CartPart indexedPart = partList[viewingIndex];
		if (indexedPart.alternateForms == null)
		{
			return;
		}
		int num = Array.FindIndex(indexedPart.alternateForms.forms, (AlternateForm.FormData obj) => obj.part.UIName == indexedPart.UIName) + 1;
		if (num >= indexedPart.alternateForms.forms.Length)
		{
			num = 0;
		}
		CartPart part = indexedPart.alternateForms.forms[num].part;
		CartSlot cartSlot = PlayerInstance.Instance.cartSlots[(int)currentSlot];
		cartSlot.partInSlot = part;
		paintList = part.validPaintJobs;
		if (paintList != null && paintList.Length > 0)
		{
			viewingPaintIndex = 0;
			if (cartSlot.partInSlot == previousPart)
			{
				cartSlot.slotPaint = previousPaint;
			}
			else
			{
				cartSlot.slotPaint = paintList[0];
			}
		}
		else
		{
			viewingPaintIndex = -1;
		}
		PreviewCart.SetSlotTransparent(cartSlot.slot, cartSlot.partInSlot != previousPart);
		PlayerInstance.MatchAlternateForms();
		PreviewCart.GenerateCartPreview();
		RefreshDisplay();
		PopulatePaintMenu();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedDownArrow token 0x0600060c @0x00124844
	// RECUPERADO-AOT CartCustomizerPublisher/<PressedDownArrow>c__AnonStorey9F::<>m__22 token 0x06000b52 @0x00166d7c
	// Cycles the previewed part to its previous alternate body form.
	private void PressedDownArrow()
	{
		if (paintMenuIsOut)
		{
			PressedClosePaint();
		}
		SoundLibrary.ButtonClickPlay("menuButton1");
		if (PreviewCart.IsLoading)
		{
			return;
		}
		CartPart indexedPart = partList[viewingIndex];
		if (indexedPart.alternateForms == null)
		{
			return;
		}
		int num = Array.FindIndex(indexedPart.alternateForms.forms, (AlternateForm.FormData obj) => obj.part.UIName == indexedPart.UIName) - 1;
		if (num < 0)
		{
			num = indexedPart.alternateForms.forms.Length - 1;
		}
		CartPart part = indexedPart.alternateForms.forms[num].part;
		CartSlot cartSlot = PlayerInstance.Instance.cartSlots[(int)currentSlot];
		cartSlot.partInSlot = part;
		paintList = part.validPaintJobs;
		if (paintList != null && paintList.Length > 0)
		{
			viewingPaintIndex = 0;
			if (cartSlot.partInSlot == previousPart)
			{
				cartSlot.slotPaint = previousPaint;
			}
			else
			{
				cartSlot.slotPaint = paintList[0];
			}
		}
		else
		{
			viewingPaintIndex = -1;
		}
		PreviewCart.SetSlotTransparent(cartSlot.slot, cartSlot.partInSlot != previousPart);
		PlayerInstance.MatchAlternateForms();
		PreviewCart.GenerateCartPreview();
		RefreshDisplay();
		PopulatePaintMenu();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedAction token 0x0600060d @0x00124ac8
	// Paint (equipped part), Use (owned part) or Buy (and then equip).
	private void PressedAction()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		CartPart partInSlot = PlayerInstance.GetCartSlot(currentSlot).partInSlot;
		if (partInSlot == previousPart)
		{
			PressedPaint();
		}
		else if (!partInSlot.IsLocked || partInSlot.cost == 0)
		{
			EquipPart(partInSlot);
		}
		else if (BuyPart(partInSlot))
		{
			EquipPart(partInSlot);
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::BuyPart token 0x0600060e @0x00124b80
	// ELIMINADO (analitica): after a purchase the original sent GDMOManager.SendWithContext("in_app_currency_action",
	// {player_id, currency: "coins", amount: -cost, item: {item_id, item_count: 1}, type: "cart part",
	// subtype: cartSlot, level: 0, balance}).
	private bool BuyPart(CartPart selectedPart)
	{
		if (DataUtility.Instance.BuyItem(selectedPart.UIName.baseText, selectedPart.cost))
		{
			SoundLibrary.ButtonClickPlay("buyPart");
			return true;
		}
		return false;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::EquipPart token 0x0600060f @0x00124efc
	// ELIMINADO (analitica): the original sent GDMOManager.SendWithContext("game_action",
	// {player_id, context: "UI", action: "equip", type: part name}) before the equip sound.
	private void EquipPart(CartPart selectedPart)
	{
		previousPart = selectedPart;
		DataUtility.Instance.SetCartPart(selectedPart.cartSlot, selectedPart.UIName.baseText);
		DataUtility.Instance.SetCartPaint(selectedPart.cartSlot, selectedPart.validPaintJobs[viewingPaintIndex].name);
		previousPaint = selectedPart.validPaintJobs[viewingPaintIndex];
		RefreshDisplay();
		DataUtility.Instance.Save();
		PreviewCart.SetSlotTransparent(selectedPart.cartSlot, false);
		PreviewCart.GenerateCartPreview();
		SoundLibrary.ButtonClickPlay("Part Equip " + UnityEngine.Random.Range(0, 3).ToString());
		Script.Instantiate(poofPrefab, base.transforms["Poof Anchor"].position, Quaternion.identity);
	}

	// RECUPERADO-AOT CartCustomizerPublisher::CloseLockedMenu token 0x06000610 @0x001251e8
	private void CloseLockedMenu()
	{
		paintLockedTransitionStart = base.transforms["Paint Purchase"].localPosition;
		paintLockedTransitionTimer = 0.25f;
		lockedMenuIsOut = false;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedPaint token 0x06000611 @0x00125284
	private void PressedPaint()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		if (!PreviewCart.IsLoading)
		{
			PaintJob slotPaint = PlayerInstance.GetCartSlot(currentSlot).slotPaint;
			if ((!(slotPaint != null) || slotPaint.multilayerTexture.layers.Length > 0) && currentSlot != CartSlot.Slots.wheels)
			{
				paintMenuTransitionStart = base.transforms["Paint Menu"].localPosition;
				paintMenuTransitionTimer = 0.25f;
				paintMenuIsOut = !paintMenuIsOut;
			}
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::PressedClosePaint token 0x06000612 @0x0012538c
	private void PressedClosePaint()
	{
		if (lockedMenuIsOut)
		{
			CloseLockedMenu();
		}
		SoundLibrary.ButtonClickPlay("menuButton1");
		paintMenuTransitionStart = base.transforms["Paint Menu"].localPosition;
		paintMenuTransitionTimer = 0.25f;
		paintMenuIsOut = !paintMenuIsOut;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnDisable token 0x06000613 @0x0012545c
	private void OnDisable()
	{
		ResetPreviewSlot();
		PreviewCart.ClearnTransparencies();
		PreviewCart.GenerateCartPreview();
		if (DataUtility.Exists)
		{
			DataUtility.Instance.Save();
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::Refresh token 0x06000614 @0x001254b4
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void Refresh()
	{
		CartCustomizerPublisher cartCustomizerPublisher = (CartCustomizerPublisher)U4Compat.FindObjectOfType(typeof(CartCustomizerPublisher));
		if (cartCustomizerPublisher != null)
		{
			cartCustomizerPublisher.RefreshDisplay();
		}
	}

	// RECUPERADO-AOT CartCustomizerPublisher::SetViewingPaintIndex token 0x06000615 @0x00125560
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	// Previews the paint; applies it right away when the part is the equipped one and the paint is free or owned.
	public static void SetViewingPaintIndex(int index)
	{
		CartCustomizerPublisher cartCustomizerPublisher = (CartCustomizerPublisher)U4Compat.FindObjectOfType(typeof(CartCustomizerPublisher));
		if (cartCustomizerPublisher == null || PreviewCart.IsLoading || cartCustomizerPublisher.viewingPaintIndex == -1 || cartCustomizerPublisher.paintList == null || cartCustomizerPublisher.paintList.Length == 0)
		{
			return;
		}
		cartCustomizerPublisher.viewingPaintIndex = index;
		PaintJob paintJob = cartCustomizerPublisher.paintList[cartCustomizerPublisher.viewingPaintIndex];
		PlayerInstance.GetCartSlot(cartCustomizerPublisher.currentSlot).slotPaint = paintJob;
		if (cartCustomizerPublisher.previousPart != null && cartCustomizerPublisher.previousPart.UIName.baseText == PlayerInstance.GetCartSlot(cartCustomizerPublisher.currentSlot).partInSlot.UIName.baseText && (DataUtility.Instance.IsUnlocked(paintJob.name) || paintJob.cost == 0))
		{
			DataUtility.Instance.SetCartPaint(cartCustomizerPublisher.currentSlot, paintJob.name);
			cartCustomizerPublisher.previousPaint = paintJob;
			cartCustomizerPublisher.PressedClosePaint();
		}
		PreviewCart.GenerateCartPreview();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::IsTemporaryInSlot token 0x06000616 @0x00125758
	// True while the customizer previews, in that slot, a part other than the one the player owns there.
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static bool IsTemporaryInSlot(CartSlot.Slots slot)
	{
		CartCustomizerPublisher cartCustomizerPublisher = (CartCustomizerPublisher)U4Compat.FindObjectOfType(typeof(CartCustomizerPublisher));
		if (cartCustomizerPublisher == null || cartCustomizerPublisher.currentSlot != slot || cartCustomizerPublisher.viewingIndex == -1)
		{
			return false;
		}
		CartPart cartPart = cartCustomizerPublisher.partList[cartCustomizerPublisher.viewingIndex];
		return cartPart.UIName.baseText != cartCustomizerPublisher.previousPart.UIName.baseText;
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnBodyToggleChanged token 0x06000617 @0x00125878
	private void OnBodyToggleChanged(UghToggle toggle)
	{
		PressedBodySlot();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnScoopToggleChanged token 0x06000618 @0x001258b0
	private void OnScoopToggleChanged(UghToggle toggle)
	{
		PressedScoopSlot();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnSpoilerToggleChanged token 0x06000619 @0x001258e8
	private void OnSpoilerToggleChanged(UghToggle toggle)
	{
		PressedSpoilerSlot();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnThrusterToggleChanged token 0x0600061a @0x00125920
	private void OnThrusterToggleChanged(UghToggle toggle)
	{
		PressedThrusterSlot();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnWheelToggleChanged token 0x0600061b @0x00125958
	private void OnWheelToggleChanged(UghToggle toggle)
	{
		PressedWheelsSlot();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnBikeToggleChanged token 0x0600061c @0x00125990
	private void OnBikeToggleChanged(UghToggle toggle)
	{
		PressedBikeForm();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnTrikeToggleChanged token 0x0600061d @0x001259c8
	private void OnTrikeToggleChanged(UghToggle toggle)
	{
		PressedTrikeForm();
	}

	// RECUPERADO-AOT CartCustomizerPublisher::OnTruckToggleChanged token 0x0600061e @0x00125a00
	private void OnTruckToggleChanged(UghToggle toggle)
	{
		PressedTruckForm();
	}
}
