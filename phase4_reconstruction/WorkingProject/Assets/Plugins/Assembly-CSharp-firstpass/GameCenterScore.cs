using System;
using System.Collections;
using System.Collections.Generic;

public class GameCenterScore
{
	public string category;

	public string formattedValue;

	public long value;

	public DateTime date;

	public string playerId;

	public int rank;

	public bool isFriend;

	public string alias;

	public int maxRange;

	public GameCenterScore(Hashtable ht)
	{
	}

	public static List<GameCenterScore> fromJSON(string json)
	{
		return default(List<GameCenterScore>);
	}

	public override string ToString()
	{
		return default(string);
	}
}
