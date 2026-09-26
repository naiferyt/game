using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameCenterManager : MonoBehaviour
{
	public static event Action<string> loadPlayerDataFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<List<GameCenterPlayer>> playerDataLoaded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action playerAuthenticated
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> playerFailedToAuthenticate
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action playerLoggedOut
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> profilePhotoLoaded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> profilePhotoFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> loadCategoryTitlesFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<List<GameCenterLeaderboard>> categoriesLoaded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> reportScoreFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> reportScoreFinished
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> retrieveScoresFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<List<GameCenterScore>> scoresLoaded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> retrieveScoresForPlayerIdFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<List<GameCenterScore>> scoresForPlayerIdLoaded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> reportAchievementFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> reportAchievementFinished
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> loadAchievementsFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<List<GameCenterAchievement>> achievementsLoaded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> resetAchievementsFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action resetAchievementsFinished
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<string> retrieveAchievementMetadataFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<List<GameCenterAchievementMetadata>> achievementMetadataLoaded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void loadPlayerDataDidFail(string error)
	{
	}

	public void loadPlayerDataDidLoad(string jsonFriendList)
	{
	}

	public void playerDidLogOut()
	{
	}

	public void playerDidAuthenticate()
	{
	}

	public void playerAuthenticationFailed(string error)
	{
	}

	public void loadProfilePhotoDidLoad(string path)
	{
	}

	public void loadProfilePhotoDidFail(string error)
	{
	}

	public void loadCategoryTitlesDidFail(string error)
	{
	}

	public void categoriesDidLoad(string jsonCategoryList)
	{
	}

	public void reportScoreDidFail(string error)
	{
	}

	public void reportScoreDidFinish(string category)
	{
	}

	public void retrieveScoresDidFail(string category)
	{
	}

	public void retrieveScoresDidLoad(string jsonScoresList)
	{
	}

	public void retrieveScoresForPlayerIdDidFail(string error)
	{
	}

	public void retrieveScoresForPlayerIdDidLoad(string jsonScoresList)
	{
	}

	public void reportAchievementDidFail(string error)
	{
	}

	public void reportAchievementDidFinish(string identifier)
	{
	}

	public void loadAchievementsDidFail(string error)
	{
	}

	public void achievementsDidLoad(string jsonAchievmentList)
	{
	}

	public void resetAchievementsDidFail(string error)
	{
	}

	public void resetAchievementsDidFinish(string emptyString)
	{
	}

	public void retrieveAchievementsMetadataDidFail(string error)
	{
	}

	public void achievementMetadataDidLoad(string jsonAchievementDescriptionList)
	{
	}
}
