using UnityEngine;

// Per-device options (volumes, difficulty), kept in PlayerPrefs as in the original.
// Source listing: recovery/aot_listings/Assembly-CSharp/LocalOptionsData.txt
public class LocalOptionsData
{
	public float musicVolumeLevel;

	public float sfxVolumeLevel;

	public bool appPurchases;

	public RaceManager.RaceDifficultyLevel raceDifficulty;

	public GameObject[] selectedCircuitTracks;

	public string circuitName;

	// RECUPERADO-AOT LocalOptionsData..ctor token 0x06000252 @0x000e604c
	public LocalOptionsData(float musicVolume, float sfxVolume, bool _appPurchases, RaceManager.RaceDifficultyLevel difficulty)
	{
		musicVolumeLevel = musicVolume;
		sfxVolumeLevel = sfxVolume;
		appPurchases = _appPurchases;
		raceDifficulty = difficulty;
		selectedCircuitTracks = null;
	}

	// RECUPERADO-AOT LocalOptionsData.Save token 0x06000253 @0x000e60c4
	public void Save()
	{
		PlayerPrefs.SetFloat("musicVolumeLevel", musicVolumeLevel);
		PlayerPrefs.SetFloat("sfxVolumeLevel", sfxVolumeLevel);
		PlayerPrefs.SetInt("appPurchases", appPurchases ? 1 : 0);
		PlayerPrefs.SetInt("raceDifficulty", (int)raceDifficulty);
	}

	// RECUPERADO-AOT LocalOptionsData.Load token 0x06000254 @0x000e6190
	public void Load()
	{
		if (PlayerPrefs.HasKey("musicVolumeLevel"))
		{
			musicVolumeLevel = PlayerPrefs.GetFloat("musicVolumeLevel");
		}
		if (PlayerPrefs.HasKey("sfxVolumeLevel"))
		{
			sfxVolumeLevel = PlayerPrefs.GetFloat("sfxVolumeLevel");
		}
		if (PlayerPrefs.HasKey("appPurchases"))
		{
			appPurchases = PlayerPrefs.GetInt("appPurchases") == 1;
		}
		if (PlayerPrefs.HasKey("raceDifficulty"))
		{
			raceDifficulty = (RaceManager.RaceDifficultyLevel)PlayerPrefs.GetInt("raceDifficulty");
		}
	}
}
