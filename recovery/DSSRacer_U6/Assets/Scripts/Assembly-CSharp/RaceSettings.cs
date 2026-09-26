using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

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

	public static UnlocalizedString LOADING_GUI_NAME;

	private UnlocalizedString[] characterNames;

	public LocalizedString UIName;

	public UnlocalizedString levelName;

	public RaceModes raceType;

	public int numLaps;

	public int numberAICars;

	public BaseMission[] missions;

	public bool useTouchTurnTrack;

	public int lapNumber;

	public RaceManager.RaceDifficultyLevel baseDifficulty;

	private AICartSettings[] aiCarts;

	public AICartSettings[] AICarts
	{
		get
		{
			RecoveryPending.Hit("RaceSettings.get_AICarts");
			return default(AICartSettings[]);
		}
	}

	public RaceModes RaceType
	{
		get
		{
			RecoveryPending.Hit("RaceSettings.get_RaceType");
			return default(RaceModes);
		}
		set
		{
			RecoveryPending.Hit("RaceSettings.set_RaceType");
		}
	}

	private StreamManager.AssetCluster GatherRequiredAssets()
	{
		RecoveryPending.Hit("RaceSettings.GatherRequiredAssets");
		return default(StreamManager.AssetCluster);
	}

	private void DetermineAICars()
	{
		RecoveryPending.Hit("RaceSettings.DetermineAICars");
	}

	[DebuggerHidden]
	private IEnumerator CleanupCoroutine()
	{
		RecoveryPending.Hit("RaceSettings.CleanupCoroutine");
		yield break;
	}

	private void Awake()
	{
		RecoveryPending.Hit("RaceSettings.Awake");
	}

	public void StartBundleLoads()
	{
		RecoveryPending.Hit("RaceSettings.StartBundleLoads");
	}

	public void Launch()
	{
		RecoveryPending.Hit("RaceSettings.Launch");
	}

	public int GetCircuit()
	{
		RecoveryPending.Hit("RaceSettings.GetCircuit");
		return default(int);
	}
}
