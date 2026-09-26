using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCart : MonoBehaviour
{
	public class PreviewPart
	{
		public GameObject mesh;

		public CartPart part;

		public StreamManager.Asset asset;
	}

	public class PreviewPaint
	{
		public PaintJob paint;

		public StreamManager.Asset asset;
	}

	public GameObject loadingPrefab;

	public Material materialPrefab;

	public Material transparentPrefab;

	private List<PaintJob> paintList;

	private Texture2D cachedPaint;

	private bool isUpdating;

	public FrontEndCameraTarget driveOutCameraTarget;

	public Transform driveOutFrom;

	public Transform driveOutTo;

	public Transform liftAttach;

	public List<PreviewPart> previewParts;

	public List<PreviewPaint> previewPaints;

	public List<CartSlot.Slots> transparentSlots;

	private Material multilayerMaterial;

	private bool isCheckingLoad;

	private GameObject loadingObject;

	private bool isDrivingOut;

	private float driveOutDuration;

	private float driveOutTimer;

	public Texture2D CachedPaint
	{
		get
		{
			return default(Texture2D);
		}
		set
		{
		}
	}

	public static bool IsUpdating
	{
		get
		{
			return default(bool);
		}
	}

	public static bool IsLoading
	{
		get
		{
			return default(bool);
		}
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ApplyPaints()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator UpdateRenderers()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator UpdateColorShift()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ComposeCart()
	{
		return default(IEnumerator);
	}

	private void SetPartVisibility(GameObject obj, bool state)
	{
	}

	private void ShowLoadingObject(bool state)
	{
	}

	private void CharacterVisibility(bool state)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CheckLoadingCoroutine()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator UpdateCachedPaint()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator DriveOutCoroutine()
	{
		return default(IEnumerator);
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void AddPart(CartPart part)
	{
	}

	public void RemovePart(CartPart part)
	{
	}

	public void AddPaint(PaintJob paint)
	{
	}

	public void RemovePaint(PaintJob paint)
	{
	}

	public static void GenerateCartPreview()
	{
	}

	public static Transform GetPartTransform(CartSlot.Slots slot)
	{
		return default(Transform);
	}

	public static void StartDriveout()
	{
	}

	public static void ClearnTransparencies()
	{
	}

	public static void SetSlotTransparent(CartSlot.Slots slot, bool state)
	{
	}
}
