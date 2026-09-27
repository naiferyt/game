using System.Collections.Generic;
using UnityEngine;

// Magnet (Shield + Pickup combo): shields the kart and every 0.15 s grabs "Pickup"-tagged objects
// within magnetRadius, pulling them in (coins 5x faster).
// Source listing: recovery/aot_listings/Assembly-CSharp/PowerupMagnet.txt
public class PowerupMagnet : BaseEffect
{
	private const float TIME_DELAY = 0.15f;

	public GameObject parentObject;

	// RECUPERADO-AOT PowerupMagnet::.ctor token 0x0600039b @0x000f5500 (initializers + body below)
	public float magnetRadius = 25f;

	public float pullSpeed = 8f;

	public float timer = 0.15f;

	private EffectManager em;

	private List<GameObject> itemList;

	private GameObject particles;

	private GameObject camera;

	public PowerupMagnet(GameObject owner)
	{
		parentObject = owner;
		effectType = EffectTypes.PowerupMagnetEffect;
		time = 10f;
		em = parentObject.GetComponent<EffectManager>();
		itemList = new List<GameObject>();
	}

	// RECUPERADO-AOT PowerupMagnet::Start token 0x0600039c @0x000f55fc
	private void Start()
	{
	}

	// RECUPERADO-AOT PowerupMagnet::Init token 0x0600039d @0x000f5628
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public override void Init()
	{
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		if (em != null)
		{
			em.AddEffect(new ShieldEffect(parentObject));
		}
		GameObject prefab = ParticleLibrary.Instance.GetPrefab("MagnetShield");
		Transform transform = em.transform.Find("Shield Particle Effect");
		if (transform != null)
		{
			Object.Destroy(transform.gameObject);
		}
		particles = Object.Instantiate(prefab, parentObject.transform.position, parentObject.transform.rotation) as GameObject;
		particles.transform.parent = parentObject.transform;
		if (PlayerInstance.GetCartSlot(CartSlot.Slots.body).partInSlot == PlayerInstance.GetCartSlot(CartSlot.Slots.body).partInSlot.alternateForms.FindFirstWithForm(AlternateForm.BodyForm.MonsterTruck))
		{
			particles.transform.localScale = particles.transform.localScale * 2f;
		}
		particles.name = "Shield Particle Effect";
	}

	// RECUPERADO-AOT PowerupMagnet::Update token 0x0600039e @0x000f5920
	public override void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			Collider[] array = Physics.OverlapSphere(parentObject.transform.position, magnetRadius);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.CompareTag("Pickup"))
				{
					itemList.Add(array[i].gameObject);
				}
			}
			timer = 0.15f;
		}
		if (particles != null && camera != null)
		{
			Vector3 vector = camera.transform.position - particles.transform.position;
			Vector3 worldPosition = particles.transform.position - vector;
			particles.transform.LookAt(worldPosition);
		}
	}

	// RECUPERADO-AOT PowerupMagnet::FixedUpdate token 0x0600039f @0x000f5c1c
	public override void FixedUpdate()
	{
		foreach (GameObject item in itemList)
		{
			if (item != null)
			{
				Vector3 normalized = (parentObject.transform.position - item.transform.position).normalized;
				if (item.GetComponent<Coin>() != null)
				{
					item.transform.position = item.transform.position + normalized * (pullSpeed * 5f * Time.deltaTime);
				}
				else
				{
					item.transform.position = item.transform.position + normalized * (pullSpeed * Time.deltaTime);
				}
			}
		}
	}

	// RECUPERADO-AOT PowerupMagnet::Shutdown token 0x060003a0 @0x000f5fa0
	// ADAPTADO-U6: FindChild -> Find, DestroyObject -> Destroy.
	// Note (original): every object the magnet grabbed and that is still alive is destroyed.
	public override void Shutdown()
	{
		Transform transform = parentObject.GetComponent<EffectManager>().transform.Find("Shield Particle Effect");
		if (transform != null)
		{
			Object.Destroy(transform.gameObject);
		}
		for (int i = 0; i < itemList.Count; i++)
		{
			Object.Destroy(itemList[i]);
		}
	}

	// RECUPERADO-AOT PowerupMagnet::Stack token 0x060003a1 @0x000f6078
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT PowerupMagnet::GetEffectSnapShot token 0x060003a2 @0x000f60ac
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
