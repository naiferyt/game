using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Achievement list of one category: pages of panels on two surfaces that slide in and out when paging.
// Source listing: recovery/aot_listings/Assembly-CSharp/AchievementUI.txt
public class AchievementUI : UghPublisher
{
	public GameObject scrollSurfaceObject1;

	public AchievementPanelPublisher[] scrollSurface1;

	public GameObject scrollSurfaceObject2;

	public AchievementPanelPublisher[] scrollSurface2;

	private List<AchievementListener> filteredList;

	private bool currentSurface;

	private int page;

	// RECUPERADO-AOT AchievementUI::AnimatePanelOutCoroutine token 0x060005ca @0x0011dbe8
	// RECUPERADO-AOT AchievementUI/<AnimatePanelOutCoroutine>c__Iterator4C::MoveNext token 0x0600099c @0x001510b0
	[DebuggerHidden]
	private IEnumerator AnimatePanelOutCoroutine(GameObject surface, int direction)
	{
		if (direction != 0)
		{
			Vector3 startPos = surface.transform.localPosition;
			Vector3 endPos = new Vector3(0f, surface.transform.localPosition.y, surface.transform.localPosition.z);
			endPos = ((direction != 1) ? new Vector3(15f, surface.transform.localPosition.y, surface.transform.localPosition.z) : new Vector3(-15f, surface.transform.localPosition.y, surface.transform.localPosition.z));
			for (float timer = 0f; timer < 0.75f; timer += 0.1f)
			{
				surface.transform.localPosition = Vector3.Lerp(startPos, endPos, timer);
				yield return new WaitForSeconds(0.0333f);
			}
			surface.transform.localPosition = endPos;
		}
	}

	// RECUPERADO-AOT AchievementUI::AnimatePanelInCoroutine token 0x060005cb @0x0011dc48
	// RECUPERADO-AOT AchievementUI/<AnimatePanelInCoroutine>c__Iterator4D::MoveNext token 0x060009a2 @0x00151790
	[DebuggerHidden]
	private IEnumerator AnimatePanelInCoroutine(GameObject surface, int direction)
	{
		if (direction != 0)
		{
			SoundLibrary.PlayRandomWhoosh();
			Vector3 startPos = surface.transform.localPosition;
			Vector3 endPos = new Vector3(0f, surface.transform.localPosition.y, surface.transform.localPosition.z);
			startPos = ((direction != -1) ? new Vector3(15f, surface.transform.localPosition.y, surface.transform.localPosition.z) : new Vector3(-15f, surface.transform.localPosition.y, surface.transform.localPosition.z));
			for (float timer = 0f; timer < 0.75f; timer += 0.1f)
			{
				surface.transform.localPosition = Vector3.Lerp(startPos, endPos, timer);
				yield return new WaitForSeconds(0.0333f);
			}
			surface.transform.localPosition = endPos;
		}
	}

	// RECUPERADO-AOT AchievementUI::GetCurrentSurface token 0x060005cc @0x0011dca8
	private AchievementPanelPublisher[] GetCurrentSurface()
	{
		if (currentSurface)
		{
			return scrollSurface2;
		}
		return scrollSurface1;
	}

	// RECUPERADO-AOT AchievementUI::SwapSurface token 0x060005cd @0x0011dcec
	private AchievementPanelPublisher[] SwapSurface()
	{
		currentSurface = !currentSurface;
		return GetCurrentSurface();
	}

	// RECUPERADO-AOT AchievementUI::SetPage token 0x060005ce @0x0011dd34
	private void SetPage(int num)
	{
		int num2 = filteredList.Count / scrollSurface1.Length + ((filteredList.Count % scrollSurface1.Length != 0) ? 1 : 0) - 1;
		if (num < 0)
		{
			num = 0;
		}
		else if (num >= num2)
		{
			num = num2;
		}
		int num3 = 0;
		if (num > page)
		{
			num3 = 1;
		}
		else if (num < page)
		{
			num3 = -1;
		}
		page = num;
		AchievementPanelPublisher[] array = null;
		array = ((num3 != 0) ? SwapSurface() : GetCurrentSurface());
		if (page == 0)
		{
			base.ughButtons["Prev"].gameObject.SetActive(false);
		}
		else
		{
			base.ughButtons["Prev"].gameObject.SetActive(true);
		}
		if (page == num2)
		{
			base.ughButtons["Next"].gameObject.SetActive(false);
		}
		else
		{
			base.ughButtons["Next"].gameObject.SetActive(true);
		}
		int num4 = page * scrollSurface1.Length;
		int count = filteredList.Count;
		for (int i = 0; i < array.Length; i++)
		{
			int num5 = i + num4;
			if (num5 >= count)
			{
				array[i].gameObject.SetActive(false);
				continue;
			}
			array[i].gameObject.SetActive(true);
			array[i].Achievement = filteredList[num5];
		}
		if (num3 != 0)
		{
			GameObject surface = scrollSurfaceObject1;
			GameObject surface2 = scrollSurfaceObject2;
			if (!currentSurface)
			{
				surface = scrollSurfaceObject2;
				surface2 = scrollSurfaceObject1;
			}
			StartCoroutine(AnimatePanelOutCoroutine(surface, num3));
			StartCoroutine(AnimatePanelInCoroutine(surface2, num3));
		}
	}

	// RECUPERADO-AOT AchievementUI::BuildFilteredList token 0x060005cf @0x0011e12c
	private void BuildFilteredList()
	{
		AchievementListener.AchievementFilterCategory achievementUIFilter = AchievementManager.achievementUIFilter;
		filteredList = new List<AchievementListener>();
		AchievementListener[] frontEndAchievements = AchievementManager.Instance.frontEndAchievements;
		for (int i = 0; i < frontEndAchievements.Length; i++)
		{
			if (frontEndAchievements[i].categoryFilter == achievementUIFilter)
			{
				filteredList.Add(frontEndAchievements[i]);
			}
		}
		AchievementListener[] linearAchievements = AchievementManager.Instance.linearAchievements;
		for (int j = 0; j < linearAchievements.Length; j++)
		{
			if (linearAchievements[j].categoryFilter == achievementUIFilter)
			{
				filteredList.Add(linearAchievements[j]);
			}
		}
		AchievementListener[] randomAchievements = AchievementManager.Instance.randomAchievements;
		for (int k = 0; k < randomAchievements.Length; k++)
		{
			if (randomAchievements[k].categoryFilter == achievementUIFilter)
			{
				filteredList.Add(randomAchievements[k]);
			}
		}
	}

	// RECUPERADO-AOT AchievementUI::Start token 0x060005d0 @0x0011e314
	private void Start()
	{
		BuildFilteredList();
		SetPage(0);
		scrollSurfaceObject2.transform.localPosition = new Vector3(15f, scrollSurfaceObject2.transform.localPosition.y, scrollSurfaceObject2.transform.localPosition.z);
	}

	// RECUPERADO-AOT AchievementUI::OnPressedNext token 0x060005d1 @0x0011e488
	private void OnPressedNext()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		SetPage(page + 1);
	}

	// RECUPERADO-AOT AchievementUI::OnPressedPrev token 0x060005d2 @0x0011e4d8
	private void OnPressedPrev()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		SetPage(page - 1);
	}

	// RECUPERADO-AOT AchievementUI::OnPressedBack token 0x060005d3 @0x0011e528
	private void OnPressedBack()
	{
		SoundLibrary.ButtonClickPlay("menuButton1");
		FrontEndLogic.RequestMenuChange("Achievement Categories");
	}
}
