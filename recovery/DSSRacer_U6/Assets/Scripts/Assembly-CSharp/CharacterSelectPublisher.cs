using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// "Character Select" menu: browse the drivers with the arrows, use or buy one; shows the show logo, the
// owned/using/locked status and the player's coins.
// Source listing: recovery/aot_listings/Assembly-CSharp/CharacterSelectPublisher.txt
public class CharacterSelectPublisher : UghPublisher
{
	[Serializable]
	public class Logo
	{
		[HideInInspector]
		public Texture2D texture;

		public string name;

		public LocalizedString resourcePath;

		public LocalizedString webPath;
	}

	private const float SAMPLE_DURATION = 10f;

	public Material blackoutMatrial;

	private int viewingIndex;

	private CartPart previousPart;

	private CartPart[] characterList;

	public GameObject debugPopoverPrefab;

	public List<Logo> logos;

	private bool loadingInLocalizedAssets;

	// RECUPERADO-AOT CharacterSelectPublisher::Awake token 0x0600062c @0x00126e24
	// ADAPTADO-U6: Application.isWebPlayer (always false) dropped; the web route still follows forceWebPlayer.
	private new void Awake()
	{
		base.Awake();
		StartCoroutine(LoadInLocalizedAssets(DataUtility.Instance.forceWebPlayer));
	}

	// RECUPERADO-AOT CharacterSelectPublisher::LoadInLocalizedAssets token 0x0600062d @0x00126e90
	// (iterator <LoadInLocalizedAssets>c__Iterator54 MoveNext token 0x060009cc @0x00153a28)
	// Loads every show logo (Resources, or WWW in the web route), then refreshes once the list exists.
	[DebuggerHidden]
	private IEnumerator LoadInLocalizedAssets(bool web)
	{
		loadingInLocalizedAssets = true;
		foreach (Logo l in logos)
		{
			if (web)
			{
				WWW www = new WWW(StreamManager.PrependRootFileLocation(l.webPath.Text));
				yield return www;
				l.texture = www.texture;
			}
			else
			{
				l.texture = Resources.Load(l.resourcePath.Text, typeof(Texture2D)) as Texture2D;
			}
		}
		loadingInLocalizedAssets = false;
		while (characterList == null)
		{
			yield return null;
		}
		RefreshDisplay();
	}

	// RECUPERADO-AOT CharacterSelectPublisher::SetCharacter token 0x0600062e @0x00126ee8
	// Makes the viewed driver the player's: saves it, updates the shifter icon, plays the "selection" clip and
	// the character's voice line.
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	private void SetCharacter()
	{
		CartPart cartPart = characterList[viewingIndex];
		previousPart = cartPart;
		RefreshCharacter(false);
		DataUtility.Instance.SetCartPart(CartSlot.Slots.character, cartPart.UIName.baseText);
		DataUtility.Instance.Save();
		ShiftUIPublisher.UpdateCharacterIcon(cartPart.UIName.baseText);
		CharacterPreview characterPreview = (CharacterPreview)U4Compat.FindObjectOfType(typeof(CharacterPreview));
		if (!(characterPreview != null))
		{
			return;
		}
		Animation componentInChildren = characterPreview.GetComponentInChildren<Animation>();
		if (componentInChildren != null)
		{
			foreach (AnimationState item in componentInChildren)
			{
				if (item.name.ToLower().Contains("selection"))
				{
					componentInChildren.Play(item.name);
					componentInChildren.wrapMode = WrapMode.Once;
					break;
				}
			}
		}
		CharacterVOController vOController = characterPreview.gameObject.GetVOController();
		if (vOController != null)
		{
			vOController.PlayCharacterSelect();
		}
	}

	// RECUPERADO-AOT CharacterSelectPublisher::RefreshCharacter token 0x0600062f @0x00127314
	private void RefreshCharacter(bool force)
	{
		PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot = characterList[viewingIndex];
		CharacterPreview.Refresh(force);
		RefreshDisplay();
	}

	// RECUPERADO-AOT CharacterSelectPublisher::SetStatBar token 0x06000630 @0x0012739c
	// Neutral (|rating| <= 0.1), negative or positive bar.
	private void SetStatBar(Transform stat, Transform positive, Transform negative, float currentRating)
	{
		if (!(Mathf.Abs(currentRating) > 0.1f))
		{
			stat.gameObject.SetActive(true);
			positive.gameObject.SetActive(false);
			negative.gameObject.SetActive(false);
			Vector3 localScale = stat.localScale;
			localScale.x = 0.75f;
			stat.localScale = localScale;
		}
		else if (currentRating < 0f)
		{
			stat.gameObject.SetActive(false);
			positive.gameObject.SetActive(false);
			negative.gameObject.SetActive(true);
			Vector3 localScale2 = negative.localScale;
			localScale2.x = 0.525f;
			negative.localScale = localScale2;
		}
		else
		{
			stat.gameObject.SetActive(false);
			positive.gameObject.SetActive(true);
			negative.gameObject.SetActive(false);
			Vector3 localScale3 = positive.localScale;
			localScale3.x = 1.575f;
			positive.localScale = localScale3;
		}
		stat.GetComponent<UghSprite>().UpdateMesh();
		positive.GetComponent<UghSprite>().UpdateMesh();
		negative.GetComponent<UghSprite>().UpdateMesh();
	}

