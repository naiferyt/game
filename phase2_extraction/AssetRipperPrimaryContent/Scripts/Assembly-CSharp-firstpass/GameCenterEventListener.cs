using System.Collections.Generic;
using UnityEngine;

public class GameCenterEventListener : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void playerAuthenticated()
	{
	}

	private void playerFailedToAuthenticate(string error)
	{
	}

	private void playerLoggedOut()
	{
	}

	private void playerDataLoaded(List<GameCenterPlayer> players)
	{
	}

	private void loadPlayerDataFailed(string error)
	{
	}

	private void profilePhotoLoaded(string path)
	{
	}

	private void profilePhotoFailed(string error)
	{
	}

	private void categoriesLoaded(List<GameCenterLeaderboard> leaderboards)
	{
	}

	private void loadCategoryTitlesFailed(string error)
	{
	}

	private void scoresLoaded(List<GameCenterScore> scores)
	{
	}

	private void retrieveScoresFailed(string error)
	{
	}

	private void retrieveScoresForPlayerIdFailed(string error)
	{
	}

	private void scoresForPlayerIdLoaded(List<GameCenterScore> scores)
	{
	}

	private void reportScoreFinished(string category)
	{
	}

	private void reportScoreFailed(string error)
	{
	}

	private void achievementMetadataLoaded(List<GameCenterAchievementMetadata> achievementMetadata)
	{
	}

	private void retrieveAchievementMetadataFailed(string error)
	{
	}

	private void resetAchievementsFinished()
	{
	}

	private void resetAchievementsFailed(string error)
	{
	}

	private void achievementsLoaded(List<GameCenterAchievement> achievements)
	{
	}

	private void loadAchievementsFailed(string error)
	{
	}

	private void reportAchievementFinished(string identifier)
	{
	}

	private void reportAchievementFailed(string error)
	{
	}
}
