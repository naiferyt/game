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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public AchievementListener[] AllAchievements
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRaceInit()
	{
	}

	private void OnRaceEnd()
	{
	}

	public void Achieve(AchievementListener listener)
	{
	}

	public void Fail(AchievementListener listener)
	{
	}

	public void ClearActiveListeners()
	{
	}

	public void ChooseActiveListeners()
	{
	}

	public void InitFrontEndAchievements()
	{
	}
}
