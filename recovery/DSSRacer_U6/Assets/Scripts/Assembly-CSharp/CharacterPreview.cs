using UnityEngine;

// The selected character standing in the garage: streams in its prefab, plays idle animations, and can be hidden
// or blacked out (locked characters in the character select).
// Source listing: recovery/aot_listings/Assembly-CSharp/CharacterPreview.txt
public class CharacterPreview : MonoBehaviour
{
	public class PreviewPart
	{
		public GameObject mesh;

		public CartPart part;

		public StreamManager.Asset asset;
	}

	private const float IDLE_TIMER = 10f;

	public Material blackoutMaterial;

	private PreviewPart previewCharacter;

	private bool blackedOut;

	// RECUPERADO-AOT CharacterPreview::.ctor token 0x06000621 @0x00125af0 (field initializers)
	private float idleTime = 10f;

	private string curAnimName = "idle";

	public bool hidden = true;

	public int randomTime;

	// RECUPERADO-AOT CharacterPreview::Update token 0x06000622 @0x00125b58
	// ADAPTADO-U6: Transform.FindChild -> Find.
	private void Update()
	{
		if (previewCharacter == null)
		{
			return;
		}
		Animation componentInChildren = base.gameObject.GetComponentInChildren<Animation>();
		if (previewCharacter.mesh == null && previewCharacter.asset != null && previewCharacter.asset.isDone)
		{
			previewCharacter.mesh = (GameObject)Object.Instantiate(previewCharacter.asset.mainAsset, base.transform.position, base.transform.rotation);
			previewCharacter.mesh.transform.parent = base.transform;
			curAnimName = "idle";
			if (Random.Range(0, 11) % 2 == 0)
			{
				curAnimName += "2";
			}
			if (componentInChildren != null)
			{
				foreach (AnimationState item in componentInChildren)
				{
					if (item.name.ToLower().EndsWith(curAnimName))
					{
						componentInChildren.Play(item.name);
						componentInChildren.wrapMode = WrapMode.Loop;
						break;
					}
				}
			}
			Transform transform = previewCharacter.mesh.transform.GetChild(0).Find("belt");
			if (transform != null)
			{
				transform.gameObject.SetActive(false);
			}
			if (blackedOut)
			{
				Blackout(true);
			}
		}
		if (componentInChildren != null)
		{
			componentInChildren.wrapMode = WrapMode.Once;
			foreach (AnimationState item2 in componentInChildren)
			{
				if (item2.name.ToLower().EndsWith(curAnimName))
				{
					if (!componentInChildren.IsPlaying(item2.name))
					{
						componentInChildren.CrossFadeQueued(item2.name);
					}
					break;
				}
			}
		}
		idleTime -= Time.deltaTime;
		if (!((float)randomTime < idleTime))
		{
			PlayRandomIdleAnimation(componentInChildren);
			idleTime = 10f;
			randomTime = Random.Range(0, 5);
		}
	}

	// RECUPERADO-AOT CharacterPreview::PlayRandomIdleAnimation token 0x06000623 @0x001263d8
	private void PlayRandomIdleAnimation(Animation anim)
	{
		if (!(anim != null))
		{
			return;
		}
		anim.wrapMode = WrapMode.Once;
		string value = "idle3";
		foreach (AnimationState item in anim)
		{
			if (item.name.ToLower().Contains(value))
			{
				if (!anim.IsPlaying(item.name))
				{
					anim.CrossFade(item.name);
				}
				break;
			}
		}
	}

	// RECUPERADO-AOT CharacterPreview::OnDestroy token 0x06000624 @0x001266e4
	private void OnDestroy()
	{
		if (StreamManager.isAvailable && previewCharacter != null && previewCharacter.asset != null)
		{
			StreamManager.ReleaseAsset(previewCharacter.asset.name);
		}
	}

