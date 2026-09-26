using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Daily bonus popup (texts are filled by FrontEndLogic): closes with the "AchievementOUT" animation.
// Source listing: recovery/aot_listings/Assembly-CSharp/DailyBonusPublisher.txt
public class DailyBonusPublisher : UghPublisher
{
	// RECUPERADO-AOT DailyBonusPublisher::Start token 0x06000650 @0x00129350
	private void Start()
	{
		SoundLibrary.PlayRandomWhoosh();
	}

	// RECUPERADO-AOT DailyBonusPublisher::Update token 0x06000651 @0x00129380 (empty in the original)
	private void Update()
	{
	}

	// RECUPERADO-AOT DailyBonusPublisher::OnPressed token 0x06000652 @0x001293ac
	private void OnPressed()
	{
		StartCoroutine(DestroyThis());
	}

	// RECUPERADO-AOT DailyBonusPublisher::DestroyThis token 0x06000653 @0x001293fc
	// (iterator <DestroyThis>c__Iterator57 MoveNext token 0x060009de @0x00154428)
	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		Animation anim = GetComponentInChildren<Animation>();
		if (anim != null)
		{
			anim.Play("AchievementOUT");
		}
		SoundLibrary.PlayRandomWhoosh();
		base.gameObject.BroadcastMessage("FadeOut");
		yield return new WaitForSeconds(0.5f);
		Object.Destroy(base.gameObject);
	}
}
