using UnityEngine;

public abstract class AchievementListener : MonoBehaviour
{
	public enum AchievementState
	{
		UNKNOWN = 0,
		ACTIVE = 1,
		PASS = 2,
		FAIL = 3
	}

	public enum AchievementAreaType
	{
		IN_RACE = 0,
		FRONT_END = 1,
		ANYWHERE = 2
	}

	public enum AchievementFilterCategory
	{
		UNKNOWN = 0,
		TRACKS = 1,
		COINS = 2,
		POWERUPS = 3,
		STUNTS = 4
	}

	public LocalizedString UIName;

	public LocalizedString description;

	public LocalizedString rewardDescription;

	public AchievementAreaType areaType;

	public int rewardCoins;

	public string[] rewardUnlocks;

	public AchievementFilterCategory categoryFilter;

	public UnlocalizedString gcIdentifier;

	protected AchievementState state;

	public AchievementState State
	{
		get
		{
			return default(AchievementState);
		}
	}

	public abstract bool IsAvailable();

	public abstract void Prerace();

	public abstract void Postrace();

	public abstract void Reward();

	public AchievementFilterCategory FilterCategory()
	{
		return default(AchievementFilterCategory);
	}

	protected void Activate()
	{
	}

	protected void Achieve()
	{
	}

	protected void Fail()
	{
	}

	public string GetUnlockName()
	{
		return default(string);
	}

	public bool HasAchieved()
	{
		return default(bool);
	}
}
