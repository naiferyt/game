using System;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
	public Rangef slideMinMax;

	public Action<VolumeSlider> OnVolumeChanged;

	private bool isSliding;

	private Vector3 lastMousePos;

	private Vector3 currentMousePos;

	private float lastValue;

	public float percent
	{
		get
		{
			RecoveryPending.Hit("VolumeSlider.get_percent");
			return default(float);
		}
		set
		{
			RecoveryPending.Hit("VolumeSlider.set_percent");
		}
	}

	private void Update()
	{
		RecoveryPending.Hit("VolumeSlider.Update");
	}

	private void OnMouseDown()
	{
		RecoveryPending.Hit("VolumeSlider.OnMouseDown");
	}

	private void OnMouseUp()
	{
		RecoveryPending.Hit("VolumeSlider.OnMouseUp");
	}

	private void MouseLogic()
	{
		RecoveryPending.Hit("VolumeSlider.MouseLogic");
	}

	private void TouchLogic()
	{
		RecoveryPending.Hit("VolumeSlider.TouchLogic");
	}
}
