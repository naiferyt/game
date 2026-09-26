using System.Collections.Generic;

public class GameCenterLeaderboard
{
	public string leaderboardId;

	public string title;

	public GameCenterLeaderboard(string leaderboardId, string title)
	{
	}

	public static List<GameCenterLeaderboard> fromJSON(string json)
	{
		return default(List<GameCenterLeaderboard>);
	}

	public override string ToString()
	{
		return default(string);
	}
}
