using System;
using System.Collections;
using UnityEngine;

// Horizontal slider knob: dragging moves it along visualWidthUnits; Current maps 0..1 into limits.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghSlider.txt
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghSlider : UghControl
{
	public UghSpritePrototype pressed;

	public Rangef limits;

	// RECUPERADO-AOT UghSlider..ctor token 0x060003cb @0x0003de90 (field initializer)
	public float visualWidthUnits = 1f;

	public Action<UghSlider> OnChanged;

	private float currentNormalized;

	private Vector3 basePosition;

	public float Current
	{
		// RECUPERADO-AOT UghSlider.get_Current token 0x060003cc @0x0003dedc
		get
		{
			return limits.Lerp(currentNormalized);
		}
		// RECUPERADO-AOT UghSlider.set_Current token 0x060003cd @0x0003df40
		set
		{
			CurrentNormalized = limits.InverseLerp(value);
		}
	}

	public float CurrentNormalized
	{
		// RECUPERADO-AOT UghSlider.get_CurrentNormalized token 0x060003ce @0x0003dfb4
		get
		{
			return currentNormalized;
		}
		// RECUPERADO-AOT UghSlider.set_CurrentNormalized token 0x060003cf @0x0003dff4
		set
		{
			currentNormalized = Mathf.Clamp01(value);
			UpdatePosition();
			if (OnChanged != null)
			{
				OnChanged(this);
			}
		}
	}

	// RECUPERADO-AOT UghSlider.Awake token 0x060003d0 @0x0003e074
	private void Awake()
	{
		basePosition = transform.localPosition;
	}

	// RECUPERADO-AOT UghSlider.LocalPositionForInput token 0x060003d1 @0x0003e0dc
	private Vector3 LocalPositionForInput(Vector3 input)
	{
		// ADAPTADO-U6: Component.camera -> GetComponent<Camera>()
		float depth = transform.position.z - UghCamera.Instance.GetComponent<Camera>().transform.position.z;
		return transform.InverseTransformPoint(UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(input.x, input.y, depth)));
	}

	// RECUPERADO-AOT UghSlider.OnUghInputDown token 0x060003d2 @0x0003e2c4
	// (body: <OnUghInputDown>c__Iterator24.MoveNext token 0x060005ee @0x0005d694)
	public override IEnumerator OnUghInputDown()
	{
		UghSpritePrototype pressedPrototype = pressed;
		if (!pressedPrototype)
		{
			pressedPrototype = normal;
		}
		UpdateMeshWithSpritePrototype(pressedPrototype);
		Vector3 startLocalPosition = LocalPositionForInput(UghInput.InputPosition);
		while (UghInput.IsInputDown)
		{
			Vector3 currentLocalPosition = LocalPositionForInput(UghInput.InputPosition);
			Vector3 delta = currentLocalPosition - startLocalPosition;
			delta.y = 0f;
			delta.z = 0f;
			float normalizedDelta = delta.x / visualWidthUnits;
			CurrentNormalized = currentNormalized + normalizedDelta;
			yield return 0;
		}
	}

	// RECUPERADO-AOT UghSlider.OnUghInputUp token 0x060003d3 @0x0003e30c
	public override void OnUghInputUp()
	{
		UpdateMeshWithSpritePrototype(normal);
	}

	// RECUPERADO-AOT UghSlider.OnUghInputUpAsButton token 0x060003d4 @0x0003e34c
	public override void OnUghInputUpAsButton()
	{
		UpdateMeshWithSpritePrototype(normal);
	}

	// RECUPERADO-AOT UghSlider.UpdatePosition token 0x060003d5 @0x0003e38c
	private void UpdatePosition()
	{
		Vector3 inverseParentScale = Vector3.one;
		if (transform.parent != null)
		{
			inverseParentScale = transform.parent.lossyScale;
			inverseParentScale.x = 1f / inverseParentScale.x;
			inverseParentScale.y = 1f / inverseParentScale.y;
		}
		transform.localPosition = basePosition + Vector3.Scale(Vector3.right * visualWidthUnits * currentNormalized, inverseParentScale);
	}
}
