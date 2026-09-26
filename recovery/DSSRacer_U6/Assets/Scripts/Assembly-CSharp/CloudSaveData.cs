using System.Collections.Generic;

// The player's progress. DataUtility saves each public field under its own name (see DataUtility.Load/Save).
// Source listing: recovery/aot_listings/Assembly-CSharp/CloudSaveData.txt
public class CloudSaveData
{
	// RECUPERADO-AOT CloudSaveData..ctor token 0x06000255 @0x000e62b0 (field initializers)
	public int cloudSaveDataVersion = 1;

	public int playerMoney;

	public long timeStamp = long.MinValue;

	public int bonusCount;

	public bool useTutorial = true;

	public Dictionary<string, string> unlockDictionary = new Dictionary<string, string>();

	public Dictionary<string, string> playerCartParts;

	public Dictionary<string, string> playerPaintJob;

	public static int CurrentCloudSaveDataVersion
	{
		// RECUPERADO-AOT CloudSaveData.get_CurrentCloudSaveDataVersion token 0x06000256 @0x000e6320
		get
		{
			return 1;
		}
	}
}
