using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Loading spinner: steps 30 degrees every 0.06 s; FadeOut ramps the material alpha and destroys the spinner.
// Source listing: recovery/aot_listings/Assembly-CSharp/LoadSpin.txt
public class LoadSpin : MonoBehaviour
{
	// RECUPERADO-AOT LoadSpin::Start token 0x0600041d @0x000fe140
	// (iterator <Start>c__Iterator2C MoveNext token 0x060008dc @0x0014ab6c)
	[DebuggerHidden]
	private IEnumerator Start()
	{
		float timer = 0f;
		float turnTime = 0.06f;
		while (true)
		{
			if (timer > turnTime)
			{
				base.transform.Rotate(0f, 0f, 30f);
				timer = 0f;
			}
			else
			{
				timer += Time.deltaTime;
			}
			yield return null;
		}
	}

	// RECUPERADO-AOT LoadSpin::FadeOut token 0x0600041e @0x000fe188
	public void FadeOut()
	{
		FadeOut(0.5f);
	}

	// RECUPERADO-AOT LoadSpin::FadeOut token 0x0600041f @0x000fe1d8
	public void FadeOut(float fadeDuration)
	{
		StartCoroutine(FadeHelper(fadeDuration));
	}

	// RECUPERADO-AOT LoadSpin::FadeHelper token 0x06000420 @0x000fe230
	// (iterator <FadeHelper>c__Iterator2D MoveNext token 0x060008e2 @0x0014ae00)
	// Alpha goes from Color.clear.a to Color.white.a (0 -> 1), as in the original.
	[DebuggerHidden]
	private IEnumerator FadeHelper(float fadeDuration)
	{
		Renderer r = GetComponent<Renderer>();
		Color startColor = Color.clear;
		Color endColor = Color.white;
		float timer = 0f;
		while (timer < fadeDuration)
		{
			r.material.color = new Color(1f, 1f, 1f, Mathf.Lerp(startColor.a, endColor.a, timer / fadeDuration));
			timer += Time.deltaTime;
			yield return null;
		}
		Object.Destroy(base.gameObject);
	}
}
