using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

// One race definition (prefab per track): scene, laps, AI count, missions, base difficulty. Chooses the AI
// characters, gathers the kart/AI assets for the Loading screen and starts the race once the track is loaded.
// Source listing: recovery/aot_listings/Assembly-CSharp/RaceSettings.txt
public class RaceSettings : MonoBehaviour
{
	public enum RaceModes
	{
		Campaign = 0,
		Mission = 1,
		Elimination = 2
	}

	[Serializable]
	public class AICartSettings
	{
		public string characterName;

		public string assetName;

		public string bundlePath;

		public string resourcePath;
	}

	// RECUPERADO-AOT RaceSettings::.cctor token 0x0600055c @0x00113dc4
	public static UnlocalizedString LOADING_GUI_NAME = new UnlocalizedString("LoadingGUI");

	// RECUPERADO-AOT RaceSettings::.ctor token 0x0600055b @0x00113ab8 (field initializers)
	private UnlocalizedString[] characterNames = new UnlocalizedString[13]
	{
		"Agent P", "Bea", "Brad", "Dipper", "Ferb", "Gunther", "Kick", "Mabel", "Mike", "Milo",
		"Oscar", "Phineas", "Randy"
	};

	public LocalizedString UIName;

	public UnlocalizedString levelName = new UnlocalizedString("Game");

	public RaceModes raceType;

	public int numLaps = 3;

	public int numberAICars;

	public BaseMission[] missions;

	public bool useTouchTurnTrack;

	public int lapNumber = -1;

	public RaceManager.RaceDifficultyLevel baseDifficulty;

	private AICartSettings[] aiCarts;

	// RECUPERADO-AOT RaceSettings::get_AICarts token 0x0600055d @0x00113e38
	public AICartSettings[] AICarts
	{
		get
		{
			return aiCarts;
		}
	}

	// RECUPERADO-AOT RaceSettings::get_RaceType token 0x0600055e @0x00113e6c
	// RECUPERADO-AOT RaceSettings::set_RaceType token 0x0600055f @0x00113ea0
	public RaceModes RaceType
	{
		get
		{
			return raceType;
		}
		set
		{
			raceType = value;
		}
	}

	// RECUPERADO-AOT RaceSettings::GatherRequiredAssets token 0x06000560 @0x00113edc
	// Player kart parts and AI karts (plus paint bundles in the web route).
	// ADAPTADO-U6: Application.isWebPlayer (always false) dropped; the bundle route still follows forceWebPlayer.
	private StreamManager.AssetCluster GatherRequiredAssets()
	{
		StreamManager.AssetCluster assetCluster = new StreamManager.AssetCluster();
		CartSlot[] cartSlots = PlayerInstance.Instance.cartSlots;
		foreach (CartSlot cartSlot in cartSlots)
		{
			if (cartSlot.partInSlot != null && cartSlot.partInSlot.bundlePath.baseText.Length > 0)
			{
				if (DataUtility.Instance.forceWebPlayer)
				{
					assetCluster.AddAsset(cartSlot.partInSlot.UIName.baseText, DataUtility.PrependBundlePath(cartSlot.partInSlot.bundlePath.baseText), StreamManager.StreamType.ASSET_BUNDLE);
				}
				else
				{
					assetCluster.AddAsset(cartSlot.partInSlot.UIName.baseText, cartSlot.partInSlot.resourcePath.baseText, StreamManager.StreamType.RESOURCE);
				}
			}
			if (DataUtility.Instance.forceWebPlayer && cartSlot.slotPaint != null && cartSlot.slotPaint.multilayerTexture.bundlePath.Length > 0)
			{
				assetCluster.AddAsset(cartSlot.slotPaint.multilayerTexture.name, DataUtility.PrependBundlePath(cartSlot.slotPaint.multilayerTexture.bundlePath), StreamManager.StreamType.ASSET_BUNDLE);
			}
		}
		AICartSettings[] array = aiCarts;
		foreach (AICartSettings aICartSettings in array)
		{
			if (DataUtility.Instance.forceWebPlayer)
			{
				assetCluster.AddAsset(aICartSettings.assetName, DataUtility.PrependBundlePath(aICartSettings.bundlePath), StreamManager.StreamType.ASSET_BUNDLE);
			}
			else
			{
				assetCluster.AddAsset(aICartSettings.assetName, aICartSettings.resourcePath, StreamManager.StreamType.RESOURCE);
			}
		}
		return assetCluster;
	}

