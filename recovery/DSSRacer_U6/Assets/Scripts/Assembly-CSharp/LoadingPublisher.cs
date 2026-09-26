using System.Collections;
using System.Diagnostics;

public class LoadingPublisher : UghPublisher
{
	private StreamManager.AssetCluster watchCluster;

	private RaceSettings settings;

	private bool goHasAlreadyBeenPressed;

	[DebuggerHidden]
	private IEnumerator WaitForAssetBundles()
	{
		RecoveryPending.Hit("LoadingPublisher.WaitForAssetBundles");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator WaitForCartConstruction()
	{
		RecoveryPending.Hit("LoadingPublisher.WaitForCartConstruction");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator WaitForLevelLoad()
	{
		RecoveryPending.Hit("LoadingPublisher.WaitForLevelLoad");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator SetupMissionText()
	{
		RecoveryPending.Hit("LoadingPublisher.SetupMissionText");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator LoadingProcess()
	{
		RecoveryPending.Hit("LoadingPublisher.LoadingProcess");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator FadeAndDestroyCoroutine()
	{
		RecoveryPending.Hit("LoadingPublisher.FadeAndDestroyCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("LoadingPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("LoadingPublisher.Update");
	}

	private void PressedGoButton()
	{
		RecoveryPending.Hit("LoadingPublisher.PressedGoButton");
	}

	public void SetAssetCluster(StreamManager.AssetCluster cluster)
	{
		RecoveryPending.Hit("LoadingPublisher.SetAssetCluster");
	}
}
