using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Dropped/spread mine: arms after 0.2 s, stays armed 16 s, wipes out the first kart that touches it
// (a level-2 shield turns it into an area blast). Spread mines fly out along spreadVector first.
// Source listing: recovery/aot_listings/Assembly-CSharp/MineAI.txt
public class MineAI : MonoBehaviour
{
	private const int groundLayerMask = 256;

	private const int carLayerMask = 512;

	// RECUPERADO-AOT MineAI::.ctor token 0x0600006a @0x000c9b8c (field initializers)
	public float explosionRadius = 25f;

	public bool isSpread;

	public Vector3 spreadVector = Vector3.zero;

	private float spreadTime = 1.5f;

	private float armedDuration = 16f;

	private float armTime;

	private bool isArmed;

	private GameObject owner;

	// RECUPERADO-AOT MineAI::get_IsArmed token 0x0600006b @0x000c9c2c
	public bool IsArmed
	{
		get
		{
			return isArmed;
		}
	}

	// RECUPERADO-AOT MineAI::OnTriggerEnter token 0x0600006c @0x000c9c60
	// ADAPTADO-U6: Transform.FindChild -> Find.
	private void OnTriggerEnter(Collider other)
	{
		if (!isArmed)
		{
			return;
		}
		CarCollider component = other.gameObject.GetComponent<CarCollider>();
		if (!component)
		{
			return;
		}
		EffectManager component2 = component.gameObject.GetComponent<EffectManager>();
		if (component.IsShielded())
		{
			ShieldEffect shieldEffect = component.gameObject.GetComponent<EffectManager>().GetStrongestEffect(typeof(ShieldEffect)) as ShieldEffect;
			if (shieldEffect.PowerLevel > 1)
			{
				Collider[] array = Physics.OverlapSphere(base.gameObject.transform.position, explosionRadius, 512);
				for (int i = 0; i < array.Length; i++)
				{
					Collider collider = array[i];
					if (collider != null)
					{
						EffectManager component3 = collider.gameObject.GetComponent<EffectManager>();
						if (component3 != null)
						{
							WipeoutEffect wipeoutEffect = new WipeoutEffect(collider.gameObject);
							wipeoutEffect.power = 1;
							wipeoutEffect.time = 2.5f;
							component3.AddEffect(wipeoutEffect);
						}
					}
				}
			}
		}
		else
		{
			WipeoutEffect wipeoutEffect2 = new WipeoutEffect(component.gameObject);
			wipeoutEffect2.power = 1;
			wipeoutEffect2.time = 2.5f;
			component2.AddEffect(wipeoutEffect2);
			if (owner != null && RaceManager.IsPlayerCar(owner))
			{
				if (component == owner.GetComponent<CarCollider>())
				{
					HUDLogic.Instance.ShowMineNotify(PlayerInstance.GetCartSlot(CartSlot.Slots.character).partInSlot.UIName.Text);
				}
				else
				{
					HUDLogic.Instance.ShowMineNotify(component.name);
					CharacterVOController vOController = owner.GetVOController();
					if (vOController != null)
					{
						vOController.PlayCelebrate();
					}
				}
				CarMetrics component4 = owner.GetComponent<CarMetrics>();
				if (component4 != null)
				{
					component4.Signal("MineEffect success");
					CarCollider component5 = owner.GetComponent<CarCollider>();
					if (component5 != null && component5.isInAir)
					{
						component4.Signal("Powerup hit in air");
					}
					LifetimeMetrics.Signal("Lifetime MineEffect success");
				}
			}
		}
		if (other.transform.Find("Explosion Particle Effect") == null)
		{
			GameObject gameObject = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Explosion"), other.transform.position, other.transform.rotation) as GameObject;
			gameObject.transform.parent = other.transform;
			gameObject.name = "Explosion Particle Effect";
		}
		KillAI();
	}

	// RECUPERADO-AOT MineAI::KillAI token 0x0600006d @0x000ca330
	public void KillAI()
	{
		isArmed = false;
		base.gameObject.SetActive(false);
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT MineAI::ArmMine token 0x0600006e @0x000ca388
	// RECUPERADO-AOT MineAI/<ArmMine>c__Iterator3::MoveNext token 0x060007e2 @0x001417f0
	[DebuggerHidden]
	private IEnumerator ArmMine()
	{
		yield return new WaitForSeconds(0.2f);
		isArmed = true;
		armTime = armedDuration;
		yield return null;
	}

	// RECUPERADO-AOT MineAI::Start token 0x0600006f @0x000ca3d0
	private void Start()
	{
		StartCoroutine(ArmMine());
	}

	// RECUPERADO-AOT MineAI::Update token 0x06000070 @0x000ca420
	// Spread flight while airborne: 0.75 s outwards at 10x spreadVector, then 5x plus gravity, then
	// falling at 2.5x gravity until the ground ray (radius + 0.1) hits.
	private void Update()
	{
		if (isArmed)
		{
			armTime -= Time.deltaTime;
			if (armTime <= 0f)
			{
				KillAI();
			}
		}
		if (!isSpread)
		{
			return;
		}
		float distance = 1f;
		SphereCollider component = GetComponent<SphereCollider>();
		if (component != null)
		{
			distance = component.radius + 0.1f;
		}
		if (!Physics.Raycast(base.transform.position, new Vector3(0f, -1f, 0f), distance, 256))
		{
			spreadTime -= Time.deltaTime;
			Vector3 vector = new Vector3(0f, -9.8f, 0f);
			if (spreadTime > 0.75f)
			{
				base.transform.position = base.transform.position + spreadVector * (Time.deltaTime * 10f);
			}
			else if (spreadTime > 0f)
			{
				base.transform.position = base.transform.position + spreadVector * (Time.deltaTime * 5f);
				base.transform.position = base.transform.position + vector * Time.deltaTime;
			}
			else
			{
				base.transform.position = base.transform.position + vector * (Time.deltaTime * 2.5f);
			}
		}
	}

	// RECUPERADO-AOT MineAI::SetOwner token 0x06000071 @0x000ca9f8
	public void SetOwner(GameObject obj)
	{
		owner = obj;
	}
}
