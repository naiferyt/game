using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Yes/No confirmation popup: stores the answer in "confirm", then fades out and destroys itself.
// Source listing: recovery/aot_listings/Assembly-CSharp/ConfirmationPublisher.txt
public class ConfirmationPublisher : UghPublisher
{
	[HideInInspector]
	public bool confirm;

	// RECUPERADO-AOT ConfirmationPublisher::Start token 0x06000641 @0x00128fa4
	private void Start()
	{
		SoundLibrary.PlayRandomWhoosh();
	}

	// RECUPERADO-AOT ConfirmationPublisher::Update token 0x06000642 @0x00128fd4 (empty in the original)
	private void Update()
	{
	}

	// RECUPERADO-AOT ConfirmationPublisher::PressedYes token 0x06000643 @0x00129000
	public void PressedYes()
	{
		confirm = true;
		StartCoroutine(Close());
	}

	// RECUPERADO-AOT ConfirmationPublisher::PressedNo token 0x06000644 @0x00129058
	public void PressedNo()
	{
		confirm = false;
		StartCoroutine(Close());
	}

	// RECUPERADO-AOT ConfirmationPublisher::Close token 0x06000645 @0x001290b0
	// (iterator <Close>c__Iterator55 MoveNext token 0x060009d2 @0x00153fb4)
	[DebuggerHidden]
	private IEnumerator Close()
	{
		yield return 0;
		base.gameObject.BroadcastMessage("FadeOut");
		StartCoroutine(DestroyThis());
	}

	// RECUPERADO-AOT ConfirmationPublisher::DestroyThis token 0x06000646 @0x001290f8
	// (iterator <DestroyThis>c__Iterator56 MoveNext token 0x060009d8 @0x001541c8)
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
