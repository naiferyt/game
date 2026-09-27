using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Rolling/stationary barrel: explodes on contact (wipeout unless shielded) or after lifeTime seconds;
// its rigidbody is frozen while the race is paused.
// Source listing: recovery/aot_listings/Assembly-CSharp/ExplodingBarrel.txt
public class ExplodingBarrel : MonoBehaviour
{
	// RECUPERADO-AOT ExplodingBarrel::.ctor token 0x060004de @0x0010ae30 (field initializers)
	public float lifeTime = 6f;

	public bool stationary;

	private Vector3 velocityForPause = Vector3.zero;

	private bool paused;

	// RECUPERADO-AOT ExplodingBarrel::LifeCountdown token 0x060004df @0x0010aea0
	// RECUPERADO-AOT ExplodingBarrel/<LifeCountdown>c__Iterator37::MoveNext token 0x0600091e @0x0014cebc
	[DebuggerHidden]
	private IEnumerator LifeCountdown()
	{
		yield return new WaitForSeconds(lifeTime);
		StartCoroutine(Explode());
	}

	// RECUPERADO-AOT ExplodingBarrel::Update token 0x060004e0 @0x0010aee8
	// ADAPTADO-U6: Component.rigidbody -> GetComponent<Rigidbody>(); Rigidbody.velocity is linearVelocity in Unity 6.
	private void Update()
	{
		if (RaceManager.isPaused && GetComponent<Rigidbody>() != null)
		{
#if UNITY_6000_0_OR_NEWER
			velocityForPause = GetComponent<Rigidbody>().linearVelocity;
#else
			velocityForPause = GetComponent<Rigidbody>().velocity;
#endif
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			paused = true;
		}
		else if (paused && GetComponent<Rigidbody>() != null)
		{
			paused = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
#if UNITY_6000_0_OR_NEWER
			GetComponent<Rigidbody>().linearVelocity = velocityForPause;
#else
			GetComponent<Rigidbody>().velocity = velocityForPause;
#endif
		}
	}

	// RECUPERADO-AOT ExplodingBarrel::Explode token 0x060004e1 @0x0010b018
	// RECUPERADO-AOT ExplodingBarrel/<Explode>c__Iterator38::MoveNext token 0x06000924 @0x0014d0cc
	[DebuggerHidden]
	private IEnumerator Explode()
	{
		while (RaceManager.isPaused)
		{
			yield return null;
		}
		GameObject particles = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Explosion"), base.transform.position, Quaternion.identity) as GameObject;
		particles.transform.parent = null;
		particles.transform.localScale = particles.transform.localScale * 2f;
		particles.name = "Explosion Particle Effect";
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT ExplodingBarrel::Start token 0x060004e2 @0x0010b060
	private void Start()
	{
		if (!stationary)
		{
			StartCoroutine(LifeCountdown());
		}
	}

	// RECUPERADO-AOT ExplodingBarrel::OnCollisionEnter token 0x060004e3 @0x0010b0bc
	private void OnCollisionEnter(Collision col)
	{
		OnTriggerEnter(col.collider);
	}

	// RECUPERADO-AOT ExplodingBarrel::OnTriggerEnter token 0x060004e4 @0x0010b0fc
	private void OnTriggerEnter(Collider other)
	{
		CarCollider component = other.GetComponent<CarCollider>();
		if (component == null)
		{
			return;
		}
		UnityEngine.Debug.Log("Colliding with Car");
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
					component2.Signal("Barrel collision");
				}
			}
		}
		UnityEngine.Debug.Log("Exploding OnTrigger");
		StartCoroutine(Explode());
	}
}
