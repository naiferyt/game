using UnityEngine;

// Electric shock (Phineas and Ferb shock pads): a slowdown of the same power and time plus sparks on the
// engine (removed by the slowdown's Shutdown).
// Source listing: recovery/aot_listings/Assembly-CSharp/ShockedEffect.txt
// (Adelantado de la Etapa 4 en 3.9: lo usan las pistas y los choques de la carrera.)
public class ShockedEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject shockParticle;

	// RECUPERADO-AOT ShockedEffect::.ctor token 0x060003c1 @0x000f8084
	public ShockedEffect(GameObject owner)
	{
		effectType = EffectTypes.ShockEffect;
		parentObject = owner;
		power = 50;
		time = 4f;
	}

	// RECUPERADO-AOT ShockedEffect::Init token 0x060003c2 @0x000f80ec
	// (The empty "ShockedParticle" object is created and then replaced, as in the original.)
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public override void Init()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component != null)
		{
			SlowdownEffect slowdownEffect = new SlowdownEffect(parentObject);
			slowdownEffect.time = time;
			slowdownEffect.power = power;
			component.AddEffect(slowdownEffect);
		}
		if (parentObject.transform.Find("Shocked Engine Particle") == null)
		{
			shockParticle = new GameObject("ShockedParticle");
			shockParticle = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("ShockedEngine"), parentObject.transform.position, parentObject.transform.rotation) as GameObject;
			shockParticle.name = "Shocked Engine Particle";
			shockParticle.transform.parent = parentObject.transform;
		}
		CharacterVOController vOController = parentObject.GetVOController();
		if (vOController != null)
		{
			vOController.PlayPout();
		}
	}

	// RECUPERADO-AOT ShockedEffect::Update token 0x060003c3 @0x000f8398 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT ShockedEffect::Shutdown token 0x060003c4 @0x000f83c4 (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT ShockedEffect::Stack token 0x060003c5 @0x000f83f0
	// A new shock only refreshes the time of the current one.
	public override bool Stack(BaseEffect second)
	{
		time = second.time;
		return false;
	}

	// RECUPERADO-AOT ShockedEffect::GetEffectSnapShot token 0x060003c6 @0x000f843c
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
