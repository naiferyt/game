using System;
using System.Collections.Generic;
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
		// RECUPERADO-AOT AchievementManager::get_Instance token 0x060000ba @0x000cfa54
		// ADAPTADO-U6: FindObjectOfType -> U4Compat.
		get
		{
			AchievementManager achievementManager = (AchievementManager)U4Compat.FindObjectOfType(typeof(AchievementManager));
			if (achievementManager == null)
			{
				Debug.LogError("Scene requires an AchievementManager!");
			}
			return achievementManager;
		}
	}

	public AchievementListener[] AllAchievements
	{
		// RECUPERADO-AOT AchievementManager::get_AllAchievements token 0x060000bb @0x000cfb04
		get
		{
			List<AchievementListener> list = new List<AchievementListener>();
			list.AddRange(linearAchievements);
			list.AddRange(randomAchievements);
			list.AddRange(frontEndAchievements);
			return list.ToArray();
		}
	}

	// RECUPERADO-AOT AchievementManager::Awake token 0x060000bc @0x000cfbb8
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// RECUPERADO-AOT AchievementManager::Start token 0x060000bd @0x000cfbf0
	// ADAPTADO-U6: FindObjectsOfType -> U4Compat.
	private void Start()
	{
		if (U4Compat.FindObjectsOfType(typeof(AchievementManager)).Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
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
