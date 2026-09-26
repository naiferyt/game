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
			RecoveryPending.Hit("PreviewCart.get_CachedPaint");
			return default(Texture2D);
		}
		set
		{
			RecoveryPending.Hit("PreviewCart.set_CachedPaint");
		}
	}

	public static bool IsUpdating
	{
		get
		{
			RecoveryPending.Hit("PreviewCart.get_IsUpdating");
			return default(bool);
		}
	}

	public static bool IsLoading
	{
		get
		{
			RecoveryPending.Hit("PreviewCart.get_IsLoading");
			return default(bool);
		}
	}

	[DebuggerHidden]
	private IEnumerator ApplyPaints()
	{
		RecoveryPending.Hit("PreviewCart.ApplyPaints");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator UpdateRenderers()
	{
		RecoveryPending.Hit("PreviewCart.UpdateRenderers");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator UpdateColorShift()
	{
		RecoveryPending.Hit("PreviewCart.UpdateColorShift");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator ComposeCart()
	{
		RecoveryPending.Hit("PreviewCart.ComposeCart");
		yield break;
	}

	private void SetPartVisibility(GameObject obj, bool state)
	{
		RecoveryPending.Hit("PreviewCart.SetPartVisibility");
	}

	private void ShowLoadingObject(bool state)
	{
		RecoveryPending.Hit("PreviewCart.ShowLoadingObject");
	}

	private void CharacterVisibility(bool state)
	{
		RecoveryPending.Hit("PreviewCart.CharacterVisibility");
	}

	[DebuggerHidden]
	private IEnumerator CheckLoadingCoroutine()
	{
		RecoveryPending.Hit("PreviewCart.CheckLoadingCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator UpdateCachedPaint()
	{
		RecoveryPending.Hit("PreviewCart.UpdateCachedPaint");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator DriveOutCoroutine()
	{
		RecoveryPending.Hit("PreviewCart.DriveOutCoroutine");
		yield break;
	}

	private void Update()
	{
		RecoveryPending.Hit("PreviewCart.Update");
	}

	private void OnDestroy()
	{
		RecoveryPending.Hit("PreviewCart.OnDestroy");
	}

	public void AddPart(CartPart part)
	{
		RecoveryPending.Hit("PreviewCart.AddPart");
	}

	public void RemovePart(CartPart part)
	{
		RecoveryPending.Hit("PreviewCart.RemovePart");
	}

	public void AddPaint(PaintJob paint)
	{
		RecoveryPending.Hit("PreviewCart.AddPaint");
	}

	public void RemovePaint(PaintJob paint)
	{
		RecoveryPending.Hit("PreviewCart.RemovePaint");
	}

	public static void GenerateCartPreview()
	{
		RecoveryPending.Hit("PreviewCart.GenerateCartPreview");
	}

	public static Transform GetPartTransform(CartSlot.Slots slot)
	{
		RecoveryPending.Hit("PreviewCart.GetPartTransform");
		return default(Transform);
	}

	public static void StartDriveout()
	{
		RecoveryPending.Hit("PreviewCart.StartDriveout");
	}

	public static void ClearnTransparencies()
	{
		RecoveryPending.Hit("PreviewCart.ClearnTransparencies");
	}

	public static void SetSlotTransparent(CartSlot.Slots slot, bool state)
	{
		RecoveryPending.Hit("PreviewCart.SetSlotTransparent");
	}
}
