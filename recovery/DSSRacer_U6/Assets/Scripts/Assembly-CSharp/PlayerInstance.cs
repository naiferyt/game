using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// The player's kart: one CartSlot per slot (part + paint), filled from the defaults and the save; builds the race kart.
// Source listing: recovery/aot_listings/Assembly-CSharp/PlayerInstance.txt
public class PlayerInstance : MonoBehaviour
{
	public CartSlot[] cartSlots;

	private Material multilayerMaterial;

	private bool hasBootstrapped;

	private static PlayerInstance s_Instance;

	private static GameObject constructedCart;

	// RECUPERADO-AOT PlayerInstance::get_Instance token 0x06000243 @0x000e4f50
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static PlayerInstance Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(PlayerInstance)) as PlayerInstance;
				if (s_Instance == null)
				{
					UnityEngine.Debug.LogError("Could not find PlayerInstance!");
					return null;
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT PlayerInstance::.ctor token 0x06000241 @0x000e4e20
	private PlayerInstance()
	{
		Array values = Enum.GetValues(typeof(CartSlot.Slots));
		cartSlots = new CartSlot[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			cartSlots[i] = new CartSlot((CartSlot.Slots)(int)values.GetValue(i));
		}
	}

	// RECUPERADO-AOT PlayerInstance::Awake token 0x06000244 @0x000e5050
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// RECUPERADO-AOT PlayerInstance::Start token 0x06000245 @0x000e5088
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	private void Start()
	{
		if (U4Compat.FindObjectsOfType(typeof(PlayerInstance)).Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// RECUPERADO-AOT PlayerInstance::Bootstrap token 0x06000246 @0x000e50e0
	public static void Bootstrap()
	{
		PlayerInstance instance = Instance;
		if (instance.hasBootstrapped)
		{
			UnityEngine.Debug.Log("Skipping PlayerInstance.Bootstrap()");
			return;
		}
		instance.hasBootstrapped = true;
		if (CartPartList.CartPartListExists())
		{
			CartPart[] defaultParts = CartPartList.GetDefaultParts();
			for (int i = 0; i < defaultParts.Length; i++)
			{
				CartPart cartPart = defaultParts[i];
				instance.cartSlots[(int)cartPart.cartSlot].partInSlot = cartPart;
			}
		}
		DataUtility dataUtility = DataUtility.Instance;
		if (dataUtility.cloudData.playerCartParts == null)
		{
			dataUtility.cloudData.playerCartParts = new Dictionary<string, string>();
			CartPart[] defaultParts2 = CartPartList.GetDefaultParts();
			foreach (CartPart cartPart2 in defaultParts2)
			{
				dataUtility.SetCartPart(cartPart2.cartSlot, cartPart2.UIName.baseText);
			}
			dataUtility.Save();
		}
		else
		{
			foreach (KeyValuePair<string, string> playerCartPart in dataUtility.cloudData.playerCartParts)
			{
				CartSlot.Slots slots = (CartSlot.Slots)(int)Enum.Parse(typeof(CartSlot.Slots), playerCartPart.Key);
				instance.cartSlots[(int)slots].partInSlot = CartPartList.GetPart(playerCartPart.Value);
			}
		}
		if (dataUtility.cloudData.playerPaintJob == null)
		{
			dataUtility.cloudData.playerPaintJob = new Dictionary<string, string>();
			CartPart[] defaultParts3 = CartPartList.GetDefaultParts();
			foreach (CartPart cartPart3 in defaultParts3)
			{
				if (cartPart3.validPaintJobs.Length > 0)
				{
					dataUtility.SetCartPaint(cartPart3.cartSlot, cartPart3.validPaintJobs[0].name);
					instance.cartSlots[(int)cartPart3.cartSlot].slotPaint = CartPartList.GetPaintJob(cartPart3.validPaintJobs[0].name);
				}
			}
			dataUtility.Save();
			return;
		}
		foreach (KeyValuePair<string, string> item in dataUtility.cloudData.playerPaintJob)
		{
			CartSlot.Slots slots2 = (CartSlot.Slots)(int)Enum.Parse(typeof(CartSlot.Slots), item.Key);
			instance.cartSlots[(int)slots2].slotPaint = CartPartList.GetPaintJob(item.Value);
		}
	}

	// RECUPERADO-AOT PlayerInstance::GetCartSlot token 0x06000247 @0x000e57c4
	public static CartSlot GetCartSlot(CartSlot.Slots slot)
	{
		return Instance.cartSlots[(int)slot];
	}

	// RECUPERADO-AOT PlayerInstance::GetConstructedCart token 0x06000248 @0x000e5828
	public static GameObject GetConstructedCart()
	{
		if (constructedCart == null)
		{
			UnityEngine.Debug.LogError("No constructed cart available.  Call ConstructCart() first!");
		}
		return constructedCart;
	}

	// RECUPERADO-AOT PlayerInstance::ConstructCart token 0x06000249 @0x000e5898
	// (iterator <ConstructCart>c__Iterator20 MoveNext token 0x06000890 @0x00145e40)
	// Builds the race kart "LocalPlayer" from the preloaded assets: the wheels prefab is the root (with
	// CarCollider/PowerupHolder/PlayerControlLinker), the body is parented to it, the other parts go to their
	// "<Slot>Slot" attach points, the attributes are summed, the paint layers are composited into one material
	// and the character is seated with an AnimationDriver. Spread over several frames.
	// ADAPTADO-U6: Transform.FindChild -> Find.
	[DebuggerHidden]
	public static IEnumerator ConstructCart()
	{
		if (constructedCart != null)
		{
			ReleaseCart();
		}
		yield return null;
		PlayerInstance pi = Instance;
		CartSlot bodySlot = pi.cartSlots[0];
		if (bodySlot.partInSlot == null || bodySlot.partInSlot.bundlePath.baseText.Length == 0)
		{
			UnityEngine.Debug.LogError("Player cart does not have a body!  Aborting cart build.");
			yield break;
		}
		StreamManager.Asset bodyAsset = StreamManager.RequestAsset(bodySlot.partInSlot.UIName.baseText, string.Empty, StreamManager.StreamType.UNKNOWN);
		if (!bodyAsset.isDone)
		{
			UnityEngine.Debug.LogError("Body asset is not finished loading! Aborting car build.");
			yield break;
		}
		GameObject bodyPrefabPart = (GameObject)bodyAsset.mainAsset;
		CartSlot wheelSlot = pi.cartSlots[2];
		if (wheelSlot.partInSlot == null || wheelSlot.partInSlot.bundlePath.baseText.Length == 0)
		{
			UnityEngine.Debug.LogError("Player cart does not have wheels!  Aborting cart build.");
			yield break;
		}
		StreamManager.Asset wheelAsset = StreamManager.RequestAsset(wheelSlot.partInSlot.UIName.baseText, string.Empty, StreamManager.StreamType.UNKNOWN);
		if (!wheelAsset.isDone)
		{
			UnityEngine.Debug.LogError("Wheel asset is not finished loading!  Aborting cart build!");
			yield break;
		}
		GameObject wheelPrefabPart = (GameObject)wheelAsset.mainAsset;
		yield return null;
		GameObject cart = (GameObject)UnityEngine.Object.Instantiate(wheelPrefabPart);
		cart.name = new UnlocalizedString("LocalPlayer").baseText;
		CarCollider cc = cart.AddComponent(typeof(CarCollider)) as CarCollider;
		cart.AddComponent(typeof(PowerupHolder));
		cart.AddComponent(typeof(PlayerControlLinker));
		yield return null;
		GameObject cartBody = (GameObject)UnityEngine.Object.Instantiate(bodyPrefabPart);
		cartBody.transform.parent = cart.transform;
		CartAttributes attributes = bodySlot.partInSlot.cartAttributeMods + wheelSlot.partInSlot.cartAttributeMods;
		attributes.engineSoundString = bodySlot.partInSlot.cartAttributeMods.engineSoundString;
		yield return null;
		SpringConnection shocks = cart.GetComponent<SpringConnection>();
		if (shocks != null)
		{
			shocks.connection = cartBody;
		}
		yield return null;
		CartSlot[] cartSlots = pi.cartSlots;
		foreach (CartSlot slot in cartSlots)
		{
			if (slot.slot == CartSlot.Slots.body || slot.slot == CartSlot.Slots.wheels || slot.slot == CartSlot.Slots.character)
			{
				continue;
			}
			if (slot.partInSlot != null)
			{
				if (slot.partInSlot.bundlePath.baseText != null && slot.partInSlot.bundlePath.baseText.Length > 0)
				{
					Transform targetParentTransform = cartBody.transform.Find(CartSlot.TargetGameObjectName[(int)slot.slot]);
					if (targetParentTransform == null)
					{
						UnityEngine.Debug.LogWarning("Could not find part attach point '" + CartSlot.TargetGameObjectName[(int)slot.slot] + "'");
					}
					else
					{
						StreamManager.Asset partAsset = StreamManager.RequestAsset(slot.partInSlot.UIName.baseText, string.Empty, StreamManager.StreamType.UNKNOWN);
						if (partAsset.isDone)
						{
							GameObject partPrefab = (GameObject)partAsset.mainAsset;
							GameObject part = (GameObject)UnityEngine.Object.Instantiate(partPrefab, targetParentTransform.position, targetParentTransform.rotation);
							part.transform.parent = targetParentTransform;
						}
						else
						{
							UnityEngine.Debug.LogWarning("Part '" + slot.partInSlot.UIName.baseText + "' was not finished loading--skipping attach.");
						}
					}
				}
				attributes += slot.partInSlot.cartAttributeMods;
			}
			else if (CartSlot.SlotRequired[(int)slot.slot])
			{
				UnityEngine.Debug.LogError("Slot '" + CartSlot.SlotNames[(int)slot.slot] + "' is empty, but is required");
			}
			yield return null;
		}
		cc.attributes = attributes;
		List<Texture2D> temporaryTextures = new List<Texture2D>();
		CompositeProfile profile = CartPrimaryTextureProfile.profile;
		CartSlot[] cartSlots2 = pi.cartSlots;
		foreach (CartSlot slot2 in cartSlots2)
		{
			if (slot2.slotPaint == null)
			{
				continue;
			}
			Texture2D newTex = slot2.slotPaint.GetTexture();
			if (newTex != null)
			{
				temporaryTextures.Add(newTex);
				profile.SetSlotSource(slot2.slot.ToString(), newTex, new Rect(0f, 0f, newTex.width, newTex.height));
			}
			yield return null;
		}
		if (temporaryTextures.Count > 0)
		{
			if (pi.multilayerMaterial == null)
			{
				pi.multilayerMaterial = new Material(Shader.Find("Mobile/Diffuse"));
			}
			else
			{
				UnityEngine.Object.Destroy(pi.multilayerMaterial.mainTexture);
			}
			CompositeTextureUtil.AsyncTextureProcessor textureProc = new CompositeTextureUtil.AsyncTextureProcessor();
			yield return s_Instance.StartCoroutine(textureProc.GenerateCompositeTextureAsync(profile));
			pi.multilayerMaterial.mainTexture = textureProc.newTexture;
			Renderer[] renderers = cart.GetComponentsInChildren<Renderer>();
			Renderer[] array = renderers;
			foreach (Renderer renderer in array)
			{
				if (renderer.gameObject.name != "ExhaustParticle" && !renderer.gameObject.name.Contains("Shadow Blob"))
				{
					renderer.material = pi.multilayerMaterial;
					yield return null;
				}
			}
			foreach (Texture2D tex in temporaryTextures)
			{
				UnityEngine.Object.Destroy(tex);
				yield return null;
			}
		}
		CartSlot characterSlot = pi.cartSlots[5];
		if (characterSlot.partInSlot != null)
		{
			Transform characterTransform = cartBody.transform.Find(CartSlot.TargetGameObjectName[(int)characterSlot.slot]);
			StreamManager.Asset partAsset2 = StreamManager.RequestAsset(characterSlot.partInSlot.UIName.baseText, string.Empty, StreamManager.StreamType.UNKNOWN);
			if (partAsset2.isDone)
			{
				GameObject partPrefab2 = (GameObject)partAsset2.mainAsset;
				GameObject part2 = (GameObject)UnityEngine.Object.Instantiate(partPrefab2);
				part2.transform.parent = characterTransform;
				part2.transform.localPosition = Vector3.zero;
				part2.transform.localRotation = Quaternion.identity;
				AnimationDriver ad = cart.AddComponent<AnimationDriver>();
				ad.SetAnimationTarget(part2);
			}
		}
		constructedCart = cart;
	}

	// RECUPERADO-AOT PlayerInstance::MatchAlternateForms token 0x0600024a @0x000e58d0
	// Moves every slot to the body's form (kart / monster truck / bike), unlocking the matching variant of an owned part.
	public static void MatchAlternateForms()
	{
		CartSlot cartSlot = GetCartSlot(CartSlot.Slots.body);
		if (cartSlot == null || cartSlot.partInSlot == null)
		{
			return;
		}
		AlternateForm.BodyForm bodyForm = cartSlot.partInSlot.alternateForms.GetBodyForm(cartSlot.partInSlot);
		CartSlot[] array = Instance.cartSlots;
		foreach (CartSlot cartSlot2 in array)
		{
			if (cartSlot2.partInSlot == null || cartSlot2.partInSlot.alternateForms == null)
			{
				continue;
			}
			AlternateForm.FormData[] forms = cartSlot2.partInSlot.alternateForms.forms;
			foreach (AlternateForm.FormData formData in forms)
			{
				if (!formData.part.AreAllAlternateFormsLocked && formData.part.IsLocked && cartSlot2.slot != CartSlot.Slots.body)
				{
					DataUtility.Instance.Unlock(formData.part.UIName.baseText);
				}
			}
			CartPart cartPart = cartSlot2.partInSlot.alternateForms.FindFirstWithForm(bodyForm);
			if (cartPart != null)
			{
				cartSlot2.partInSlot = cartPart;
			}
		}
	}

	// RECUPERADO-AOT PlayerInstance::ReleaseCart token 0x0600024b @0x000e5ab4
	public static void ReleaseCart()
	{
		CartSlot[] array = Instance.cartSlots;
		foreach (CartSlot cartSlot in array)
		{
			// ADAPTADO-U6: the original released the part's streamed asset only when
			// `cartSlot.partInSlot.guiText != null && cartSlot.partInSlot.bundlePath.baseText.Length > 0`
			// (Component.guiText, removed in Unity 2019). Kart parts carry no GUIText, so that branch never ran:
			//     StreamManager.ReleaseAsset(cartSlot.partInSlot.UIName.baseText);
			if (cartSlot.slotPaint != null)
			{
				cartSlot.slotPaint.multilayerTexture.ReleaseAssets();
			}
		}
		if (constructedCart != null)
		{
			UnityEngine.Object.Destroy(constructedCart);
		}
		constructedCart = null;
	}
}
