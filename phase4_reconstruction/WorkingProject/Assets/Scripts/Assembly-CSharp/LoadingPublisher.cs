using System.Collections;

public class LoadingPublisher : UghPublisher
{
	private StreamManager.AssetCluster watchCluster;

	private RaceSettings settings;

	private bool goHasAlreadyBeenPressed;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator WaitForAssetBundles()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator WaitForCartConstruction()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator WaitForLevelLoad()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator SetupMissionText()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadingProcess()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator FadeAndDestroyCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void PressedGoButton()
	{
	}

	public void SetAssetCluster(StreamManager.AssetCluster cluster)
	{
	}
}
