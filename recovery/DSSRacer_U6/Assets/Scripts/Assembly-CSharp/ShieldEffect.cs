using UnityEngine;

// Shield: bubble particles around the kart (turned to face the camera) and a looping sound; blocks rockets,
// mines and bumps. Level 2 is reflective and also grants a smash for the same time.
// Source listing: recovery/aot_listings/Assembly-CSharp/ShieldEffect.txt
public class ShieldEffect : BaseEffect
{
	private GameObject parentObject;

	private GameObject particles;

	private GameObject camera;

	public bool Reflective
	{
		// RECUPERADO-AOT ShieldEffect::get_Reflective token 0x060003bb @0x000f7978
		get
		{
			return powerLevel > 1;
		}
	}

	// RECUPERADO-AOT ShieldEffect::.ctor token 0x060003ba @0x000f7908
	public ShieldEffect(GameObject parent)
	{
		parentObject = parent;
		effectType = EffectTypes.ShieldEffect;
		power = 3;
		time = 8f;
		isMultiLevel = true;
	}

	// RECUPERADO-AOT ShieldEffect::Init token 0x060003bc @0x000f79b8
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public override void Init()
	{
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		if (parentObject == null)
		{
			return;
		}
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (powerLevel > 1)
		{
			SmashEffect smashEffect = new SmashEffect(parentObject);
			smashEffect.power = power;
			smashEffect.time = time;
			component.AddEffect(smashEffect);
		}
		if (component.transform.Find("Shield Particle Effect") == null)
		{
			GameObject original = (powerLevel <= 1) ? ParticleLibrary.Instance.GetPrefab("Shield") : ParticleLibrary.Instance.GetPrefab("DoubleShield");
			particles = Object.Instantiate(original, parentObject.transform.position, parentObject.transform.rotation) as GameObject;
			particles.transform.parent = parentObject.transform;
			// The bubble is doubled when the player's body is the monster-truck form.
			if (PlayerInstance.GetCartSlot(CartSlot.Slots.body).partInSlot == PlayerInstance.GetCartSlot(CartSlot.Slots.body).partInSlot.alternateForms.FindFirstWithForm(AlternateForm.BodyForm.MonsterTruck))
			{
				particles.transform.localScale = particles.transform.localScale * 2f;
			}
			particles.name = "Shield Particle Effect";
		}
		if (component != null && component.gameObject.GetComponent<SoundSequencer>() != null)
		{
			component.gameObject.GetComponent<SoundSequencer>().RequestPlayLoop("shieldOn");
		}
	}

	// RECUPERADO-AOT ShieldEffect::Shutdown token 0x060003bd @0x000f7d84
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.DestroyObject -> Destroy.
	public override void Shutdown()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component != null && component.gameObject.GetComponent<SoundSequencer>() != null)
		{
			component.gameObject.GetComponent<SoundSequencer>().StopLoopingSound("shieldOn");
		}
		if (!component.HasEffect(typeof(ShieldEffect)))
		{
			Transform transform = component.transform.Find("Shield Particle Effect");
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
		}
	}

	// RECUPERADO-AOT ShieldEffect::Stack token 0x060003be @0x000f7eb0
	public override bool Stack(BaseEffect second)
	{
		return true;
	}

	// RECUPERADO-AOT ShieldEffect::Update token 0x060003bf @0x000f7ee4
	// Points the bubble away from the camera (it looks at the mirror of the camera position).
	public override void Update()
	{
		if (particles != null && camera != null)
		{
			Vector3 vector = camera.transform.position - particles.transform.position;
			Vector3 worldPosition = particles.transform.position - vector;
			particles.transform.LookAt(worldPosition);
		}
	}

	// RECUPERADO-AOT ShieldEffect::GetEffectSnapShot token 0x060003c0 @0x000f8054
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
