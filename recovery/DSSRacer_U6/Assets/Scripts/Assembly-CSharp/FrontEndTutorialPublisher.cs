using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Menu tutorial tip: speech bubble + pulsing arrow pointing at a control; while it is up only the target
// controls (or any touch) are allowed, and pressing them dismisses the tip.
// Source listing: recovery/aot_listings/Assembly-CSharp/FrontEndTutorialPublisher.txt
public class FrontEndTutorialPublisher : UghPublisher
{
	private Transform anchor;

	// RECUPERADO-AOT FrontEndTutorialPublisher::.ctor token 0x06000681 @0x0012c3f8 (field initializers)
	private Vector3 anchorTarget = Vector3.zero;

	private UghControl[] targetControls;

	public bool anyTouchDismissesTutorialStep = true;

	public GameObject inputBlockerPrefab;

	// RECUPERADO-AOT FrontEndTutorialPublisher::PulseArrowCoroutine token 0x06000682 @0x0012c458
	// RECUPERADO-AOT FrontEndTutorialPublisher/<PulseArrowCoroutine>c__Iterator5A::MoveNext token 0x060009f0 @0x00154bb8
	[DebuggerHidden]
	private IEnumerator PulseArrowCoroutine()
	{
		Vector3 originScale = base.transforms["Arrow"].localScale;
		while (true)
		{
			for (float scale = 1f; scale >= 0.5f; scale -= Time.deltaTime * 2f)
			{
				base.transforms["Arrow"].localScale = originScale * scale;
				yield return new WaitForSeconds(Time.deltaTime);
			}
			yield return new WaitForSeconds(Time.deltaTime);
			for (float scale2 = 0.5f; scale2 <= 1f; scale2 += Time.deltaTime * 2f)
			{
				base.transforms["Arrow"].localScale = originScale * scale2;
				yield return new WaitForSeconds(Time.deltaTime);
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::FadeInCoroutine token 0x06000683 @0x0012c4a0
	// RECUPERADO-AOT FrontEndTutorialPublisher/<FadeInCoroutine>c__Iterator5B::MoveNext token 0x060009f6 @0x001550cc
	[DebuggerHidden]
	private IEnumerator FadeInCoroutine()
	{
		Renderer[] renderList = GetComponentsInChildren<Renderer>();
		for (float alpha = 0f; alpha <= 1f; alpha += 0.05f)
		{
			Renderer[] array = renderList;
			foreach (Renderer r in array)
			{
				if (r.material != null && !r.material.name.Contains("Invisible"))
				{
					Color newColor = r.material.color;
					newColor.a = alpha;
					r.material.color = newColor;
				}
			}
			yield return new WaitForSeconds(1f / 60f);
		}
		Renderer[] array2 = renderList;
		foreach (Renderer r2 in array2)
		{
			if (r2.material != null && !r2.material.name.Contains("Invisible"))
			{
				Color newColor2 = r2.material.color;
				newColor2.a = 1f;
				r2.material.color = newColor2;
			}
		}
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::Resize token 0x06000684 @0x0012c4e8
	// ADAPTADO-U6: Component.renderer / .camera -> GetComponent<Renderer>() / GetComponent<Camera>().
	// Shrinks the text until it fits (14 units wide), sizes the backing to it, keeps the bubble on screen and
	// puts it above or below the target with the arrow pointing at it.
	private void Resize()
	{
		Vector3 size = base.ughTexts["Text"].GetComponent<Renderer>().bounds.size;
		float characterSize = base.ughTexts["Text"].GetComponent<TextMesh>().characterSize;
		while (size.x > 14f)
		{
			characterSize *= 0.9f;
			if (characterSize < 0.01f)
			{
				break;
			}
			TextMesh[] componentsInChildren = base.ughTexts["Text"].GetComponentsInChildren<TextMesh>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].characterSize = characterSize;
			}
			size = base.ughTexts["Text"].GetComponent<Renderer>().bounds.size;
		}
		base.transform.position = anchorTarget;
		float x = UghCamera.Instance.CameraPixelSize.x;
		Vector3 localScale = base.ughButtons["Backing"].transform.localScale;
		localScale.x = size.x / 1.58f;
		base.ughButtons["Backing"].transform.localScale = localScale;
		base.ughButtons["Backing"].UpdateMesh();
		Camera component = UghCamera.Instance.GetComponent<Camera>();
		Vector3 vector = component.WorldToScreenPoint(base.ughButtons["Backing"].GetComponent<Renderer>().bounds.max);
		if (vector.x > x)
		{
			Vector3 position = UghCamera.Instance.GetComponent<Camera>().WorldToScreenPoint(base.transform.position);
			position.x -= vector.x - x;
			Vector3 position2 = UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(position);
			position2.z = base.transform.position.z;
			base.transform.position = position2;
		}
		if (base.transform.position.y > 0f)
		{
			Vector3 position3 = base.transform.position;
			position3.y -= 3.25f;
			base.transform.position = position3;
		}
		else
		{
			Vector3 position4 = base.transform.position;
			position4.y += 3.25f;
			base.transform.position = position4;
		}
		Vector3 position5 = base.transforms["Arrow"].transform.position;
		position5.x = anchorTarget.x;
		position5.y = anchorTarget.y;
		base.transforms["Arrow"].transform.position = position5;
		if (anchorTarget.y > 0f)
		{
			base.transforms["Arrow"].rotation = Quaternion.Euler(0f, 0f, 90f);
		}
		else
		{
			base.transforms["Arrow"].rotation = Quaternion.Euler(0f, 0f, -90f);
		}
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::RegisterControlListeners token 0x06000685 @0x0012cf98
	// ELIMINADO (servicio iOS): DebugMoreCoinsPublisher.AddButtonsToLegalControls() added the coin-store pop-up's
	// buttons to the legal controls when that pop-up was open; the coin store (StoreKit) is gone.
	private void RegisterControlListeners()
	{
		if (targetControls == null && !anyTouchDismissesTutorialStep)
		{
			return;
		}
		if (anyTouchDismissesTutorialStep)
		{
			UghControl.theOnlyLegalControls = new UghControl[2]
			{
				base.ughButtons["Backing"],
				base.ughButtons["InputBlocker"]
			};
			return;
		}
		List<UghControl> list = new List<UghControl>(targetControls);
		if (ShiftUIPublisher.shifterButtons[0] != null)
		{
			UghControl[] array = new UghControl[ShiftUIPublisher.shifterButtons.Length];
			for (int i = 0; i < ShiftUIPublisher.shifterButtons.Length; i++)
			{
				array[i] = ShiftUIPublisher.shifterButtons[i];
			}
			list.AddRange(array);
		}
		list.Add(base.ughButtons["Backing"]);
		UghControl.theOnlyLegalControls = list.ToArray();
		for (int j = 0; j < targetControls.Length; j++)
		{
			if (targetControls[j] is UghButton)
			{
				UghButton ughButton = (UghButton)targetControls[j];
				ughButton.OnPressed = (System.Action<UghButton>)System.Delegate.Combine(ughButton.OnPressed, new System.Action<UghButton>(OnTargetButtonPressed));
			}
			if (targetControls[j] is UghToggle)
			{
				UghToggle ughToggle = (UghToggle)targetControls[j];
				ughToggle.OnChanged = (System.Action<UghToggle>)System.Delegate.Combine(ughToggle.OnChanged, new System.Action<UghToggle>(OnTargetTogglePressed));
			}
		}
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::UnregisterControlListeners token 0x06000686 @0x0012d564
	private void UnregisterControlListeners()
	{
		if (targetControls == null)
		{
			return;
		}
		UghControl.theOnlyLegalControls = null;
		for (int i = 0; i < targetControls.Length; i++)
		{
			if (targetControls[i] is UghButton)
			{
				UghButton ughButton = (UghButton)targetControls[i];
				ughButton.OnPressed = (System.Action<UghButton>)System.Delegate.Remove(ughButton.OnPressed, new System.Action<UghButton>(OnTargetButtonPressed));
			}
			if (targetControls[i] is UghToggle)
			{
				UghToggle ughToggle = (UghToggle)targetControls[i];
				ughToggle.OnChanged = (System.Action<UghToggle>)System.Delegate.Remove(ughToggle.OnChanged, new System.Action<UghToggle>(OnTargetTogglePressed));
			}
		}
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::Start token 0x06000687 @0x0012d8cc
	private void Start()
	{
		base.transforms["Arrow"].gameObject.SetActive(false);
		base.ughTexts["Text"].gameObject.SetActive(false);
		base.ughButtons["Backing"].gameObject.SetActive(false);
		base.ughButtons["InputBlocker"].gameObject.SetActive(false);
		UghControl.theOnlyLegalControls = null;
		StartCoroutine("StartHelper");
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::StartHelper token 0x06000688 @0x0012da18
	// RECUPERADO-AOT FrontEndTutorialPublisher/<StartHelper>c__Iterator5C::MoveNext token 0x060009fc @0x00155628
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	[DebuggerHidden]
	private IEnumerator StartHelper()
	{
		while (anchor == null || anchor.gameObject == null || !anchor.gameObject.activeInHierarchy || (U4Compat.FindObjectOfType<CartCustomizerPublisher>() != null && U4Compat.FindObjectOfType<CartCustomizerPublisher>().GetPaintMenuIsOut()) || U4Compat.FindObjectOfType<AchievementWindowPublisher>() != null)
		{
			yield return null;
		}
		base.transforms["Arrow"].gameObject.SetActive(true);
		base.ughTexts["Text"].gameObject.SetActive(true);
		base.ughButtons["Backing"].gameObject.SetActive(true);
		if (anyTouchDismissesTutorialStep)
		{
			base.ughButtons["InputBlocker"].gameObject.SetActive(true);
		}
		RegisterControlListeners();
		StartCoroutine(PulseArrowCoroutine());
		StartCoroutine(FadeInCoroutine());
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::OnPressedDismiss token 0x06000689 @0x0012da60
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public void OnPressedDismiss()
	{
		if (!(U4Compat.FindObjectOfType<AchievementWindowPublisher>() != null))
		{
			SoundLibrary.ButtonClickPlay("menuButton1");
			UnregisterControlListeners();
			StopCoroutine("StartHelper");
			Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::OnTargetButtonPressed token 0x0600068a @0x0012daf0
	private void OnTargetButtonPressed(UghButton btn)
	{
		OnPressedDismiss();
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::OnTargetTogglePressed token 0x0600068b @0x0012db28
	private void OnTargetTogglePressed(UghToggle tgl)
	{
		if (tgl.State)
		{
			OnPressedDismiss();
		}
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::OnEnabled token 0x0600068c @0x0012db70 (empty)
	private void OnEnabled()
	{
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::OnDisabled token 0x0600068d @0x0012db9c
	private void OnDisabled()
	{
		UnregisterControlListeners();
		StopCoroutine("StartHelper");
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::SetText token 0x0600068e @0x0012dbe8
	public void SetText(string text)
	{
		base.ughTexts["Text"].Text = text;
		Resize();
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::SetAnchorPoint token 0x0600068f @0x0012dc54
	public void SetAnchorPoint(Transform newAnchor, Vector3 newAnchorOffset)
	{
		anchor = newAnchor;
		anchorTarget = newAnchor.position + newAnchorOffset;
		anchorTarget.z = base.transform.position.z;
		Resize();
	}

	// RECUPERADO-AOT FrontEndTutorialPublisher::SetTargetControls token 0x06000690 @0x0012dd50
	public void SetTargetControls(UghControl[] ctrls)
	{
		UnregisterControlListeners();
		targetControls = ctrls;
	}
}
