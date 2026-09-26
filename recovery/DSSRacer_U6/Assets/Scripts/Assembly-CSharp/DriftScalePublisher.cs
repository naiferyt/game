using System.Collections;
using System.Diagnostics;
using UnityEngine;

// HUD drift meter: fills while drifting, then shows the power-slide bar ("Full") and the wipeout
// countdown with a blinking warning until the power slide fires or is lost.
// Source listing: recovery/aot_listings/Assembly-CSharp/DriftScalePublisher.txt
public class DriftScalePublisher : UghPublisher
{
	private CarCollider carCollider;

	private Transform fill;

	private Transform full;

	private Transform wipeout;

	// RECUPERADO-AOT DriftScalePublisher::.ctor token 0x0600074d @0x00139364 (field initializers)
	private float fillMaxScale = 1f;

	private float wipeoutMaxScale = 1f;

	private bool blinkingWarning;

	// RECUPERADO-AOT DriftScalePublisher::BlinkLabelCoroutine token 0x0600074e @0x001393c8
	// (iterator <BlinkLabelCoroutine>c__Iterator77 MoveNext token 0x06000aa5 @0x0015e8dc)
	[DebuggerHidden]
	private IEnumerator BlinkLabelCoroutine()
	{
		GameObject darkGreen = base.transforms["Label Dark Green"].gameObject;
		while (true)
		{
			darkGreen.SetActive(false);
			yield return new WaitForSeconds(0.25f);
			darkGreen.SetActive(true);
			yield return new WaitForSeconds(0.25f);
		}
	}

	// RECUPERADO-AOT DriftScalePublisher::BlinkWarningCoroutine token 0x0600074f @0x00139410
	// (iterator <BlinkWarningCoroutine>c__Iterator78 MoveNext token 0x06000aab @0x0015eb60)
	[DebuggerHidden]
	private IEnumerator BlinkWarningCoroutine()
	{
		if (blinkingWarning)
		{
			yield break;
		}
		blinkingWarning = true;
		GameObject warning = base.transforms["Warning"].gameObject;
		GameObject lowlight = base.transforms["Warning Lowlight"].gameObject;
		warning.SetActive(true);
		while (carCollider.isPowerSlideQueued)
		{
			lowlight.SetActive(true);
			yield return new WaitForSeconds(0.1f);
			lowlight.SetActive(false);
			yield return new WaitForSeconds(0.1f);
		}
		warning.SetActive(false);
		blinkingWarning = false;
	}

	// RECUPERADO-AOT DriftScalePublisher::Start token 0x06000750 @0x00139458
	private void Start()
	{
		carCollider = HUDLogic.playerCar.GetComponent<CarCollider>();
		fill = base.transforms["Fill"];
		full = base.transforms["Full"];
		wipeout = base.transforms["Wipeout"];
		fillMaxScale = fill.localScale.x;
		wipeoutMaxScale = wipeout.localScale.x;
		fill.gameObject.SetActive(false);
		full.gameObject.SetActive(false);
		wipeout.gameObject.SetActive(false);
		base.transforms["Warning"].gameObject.SetActive(false);
		StartCoroutine(BlinkLabelCoroutine());
	}

	// RECUPERADO-AOT DriftScalePublisher::Update token 0x06000751 @0x0013964c
	private void Update()
	{
		bool isPowerSlideQueued = carCollider.isPowerSlideQueued;
		full.gameObject.SetActive(isPowerSlideQueued);
		wipeout.gameObject.SetActive(isPowerSlideQueued);
		fill.gameObject.SetActive(!isPowerSlideQueued);
		if (isPowerSlideQueued)
		{
			if (!blinkingWarning)
			{
				StartCoroutine(BlinkWarningCoroutine());
			}
			float num = (carCollider.PowerSlideTimer - carCollider.attributes.secondsToPowerSlide) / (carCollider.attributes.driftTooLong - carCollider.attributes.secondsToPowerSlide);
			if (num < 0f)
			{
				num = 0f;
			}
			Vector3 localScale = wipeout.localScale;
			localScale.x = num * wipeoutMaxScale;
			wipeout.localScale = localScale;
			wipeout.GetComponent<UghSprite>().UpdateMesh();
		}
		else
		{
			Vector3 localScale2 = fill.localScale;
			localScale2.x = carCollider.PowerSlideTimer / carCollider.attributes.secondsToPowerSlide * fillMaxScale;
			fill.localScale = localScale2;
			fill.GetComponent<UghSprite>().UpdateMesh();
		}
	}
}
