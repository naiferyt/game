using System;
using UnityEngine;

// Draggable volume thumb: its x position inside slideMinMax is the volume percentage.
// Source listing: recovery/aot_listings/Assembly-CSharp/VolumeSlider.txt
public class VolumeSlider : MonoBehaviour
{
	// RECUPERADO-AOT VolumeSlider::.ctor token 0x06000739 @0x00137dc8 (field initializers)
	public Rangef slideMinMax = new Rangef(-4f, 4f);

	public Action<VolumeSlider> OnVolumeChanged;

	private bool isSliding;

	private Vector3 lastMousePos = Vector3.zero;

	private Vector3 currentMousePos = Vector3.zero;

	private float lastValue = 0.5f;

	// RECUPERADO-AOT VolumeSlider::get_percent token 0x0600073a @0x00137ec8
	// RECUPERADO-AOT VolumeSlider::set_percent token 0x0600073b @0x00137f7c
	public float percent
	{
		get
		{
			return (base.transform.position.x - slideMinMax.min) / (slideMinMax.max - slideMinMax.min);
		}
		set
		{
			base.transform.position = new Vector3(slideMinMax.Lerp(value), base.transform.position.y, base.transform.position.z);
		}
	}

	// RECUPERADO-AOT VolumeSlider::Update token 0x0600073c @0x001380e4
	// ADAPTADO-U6: Component.camera -> GetComponent<Camera>().
	private void Update()
	{
		MouseLogic();
		TouchLogic();
		if (isSliding)
		{
			Vector3 vector = UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(currentMousePos);
			Vector3 vector2 = vector - lastMousePos;
			lastMousePos = vector;
			Vector3 position = base.transform.position + vector2;
			position.y = base.transform.position.y;
			position.z = base.transform.position.z;
			position.x = slideMinMax.Clamp(position.x);
			base.transform.position = position;
		}
		float num = percent;
		if (num != lastValue)
		{
			lastValue = num;
			if (OnVolumeChanged != null)
			{
				OnVolumeChanged(this);
			}
		}
	}

	// RECUPERADO-AOT VolumeSlider::OnMouseDown token 0x0600073d @0x001383ec
	private void OnMouseDown()
	{
		isSliding = true;
		lastMousePos = UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
	}

	// RECUPERADO-AOT VolumeSlider::OnMouseUp token 0x0600073e @0x0013848c
	private void OnMouseUp()
	{
		isSliding = false;
	}

	// RECUPERADO-AOT VolumeSlider::MouseLogic token 0x0600073f @0x001384c4
	private void MouseLogic()
	{
		currentMousePos = Input.mousePosition;
	}

	// RECUPERADO-AOT VolumeSlider::TouchLogic token 0x06000740 @0x00138518
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	private void TouchLogic()
	{
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if (touch.phase == TouchPhase.Began)
			{
				RaycastHit hitInfo;
				if (GetComponent<Collider>().Raycast(UghCamera.Instance.GetComponent<Camera>().ScreenPointToRay(touch.position), out hitInfo, float.PositiveInfinity))
				{
					isSliding = true;
					lastMousePos = UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(touch.position);
				}
			}
			else if (isSliding && touch.phase == TouchPhase.Moved)
			{
				currentMousePos = touch.position;
			}
			else if (isSliding && (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended))
			{
				isSliding = false;
			}
		}
	}
}
