using System;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
	private const int NUMBER_OF_ACHIEVEMENTS_PER_RACE = 3;

	private const int NUMBER_OF_LINEAR_ACHIEVEMENTS = 2;

	public static Action<string> achievementPassedCallback;

	public static Action<string> achievementFailedCallback;

	public GameObject WindowPrefab;

	public GameObject WindowUnlockPrefab;

	public AchievementListener[] linearAchievements;

	public AchievementListener[] randomAchievements;

	public AchievementListener[] frontEndAchievements;

	public AchievementListener[] activeListeners;

	public GameObject activeAchievementNotificationWindow;

	public static AchievementListener.AchievementFilterCategory achievementUIFilter;

	public static AchievementManager Instance
	{
		get
		{
			RecoveryPending.Hit("AchievementManager.get_Instance");
			return default(AchievementManager);
		}
	}

	public AchievementListener[] AllAchievements
	{
		get
		{
			RecoveryPending.Hit("AchievementManager.get_AllAchievements");
			return default(AchievementListener[]);
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("AchievementManager.Awake");
	}

	private void Start()
	{
		RecoveryPending.Hit("AchievementManager.Start");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("AchievementManager.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("AchievementManager.OnDisable");
	}

	private void OnRaceInit()
	{
		RecoveryPending.Hit("AchievementManager.OnRaceInit");
	}

	private void OnRaceEnd()
	{
		RecoveryPending.Hit("AchievementManager.OnRaceEnd");
	}

	public void Achieve(AchievementListener listener)
	{
		RecoveryPending.Hit("AchievementManager.Achieve");
	}

	public void Fail(AchievementListener listener)
	{
		RecoveryPending.Hit("AchievementManager.Fail");
	}

	public void ClearActiveListeners()
	{
		RecoveryPending.Hit("AchievementManager.ClearActiveListeners");
	}

	public void ChooseActiveListeners()
	{
		RecoveryPending.Hit("AchievementManager.ChooseActiveListeners");
	}

	public void InitFrontEndAchievements()
	{
		RecoveryPending.Hit("AchievementManager.InitFrontEndAchievements");
	}
}
