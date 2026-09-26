using System;
using System.Collections;
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
			return default(AICartSettings[]);
		}
	}

	public RaceModes RaceType
	{
		get
		{
			return default(RaceModes);
		}
		set
		{
		}
	}

	private StreamManager.AssetCluster GatherRequiredAssets()
	{
		return default(StreamManager.AssetCluster);
	}

	private void DetermineAICars()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CleanupCoroutine()
	{
		return default(IEnumerator);
	}

	private void Awake()
	{
	}

	public void StartBundleLoads()
	{
	}

	public void Launch()
	{
	}

	public int GetCircuit()
	{
		return default(int);
	}
}
