using System.Collections;
using System.Diagnostics;
using UnityEngine;

// "Achievement unlocked" pop-up window: animates in, closes on tap and hands over to the next queued window.
// Source listing: recovery/aot_listings/Assembly-CSharp/AchievementWindowPublisher.txt
public class AchievementWindowPublisher : UghPublisher
{
	private bool animatingOut;

	private GameObject nextWindow;

	// RECUPERADO-AOT AchievementWindowPublisher::Awake token 0x060005d5 @0x0011e5b0
	private new void Awake()
	{
		base.Awake();
		base.ughButtons["Window"].gameObject.SetActive(false);
	}

	// RECUPERADO-AOT AchievementWindowPublisher::PressedWindow token 0x060005d6 @0x0011e624
	private void PressedWindow()
	{
		if (!animatingOut)
		{
			StartCoroutine(DestroyThis());
		}
	}

	// RECUPERADO-AOT AchievementWindowPublisher::DestroyThis token 0x060005d7 @0x0011e680
	// RECUPERADO-AOT AchievementWindowPublisher/<DestroyThis>c__Iterator4E::MoveNext token 0x060009a8 @0x00151e78
	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		animatingOut = true;
		SoundLibrary.ButtonClickPlay("menuButton1");
		Animation anim = GetComponentInChildren<Animation>();
		if (anim != null)
		{
			anim.Play("AchievementOUT");
			SoundLibrary.PlayRandomWhoosh();
			yield return new WaitForSeconds(0.5f);
			while (anim.isPlaying)
			{
				yield return null;
			}
		}
		if (nextWindow != null)
		{
			AchievementManager.Instance.activeAchievementNotificationWindow = nextWindow;
			AchievementWindowPublisher awp = nextWindow.GetComponent<AchievementWindowPublisher>();
			UghAlign align = awp.ughButtons["Window"].gameObject.GetComponent<UghAlign>();
			if (align != null)
			{
				align.Align();
			}
			awp.TriggerAnimIn();
		}
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT AchievementWindowPublisher::TriggerAnimIn token 0x060005d8 @0x0011e6c8
	public void TriggerAnimIn()
	{
		StartCoroutine(AnimInHelper());
	}

	// RECUPERADO-AOT AchievementWindowPublisher::AnimInHelper token 0x060005d9 @0x0011e718
	// RECUPERADO-AOT AchievementWindowPublisher/<AnimInHelper>c__Iterator4F::MoveNext token 0x060009ae @0x001521d0
	[DebuggerHidden]
	private IEnumerator AnimInHelper()
	{
		Animation anim = GetComponentInChildren<Animation>();
		if (anim != null)
		{
			anim.Play("AchievementIN");
			SoundLibrary.PlayRandomWhoosh();
			yield return new WaitForSeconds(0.5f);
			while (anim.isPlaying)
			{
				yield return null;
			}
		}
		base.ughButtons["Window"].gameObject.SetActive(true);
	}

	// RECUPERADO-AOT AchievementWindowPublisher::SetContent token 0x060005da @0x0011e760
	public virtual void SetContent(AchievementListener listener)
	{
		base.ughTexts["Name"].Text = listener.UIName.Text;
		base.ughTexts["Text"].Text = listener.description.Text;
		if (listener.rewardCoins > 0)
		{
			base.ughTexts["Coins"].Text = listener.rewardCoins.ToString();
			return;
		}
		base.ughTexts["Coins"].gameObject.SetActive(false);
		base.transforms["Coin Icon"].gameObject.SetActive(false);
	}

	// RECUPERADO-AOT AchievementWindowPublisher::SetNextWindow token 0x060005db @0x0011e8f0
	public void SetNextWindow(GameObject window)
	{
		AchievementWindowPublisher achievementWindowPublisher = this;
		while (achievementWindowPublisher.nextWindow != null)
		{
			achievementWindowPublisher = achievementWindowPublisher.nextWindow.GetComponent<AchievementWindowPublisher>();
		}
		if (achievementWindowPublisher != null)
		{
			achievementWindowPublisher.nextWindow = window;
		}
	}
}
