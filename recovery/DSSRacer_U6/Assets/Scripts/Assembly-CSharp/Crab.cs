using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Track hazard: wanders around its start point (new random target every wanderRate seconds) and wipes out karts it touches.
// Source listing: recovery/aot_listings/Assembly-CSharp/Crab.txt
[RequireComponent(typeof(Collider))]
public class Crab : MonoBehaviour
{
	// RECUPERADO-AOT Crab::.ctor token 0x060004d7 @0x0010a420 (field initializers)
	public float wanderRadius = 15f;

	public float wanderRate = 3f;

	public float wanderMaxSpeed = 60f;

	public float wanderAccel = 10f;

	private Vector3 homePoint = Vector3.zero;

	private Vector3 wanderPoint = Vector3.zero;

	private float wanderTimer;

	private float linearVelocity;

	// RECUPERADO-AOT Crab::SleepRoutine token 0x060004d8 @0x0010a4fc
	// RECUPERADO-AOT Crab/<SleepRoutine>c__Iterator36::MoveNext token 0x06000918 @0x0014ccb8
	[DebuggerHidden]
	private IEnumerator SleepRoutine(float time)
	{
		base.gameObject.SetActive(false);
		yield return new WaitForSeconds(time);
		base.gameObject.SetActive(true);
	}

	// RECUPERADO-AOT Crab::Start token 0x060004d9 @0x0010a568
	private void Start()
	{
		homePoint = base.transform.position;
	}

	// RECUPERADO-AOT Crab::Update token 0x060004da @0x0010a5d0
	private void Update()
	{
		wanderTimer -= Time.deltaTime;
		if (!(wanderTimer > 0f))
		{
			wanderTimer = wanderRate;
			wanderPoint = Random.onUnitSphere * wanderRadius * Random.value;
			wanderPoint.y = 0f;
			wanderPoint = base.transform.rotation * wanderPoint;
			wanderPoint = wanderPoint + homePoint;
		}
	}

	// RECUPERADO-AOT Crab::FixedUpdate token 0x060004db @0x0010a7f0
	private void FixedUpdate()
	{
		Vector3 vector = wanderPoint - base.transform.position;
		if (!(vector.magnitude > 0.1f))
		{
			linearVelocity = 0f;
			return;
		}
		linearVelocity += wanderAccel * Time.deltaTime;
		if (Vector3.Angle(base.transform.forward, vector.normalized) < 15f)
		{
			linearVelocity = Mathf.Min(linearVelocity, wanderMaxSpeed);
		}
		else
		{
			linearVelocity = Mathf.Min(linearVelocity, 0.5f);
		}
		Vector3 position = base.transform.position + base.transform.forward * linearVelocity * Time.deltaTime;
		Quaternion b = Quaternion.LookRotation(wanderPoint - base.transform.position);
		base.transform.position = position;
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 3f);
	}

	// RECUPERADO-AOT Crab::OnTriggerEnter token 0x060004dc @0x0010ac60
	private void OnTriggerEnter(Collider other)
	{
		CarCollider component = other.GetComponent<CarCollider>();
		if (component != null)
		{
			WipeoutEffect wipeoutEffect = new WipeoutEffect(component.gameObject);
			wipeoutEffect.power = 50;
			wipeoutEffect.time = 1f;
			component.EffectMgr.AddEffect(wipeoutEffect);
			if (RaceManager.IsPlayerCar(other.gameObject))
			{
				CarMetrics component2 = other.gameObject.GetComponent<CarMetrics>();
				if (component2 != null)
				{
					component2.Signal("Crab collision");
				}
			}
		}
	}

	// RECUPERADO-AOT Crab::OnDrawGizmos token 0x060004dd @0x0010ada4
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(base.transform.position, wanderRadius);
	}
}
