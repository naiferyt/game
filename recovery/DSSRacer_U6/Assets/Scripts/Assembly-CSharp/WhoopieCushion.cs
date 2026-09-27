using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Track hazard: a kart touching it gets a wipeout (unless shielded); it then puffs, plays its animation and removes itself.
// Source listing: recovery/aot_listings/Assembly-CSharp/WhoopieCushion.txt
public class WhoopieCushion : MonoBehaviour
{
	public ParticleSystem whoopieBurst;

	// RECUPERADO-AOT WhoopieCushion::Start token 0x06000505 @0x0010cb9c
	// ADAPTADO-U6: ParticleSystem.enableEmission -> emission.enabled.
	private void Start()
	{
		ParticleSystem.EmissionModule emission = whoopieBurst.emission;
		emission.enabled = false;
	}

	// RECUPERADO-AOT WhoopieCushion::Explode token 0x06000506 @0x0010cbe0
	// RECUPERADO-AOT WhoopieCushion/<Explode>c__Iterator3E::MoveNext token 0x06000948 @0x0014e0f0
	// ADAPTADO-U6: enableEmission -> emission.enabled; Component.animation -> GetComponent<Animation>().
	[DebuggerHidden]
	private IEnumerator Explode()
	{
		while (RaceManager.isPaused)
		{
			yield return null;
		}
		ParticleSystem.EmissionModule emission = whoopieBurst.emission;
		emission.enabled = true;
		whoopieBurst.Emit(1);
		yield return new WaitForSeconds(0.1f);
		GetComponent<Animation>().Play();
		while (GetComponent<Animation>().isPlaying)
		{
			yield return null;
		}
		while (whoopieBurst.particleCount > 0)
		{
			yield return null;
		}
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT WhoopieCushion::OnCollisionEnter token 0x06000507 @0x0010cc28
	private void OnCollisionEnter(Collision col)
	{
		OnTriggerEnter(col.collider);
	}

	// RECUPERADO-AOT WhoopieCushion::OnTriggerEnter token 0x06000508 @0x0010cc68
	private void OnTriggerEnter(Collider other)
	{
		CarCollider component = other.GetComponent<CarCollider>();
		if (component == null)
		{
			return;
		}
		if (component.EffectMgr != null && !component.EffectMgr.HasEffect(typeof(ShieldEffect)))
		{
			WipeoutEffect wipeoutEffect = new WipeoutEffect(other.gameObject);
			wipeoutEffect.power = 50;
			wipeoutEffect.time = 1.5f;
			component.EffectMgr.AddEffect(wipeoutEffect);
			if (RaceManager.IsPlayerCar(other.gameObject))
			{
				CarMetrics component2 = other.gameObject.GetComponent<CarMetrics>();
				if (component2 != null)
				{
					component2.Signal("Whoopie collision");
				}
			}
		}
		StartCoroutine(Explode());
	}
}
