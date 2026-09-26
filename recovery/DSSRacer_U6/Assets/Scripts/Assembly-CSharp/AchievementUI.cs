using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AchievementUI : UghPublisher
{
	public GameObject scrollSurfaceObject1;

	public AchievementPanelPublisher[] scrollSurface1;

	public GameObject scrollSurfaceObject2;

	public AchievementPanelPublisher[] scrollSurface2;

	private List<AchievementListener> filteredList;

	private bool currentSurface;

	private int page;

	[DebuggerHidden]
	private IEnumerator AnimatePanelOutCoroutine(GameObject surface, int direction)
	{
		RecoveryPending.Hit("AchievementUI.AnimatePanelOutCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator AnimatePanelInCoroutine(GameObject surface, int direction)
	{
		RecoveryPending.Hit("AchievementUI.AnimatePanelInCoroutine");
		yield break;
	}

	private AchievementPanelPublisher[] GetCurrentSurface()
	{
		RecoveryPending.Hit("AchievementUI.GetCurrentSurface");
		return default(AchievementPanelPublisher[]);
	}

	private AchievementPanelPublisher[] SwapSurface()
	{
		RecoveryPending.Hit("AchievementUI.SwapSurface");
		return default(AchievementPanelPublisher[]);
	}

	private void SetPage(int num)
	{
		RecoveryPending.Hit("AchievementUI.SetPage");
	}

	private void BuildFilteredList()
	{
		RecoveryPending.Hit("AchievementUI.BuildFilteredList");
	}

	private void Start()
	{
		RecoveryPending.Hit("AchievementUI.Start");
	}

	private void OnPressedNext()
	{
		RecoveryPending.Hit("AchievementUI.OnPressedNext");
	}

	private void OnPressedPrev()
	{
		RecoveryPending.Hit("AchievementUI.OnPressedPrev");
	}

	private void OnPressedBack()
	{
		RecoveryPending.Hit("AchievementUI.OnPressedBack");
	}
}
