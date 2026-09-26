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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
	}

	private void OnMouseUp()
	{
	}

	private void MouseLogic()
	{
	}

	private void TouchLogic()
	{
	}
}