	// RECUPERADO-AOT CharacterPreview::SetCharacter token 0x06000625 @0x00126748
	// ADAPTADO-U6: FindObjectOfType -> U4Compat; Application.isWebPlayer (always false) dropped.
	public static void SetCharacter(CartPart part, bool force)
	{
		CharacterPreview characterPreview = (CharacterPreview)U4Compat.FindObjectOfType(typeof(CharacterPreview));
		if (characterPreview == null)
		{
			Debug.LogError("Character Preview required!");
		}
		else
		{
			if (characterPreview.hidden || (!force && characterPreview.previewCharacter != null && characterPreview.previewCharacter.part.UIName.baseText == part.UIName.baseText))
			{
				return;
			}
			if (characterPreview.previewCharacter != null)
			{
				if (characterPreview.previewCharacter.mesh != null)
				{
					Object.Destroy(characterPreview.previewCharacter.mesh);
				}
				if (characterPreview.previewCharacter.asset != null)
				{
					StreamManager.ReleaseAsset(characterPreview.previewCharacter.asset.name);
				}
				Resources.UnloadUnusedAssets();
				System.GC.Collect();
			}
			if (characterPreview.hidden)
			{
				return;
			}
			characterPreview.previewCharacter = new PreviewPart();
			characterPreview.previewCharacter.part = part;
			if (part.bundlePath.baseText != null && part.bundlePath.baseText.Length > 0)
			{
				if (DataUtility.Instance.forceWebPlayer)
				{
					characterPreview.previewCharacter.asset = StreamManager.RequestAsset(part.UIName.baseText, DataUtility.PrependBundlePath(part.bundlePath.baseText), StreamManager.StreamType.ASSET_BUNDLE);
				}
				else
				{
					characterPreview.previewCharacter.asset = StreamManager.RequestAsset(part.UIName.baseText, part.resourcePath.baseText, StreamManager.StreamType.RESOURCE);
				}
			}
		}
	}

	// RECUPERADO-AOT CharacterPreview::Refresh token 0x06000626 @0x00126988
	public static void Refresh(bool force)
	{
		CartPart partInSlot = PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot;
		if (partInSlot != null)
		{
			SetCharacter(partInSlot, force);
		}
	}

	// RECUPERADO-AOT CharacterPreview::Blackout token 0x06000627 @0x001269e0
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void Blackout(bool state)
	{
		CharacterPreview characterPreview = (CharacterPreview)U4Compat.FindObjectOfType(typeof(CharacterPreview));
		if (characterPreview == null)
		{
			Debug.LogError("Character Preview required!");
			return;
		}
		if (state && characterPreview.previewCharacter != null && characterPreview.previewCharacter.mesh != null)
		{
			Renderer[] componentsInChildren = characterPreview.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.material = characterPreview.blackoutMaterial;
			}
		}
		else if (!state && characterPreview.blackedOut)
		{
			Refresh(true);
		}
		characterPreview.blackedOut = state;
	}

	// RECUPERADO-AOT CharacterPreview::Unhide token 0x06000628 @0x00126b8c
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void Unhide()
	{
		CharacterPreview characterPreview = (CharacterPreview)U4Compat.FindObjectOfType(typeof(CharacterPreview));
		if (characterPreview != null)
		{
			if (characterPreview.previewCharacter != null && characterPreview.previewCharacter.mesh != null)
			{
				Renderer componentInChildren = characterPreview.previewCharacter.mesh.GetComponentInChildren<Renderer>();
				if (componentInChildren != null)
				{
					componentInChildren.enabled = true;
				}
			}
			characterPreview.hidden = false;
			Refresh(true);
		}
	}

	// RECUPERADO-AOT CharacterPreview::Hide token 0x06000629 @0x00126ca8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static void Hide()
	{
		CharacterPreview characterPreview = (CharacterPreview)U4Compat.FindObjectOfType(typeof(CharacterPreview));
		if (!(characterPreview != null))
		{
			return;
		}
		characterPreview.hidden = true;
		if (characterPreview.previewCharacter != null && characterPreview.previewCharacter.mesh != null)
		{
			Renderer componentInChildren = characterPreview.previewCharacter.mesh.GetComponentInChildren<Renderer>();
			if (componentInChildren != null)
			{
				componentInChildren.enabled = false;
			}
		}
	}
}
