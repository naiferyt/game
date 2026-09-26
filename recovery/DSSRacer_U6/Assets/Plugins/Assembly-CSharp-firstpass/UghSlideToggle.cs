using System;
using System.Collections;
using UnityEngine;

// On/off slide switch: the mesh shows a window (edgePixelInsets.left wide) over a wider strip; slideFactor 0 = on,
// 1 = off. Tap toggles, dragging slides and snaps to the nearest side (0.3 s animation, unscaled time).
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghSlideToggle.txt
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class UghSlideToggle : UghControl
{
	private const float slideSpeed = 2f;

	public Action<UghSlideToggle> OnChanged;

	private bool state;

	private bool hot;

	// RECUPERADO-AOT UghSlideToggle..ctor token 0x060003be @0x0003cdc8 (field initializer)
	private float slideFactor = 1f;

	private float realDeltaTime;

	private float lastRealtimeSinceStartup;

	private int lastRealtimeSinceStartupFrame;

	public bool State
	{
		// RECUPERADO-AOT UghSlideToggle.get_State token 0x060003bf @0x0003ce14
		get
		{
			return state;
		}
		// RECUPERADO-AOT UghSlideToggle.set_State token 0x060003c0 @0x0003ce48
		set
		{
			state = value;
			slideFactor = value ? 0f : 1f;
			UpdateMeshWithSpritePrototype(normal);
			SendOnChanged();
		}
	}

	// RECUPERADO-AOT UghSlideToggle.AutoSizeCollider token 0x060003c1 @0x0003cee8 (empty override in the original)
	[ContextMenu("Autosize Collider")]
	public override void AutoSizeCollider()
	{
	}

	// RECUPERADO-AOT UghSlideToggle.UpdateRealDeltaTime token 0x060003c2 @0x0003cf14
	private void UpdateRealDeltaTime()
	{
		if (Time.frameCount != lastRealtimeSinceStartupFrame)
		{
			float now = Time.realtimeSinceStartup;
			realDeltaTime = now - lastRealtimeSinceStartup;
			lastRealtimeSinceStartup = now;
			lastRealtimeSinceStartupFrame = Time.frameCount;
		}
	}

	// RECUPERADO-AOT UghSlideToggle.Awake token 0x060003c3 @0x0003cf98
	private void Awake()
	{
		lastRealtimeSinceStartup = Time.realtimeSinceStartup;
		lastRealtimeSinceStartupFrame = Time.frameCount;
	}

	// RECUPERADO-AOT UghSlideToggle.LocalPositionForInput token 0x060003c4 @0x0003cfec
	private Vector3 LocalPositionForInput(Vector3 input)
	{
		// ADAPTADO-U6: Component.camera -> GetComponent<Camera>()
		float depth = transform.position.z - UghCamera.Instance.GetComponent<Camera>().transform.position.z;
		return transform.InverseTransformPoint(UghCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(input.x, input.y, depth)));
	}

	// RECUPERADO-AOT UghSlideToggle.SendOnChanged token 0x060003c5 @0x0003d1d4
	private void SendOnChanged()
	{
		if (OnChanged != null)
		{
			OnChanged(this);
		}
	}

	// RECUPERADO-AOT UghSlideToggle.OnUghInputDown token 0x060003c6 @0x0003d220
	// (body: <OnUghInputDown>c__Iterator23.MoveNext token 0x060005e8 @0x0005cbe8)
	public override IEnumerator OnUghInputDown()
	{
		hot = true;
		Vector3 hotPosition = UghInput.InputPosition;
		Vector3 hotLocalPosition = LocalPositionForInput(hotPosition);
		bool hasMovedInput = false;
		float oldSlideFactor = slideFactor;
		float hotSlideFactor = slideFactor;
		UghSprite sprite = GetComponent<UghSprite>();
		UghSpritePrototype prototype = sprite.normal;
		while (UghInput.IsInputDown && hot)
		{
			UpdateRealDeltaTime();
			Vector3 inputPosition = UghInput.InputPosition;
			Vector3 delta = inputPosition - hotPosition;
			if (delta.magnitude > 1f)
			{
				hasMovedInput = true;
			}
			Vector3 localPosition = LocalPositionForInput(inputPosition);
			Vector3 localDelta = localPosition - hotLocalPosition;
			float spriteHorizontalSizeFactor = prototype.edgePixelInsets.left / (float)prototype.pixelWidth;
			Vector3 localSize = new Vector3(prototype.size.x * (1f - spriteHorizontalSizeFactor), prototype.size.y, 0f);
			float deltaSlideFactor = (0f - localDelta.x) / localSize.x;
			slideFactor = Mathf.Clamp01(hotSlideFactor + deltaSlideFactor);
			if (Mathf.Abs(slideFactor - oldSlideFactor) > 0.001f)
			{
				UpdateMeshWithSpritePrototype(prototype);
			}
			oldSlideFactor = slideFactor;
			yield return 0;
		}
		hot = false;
		if (hasMovedInput)
		{
			bool oldState = state;
			state = slideFactor < 0.5f;
			if (state != oldState)
			{
				SendOnChanged();
			}
			float startSlideFactor = slideFactor;
			float goalSlideFactor = state ? 0f : 1f;
			float timer = 0f;
			float length = 0.3f * Mathf.Abs(goalSlideFactor - startSlideFactor);
			while (length > 0.001f && timer < length && !hot)
			{
				UpdateRealDeltaTime();
				timer += realDeltaTime;
				slideFactor = Mathf.Lerp(startSlideFactor, goalSlideFactor, timer / length);
				UpdateMeshWithSpritePrototype(normal);
				yield return 0;
			}
			slideFactor = goalSlideFactor;
			UpdateMeshWithSpritePrototype(normal);
		}
		else
		{
			state = !state;
			SendOnChanged();
			float startSlideFactor = slideFactor;
			float goalSlideFactor = state ? 0f : 1f;
			float timer = 0f;
			float length = 0.3f;
			while (timer < length && !hot)
			{
				UpdateRealDeltaTime();
				timer += realDeltaTime;
				slideFactor = Mathf.Lerp(startSlideFactor, goalSlideFactor, timer / length);
				UpdateMeshWithSpritePrototype(normal);
				yield return 0;
			}
		}
	}

	// RECUPERADO-AOT UghSlideToggle.OnUghInputUp token 0x060003c7 @0x0003d268
	public override void OnUghInputUp()
	{
		hot = false;
	}

	// RECUPERADO-AOT UghSlideToggle.OnUghInputUpAsButton token 0x060003c8 @0x0003d2a0
	public override void OnUghInputUpAsButton()
	{
		hot = false;
	}

	// RECUPERADO-AOT UghSlideToggle.UpdateMeshWithSpritePrototype token 0x060003c9 @0x0003d2d8
	protected override void UpdateMeshWithSpritePrototype(UghSpritePrototype sprite)
	{
		if (!sprite || sprite.edgePixelInsets.left == 0f)
		{
			return;
		}
		MeshFilter filter = GetComponent<MeshFilter>();
		Mesh mesh = filter.sharedMesh;
		if (!filter.sharedMesh)
		{
			mesh = new Mesh();
		}
		Vector3[] vertices = new Vector3[4];
		Vector2[] uvs = new Vector2[4];
		// The visible window is edgePixelInsets.left pixels of the strip.
		Vector3 size = sprite.size;
		float windowFactor = sprite.edgePixelInsets.left / (float)sprite.pixelWidth;
		size.x *= windowFactor;
		Vector3 anchorOffset = GetOffsetForAnchor(anchor, customAnchorOffset);
		vertices[0] = Vector3.Scale(new Vector3(anchorOffset.x, anchorOffset.y, 0f), size);
		vertices[1] = Vector3.Scale(new Vector3(anchorOffset.x, 1f + anchorOffset.y, 0f), size);
		vertices[2] = Vector3.Scale(new Vector3(1f + anchorOffset.x, 1f + anchorOffset.y, 0f), size);
		vertices[3] = Vector3.Scale(new Vector3(1f + anchorOffset.x, anchorOffset.y, 0f), size);
		mesh.vertices = vertices;
		slideFactor = Mathf.Clamp01(slideFactor);
		float travel = (sprite.pixelSize.x - sprite.edgePixelInsets.left) / sprite.pixelSize.x;
		Rect uvRect = sprite.sourceUVRect;
		uvs[0] = new Vector2(uvRect.x + slideFactor * travel * uvRect.width, uvRect.y);
		uvs[1] = new Vector2(uvRect.x + slideFactor * travel * uvRect.width, uvRect.height + uvRect.y);
		uvs[2] = new Vector2(uvRect.width + uvRect.x - (1f - slideFactor) * travel * uvRect.width, uvRect.height + uvRect.y);
		uvs[3] = new Vector2(uvRect.width + uvRect.x - (1f - slideFactor) * travel * uvRect.width, uvRect.y);
		mesh.uv = uvs;
		// (static initializer data of the original, read from Assembly-CSharp-firstpass.dll)
		mesh.triangles = new int[6] { 0, 1, 3, 1, 2, 3 };
		filter.sharedMesh = mesh;
		// ADAPTADO-U6: Component.renderer -> GetComponent<Renderer>()
		GetComponent<Renderer>().sharedMaterial = sprite.material;
	}

	// RECUPERADO-AOT UghSlideToggle.Update token 0x060003ca @0x0003de50
	private void Update()
	{
		UpdateMeshWithSpritePrototype(normal);
	}
}
