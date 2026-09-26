using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// "Loading" scene GUI: preloads the kart/AI assets, loads the track scene, builds the player kart, shows the
// race missions and waits for "Go" to launch the race.
// Source listing: recovery/aot_listings/Assembly-CSharp/LoadingPublisher.txt
public class LoadingPublisher : UghPublisher
{
	private StreamManager.AssetCluster watchCluster;

	private RaceSettings settings;

	private bool goHasAlreadyBeenPressed;

	// RECUPERADO-AOT LoadingPublisher::WaitForAssetBundles token 0x06000698 @0x0012df6c
	// (iterator <WaitForAssetBundles>c__Iterator5E MoveNext token 0x06000a08 @0x00155cb0)
	[DebuggerHidden]
	private IEnumerator WaitForAssetBundles()
	{
		base.ughTexts["progress"].Text = Localize.Get("waiting");
		while (watchCluster == null)
		{
			yield return null;
		}
		while (!watchCluster.isDone)
		{
			base.ughTexts["progress"].Text = Localize.Get("Parts: ") + Mathf.RoundToInt(watchCluster.progress * 100f) + "%";
			yield return new WaitForSeconds(0.25f);
		}
	}

	// RECUPERADO-AOT LoadingPublisher::WaitForCartConstruction token 0x06000699 @0x0012dfb4
	// (iterator <WaitForCartConstruction>c__Iterator5F MoveNext token 0x06000a0e @0x00155fec)
	[DebuggerHidden]
	private IEnumerator WaitForCartConstruction()
	{
		base.ughTexts["progress"].Text = Localize.Get("Getting the cart ready...");
		yield return StartCoroutine(PlayerInstance.ConstructCart());
	}

