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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator AnimatePanelInCoroutine(GameObject surface, int direction)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private AchievementPanelPublisher[] GetCurrentSurface()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private AchievementPanelPublisher[] SwapSurface()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
