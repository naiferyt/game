using UnityEngine;

// Speed boost (+power % to acceleration and top speed through CarCollider): flame particles at the kart
// and its fire slots, full-screen streaks and camera shake for the player; a multi-level boost also
// grants a longer smash.
// Source listing: recovery/aot_listings/Assembly-CSharp/BoosterEffect.txt
// (Adelantado de la Etapa 4 en 3.9: lo usan las pistas y los choques de la carrera.)
public class BoosterEffect : BaseEffect
{
	private GameObject parentObject;

	// RECUPERADO-AOT BoosterEffect::.ctor token 0x06000363 @0x000f18e0
	public BoosterEffect(GameObject parent)
	{
		parentObject = parent;
		effectType = EffectTypes.BoosterEffect;
		power = 50;
		time = 6f;
		isMultiLevel = true;
	}

	// RECUPERADO-AOT BoosterEffect::Init token 0x06000364 @0x000f1950
	// ADAPTADO-U6: Transform.FindChild -> Find; the legacy ParticleEmitter of the fire-slot flames (converted
	// to a ParticleSystem in Stage 0) gets the same tweaks through the ParticleSystem modules: size x0.5,
	// local velocity Z x0.4 (velocity-over-lifetime Z, where the conversion put the local velocity).
	public override void Init()
	{
		if (parentObject == null)
		{
			return;
		}
		EffectManager component = parentObject.GetComponent<EffectManager>();
		SoundSequencer component2 = component.gameObject.GetComponent<SoundSequencer>();
		if (component.transform.Find("Booster Particle Effect") == null)
		{
			GameObject prefab = ParticleLibrary.Instance.GetPrefab("Boost");
			GameObject gameObject = Object.Instantiate(prefab, parentObject.transform.position, parentObject.transform.rotation) as GameObject;
			gameObject.transform.parent = parentObject.transform;
			gameObject.name = "Booster Particle Effect";
			Transform[] componentsInChildren = component.transform.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!(componentsInChildren[i].name == "FireSlot"))
				{
					continue;
				}
				GameObject gameObject2 = Object.Instantiate(prefab, componentsInChildren[i].position, componentsInChildren[i].rotation) as GameObject;
				gameObject2.transform.parent = componentsInChildren[i];
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.transform.localScale = gameObject2.transform.localScale * 0.4f;
				gameObject2.name = "Booster Particle Effect";
				ParticleSystem componentInChildren = gameObject2.GetComponentInChildren<ParticleSystem>();
				if (componentInChildren != null)
				{
					ParticleSystem.MainModule main = componentInChildren.main;
					main.startSizeMultiplier *= 0.5f;
					ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = componentInChildren.velocityOverLifetime;
					if (velocityOverLifetime.enabled)
					{
						velocityOverLifetime.zMultiplier *= 0.4f;
					}
				}
			}
		}
		if (component2 != null)
		{
			component2.RequestPlay("boosterFire");
		}
		if (RaceManager.IsPlayerCar(parentObject) && GameObject.Find("Full Screen Booster Effect") == null)
		{
			GameObject gameObject3 = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("FScreenBoost")) as GameObject;
			gameObject3.name = "Full Screen Booster Effect";
		}
		if (powerLevel > 1)
		{
			SmashEffect smashEffect = new SmashEffect(parentObject);
			time *= 1.5f;
			smashEffect.power = powerLevel;
			smashEffect.time = time;
			component.AddEffect(smashEffect);
		}
		FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
		if (parentObject == RaceManager.GetPlayerCar())
		{
			CameraShake component3 = followCamera.GetComponent<CameraShake>();
			if (component3 != null)
			{
				component3.TurnOnShake(1f, 0.1f);
			}
		}
	}

	// RECUPERADO-AOT BoosterEffect::Update token 0x06000365 @0x000f2178 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT BoosterEffect::Shutdown token 0x06000366 @0x000f21a4
	// Once no boost is left: removes the flames, the full-screen streaks and the camera shake.
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.DestroyObject -> Destroy.
	public override void Shutdown()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component.HasEffect(typeof(BoosterEffect)))
		{
			return;
		}
		Transform transform = component.transform.Find("Booster Particle Effect");
		if (transform != null)
		{
			Object.Destroy(transform.gameObject);
		}
		Transform[] componentsInChildren = component.transform.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].name == "FireSlot")
			{
				Transform transform2 = componentsInChildren[i].Find("Booster Particle Effect");
				if (transform2 != null)
				{
					Object.Destroy(transform2.gameObject);
				}
			}
		}
		if (RaceManager.IsPlayerCar(parentObject))
		{
			GameObject gameObject = GameObject.Find("Full Screen Booster Effect");
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}
		FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
		CameraShake component2 = followCamera.GetComponent<CameraShake>();
		if (component2 != null)
		{
			component2.TurnOffShake();
		}
		SoundSequencer component3 = component.gameObject.GetComponent<SoundSequencer>();
		if (component3 != null)
		{
			component3.StopLoopingSound("rocketFlight");
		}
	}

	// RECUPERADO-AOT BoosterEffect::Stack token 0x06000367 @0x000f24a4
	public override bool Stack(BaseEffect second)
	{
		return true;
	}

	// RECUPERADO-AOT BoosterEffect::GetEffectSnapShot token 0x06000368 @0x000f24d8
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