	// RECUPERADO-AOT LoadingPublisher::WaitForLevelLoad token 0x0600069a @0x0012dffc
	// (iterator <WaitForLevelLoad>c__Iterator60 MoveNext token 0x06000a14 @0x001561f4)
	// ADAPTADO-U6: Application.LoadLevelAsync -> SceneManager.LoadSceneAsync.
	// (The original shows the asset cluster's progress here too, not the scene's.)
	[DebuggerHidden]
	private IEnumerator WaitForLevelLoad()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(settings.levelName.baseText);
		while (!async.isDone)
		{
			base.ughTexts["progress"].Text = Localize.Get("Track: ") + Mathf.RoundToInt(watchCluster.progress * 100f) + "%";
			yield return new WaitForSeconds(0.25f);
		}
	}

	// RECUPERADO-AOT LoadingPublisher::SetupMissionText token 0x0600069b @0x0012e044
	// (iterator <SetupMissionText>c__Iterator61 MoveNext token 0x06000a1a @0x001564d4)
	// Fills up to three "Mission Slot" panels with the race's active achievements; no achievements -> tutorial logo.
	[DebuggerHidden]
	private IEnumerator SetupMissionText()
	{
		if (DataUtility.Instance.CurSettings.levelName.baseText == "Tutorial")
		{
			yield break;
		}
		AchievementManager.Instance.ChooseActiveListeners();
		yield return null;
		AchievementListener[] listenerList = AchievementManager.Instance.activeListeners;
		if (listenerList == null)
		{
			yield break;
		}
		for (int index = 0; index < Mathf.Min(3, listenerList.Length); index++)
		{
			if (index < listenerList.Length)
			{
				base.transforms["Mission Slot " + (index + 1)].gameObject.SetActive(true);
				base.ughTexts["Mission " + (index + 1) + " Name"].Text = listenerList[index].UIName.Text;
				base.ughTexts["Mission " + (index + 1) + " Text"].Text = listenerList[index].description.Text;
				if (listenerList[index].rewardCoins > 0)
				{
					base.ughTexts["Mission " + (index + 1) + " Prize"].Text = listenerList[index].rewardCoins.ToString();
				}
				else
				{
					base.transforms["Mission " + (index + 1) + " Prize"].gameObject.SetActive(false);
				}
			}
			yield return null;
		}
		if (AchievementManager.Instance != null && AchievementManager.Instance.activeListeners.Length <= 0)
		{
			base.transforms["Tutorial Logo"].gameObject.SetActive(true);
		}
	}

	// RECUPERADO-AOT LoadingPublisher::LoadingProcess token 0x0600069c @0x0012e08c
	// (iterator <LoadingProcess>c__Iterator62 MoveNext token 0x06000a20 @0x00156b40)
	// Order: missions, track scene, kart assets, kart construction; then fade the "Go" button in.
	[DebuggerHidden]
	private IEnumerator LoadingProcess()
	{
		yield return new WaitForSeconds(1f);
		yield return StartCoroutine(SetupMissionText());
		yield return StartCoroutine(WaitForLevelLoad());
		yield return StartCoroutine(WaitForAssetBundles());
		yield return StartCoroutine(WaitForCartConstruction());
		base.ughTexts["progress"].Text = Localize.Get("Ready!");
		Transform ughButtonContainer = base.transforms["Go Button Container"];
		ughButtonContainer.gameObject.SetActive(true);
		base.ughButtons["Go Button"].gameObject.SetActive(true);
		FadeHelper.Instance.SetOpacityRecursively(ughButtonContainer, 0f);
		FadeHelper.Instance.FadeRecursively(ughButtonContainer, 0.4f, true);
		Transform loadingContainer = base.transforms["Loading Info Container"];
		FadeHelper.Instance.FadeRecursively(loadingContainer, 0.4f, false);
	}

	// RECUPERADO-AOT LoadingPublisher::FadeAndDestroyCoroutine token 0x0600069d @0x0012e0d4
	// (iterator <FadeAndDestroyCoroutine>c__Iterator63 MoveNext token 0x06000a26 @0x00156fd4)
	[DebuggerHidden]
	private IEnumerator FadeAndDestroyCoroutine()
	{
		ScreenFader.Instance.FadeOut();
		yield return new WaitForSeconds(1f);
		settings.Launch();
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT LoadingPublisher::Start token 0x0600069e @0x0012e11c
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		base.transforms["Tutorial Logo"].gameObject.SetActive(false);
		base.ughButtons["Go Button"].gameObject.SetActive(false);
		settings = DataUtility.Instance.CurSettings;
		base.transforms["Mission Slot 1"].gameObject.SetActive(false);
		base.transforms["Mission Slot 2"].gameObject.SetActive(false);
		base.transforms["Mission Slot 3"].gameObject.SetActive(false);
		if (settings.levelName.baseText == "Tutorial")
		{
			AchievementManager.Instance.ClearActiveListeners();
			base.ughTexts["Header"].Text = string.Empty;
			base.transforms["Tutorial Logo"].gameObject.SetActive(true);
		}
		settings.StartBundleLoads();
		// The original creates this iterator without starting it (no effect); LoadingProcess runs it.
		SetupMissionText();
		StartCoroutine(LoadingProcess());
	}

	// RECUPERADO-AOT LoadingPublisher::Update token 0x0600069f @0x0012e3a4 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT LoadingPublisher::PressedGoButton token 0x060006a0 @0x0012e3d0
	private void PressedGoButton()
	{
		base.ughButtons["Go Button"].gameObject.SetActive(false);
		if (watchCluster.isDone && !goHasAlreadyBeenPressed)
		{
			if (settings == null)
			{
				UnityEngine.Debug.LogError("Loading done, but there are no race settings!");
				return;
			}
			goHasAlreadyBeenPressed = true;
			StartCoroutine(FadeAndDestroyCoroutine());
		}
	}

	// RECUPERADO-AOT LoadingPublisher::SetAssetCluster token 0x060006a1 @0x0012e4b4
	public void SetAssetCluster(StreamManager.AssetCluster cluster)
	{
		watchCluster = cluster;
	}
}
