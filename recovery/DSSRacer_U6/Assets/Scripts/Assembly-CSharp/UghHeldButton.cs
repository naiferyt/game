using UnityEngine;

// Touch button that reports Down / Held / Up every frame while a finger is on it (mobile HUD buttons).
// Source listing: recovery/aot_listings/Assembly-CSharp/UghHeldButton.txt
public class UghHeldButton : UghButton
{
	private bool isDownState;

	public bool isDown
	{
		// RECUPERADO-AOT UghHeldButton.get_isDown token 0x06000784 @0x0013ccec
		get
		{
			return isDownState;
		}
		// RECUPERADO-AOT UghHeldButton.set_isDown token 0x06000785 @0x0013cd20
		set
		{
			isDownState = value;
			SetButtonVisualState(value);
		}
	}

	// RECUPERADO-AOT UghHeldButton.SetButtonVisualState token 0x06000786 @0x0013cd60
	private void SetButtonVisualState(bool state)
	{
		if (state)
		{
			UghSpritePrototype sprite = pressed;
			if (!sprite)
			{
				sprite = normal;
			}
			UpdateMeshWithSpritePrototype(sprite);
		}
		else
		{
			UpdateMeshWithSpritePrototype(normal);
		}
	}

	// RECUPERADO-AOT UghHeldButton.Update token 0x06000787 @0x0013cde0
	private void Update()
	{
		bool touched = false;
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
			{
				// ADAPTADO-U6: Component.camera/collider -> GetComponent<Camera>() / GetComponent<Collider>()
				Ray ray = UghCamera.Instance.GetComponent<Camera>().ScreenPointToRay(touch.position);
				RaycastHit hit;
				if (GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity))
				{
					touched = true;
					break;
				}
			}
		}
		if (touched)
		{
			if (isDownState)
			{
				OnButtonHeld();
			}
			else
			{
				isDown = true;
				OnButtonDown();
			}
		}
		else
		{
			isDown = false;
			OnButtonUp();
		}
	}

	// RECUPERADO-AOT UghHeldButton.OnButtonDown token 0x06000788 @0x0013d030 (empty in the original)
	public virtual void OnButtonDown()
	{
	}

	// RECUPERADO-AOT UghHeldButton.OnButtonUp token 0x06000789 @0x0013d05c (empty in the original)
	public virtual void OnButtonUp()
	{
	}

	// RECUPERADO-AOT UghHeldButton.OnButtonHeld token 0x0600078a @0x0013d088 (empty in the original)
	public virtual void OnButtonHeld()
	{
	}
}
