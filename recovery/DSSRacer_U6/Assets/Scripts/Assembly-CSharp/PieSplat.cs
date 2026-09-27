using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Pie splat on the player's screen: the two splat layers slide in from the right, stay, then slide back out.
// Source listing: recovery/aot_listings/Assembly-CSharp/PieSplat.txt
public class PieSplat : MonoBehaviour
{
	public Transform innerSplat;

	public Transform outerSplat;

	// RECUPERADO-AOT PieSplat::.ctor token 0x06000421 @0x000fe29c (field initializer)
	public float splatDuration = 1f;

	// RECUPERADO-AOT PieSplat::Start token 0x06000422 @0x000fe2e8
	// RECUPERADO-AOT PieSplat/<Start>c__Iterator2E::MoveNext token 0x060008e8 @0x0014b1d4
	[DebuggerHidden]
	private IEnumerator Start()
	{
		Vector3 localInnerOffScreen = new Vector3(100f, 0f, 0f);
		Vector3 localOuterOffScreen = new Vector3(300f, 0f, 0f);
		innerSplat.localPosition = localInnerOffScreen;
		outerSplat.localPosition = localOuterOffScreen;
		float duration = 0.1f;
		float frequency = 1f / 60f;
		for (float t = 0f; t <= duration; t += frequency)
		{
			float delta = t / duration;
			innerSplat.localPosition = Vector3x.Hermite(localInnerOffScreen, Vector3.zero, delta);
			outerSplat.localPosition = Vector3x.Hermite(localOuterOffScreen, Vector3.zero, delta);
			yield return new WaitForSeconds(frequency);
		}
		yield return new WaitForSeconds(splatDuration / 2f);
		duration = splatDuration / 2f;
		for (float t2 = 0f; t2 <= duration; t2 += frequency)
		{
			float delta2 = t2 / duration;
			innerSplat.localPosition = Vector3x.Hermite(Vector3.zero, localInnerOffScreen, delta2);
			outerSplat.localPosition = Vector3x.Hermite(Vector3.zero, localOuterOffScreen, delta2);
			yield return new WaitForSeconds(frequency);
		}
		Object.Destroy(base.gameObject);
	}
}
