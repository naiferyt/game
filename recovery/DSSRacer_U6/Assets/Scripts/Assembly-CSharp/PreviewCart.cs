using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// The player's kart shown on the garage lift: streams in the parts, builds the painted atlas, and drives the kart
// out of the garage before loading the race.
// Source listing: recovery/aot_listings/Assembly-CSharp/PreviewCart.txt
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

	// RECUPERADO-AOT PreviewCart::.ctor token 0x060006c8 @0x00130a78 (field initializers)
	private List<PaintJob> paintList = new List<PaintJob>();

	private Texture2D cachedPaint;

	private bool isUpdating;

	public FrontEndCameraTarget driveOutCameraTarget;

	public Transform driveOutFrom;

	public Transform driveOutTo;

	public Transform liftAttach;

	public List<PreviewPart> previewParts = new List<PreviewPart>();

	public List<PreviewPaint> previewPaints = new List<PreviewPaint>();

	public List<CartSlot.Slots> transparentSlots = new List<CartSlot.Slots>();

	private Material multilayerMaterial;

	private bool isCheckingLoad;

	private GameObject loadingObject;

	private bool isDrivingOut;

	private float driveOutDuration;

	private float driveOutTimer;

	// RECUPERADO-AOT PreviewCart::get_CachedPaint token 0x060006c9 @0x00130b6c
	// RECUPERADO-AOT PreviewCart::set_CachedPaint token 0x060006ca @0x00130ba0
	public Texture2D CachedPaint
	{
		get
		{
			return cachedPaint;
		}
		set
		{
			cachedPaint = value;
		}
	}

	// RECUPERADO-AOT PreviewCart::get_IsUpdating token 0x060006cb @0x00130bdc
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static bool IsUpdating
	{
		get
		{
			PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
			if (previewCart == null)
			{
				return false;
			}
			return previewCart.isUpdating;
		}
	}

	// RECUPERADO-AOT PreviewCart::get_IsLoading token 0x060006cc @0x00130c7c
	// ADAPTADO-U6: FindObjectOfType -> U4Compat. (The original dereferences the result without a null check.)
	public static bool IsLoading
	{
		get
		{
			PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
			return previewCart.isCheckingLoad;
		}
	}

	// RECUPERADO-AOT PreviewCart::ApplyPaints token 0x060006cd @0x00130cfc
	// (iterator <ApplyPaints>c__Iterator66 MoveNext token 0x06000a38 @0x00157638, predicate <>m__2A token 0x06000a3b)
	// Rebuilds the whole kart atlas from every slot's paint job, then re-materials the parts.
	[DebuggerHidden]
	private IEnumerator ApplyPaints()
	{
		List<Texture2D> temporaryTextures = new List<Texture2D>();
		CompositeProfile profile = CartPrimaryTextureProfile.profile;
		foreach (PreviewPaint pp in previewPaints)
		{
			Texture2D newTex = pp.paint.GetTexture();
			if (newTex != null)
			{
				profile.SetSlotSource(pp.paint.slot.ToString(), newTex, new Rect(0f, 0f, newTex.width, newTex.height));
				temporaryTextures.Add(newTex);
			}
			paintList.Add(pp.paint);
			yield return null;
		}
		if (multilayerMaterial == null)
		{
			multilayerMaterial = new Material(materialPrefab);
		}
		else
		{
			Object.Destroy(multilayerMaterial.mainTexture);
		}
		yield return null;
		CompositeTextureUtil.AsyncTextureProcessor proc = new CompositeTextureUtil.AsyncTextureProcessor();
		yield return StartCoroutine(proc.GenerateCompositeTextureAsync(profile));
		multilayerMaterial.mainTexture = proc.newTexture;
		cachedPaint = proc.newTexture;
		CartSlot[] cartSlots = PlayerInstance.Instance.cartSlots;
		for (int i = 0; i < cartSlots.Length; i++)
		{
			CartSlot slot = cartSlots[i];
			if (paintList.Find((PaintJob x) => x.slot == slot.slot) != slot.slotPaint)
			{
				paintList.Add(slot.slotPaint);
			}
		}
		yield return null;
		yield return StartCoroutine(UpdateRenderers());
		foreach (Texture2D tex in temporaryTextures)
		{
			Object.Destroy(tex);
			yield return null;
		}
		temporaryTextures.Clear();
		yield return null;
		StreamManager.Cleanup();
		yield return null;
		System.GC.Collect();
	}

	// RECUPERADO-AOT PreviewCart::UpdateRenderers token 0x060006ce @0x00130d44
	// (iterator <UpdateRenderers>c__Iterator67 MoveNext token 0x06000a3f @0x001582d4)
	[DebuggerHidden]
	private IEnumerator UpdateRenderers()
	{
		isUpdating = true;
		StopCoroutine("UpdateColorShift");
		List<PreviewPart> previewPartCopy = new List<PreviewPart>(previewParts);
		foreach (PreviewPart pp in previewPartCopy)
		{
			if (pp.part.cartSlot == CartSlot.Slots.character || !(pp.mesh != null))
			{
				continue;
			}
			Renderer[] renderers = pp.mesh.GetComponentsInChildren<Renderer>();
			Renderer[] array = renderers;
			foreach (Renderer renderer in array)
			{
				if (transparentSlots.Contains(pp.part.cartSlot))
				{
					renderer.material = transparentPrefab;
				}
				else
				{
					renderer.material = multilayerMaterial;
				}
				yield return null;
			}
		}
		StartCoroutine("UpdateColorShift");
		isUpdating = false;
	}

	// RECUPERADO-AOT PreviewCart::UpdateColorShift token 0x060006cf @0x00130d8c
	// (iterator <UpdateColorShift>c__Iterator68 MoveNext token 0x06000a45 @0x00158900)
	// Pulses the alpha of the "transparent" material used to highlight slots in the customizer.
	[DebuggerHidden]
	private IEnumerator UpdateColorShift()
	{
		float change = 0f;
		bool up = true;
		while (true)
		{
			float time = Time.fixedDeltaTime * 1.25f;
			if (up)
			{
				change += time;
				if (change >= 0.35f)
				{
					change = 0.35f;
					up = false;
				}
			}
			else
			{
				change -= time;
				if (change <= 0f)
				{
					change = 0f;
					up = true;
				}
			}
			Color color = new Color(1f, 1f, 1f, 0f);
			color.a += change;
			transparentPrefab.color = color;
			yield return new WaitForSeconds(Time.fixedDeltaTime);
		}
	}

	// RECUPERADO-AOT PreviewCart::ComposeCart token 0x060006d0 @0x00130dd4
	// (iterator <ComposeCart>c__Iterator69 MoveNext token 0x06000a4b @0x00158d3c)
	// Instantiates the body, then every loaded part at its "<Slot>Slot" child of the body (hidden until loading ends).
	[DebuggerHidden]
	private IEnumerator ComposeCart()
	{
		List<PreviewPart> previewPartCopy = new List<PreviewPart>(previewParts);
		foreach (PreviewPart pp in previewPartCopy)
		{
			if (pp.part.cartSlot != CartSlot.Slots.body)
			{
				continue;
			}
			if (pp.mesh == null && pp.asset != null && pp.asset.isDone)
			{
				pp.mesh = (GameObject)Object.Instantiate(pp.asset.mainAsset, base.transform.position, base.transform.rotation);
				pp.mesh.transform.parent = base.transform;
				pp.mesh.transform.localPosition = ((pp.part.bodyFormType != AlternateForm.BodyForm.MonsterTruck) ? Vector3.zero : (Vector3.up * 0.3f));
				SetPartVisibility(pp.mesh, false);
				yield return null;
			}
			foreach (PreviewPart pView in previewPartCopy)
			{
				if (pView.asset == null || !pView.asset.isDone)
				{
					continue;
				}
				Vector3 slotPos = Vector3.zero;
				// ADAPTADO-U6: Transform.FindChild -> Find.
				Transform trans = pp.mesh.transform.Find(CartSlot.TargetGameObjectName[(int)pView.part.cartSlot]);
				if (trans != null)
				{
					slotPos = trans.localPosition;
					if (pView.mesh == null)
					{
						pView.mesh = (GameObject)Object.Instantiate(pView.asset.mainAsset, slotPos, trans.rotation);
					}
					pView.mesh.transform.parent = base.transform;
					pView.mesh.transform.localPosition = slotPos + ((pp.part.bodyFormType != AlternateForm.BodyForm.MonsterTruck) ? Vector3.zero : (Vector3.up * 0.3f));
					pView.mesh.transform.rotation = trans.rotation;
					SetPartVisibility(pView.mesh, false);
				}
				else
				{
					UnityEngine.Debug.Log("Couldn't Find the child transform: " + CartSlot.TargetGameObjectName[(int)pView.part.cartSlot]);
				}
				yield return null;
			}
		}
	}

	// RECUPERADO-AOT PreviewCart::SetPartVisibility token 0x060006d1 @0x00130e1c
	private void SetPartVisibility(GameObject obj, bool state)
	{
		Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			renderer.enabled = state;
		}
	}

	// RECUPERADO-AOT PreviewCart::ShowLoadingObject token 0x060006d2 @0x00130ecc
	private void ShowLoadingObject(bool state)
	{
		if (loadingObject == null)
		{
			loadingObject = (GameObject)Object.Instantiate(loadingPrefab);
		}
		loadingObject.transform.position = base.transform.position;
		SetPartVisibility(loadingObject, state);
	}

	// RECUPERADO-AOT PreviewCart::CharacterVisibility token 0x060006d3 @0x00130fc4
	// (predicate <CharacterVisibility>m__25 token 0x060006e2)
	private void CharacterVisibility(bool state)
	{
		PreviewPart previewPart = previewParts.Find((PreviewPart x) => x.part.cartSlot == CartSlot.Slots.character);
		if (previewPart == null)
		{
			return;
		}
		GameObject gameObject = null;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			if (child.name == previewPart.part.name + "(Clone)")
			{
				gameObject = child.gameObject;
			}
		}
		if (gameObject != null)
		{
			SetPartVisibility(gameObject, state);
		}
	}

	// RECUPERADO-AOT PreviewCart::CheckLoadingCoroutine token 0x060006d4 @0x00131168
	// (iterator <CheckLoadingCoroutine>c__Iterator6A MoveNext token 0x06000a51 @0x00159aec)
	// Shows the loading spinner until every part/paint asset is loaded, then composes and paints the kart.
	[DebuggerHidden]
	private IEnumerator CheckLoadingCoroutine()
	{
		if (isCheckingLoad)
		{
			yield break;
		}
		isCheckingLoad = true;
		SetPartVisibility(base.gameObject, false);
		ShowLoadingObject(true);
		while (isCheckingLoad)
		{
			yield return null;
			bool ready = true;
			List<PreviewPart> previewPartCopy = new List<PreviewPart>(previewParts);
			foreach (PreviewPart item in previewPartCopy)
			{
				if (item.asset != null && !item.asset.isDone)
				{
					ready = false;
					break;
				}
			}
			foreach (PreviewPaint previewPaint in previewPaints)
			{
				if (previewPaint.asset != null && !previewPaint.asset.isDone)
				{
					ready = false;
					break;
				}
			}
			if (ready)
			{
				yield return StartCoroutine(ComposeCart());
				if (cachedPaint == null || paintList.Count == 0)
				{
					yield return StartCoroutine(ApplyPaints());
				}
				else
				{
					yield return StartCoroutine(UpdateCachedPaint());
				}
				ShowLoadingObject(false);
				SetPartVisibility(base.gameObject, true);
				CharacterVisibility(false);
				isCheckingLoad = false;
			}
		}
	}

	// RECUPERADO-AOT PreviewCart::UpdateCachedPaint token 0x060006d5 @0x001311b0
	// (iterator <UpdateCachedPaint>c__Iterator6B MoveNext token 0x06000a57 @0x0015a21c, predicate <>m__2B token 0x06000a5a)
	// Re-blits only the slots whose paint changed (or that hold a customizer preview) into the cached atlas.
	[DebuggerHidden]
	private IEnumerator UpdateCachedPaint()
	{
		List<PaintJob> previewList = new List<PaintJob>();
		CartSlot[] cartSlots = PlayerInstance.Instance.cartSlots;
		for (int i = 0; i < cartSlots.Length; i++)
		{
			CartSlot slot = cartSlots[i];
			PaintJob job = paintList.Find((PaintJob x) => x.slot == slot.slot);
			bool jobMatch = job != null && slot.slotPaint != null && job.name != slot.slotPaint.name;
			bool tempSlot = CartCustomizerPublisher.IsTemporaryInSlot(slot.slot);
			if (jobMatch || tempSlot)
			{
				previewList.Add(slot.slotPaint);
				paintList.Remove(job);
				paintList.Add(slot.slotPaint);
			}
			yield return null;
		}
		CompositeProfile profile = CartPrimaryTextureProfile.profile;
		foreach (PaintJob paint in previewList)
		{
			Texture2D newTex = paint.GetTexture();
			if (newTex != null)
			{
				profile.SetSlotSource(paint.slot.ToString(), newTex, new Rect(0f, 0f, newTex.width, newTex.height));
				cachedPaint = CompositeTextureUtil.BlitToCachedTexture(profile, paint);
			}
			if (cachedPaint == null)
			{
				UnityEngine.Debug.Log("Somehow the CachedPaint is null and we need to ApplyPaints()!");
				StartCoroutine(ApplyPaints());
				yield break;
			}
			yield return null;
		}
		multilayerMaterial.mainTexture = cachedPaint;
		transparentPrefab.mainTexture = cachedPaint;
		yield return StartCoroutine(UpdateRenderers());
		StreamManager.Cleanup();
		yield return null;
		System.GC.Collect();
	}

	// RECUPERADO-AOT PreviewCart::DriveOutCoroutine token 0x060006d6 @0x001311f8
	// (iterator <DriveOutCoroutine>c__Iterator6C MoveNext token 0x06000a5e @0x0015aca4)
	// Garage door opens, the lift lowers, the kart drives out, then the Loading scene takes over.
	[DebuggerHidden]
	private IEnumerator DriveOutCoroutine()
	{
		ClearnTransparencies();
		GenerateCartPreview();
		while (isCheckingLoad)
		{
			yield return null;
		}
		CharacterVisibility(true);
		Animation characterAnim = GetComponentInChildren<Animation>();
		if (characterAnim != null)
		{
			foreach (AnimationState animState in characterAnim)
			{
				if (animState.name.ToLower().Contains("driving"))
				{
					animState.wrapMode = WrapMode.Loop;
					characterAnim.Play(animState.name);
					characterAnim.clip.wrapMode = WrapMode.Loop;
					break;
				}
			}
		}
		FrontEndCamera menuCamera = U4Compat.FindObjectOfType(typeof(FrontEndCamera)) as FrontEndCamera;
		menuCamera.SendMessage("ForceCameraTarget", driveOutCameraTarget);
		yield return new WaitForSeconds(0.5f);
		GameObject door = GameObject.FindGameObjectWithTag("Garage");
		if (door != null)
		{
			Animation anim = door.GetComponentInChildren<Animation>();
			if (anim != null)
			{
				anim.Play();
			}
		}
		LiftControlAI lift = (LiftControlAI)U4Compat.FindObjectOfType(typeof(LiftControlAI));
		lift.SetTransition(lift.transform.position + Vector3.down * 1.4f, 0.5f);
		yield return new WaitForSeconds(0.5f);
		driveOutDuration = 2f;
		driveOutTimer = driveOutDuration;
		isDrivingOut = true;
		CameraShake shake = U4Compat.FindObjectOfType(typeof(CameraShake)) as CameraShake;
		if (shake != null)
		{
			shake.TurnOnStationaryShake(1f, 0.2f);
		}
		GameObject particle = null;
		Transform partSpawn = base.transform.Find("Rollout Drift");
		if (partSpawn != null)
		{
			particle = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("PowerSlide"), partSpawn.position, base.transform.rotation) as GameObject;
			if (particle != null)
			{
				particle.transform.parent = base.transform;
			}
			SoundLibrary.ButtonClickPlay("driveout");
		}
		// ELIMINADO (servicio iOS/externo): BurstlyBinding.ShowInterstitial("0659142059127234080") (anuncio intersticial).
		yield return new WaitForSeconds(driveOutDuration);
		if (particle != null)
		{
			Object.Destroy(particle);
		}
		yield return 0;
		ScreenTimeoutController.SupressSleep(600f);
		ScreenFader.Instance.LoadLevel("Loading");
	}

	// RECUPERADO-AOT PreviewCart::Update token 0x060006d7 @0x00131240
	// Rides the lift; while driving out, slides from driveOutFrom to driveOutTo.
	private void Update()
	{
		if (isDrivingOut)
		{
			if (driveOutTimer > 0f)
			{
				driveOutTimer -= Time.deltaTime;
				if (driveOutTimer < 0f)
				{
					driveOutTimer = 0f;
				}
				float t = driveOutTimer / driveOutDuration;
				base.transform.position = Vector3.Lerp(driveOutTo.position, driveOutFrom.position, t);
			}
		}
		else
		{
			base.transform.position = liftAttach.position;
		}
	}

	// RECUPERADO-AOT PreviewCart::OnDestroy token 0x060006d8 @0x001313f0
	private void OnDestroy()
	{
		if (multilayerMaterial != null)
		{
			Object.Destroy(multilayerMaterial.mainTexture);
			Object.Destroy(multilayerMaterial);
		}
		if (!StreamManager.isAvailable)
		{
			return;
		}
		foreach (PreviewPart previewPart in previewParts)
		{
			if (previewPart.asset != null)
			{
				StreamManager.ReleaseAsset(previewPart.asset.name);
			}
		}
		foreach (PreviewPaint previewPaint in previewPaints)
		{
			if (previewPaint.asset != null)
			{
				StreamManager.ReleaseAsset(previewPaint.asset.name);
			}
		}
		if (cachedPaint != null)
		{
			Object.Destroy(cachedPaint);
		}
	}

	// RECUPERADO-AOT PreviewCart::AddPart token 0x060006d9 @0x001316ac
	// (predicate <AddPart>c__AnonStoreyA1::<>m__26 token 0x06000b56)
	// ADAPTADO-U6: Application.isWebPlayer (always false) dropped; the bundle route still follows forceWebPlayer.
	public void AddPart(CartPart part)
	{
		PreviewPart previewPart = previewParts.Find((PreviewPart test) => test.part.cartSlot == part.cartSlot);
		if (previewPart != null)
		{
			if (previewPart.part.UIName.baseText == part.UIName.baseText)
			{
				return;
			}
			RemovePart(previewPart.part);
		}
		PreviewPart previewPart2 = new PreviewPart();
		previewPart2.part = part;
		if (part.bundlePath.baseText != null && part.bundlePath.baseText.Length > 0)
		{
			if (DataUtility.Instance.forceWebPlayer)
			{
				previewPart2.asset = StreamManager.RequestAsset(part.UIName.baseText, DataUtility.PrependBundlePath(part.bundlePath.baseText), StreamManager.StreamType.ASSET_BUNDLE);
			}
			else
			{
				previewPart2.asset = StreamManager.RequestAsset(part.UIName.baseText, part.resourcePath.baseText, StreamManager.StreamType.RESOURCE);
			}
		}
		previewParts.Add(previewPart2);
	}

	// RECUPERADO-AOT PreviewCart::RemovePart token 0x060006da @0x001318ac
	// (predicate <RemovePart>c__AnonStoreyA2::<>m__27 token 0x06000b58)
	public void RemovePart(CartPart part)
	{
		PreviewPart previewPart = previewParts.Find((PreviewPart test) => test.part.UIName.baseText == part.UIName.baseText);
		if (previewPart != null)
		{
			if (previewPart.mesh != null)
			{
				Object.Destroy(previewPart.mesh);
			}
			if (previewPart.asset != null)
			{
				StreamManager.ReleaseAsset(previewPart.asset.name);
			}
			previewParts.Remove(previewPart);
		}
	}

	// RECUPERADO-AOT PreviewCart::AddPaint token 0x060006db @0x001319d0
	// (predicate <AddPaint>c__AnonStoreyA3::<>m__28 token 0x06000b5a)
	// ADAPTADO-U6: Application.isWebPlayer (always false) dropped. With Resources the layers load in PaintJob.GetTexture.
	public void AddPaint(PaintJob paint)
	{
		PreviewPaint previewPaint = previewPaints.Find((PreviewPaint test) => test.paint.slot == paint.slot);
		if (previewPaint != null)
		{
			if (previewPaint.paint.name == paint.name)
			{
				return;
			}
			RemovePaint(previewPaint.paint);
		}
		PreviewPaint previewPaint2 = new PreviewPaint();
		previewPaint2.paint = paint;
		if (paint.multilayerTexture.bundlePath != null && paint.multilayerTexture.bundlePath.Length > 0 && DataUtility.Instance.forceWebPlayer)
		{
			previewPaint2.asset = StreamManager.RequestAsset(paint.multilayerTexture.name, DataUtility.PrependBundlePath(paint.multilayerTexture.bundlePath), StreamManager.StreamType.ASSET_BUNDLE);
		}
		previewPaints.Add(previewPaint2);
	}

	// RECUPERADO-AOT PreviewCart::RemovePaint token 0x060006dc @0x00131b9c
	// (predicate <RemovePaint>c__AnonStoreyA4::<>m__29 token 0x06000b5c)
	public void RemovePaint(PaintJob paint)
	{
		PreviewPaint previewPaint = previewPaints.Find((PreviewPaint test) => test.paint.name == paint.name);
		if (previewPaint != null)
		{
			if (previewPaint.asset != null)
			{
				StreamManager.ReleaseAsset(previewPaint.asset.name);
			}
			if (previewPaint.paint != null)
			{
				previewPaint.paint.multilayerTexture.ReleaseAssets();
			}
			previewPaints.Remove(previewPaint);
		}
	}

	// RECUPERADO-AOT PreviewCart::GenerateCartPreview token 0x060006dd @0x00131ccc
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void GenerateCartPreview()
	{
		PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
		if (previewCart == null)
		{
			UnityEngine.Debug.LogError("Could not find preview cart. Aborting.");
			return;
		}
		PlayerInstance.MatchAlternateForms();
		CartSlot[] cartSlots = PlayerInstance.Instance.cartSlots;
		foreach (CartSlot cartSlot in cartSlots)
		{
			if (cartSlot.partInSlot != null)
			{
				previewCart.AddPart(cartSlot.partInSlot);
				if (cartSlot.slotPaint != null)
				{
					previewCart.AddPaint(cartSlot.slotPaint);
				}
			}
			else
			{
				UnityEngine.Debug.Log("partInSlot is null!!!!!!!");
			}
		}
		previewCart.StartCoroutine(previewCart.CheckLoadingCoroutine());
	}

	// RECUPERADO-AOT PreviewCart::GetPartTransform token 0x060006de @0x00131e60
	// Returns the "<Slot>Slot" attachment point of the preview body for the given slot.
	// ADAPTADO-U6: FindObjectOfType -> U4Compat; Transform.FindChild -> Find.
	public static Transform GetPartTransform(CartSlot.Slots slot)
	{
		PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
		if (previewCart == null)
		{
			UnityEngine.Debug.LogError("Could not find preview cart. Aborting.");
			return null;
		}
		foreach (PreviewPart previewPart in previewCart.previewParts)
		{
			if (previewPart.part.cartSlot == CartSlot.Slots.body)
			{
				if (previewPart.mesh != null)
				{
					return previewPart.mesh.transform.Find(CartSlot.TargetGameObjectName[(int)slot]);
				}
				return null;
			}
		}
		return null;
	}

	// RECUPERADO-AOT PreviewCart::StartDriveout token 0x060006df @0x001320c8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void StartDriveout()
	{
		PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
		if (previewCart == null)
		{
			UnityEngine.Debug.LogError("Could not find preview cart. Aborting.");
			return;
		}
		previewCart.StartCoroutine(previewCart.DriveOutCoroutine());
		ShiftUIPublisher shiftUIPublisher = (ShiftUIPublisher)U4Compat.FindObjectOfType(typeof(ShiftUIPublisher));
		if (shiftUIPublisher != null)
		{
			Object.Destroy(shiftUIPublisher.gameObject);
		}
	}

	// RECUPERADO-AOT PreviewCart::ClearnTransparencies token 0x060006e0 @0x00132240
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void ClearnTransparencies()
	{
		PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
		if (previewCart == null)
		{
			UnityEngine.Debug.LogError("Could not find preview cart. Aborting.");
		}
		else
		{
			previewCart.transparentSlots.Clear();
		}
	}

	// RECUPERADO-AOT PreviewCart::SetSlotTransparent token 0x060006e1 @0x001322fc
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void SetSlotTransparent(CartSlot.Slots slot, bool state)
	{
		PreviewCart previewCart = U4Compat.FindObjectOfType(typeof(PreviewCart)) as PreviewCart;
		if (previewCart == null)
		{
			UnityEngine.Debug.LogError("Could not find preview cart. Aborting.");
		}
		else if (previewCart.transparentSlots.Contains(slot))
		{
			if (!state)
			{
				previewCart.transparentSlots.Remove(slot);
			}
		}
		else if (state)
		{
			previewCart.transparentSlots.Add(slot);
		}
	}
}
