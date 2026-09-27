using UnityEngine;

// Base of the in-game achievements: state machine, reward (coins + unlocks) and "achieved" flag kept as an unlock.
// Source listing: recovery/aot_listings/Assembly-CSharp/AchievementListener.txt
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
		// RECUPERADO-AOT AchievementListener::get_State token 0x060000ad @0x000cf76c
		get
		{
			return state;
		}
	}

	public abstract bool IsAvailable();

	public abstract void Prerace();

	public abstract void Postrace();

	public abstract void Reward();

	// RECUPERADO-AOT AchievementListener::FilterCategory token 0x060000b2 @0x000cf7a0
	public AchievementFilterCategory FilterCategory()
	{
		return categoryFilter;
	}

	// RECUPERADO-AOT AchievementListener::Activate token 0x060000b3 @0x000cf7d4
	protected void Activate()
	{
		state = AchievementState.ACTIVE;
	}

	// RECUPERADO-AOT AchievementListener::Achieve token 0x060000b4 @0x000cf80c
	protected void Achieve()
	{
		state = AchievementState.PASS;
		AchievementManager.Instance.Achieve(this);
		if (rewardCoins > 0)
		{
			DataUtility.Instance.AddPlayerMoney(rewardCoins);
		}
		if (rewardUnlocks != null && rewardUnlocks.Length > 0)
		{
			for (int i = 0; i < rewardUnlocks.Length; i++)
			{
				DataUtility.Instance.Unlock(rewardUnlocks[i]);
			}
		}
	}

	// RECUPERADO-AOT AchievementListener::Fail token 0x060000b5 @0x000cf8fc
	protected void Fail()
	{
		state = AchievementState.FAIL;
		AchievementManager.Instance.Fail(this);
	}

	// RECUPERADO-AOT AchievementListener::GetUnlockName token 0x060000b6 @0x000cf948
	public string GetUnlockName()
	{
		return GetType().ToString() + " " + UIName;
	}

	// RECUPERADO-AOT AchievementListener::HasAchieved token 0x060000b7 @0x000cf9ac
	public bool HasAchieved()
	{
		return DataUtility.Instance.IsUnlocked(GetUnlockName());
	}
}
