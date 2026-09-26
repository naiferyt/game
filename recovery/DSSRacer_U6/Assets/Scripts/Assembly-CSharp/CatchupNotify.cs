using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Catch-up notice object: one second after appearing it destroys this component (the original passes
// the component, not its GameObject, to DestroyObject; kept as is).
// Source listing: recovery/aot_listings/Assembly-CSharp/CatchupNotify.txt
public class CatchupNotify : MonoBehaviour
{
	// RECUPERADO-AOT CatchupNotify::DeathCount token 0x06000746 @0x00139164
	// RECUPERADO-AOT CatchupNotify/<DeathCount>c__Iterator76::MoveNext token 0x06000a9f @0x0015e6f8
	// ADAPTADO-U6: Object.DestroyObject -> Object.Destroy.
	[DebuggerHidden]
	private IEnumerator DeathCount()
	{
		yield return new WaitForSeconds(1f);
		Object.Destroy(this);
	}

	// RECUPERADO-AOT CatchupNotify::Start token 0x06000747 @0x001391ac
	private void Start()
	{
		StartCoroutine(DeathCount());
	}
}
