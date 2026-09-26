using System.Collections;
using System.Collections.Generic;

public class GameCenterPlayer
{
	public string playerId;

	public string alias;

	public bool isFriend;

	public GameCenterPlayer(Hashtable ht)
	{
	}

	public static List<GameCenterPlayer> fromJSON(string json)
	{
		return default(List<GameCenterPlayer>);
	}

	public override string ToString()
	{
		return default(string);
	}
}
