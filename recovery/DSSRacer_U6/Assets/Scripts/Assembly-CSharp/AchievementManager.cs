using System;
using System.Collections.Generic;
using UnityEngine;

// Achievements ("missions"): chooses the three per race, forwards race start/end to them and shows the
// unlock windows.
// Source listing: recovery/aot_listings/Assembly-CSharp/AchievementManager.txt
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

	// RECUPERADO-AOT AchievementManager::OnEnable token 0x060000be @0x000cfc48
	private void OnEnable()
	{
		RaceManager.raceInitFinishedEvent += OnRaceInit;
		RaceManager.raceEndEvent = (Action)Delegate.Combine(RaceManager.raceEndEvent, new Action(OnRaceEnd));
	}

	// RECUPERADO-AOT AchievementManager::OnDisable token 0x060000bf @0x000cfd94
	private void OnDisable()
	{
		RaceManager.raceInitFinishedEvent -= OnRaceInit;
		RaceManager.raceEndEvent = (Action)Delegate.Remove(RaceManager.raceEndEvent, new Action(OnRaceEnd));
	}

	// RECUPERADO-AOT AchievementManager::OnRaceInit token 0x060000c0 @0x000cfee0
	private void OnRaceInit()
	{
		if (activeListeners != null && activeListeners.Length != 0)
		{
			AchievementListener[] array = activeListeners;
			foreach (AchievementListener achievementListener in array)
			{
				achievementListener.Prerace();
			}
		}
	}

	// RECUPERADO-AOT AchievementManager::OnRaceEnd token 0x060000c1 @0x000cff80
	private void OnRaceEnd()
	{
		if (activeListeners != null && activeListeners.Length != 0)
		{
			AchievementListener[] array = activeListeners;
			foreach (AchievementListener achievementListener in array)
			{
				achievementListener.Postrace();
			}
		}
	}

	// RECUPERADO-AOT AchievementManager::Achieve token 0x060000c2 @0x000d0020
	// Unlocks the achievement and shows it: HUD notification during a race, otherwise a (chained) window.
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	// ELIMINADO (servicio iOS / analitica): when the listener has a gcIdentifier the original reported
	//     GameCenterBinding.reportAchievement(gcIdentifier + "_GCID", 100f) and sent GDMOManager.SendWithContext(
	//     "game_action", {player_id: SystemInfo.deviceUniqueIdentifier, context: "game center", action: "achieve",
	//     type: gcIdentifier}).
	public void Achieve(AchievementListener listener)
	{
		if (achievementPassedCallback != null)
		{
			achievementPassedCallback(listener.UIName.baseText);
		}
		if (!listener.HasAchieved())
		{
			DataUtility.Instance.Unlock(listener.GetUnlockName());
		}
		if (U4Compat.FindObjectOfType(typeof(RaceManager)) != null)
		{
			HUDLogic.Instance.ShowAchievementNotification(listener);
			return;
		}
		GameObject gameObject = ((!(listener.rewardDescription.Text != string.Empty)) ? ((GameObject)UnityEngine.Object.Instantiate(WindowPrefab)) : ((GameObject)UnityEngine.Object.Instantiate(WindowUnlockPrefab)));
		AchievementWindowPublisher component = gameObject.GetComponent<AchievementWindowPublisher>();
		component.SetContent(listener);
		if (activeAchievementNotificationWindow == null)
		{
			activeAchievementNotificationWindow = gameObject;
			component.TriggerAnimIn();
		}
		else
		{
			activeAchievementNotificationWindow.GetComponent<AchievementWindowPublisher>().SetNextWindow(gameObject);
		}
	}

	// RECUPERADO-AOT AchievementManager::Fail token 0x060000c3 @0x000d03f0
	public void Fail(AchievementListener listener)
	{
		if (achievementFailedCallback != null)
		{
			achievementFailedCallback(listener.UIName.baseText);
		}
	}

	// RECUPERADO-AOT AchievementManager::ClearActiveListeners token 0x060000c4 @0x000d0468
	public void ClearActiveListeners()
	{
		if (activeListeners != null)
		{
			AchievementListener[] array = activeListeners;
			foreach (AchievementListener achievementListener in array)
			{
				if (achievementListener != null)
				{
					UnityEngine.Object.Destroy(achievementListener.gameObject);
				}
			}
			activeListeners = null;
		}
	}

	// RECUPERADO-AOT AchievementManager::ChooseActiveListeners token 0x060000c5 @0x000d0514
	// The race missions: the first two available linear achievements, then random available ones up to three.
	// The random pool is shuffled five times (swap halves, then rotate a random tail to the front).
	public void ChooseActiveListeners()
	{
		ClearActiveListeners();
		List<AchievementListener> list = new List<AchievementListener>();
		int num = 0;
		AchievementListener[] array = linearAchievements;
		foreach (AchievementListener achievementListener in array)
		{
			if (achievementListener.IsAvailable())
			{
				list.Add(achievementListener);
				num++;
				if (num == 2)
				{
					break;
				}
			}
		}
		List<AchievementListener> list2 = new List<AchievementListener>(randomAchievements);
		for (int j = 0; j < 5; j++)
		{
			for (int k = 0; k < list2.Count / 2; k++)
			{
				int index = UnityEngine.Random.Range(0, list2.Count / 2);
				int index2 = UnityEngine.Random.Range(list2.Count / 2, list2.Count - 1);
				AchievementListener item = list2[index2];
				list2.RemoveAt(index2);
				list2.Insert(index, item);
			}
			for (int l = UnityEngine.Random.Range(1, list2.Count - 1); l < list2.Count; l++)
			{
				AchievementListener item2 = list2[l];
				list2.RemoveAt(l);
				list2.Insert(0, item2);
			}
		}
		foreach (AchievementListener item3 in list2)
		{
			if (item3.IsAvailable())
			{
				list.Add(item3);
				num++;
				if (num == 3)
				{
					break;
				}
			}
		}
		activeListeners = new AchievementListener[list.Count];
		for (int m = 0; m < list.Count; m++)
		{
			activeListeners[m] = (AchievementListener)UnityEngine.Object.Instantiate(list[m]);
			UnityEngine.Object.DontDestroyOnLoad(activeListeners[m]);
		}
	}

	// RECUPERADO-AOT AchievementManager::InitFrontEndAchievements token 0x060000c6 @0x000d09d0
	// Front-end achievements (garage/menus): active copies of every available one.
	public void InitFrontEndAchievements()
	{
		ClearActiveListeners();
		List<AchievementListener> list = new List<AchievementListener>();
		AchievementListener[] array = frontEndAchievements;
		foreach (AchievementListener achievementListener in array)
		{
			if (achievementListener.IsAvailable())
			{
				list.Add(achievementListener);
			}
		}
		activeListeners = new AchievementListener[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			activeListeners[j] = (AchievementListener)UnityEngine.Object.Instantiate(list[j]);
			UnityEngine.Object.DontDestroyOnLoad(activeListeners[j]);
		}
	}
}
