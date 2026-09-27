using System.Collections;
using System.Diagnostics;
using UnityEngine;

// "Mine dropped by <name>" notice: fades in, stays LIFE_TIME seconds, fades out and removes itself.
// Source listing: recovery/aot_listings/Assembly-CSharp/MineNotifyPublisher.txt
public class MineNotifyPublisher : UghPublisher
{
	private const float LIFE_TIME = 1f;

	// RECUPERADO-AOT MineNotifyPublisher::Lifetime token 0x06000778 @0x0013c990
	// RECUPERADO-AOT MineNotifyPublisher/<Lifetime>c__Iterator83::MoveNext token 0x06000aee @0x00162d04
	[DebuggerHidden]
	private IEnumerator Lifetime()
	{
		yield return StartCoroutine(FadeIn());
		yield return new WaitForSeconds(1f);
		yield return StartCoroutine(FadeOut());
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT MineNotifyPublisher::FadeIn token 0x06000779 @0x0013c9d8
	// RECUPERADO-AOT MineNotifyPublisher/<FadeIn>c__Iterator84::MoveNext token 0x06000af4 @0x00162fdc
	[DebuggerHidden]
	private IEnumerator FadeIn()
	{
		float alpha = 0f;
		Renderer[] rList = GetComponentsInChildren<Renderer>();
		Renderer[] array = rList;
		foreach (Renderer r in array)
		{
			Color c = r.material.color;
			c.a = 0f;
			r.material.color = c;
		}
		while (alpha < 1f)
		{
			alpha += 0.04f;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			Renderer[] array2 = rList;
			foreach (Renderer r2 in array2)
			{
				Color c2 = r2.material.color;
				c2.a = alpha;
				r2.material.color = c2;
			}
			yield return new WaitForSeconds(0.01f);
		}
	}

	// RECUPERADO-AOT MineNotifyPublisher::FadeOut token 0x0600077a @0x0013ca20
	// RECUPERADO-AOT MineNotifyPublisher/<FadeOut>c__Iterator85::MoveNext token 0x06000afa @0x001634b4
	[DebuggerHidden]
	private IEnumerator FadeOut()
	{
		float alpha = 1f;
		Renderer[] rList = GetComponentsInChildren<Renderer>();
		while (alpha > 0f)
		{
			alpha -= 0.04f;
			if (alpha < 0f)
			{
				alpha = 0f;
			}
			Renderer[] array = rList;
			foreach (Renderer r in array)
			{
				Color c = r.material.color;
				c.a = alpha;
				r.material.color = c;
			}
			yield return new WaitForSeconds(0.01f);
		}
	}

	// RECUPERADO-AOT MineNotifyPublisher::Start token 0x0600077b @0x0013ca68
	private void Start()
	{
		StartCoroutine(Lifetime());
	}

	// RECUPERADO-AOT MineNotifyPublisher::SetDisplayName token 0x0600077c @0x0013cab8
	public void SetDisplayName(string text)
	{
		base.ughTexts["Label"].Text = text;
	}
}