	// RECUPERADO-AOT RaceSettings::DetermineAICars token 0x06000561 @0x001141b4
	// (predicates <DetermineAICars>c__AnonStorey97::<>m__16 token 0x06000b42, <DetermineAICars>m__17 token 0x06000567,
	//  <DetermineAICars>m__18 token 0x06000568)
	// Random distinct opponents, never the player's character; Agent P never races together with Phineas or Ferb.
	private void DetermineAICars()
	{
		aiCarts = new AICartSettings[numberAICars];
		string baseText = PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot.UIName.baseText;
		for (int i = 0; i < numberAICars; i++)
		{
			string aiName = characterNames[UnityEngine.Random.Range(0, characterNames.Length)].baseText;
			if (aiName == baseText)
			{
				i--;
				continue;
			}
			if (Array.Exists(aiCarts, (AICartSettings x) => x != null && x.characterName == aiName))
			{
				i--;
				continue;
			}
			if (aiName == "Agent P" && (Array.Exists(aiCarts, (AICartSettings x) => x != null && (x.characterName == "Ferb" || x.characterName == "Phineas")) || baseText == "Ferb" || baseText == "Phineas"))
			{
				i--;
				continue;
			}
			if ((aiName == "Ferb" || aiName == "Phineas") && (Array.Exists(aiCarts, (AICartSettings x) => x != null && x.characterName == "Agent P") || baseText == "Agent P"))
			{
				i--;
				continue;
			}
			AICartSettings aICartSettings = new AICartSettings();
			aICartSettings.characterName = aiName;
			aICartSettings.assetName = aiName.Replace(" ", string.Empty) + "_AI";
			aICartSettings.bundlePath = aICartSettings.assetName + ".unity3d";
			aICartSettings.resourcePath = "Cart Assets/AI Carts/" + aICartSettings.assetName;
			aiCarts[i] = aICartSettings;
		}
	}

	// RECUPERADO-AOT RaceSettings::CleanupCoroutine token 0x06000562 @0x00114660
	// (iterator <CleanupCoroutine>c__Iterator48 MoveNext token 0x06000984 @0x00150724)
	[DebuggerHidden]
	private IEnumerator CleanupCoroutine()
	{
		yield return new WaitForEndOfFrame();
		StreamManager.Cleanup();
	}

	// RECUPERADO-AOT RaceSettings::Awake token 0x06000563 @0x001146a0
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// RECUPERADO-AOT RaceSettings::StartBundleLoads token 0x06000564 @0x001146d8
	public void StartBundleLoads()
	{
		GameObject gameObject = GameObject.Find(LOADING_GUI_NAME.baseText);
		if (gameObject == null)
		{
			UnityEngine.Debug.LogError("Could not find loadingGUI!!!");
			return;
		}
		if (aiCarts == null)
		{
			DetermineAICars();
		}
		StreamManager.AssetCluster assetCluster = GatherRequiredAssets();
		assetCluster.Preload();
		LoadingPublisher component = gameObject.GetComponent<LoadingPublisher>();
		component.SetAssetCluster(assetCluster);
	}

	// RECUPERADO-AOT RaceSettings::Launch token 0x06000565 @0x001147b0
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	public void Launch()
	{
		UnityEngine.Object[] array = U4Compat.FindObjectsOfType(typeof(DebugTrackStrapper));
		for (int i = 0; i < array.Length; i++)
		{
			DebugTrackStrapper debugTrackStrapper = (DebugTrackStrapper)array[i];
			UnityEngine.Debug.Log("RaceSettings found and killed a DebugTrackStrapper");
			UnityEngine.Object.Destroy(debugTrackStrapper.gameObject);
		}
		RaceManager.InitRace(lapNumber);
		StartCoroutine(CleanupCoroutine());
	}

	// RECUPERADO-AOT RaceSettings::GetCircuit token 0x06000566 @0x001148cc
	// 1, 2 or 3 = first, second or third track of a world (string switch <>f__switch$map1); 0 otherwise.
	public int GetCircuit()
	{
		UnityEngine.Debug.Log("Settings Name:" + base.name);
		string text = base.name.Replace("(Clone)", string.Empty);
		if (text != null)
		{
			switch (text)
			{
			case "Kick Butt!":
			case "Doof's Tower":
			case "Freshwater High":
				return 1;
			case "Bus Jumper":
			case "Danville River":
			case "Hokey Poke":
				return 2;
			case "Dirt Devils":
			case "Danville Arena":
			case "Fishtankia":
				return 3;
			}
		}
		return 0;
	}
}
