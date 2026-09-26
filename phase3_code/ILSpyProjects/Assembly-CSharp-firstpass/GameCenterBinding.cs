using System.Runtime.InteropServices;

public class GameCenterBinding
{
	[DllImport("__Internal")]
	private static extern bool _gameCenterIsGameCenterAvailable();

	public static bool isGameCenterAvailable()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterAuthenticateLocalPlayer();

	public static void authenticateLocalPlayer()
	{
	}

	[DllImport("__Internal")]
	private static extern bool _gameCenterIsPlayerAuthenticated();

	public static bool isPlayerAuthenticated()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern string _gameCenterPlayerAlias();

	public static string playerAlias()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern string _gameCenterPlayerIdentifier();

	public static string playerIdentifier()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern bool _gameCenterIsUnderage();

	public static bool isUnderage()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterRetrieveFriends(bool loadProfileImages);

	public static void retrieveFriends(bool loadProfileImages)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterLoadPlayerData(string playerIds, bool loadProfileImages);

	public static void loadPlayerData(string[] playerIdArray, bool loadProfileImages)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterLoadProfilePhotoForLocalPlayer();

	public static void loadProfilePhotoForLocalPlayer()
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterLoadLeaderboardLeaderboardTitles();

	public static void loadLeaderboardTitles()
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterReportScore(long score, string leaderboardId);

	public static void reportScore(long score, string leaderboardId)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterShowLeaderboardWithTimeScope(int timeScope);

	public static void showLeaderboardWithTimeScope(GameCenterLeaderboardTimeScope timeScope)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterShowLeaderboardWithTimeScopeAndLeaderboardId(int timeScope, string leaderboardId);

	public static void showLeaderboardWithTimeScopeAndLeaderboard(GameCenterLeaderboardTimeScope timeScope, string leaderboardId)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterRetrieveScores(bool friendsOnly, int timeScope, int start, int end);

	public static void retrieveScores(bool friendsOnly, GameCenterLeaderboardTimeScope timeScope, int start, int end)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterRetrieveScoresForLeaderboard(bool friendsOnly, int timeScope, int start, int end, string leaderboardId);

	public static void retrieveScores(bool friendsOnly, GameCenterLeaderboardTimeScope timeScope, int start, int end, string leaderboardId)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterRetrieveScoresForPlayerId(string playerId);

	public static void retrieveScoresForPlayerId(string playerId)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterRetrieveScoresForPlayerIdAndLeaderboard(string playerId, string leaderboardId);

	public static void retrieveScoresForPlayerId(string playerId, string leaderboardId)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterReportAchievement(string identifier, float percent);

	public static void reportAchievement(string identifier, float percent)
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterGetAchievements();

	public static void getAchievements()
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterResetAchievements();

	public static void resetAchievements()
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterShowAchievements();

	public static void showAchievements()
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterRetrieveAchievementMetadata();

	public static void retrieveAchievementMetadata()
	{
	}

	[DllImport("__Internal")]
	private static extern void _gameCenterShowCompletionBannerForAchievements();

	public static void showCompletionBannerForAchievements()
	{
	}
}