	// RECUPERADO-AOT CharacterSelectPublisher::RefreshStatBars token 0x06000631 @0x0012771c (empty)
	private void RefreshStatBars(CartPart curPart, CartPart prevPart)
	{
	}

	// RECUPERADO-AOT CharacterSelectPublisher::RefreshDisplay token 0x06000632 @0x00127750
	// Using (current driver) / Owned (free or unlocked: "Use") / Buy (cost) / Locked (silhouette, "????").
	private void RefreshDisplay()
	{
		CartPart cartPart = characterList[viewingIndex];
		UpdateLogo(cartPart.UIName.baseText);
		base.ughTexts["Object Name"].Text = cartPart.UIName.Text;
		base.transforms["Coin"].gameObject.SetActive(false);
		if (cartPart.UIName.baseText == previousPart.UIName.baseText)
		{
			base.ughButtons["Action Button"].gameObject.SetActive(false);
			base.ughTexts["Action Label"].Text = string.Empty;
			base.ughTexts["Status"].Text = Localize.Get("Using");
			base.ughTexts["Cost"].Text = string.Empty;
			CharacterPreview.Blackout(false);
		}
		else if (CharacterConfigData.GetCharacterCost(cartPart.UIName.baseText) == 0 || DataUtility.Instance.IsUnlocked(cartPart.UIName.baseText))
		{
			base.ughButtons["Action Button"].gameObject.SetActive(true);
			base.ughTexts["Action Label"].Text = Localize.Get("Use");
			base.ughTexts["Status"].Text = Localize.Get("Owned");
			base.ughTexts["Cost"].Text = string.Empty;
			CharacterPreview.Blackout(false);
		}
		else if (CharacterConfigData.GetCharacterCost(cartPart.UIName.baseText) > 0)
		{
			base.ughButtons["Action Button"].gameObject.SetActive(true);
			base.ughTexts["Action Label"].Text = Localize.Get("Buy");
			base.ughTexts["Status"].Text = string.Empty;
			base.ughTexts["Cost"].Text = cartPart.cost.ToString();
			base.transforms["Coin"].gameObject.SetActive(true);
			CharacterPreview.Blackout(false);
		}
		else
		{
			base.ughButtons["Action Button"].gameObject.SetActive(false);
			base.ughTexts["Action Label"].Text = string.Empty;
			base.ughTexts["Cost"].Text = Localize.Get("Locked");
			base.ughTexts["Status"].Text = string.Empty;
			string characterMessage = CharacterConfigData.GetCharacterMessage(cartPart.UIName.baseText);
			if (characterMessage != "ERROR")
			{
				CharacterPreview.Blackout(true);
				base.ughTexts["Object Name"].Text = "????";
			}
		}
	}

	// RECUPERADO-AOT CharacterSelectPublisher::Start token 0x06000633 @0x00127de0
	// (predicate <Start>m__23 token 0x0600063b @0x00128ca0)
	private void Start()
	{
		base.transforms["ShowLogo"].gameObject.SetActive(false);
		characterList = CartPartList.GetSlotPartList(CartSlot.Slots.character);
		previousPart = PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot;
		if (previousPart != null)
		{
			viewingIndex = Array.FindIndex(characterList, (CartPart x) => x.UIName.baseText == previousPart.UIName.baseText);
		}
		if (previousPart == null || viewingIndex == -1)
		{
			viewingIndex = 0;
			SetCharacter();
		}
		else
		{
			RefreshCharacter(false);
		}
		CharacterPreview.Unhide();
	}

	// RECUPERADO-AOT CharacterSelectPublisher::Update token 0x06000634 @0x00127f3c
	private void Update()
	{
		float num = DataUtility.Instance.cloudData.playerMoney;
		if (num > 999999f)
		{
			float num2 = num / 1000000f;
			base.ughTexts["Coins"].Text = num2.ToString("F1") + Localize.Get(" M");
		}
		else
		{
			base.ughTexts["Coins"].Text = num.ToString();
		}
	}

