using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Removes a one-shot effect once none of its particle systems has live particles.
// Source listing: recovery/aot_listings/Assembly-CSharp/ParticleSystemDestroy.txt
public class ParticleSystemDestroy : MonoBehaviour
{
	// RECUPERADO-AOT ParticleSystemDestroy::Start token 0x06000394 @0x000f5250
	// RECUPERADO-AOT ParticleSystemDestroy/<Start>c__Iterator27::MoveNext token 0x060008ba @0x001488ec
	[DebuggerHidden]
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(1f);
		while (true)
		{
			ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
			bool destroy = true;
			ParticleSystem[] array = particles;
			foreach (ParticleSystem ps in array)
			{
				if (ps.particleCount > 0)
				{
					destroy = false;
					break;
				}
			}
			if (destroy)
			{
				break;
			}
			yield return new WaitForSeconds(0.5f);
		}
		Object.Destroy(base.gameObject);
	}
}
