using UnityEngine;

// Trip line (Booster + Shield combo): drags a trip-wire behind the kart for 6 s while boosting and
// shielded; the shield bubble is replaced by the "Tripwire Shield" particles.
// Source listing: recovery/aot_listings/Assembly-CSharp/TripLineEffect.txt
public class TripLineEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject particles;

	private GameObject camera;

	private GameObject line;

	// RECUPERADO-AOT TripLineEffect::.ctor token 0x060003eb @0x000f9644
	public TripLineEffect(GameObject owner)
	{
		effectType = EffectTypes.TripLineEffect;
		parentObject = owner;
		time = 6f;
	}

	// RECUPERADO-AOT TripLineEffect::Start token 0x060003ec @0x000f96a4
	private void Start()
	{
	}

	// RECUPERADO-AOT TripLineEffect::Init token 0x060003ed @0x000f96d0
	// ADAPTADO-U6: Transform.FindChild -> Find.
	// Note (original): the "Shield Particle Effect" lookup runs on the EffectManager without a null
	// check, so a car without one throws there.
	public override void Init()
	{
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		if (!(parentObject != null))
		{
			return;
		}
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component != null)
		{
			line = Object.Instantiate(component.tripLinePrefab, parentObject.transform.position, parentObject.transform.rotation) as GameObject;
			line.SetActive(true);
			line.transform.parent = parentObject.transform;
			component.AddEffect(new BoosterEffect(parentObject));
			component.AddEffect(new ShieldEffect(parentObject));
		}
		Transform transform = component.transform.Find("Shield Particle Effect");
		if (transform != null)
		{
			Object.Destroy(transform.gameObject);
		}
		particles = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Tripwire Shield"), parentObject.transform.position, parentObject.transform.rotation) as GameObject;
		particles.transform.parent = parentObject.transform;
		if (PlayerInstance.GetCartSlot(CartSlot.Slots.body).partInSlot == PlayerInstance.GetCartSlot(CartSlot.Slots.body).partInSlot.alternateForms.FindFirstWithForm(AlternateForm.BodyForm.MonsterTruck))
		{
			particles.transform.localScale = particles.transform.localScale * 2f;
		}
		particles.name = "Shield Particle Effect";
	}

	// RECUPERADO-AOT TripLineEffect::Update token 0x060003ee @0x000f9b3c
	// Same billboard as ShieldEffect: faces the particles away from the camera.
	public override void Update()
	{
		if (particles != null && camera != null)
		{
			Vector3 vector = camera.transform.position - particles.transform.position;
			Vector3 worldPosition = particles.transform.position - vector;
			particles.transform.LookAt(worldPosition);
		}
	}

	// RECUPERADO-AOT TripLineEffect::Shutdown token 0x060003ef @0x000f9cac
	// ADAPTADO-U6: FindChild -> Find, DestroyObject -> Destroy.
	public override void Shutdown()
	{
		if (line != null)
		{
			Object.Destroy(line);
		}
		Transform transform = parentObject.GetComponent<EffectManager>().transform.Find("Shield Particle Effect");
		if (transform != null)
		{
			Object.Destroy(transform.gameObject);
		}
	}

	// RECUPERADO-AOT TripLineEffect::Stack token 0x060003f0 @0x000f9d68
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT TripLineEffect::GetEffectSnapShot token 0x060003f1 @0x000f9d9c
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
