using UnityEngine;

public class LocalOptionsData
{
	public float musicVolumeLevel;

	public float sfxVolumeLevel;

	public bool appPurchases;

	public RaceManager.RaceDifficultyLevel raceDifficulty;

	public GameObject[] selectedCircuitTracks;

	public string circuitName;

	public LocalOptionsData(float musicVolume, float sfxVolume, bool _appPurchases, RaceManager.RaceDifficultyLevel difficulty)
	{
		RecoveryPending.Hit("LocalOptionsData..ctor");
	}

	public void Save()
	{
		RecoveryPending.Hit("LocalOptionsData.Save");
	}

	public void Load()
	{
		RecoveryPending.Hit("LocalOptionsData.Load");
	}
}
