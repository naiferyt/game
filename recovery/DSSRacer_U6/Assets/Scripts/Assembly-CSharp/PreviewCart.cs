using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public static bool IsUpdating
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool IsLoading
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[DebuggerHidden]
	private IEnumerator ApplyPaints()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator UpdateRenderers()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator UpdateColorShift()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator ComposeCart()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator CheckLoadingCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator UpdateCachedPaint()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator DriveOutCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
