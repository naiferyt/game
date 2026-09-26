using UnityEngine;

// Popover bubble that slides its frame in from above the origin point and back out when dismissed.
// Source listing: recovery/aot_listings/Assembly-CSharp/PopoverPublisher.txt
public class PopoverPublisher : UghPublisher
{
	// RECUPERADO-AOT PopoverPublisher::.ctor token 0x060006c3 @0x001304a0 (field initializers)
	private Vector3 originOffset = new Vector3(0f, 3.7f, 0f);

	private float transitionTimer = 1f;

	private float transitionSpeed = 4f;

	private bool transitionOut;

	// RECUPERADO-AOT PopoverPublisher::Start token 0x060006c4 @0x001305ac
	private void Start()
	{
		base.transforms["Frame"].localPosition = base.transforms["OriginPoint"].localPosition + originOffset;
	}

	// RECUPERADO-AOT PopoverPublisher::FixedUpdate token 0x060006c5 @0x0013068c
	private void FixedUpdate()
	{
		if (transitionTimer > 0f)
		{
			transitionTimer -= Time.deltaTime * transitionSpeed;
			if (transitionTimer < 0f)
			{
				transitionTimer = 0f;
			}
			Vector3 localPosition = Vector3.zero;
			if (transitionOut)
			{
				localPosition = Vector3.Lerp(base.transforms["OriginPoint"].localPosition + originOffset, base.transforms["TargetPoint"].localPosition, transitionTimer);
			}
			else
			{
				localPosition = Vector3.Lerp(base.transforms["OriginPoint"].localPosition + originOffset, base.transforms["TargetPoint"].localPosition, 1f - transitionTimer);
			}
			base.transforms["Frame"].localPosition = localPosition;
		}
		else if (transitionOut)
		{
			Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT PopoverPublisher::PressedBacking token 0x060006c6 @0x001309c4
	private void PressedBacking()
	{
		transitionTimer = 1f;
		transitionOut = true;
	}

	// RECUPERADO-AOT PopoverPublisher::SetText token 0x060006c7 @0x00130a14
	public void SetText(string text)
	{
		base.ughTexts["Text"].Text = text;
	}
}
