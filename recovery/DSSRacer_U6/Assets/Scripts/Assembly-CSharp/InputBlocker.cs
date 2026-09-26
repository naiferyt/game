using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Dim full-screen backdrop behind popups: fades its material in on Start and out on "FadeOut".
// Source listing: recovery/aot_listings/Assembly-CSharp/InputBlocker.txt
public class InputBlocker : MonoBehaviour
{
	// RECUPERADO-AOT InputBlocker::Start token 0x06000419 @0x000fe02c
	// (iterator <Start>c__Iterator2A MoveNext token 0x060008d0 @0x0014a2d4)
	// ADAPTADO-U6: Component.renderer -> GetComponent<Renderer>().
	[DebuggerHidden]
	private IEnumerator Start()
	{
		float length = 0.25f;
		float timer = 0f;
		Color startColor = new Color(0f, 0f, 0f, 0f);
		Color goalColor = GetComponent<Renderer>().material.color;
		while (timer < length)
		{
			timer += Time.deltaTime;
			GetComponent<Renderer>().material.color = Color.Lerp(startColor, goalColor, Mathf.Clamp01(timer / length));
			yield return 0;
		}
	}

	// RECUPERADO-AOT InputBlocker::FadeOut token 0x0600041a @0x000fe074
	public void FadeOut()
	{
		StartCoroutine(FadeOutHelper());
	}

	// RECUPERADO-AOT InputBlocker::FadeOutHelper token 0x0600041b @0x000fe0c4
	// (iterator <FadeOutHelper>c__Iterator2B MoveNext token 0x060008d6 @0x0014a720)
	[DebuggerHidden]
	private IEnumerator FadeOutHelper()
	{
		float length = 0.25f;
		float timer = 0f;
		Color goalColor = new Color(0f, 0f, 0f, 0f);
		Color startColor = GetComponent<Renderer>().material.color;
		while (timer < length)
		{
			timer += Time.deltaTime;
			GetComponent<Renderer>().material.color = Color.Lerp(startColor, goalColor, Mathf.Clamp01(timer / length));
			yield return 0;
		}
	}
}
