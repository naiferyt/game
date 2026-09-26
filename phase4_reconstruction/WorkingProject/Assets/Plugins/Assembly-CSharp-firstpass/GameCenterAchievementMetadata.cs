using System.Collections;
using System.Collections.Generic;

public class GameCenterAchievementMetadata
{
	public string identifier;

	public string description;

	public string unachievedDescription;

	public bool isHidden;

	public int maximumPoints;

	public string title;

	public GameCenterAchievementMetadata(Hashtable ht)
	{
	}

	public static List<GameCenterAchievementMetadata> fromJSON(string json)
	{
		return default(List<GameCenterAchievementMetadata>);
	}

	public override string ToString()
	{
		return default(string);
	}
}
