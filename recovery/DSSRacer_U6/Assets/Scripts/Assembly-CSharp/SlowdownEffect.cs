using UnityEngine;

// Slowdown (-power % to acceleration and top speed through CarCollider), e.g. slow terrain or a shock.
// Source listing: recovery/aot_listings/Assembly-CSharp/SlowdownEffect.txt
// (Adelantado de la Etapa 4 en 3.9: lo usan las pistas y los choques de la carrera.)
public class SlowdownEffect : BaseEffect
{
	private GameObject parentObject;

	// RECUPERADO-AOT SlowdownEffect::.ctor token 0x060003cd @0x000f869c
	public SlowdownEffect(GameObject parent)
	{
		parentObject = parent;
		effectType = EffectTypes.SlowdownEffect;
		power = 50;
		time = 2f;
	}

	// RECUPERADO-AOT SlowdownEffect::Init token 0x060003ce @0x000f8704 (empty)
	public override void Init()
	{
	}

	// RECUPERADO-AOT SlowdownEffect::Update token 0x060003cf @0x000f8730 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT SlowdownEffect::Shutdown token 0x060003d0 @0x000f875c
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public override void Shutdown()
	{
		if (parentObject.GetComponent<EffectManager>() != null)
		{
			Transform transform = parentObject.transform.Find("Shocked Engine Particle");
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
		}
	}

	// RECUPERADO-AOT SlowdownEffect::Stack token 0x060003d1 @0x000f8814
	public override bool Stack(BaseEffect second)
	{
		return true;
	}

	// RECUPERADO-AOT SlowdownEffect::GetEffectSnapShot token 0x060003d2 @0x000f8848
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
