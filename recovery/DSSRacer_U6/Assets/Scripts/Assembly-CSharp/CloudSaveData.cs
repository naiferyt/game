using System.Collections.Generic;

public class CloudSaveData
{
	public int cloudSaveDataVersion;

	public int playerMoney;

	public long timeStamp;

	public int bonusCount;

	public bool useTutorial;

	public Dictionary<string, string> unlockDictionary;

	public Dictionary<string, string> playerCartParts;

	public Dictionary<string, string> playerPaintJob;

	public static int CurrentCloudSaveDataVersion
	{
		get
		{
			RecoveryPending.Hit("CloudSaveData.get_CurrentCloudSaveDataVersion");
			return default(int);
		}
	}
}
