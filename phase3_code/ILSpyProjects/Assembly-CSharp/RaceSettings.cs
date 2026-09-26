using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class RaceSettings : MonoBehaviour
{
	public enum RaceModes
	{
		Campaign,
		Mission,
		Elimination
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public RaceModes RaceType
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	private StreamManager.AssetCluster GatherRequiredAssets()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void DetermineAICars()
	{
	}

	[DebuggerHidden]
	private IEnumerator CleanupCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
