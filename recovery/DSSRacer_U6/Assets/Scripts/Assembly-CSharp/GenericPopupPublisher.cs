using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Simple message popup: SetText fills "Text"; tapping the backing closes it.
// Source listing: recovery/aot_listings/Assembly-CSharp/GenericPopupPublisher.txt
public class GenericPopupPublisher : UghPublisher
{
	// RECUPERADO-AOT GenericPopupPublisher::Start token 0x06000692 @0x0012ddc8
	private void Start()
	{
		SoundLibrary.PlayRandomWhoosh();
	}

	// RECUPERADO-AOT GenericPopupPublisher::Update token 0x06000693 @0x0012ddf8 (empty in the original)
	private void Update()
	{
	}

	// RECUPERADO-AOT GenericPopupPublisher::SetText token 0x06000694 @0x0012de24
	public void SetText(string text)
	{
		base.ughTexts["Text"].Text = text;
	}

	// RECUPERADO-AOT GenericPopupPublisher::PressedBacking token 0x06000695 @0x0012de88
	private void PressedBacking()
	{
		if (base.gameObject != null)
		{
			StartCoroutine(DestroyThis());
		}
	}

	// RECUPERADO-AOT GenericPopupPublisher::DestroyThis token 0x06000696 @0x0012def0
	// (iterator <DestroyThis>c__Iterator5D MoveNext token 0x06000a02 @0x00155a50)
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
