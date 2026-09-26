using System.Collections;
using System.Collections.Generic;
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

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimatePanelOutCoroutine(GameObject surface, int direction)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimatePanelInCoroutine(GameObject surface, int direction)
	{
		return default(IEnumerator);
	}

	private AchievementPanelPublisher[] GetCurrentSurface()
	{
		return default(AchievementPanelPublisher[]);
	}

	private AchievementPanelPublisher[] SwapSurface()
	{
		return default(AchievementPanelPublisher[]);
	}

	private void SetPage(int num)
	{
	}

	private void BuildFilteredList()
	{
	}

	private void Start()
	{
	}

	private void OnPressedNext()
	{
	}

	private void OnPressedPrev()
	{
	}

	private void OnPressedBack()
	{
	}
}
