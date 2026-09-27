using UnityEngine;

// Smash (from a level-2 boost): smash particles on the kart for `time` seconds; karts it rams get flipped
// (GimpedCarAI / CarCollider collisions check for this effect).
// Source listing: recovery/aot_listings/Assembly-CSharp/SmashEffect.txt
public class SmashEffect : BaseEffect
{
	private GameObject parentObject;

	// RECUPERADO-AOT SmashEffect::.ctor token 0x060003d3 @0x000f8878
	public SmashEffect(GameObject parent)
	{
		parentObject = parent;
		effectType = EffectTypes.SmashEffect;
		power = 1;
		time = 6f;
	}

	// RECUPERADO-AOT SmashEffect::Init token 0x060003d4 @0x000f88e0
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public override void Init()
	{
		if (parentObject != null)
		{
			EffectManager component = parentObject.GetComponent<EffectManager>();
			if (component.transform.Find("Smash Particle Effect") == null)
			{
				GameObject gameObject = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Smash"), parentObject.transform.position, parentObject.transform.rotation) as GameObject;
				gameObject.transform.parent = parentObject.transform;
				gameObject.name = "Smash Particle Effect";
			}
		}
	}

	// RECUPERADO-AOT SmashEffect::Update token 0x060003d5 @0x000f8abc
	public override void Update()
	{
	}

	// RECUPERADO-AOT SmashEffect::Shutdown token 0x060003d6 @0x000f8ae8
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.DestroyObject -> Destroy.
	public override void Shutdown()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (!component.HasEffect(typeof(SmashEffect)))
		{
			Transform transform = component.transform.Find("Smash Particle Effect");
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
		}
	}

	// RECUPERADO-AOT SmashEffect::Stack token 0x060003d7 @0x000f8bb0
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT SmashEffect::GetEffectSnapShot token 0x060003d8 @0x000f8be4
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
