using System;
using System.Collections;
using System.Collections.Generic;

public class GameCenterAchievement
{
	public string identifier;

	public bool isHidden;

	public bool completed;

	public DateTime lastReportedDate;

	public float percentComplete;

	public GameCenterAchievement(Hashtable ht)
	{
	}

	public static List<GameCenterAchievement> fromJSON(string json)
	{
		return default(List<GameCenterAchievement>);
	}

	public override string ToString()
	{
		return default(string);
	}
}
