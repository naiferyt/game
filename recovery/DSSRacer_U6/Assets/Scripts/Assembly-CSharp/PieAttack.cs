using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Flying pie: hitting the player splats the screen (side taken from where it came from), hitting a rival wipes it out;
// explodes on contact or after lifeTime seconds; its rigidbody is frozen while the race is paused.
// Source listing: recovery/aot_listings/Assembly-CSharp/PieAttack.txt
public class PieAttack : MonoBehaviour
{
	// RECUPERADO-AOT PieAttack::.ctor token 0x060004e8 @0x0010b77c (field initializers)
	public float lifeTime = 6f;

	public bool stationary;

	private Vector3 velocityForPause = Vector3.zero;

	private bool paused;

	// RECUPERADO-AOT PieAttack::LifeCountdown token 0x060004e9 @0x0010b7ec
	// RECUPERADO-AOT PieAttack/<LifeCountdown>c__Iterator39::MoveNext token 0x0600092a @0x0014d3f0
	[DebuggerHidden]
	private IEnumerator LifeCountdown()
	{
		yield return new WaitForSeconds(lifeTime);
		Explode();
	}

	// RECUPERADO-AOT PieAttack::Update token 0x060004ea @0x0010b834
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

	// RECUPERADO-AOT PieAttack::Explode token 0x060004eb @0x0010b964
	public void Explode()
	{
		StartCoroutine(ExplodeCoroutine());
	}

	// RECUPERADO-AOT PieAttack::ExplodeCoroutine token 0x060004ec @0x0010b9b4
	// RECUPERADO-AOT PieAttack/<ExplodeCoroutine>c__Iterator3A::MoveNext token 0x06000930 @0x0014d5d0
	[DebuggerHidden]
	private IEnumerator ExplodeCoroutine()
	{
		while (RaceManager.isPaused)
		{
			yield return null;
		}
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT PieAttack::Start token 0x060004ed @0x0010b9fc
	private void Start()
	{
		if (!stationary)
		{
			StartCoroutine(LifeCountdown());
		}
	}

	// RECUPERADO-AOT PieAttack::OnCollisionEnter token 0x060004ee @0x0010ba58
	private void OnCollisionEnter(Collision col)
	{
		OnTriggerEnter(col.collider);
	}

	// RECUPERADO-AOT PieAttack::OnTriggerEnter token 0x060004ef @0x0010ba98
	private void OnTriggerEnter(Collider other)
	{
		CarCollider component = other.GetComponent<CarCollider>();
		if (component == null)
		{
			return;
		}
		if (component.EffectMgr != null && !component.EffectMgr.HasEffect(typeof(ShieldEffect)))
		{
			if (RaceManager.IsPlayerCar(other.gameObject))
			{
				PieHitEffect.HitDirection dir = PieHitEffect.HitDirection.Right;
				Vector3 vector = base.transform.position - other.transform.position;
				if (Vector3.Dot(other.transform.right, vector.normalized) < 0f)
				{
					dir = PieHitEffect.HitDirection.Left;
				}
				PieHitEffect pieHitEffect = new PieHitEffect(other.gameObject, dir);
				pieHitEffect.time = 5f;
				component.EffectMgr.AddEffect(pieHitEffect);
				CarMetrics component2 = other.gameObject.GetComponent<CarMetrics>();
				if (component2 != null)
				{
					component2.Signal("Pie collision");
				}
			}
			else
			{
				WipeoutEffect wipeoutEffect = new WipeoutEffect(other.gameObject);
				wipeoutEffect.power = 150;
				wipeoutEffect.time = 2f;
				component.EffectMgr.AddEffect(wipeoutEffect);
			}
		}
		Explode();
	}
}