	// RECUPERADO-AOT CharacterSelectPublisher::OnDestroy token 0x06000635 @0x001280c4
	// Leaving without choosing puts the previous driver back.
	private void OnDestroy()
	{
		CharacterPreview.Hide();
		if (previousPart != characterList[viewingIndex] && DataUtility.Exists)
		{
			PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot = previousPart;
			DataUtility.Instance.SetCartPart(CartSlot.Slots.character, previousPart.UIName.baseText);
			CharacterPreview.Refresh(false);
		}
		PreviewCart.GenerateCartPreview();
	}

	// RECUPERADO-AOT CharacterSelectPublisher::PressedRightArrow token 0x06000636 @0x00128184
	private void PressedRightArrow()
	{
		viewingIndex++;
		if (viewingIndex >= characterList.Length)
		{
			viewingIndex = 0;
		}
		RefreshCharacter(false);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CharacterSelectPublisher::PressedLeftArrow token 0x06000637 @0x001281f4
	private void PressedLeftArrow()
	{
		viewingIndex--;
		if (viewingIndex < 0)
		{
			viewingIndex = characterList.Length - 1;
		}
		RefreshCharacter(false);
		SoundLibrary.ButtonClickPlay("menuButton1");
	}

	// RECUPERADO-AOT CharacterSelectPublisher::PressedAction token 0x06000638 @0x00128264
	// "Use" or "Buy" (coins, local wallet).
	// ELIMINADO (analitica): after equipping / buying the original sent GDMOManager.SendWithContext("game_action",
	//     {player_id, context: "UI" | "front_end", action: "equip" | "buy part", type: part name}).
	private void PressedAction()
	{
		if (PreviewCart.IsUpdating)
		{
			return;
		}
		SoundLibrary.ButtonClickPlay("menuButton1");
		CartPart cartPart = characterList[viewingIndex];
		if (CharacterConfigData.GetCharacterCost(cartPart.UIName.baseText) == 0 || DataUtility.Instance.IsUnlocked(cartPart.UIName.baseText))
		{
			SetCharacter();
		}
		else if (DataUtility.Instance.BuyItem(cartPart.UIName.baseText, cartPart.cost))
		{
			SoundLibrary.ButtonClickPlay("buyPart");
			SetCharacter();
		}
	}

	// RECUPERADO-AOT CharacterSelectPublisher::IsTemporary token 0x06000639 @0x00128588
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static bool IsTemporary(CartSlot.Slots slot)
	{
		if (slot != CartSlot.Slots.character)
		{
			return false;
		}
		CharacterSelectPublisher characterSelectPublisher = (CharacterSelectPublisher)U4Compat.FindObjectOfType(typeof(CharacterSelectPublisher));
		if (characterSelectPublisher == null || characterSelectPublisher.viewingIndex == -1)
		{
			return false;
		}
		CartPart cartPart = characterSelectPublisher.characterList[characterSelectPublisher.viewingIndex];
		return cartPart.UIName.baseText != characterSelectPublisher.previousPart.UIName.baseText;
	}

	// RECUPERADO-AOT CharacterSelectPublisher::UpdateLogo token 0x0600063a @0x001286a8
	// Shows the logo of the character's show (string switch <>f__switch$map2).
	private void UpdateLogo(string character)
	{
		if (loadingInLocalizedAssets)
		{
			return;
		}
		GameObject gameObject = base.transforms["ShowLogo"].gameObject;
		if (gameObject == null)
		{
			UnityEngine.Debug.LogError("No ShowLogo Transform to swap textures on!");
			return;
		}
		Material material = gameObject.GetComponent<Renderer>().material;
		if (material == null)
		{
			UnityEngine.Debug.LogError("Somehow there is no render material on the showLogo object!");
			return;
		}
		string text = string.Empty;
		switch (character)
		{
		case "Agent P":
		case "Ferb":
		case "Phineas":
			text = "Phineas";
			break;
		case "Mabel":
		case "Dipper":
		case "Soos":
			text = "Gravity";
			break;
		case "Milo":
		case "Oscar":
		case "Bea":
			text = "Fish";
			break;
		case "Kick":
		case "Brad":
		case "Gunther":
			text = "Kick";
			break;
		case "Mike":
			text = "Motorcity";
			break;
		case "Randy":
			text = "Randy";
			break;
		case "Crash":
			text = "Crash";
			break;
		default:
			UnityEngine.Debug.LogWarning("Not a valid show to have a logo!");
			break;
		}
		if (text == string.Empty)
		{
			UnityEngine.Debug.LogWarning("Something is wrong with the Logo!!");
			return;
		}
		foreach (Logo logo in logos)
		{
			if (logo.name == text)
			{
				material.mainTexture = logo.texture;
				gameObject.SetActive(true);
				return;
			}
		}
		UnityEngine.Debug.LogWarning("If you got here that means there was no matching logoName and Localized Texture!");
	}
}
