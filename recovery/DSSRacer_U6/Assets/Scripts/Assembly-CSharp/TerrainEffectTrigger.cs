using UnityEngine;

// Track surface volume (boost strip, oil slick, slow zone...): applies its effect to karts entering it.
// Source listing: recovery/aot_listings/Assembly-CSharp/TerrainEffectTrigger.txt
public class TerrainEffectTrigger : MonoBehaviour
{
	public BaseEffect.EffectTypes effectType;

	// RECUPERADO-AOT TerrainEffectTrigger::.ctor token 0x060004fe @0x0010c6a4 (field initializers)
	public int power = 50;

	public float time = 2f;

	public bool removeOnExit;

	public bool oilSlick;

	private BaseEffect spawnedEffect;

	// RECUPERADO-AOT TerrainEffectTrigger::Start token 0x060004ff @0x0010c6f8 (empty)
	private void Start()
	{
	}

	// RECUPERADO-AOT TerrainEffectTrigger::OnTriggerEnter token 0x06000500 @0x0010c724
	// Boost strips only work when driven along their direction (within 90 degrees); shields block harmful
	// effects other than slowdowns.
	private void OnTriggerEnter(Collider other)
	{
		EffectManager component = other.gameObject.GetComponent<EffectManager>();
		CarCollider component2 = other.gameObject.GetComponent<CarCollider>();
		if (component == null || (effectType == BaseEffect.EffectTypes.BoosterEffect && !(Vector3.Angle(other.transform.forward, base.transform.forward) <= 90f)))
		{
			return;
		}
		spawnedEffect = BaseEffect.GetEffectInstance(effectType, other.gameObject);
		if (spawnedEffect == null)
		{
			return;
		}
		spawnedEffect.power = power;
		spawnedEffect.time = time;
		if (!(component2 != null) || effectType == BaseEffect.EffectTypes.SlowdownEffect || spawnedEffect.isBeneficial() || !component2.IsShielded())
		{
			component.AddEffect(spawnedEffect);
			if (oilSlick)
			{
				SoundSequencer component3 = component.gameObject.GetComponent<SoundSequencer>();
				if (component3 != null)
				{
					component3.RequestPlay("Oil Slide");
				}
			}
			CarMetrics component4 = other.GetComponent<CarMetrics>();
			if (component4 != null)
			{
				if (spawnedEffect.effectType == BaseEffect.EffectTypes.BoosterEffect)
				{
					component4.Signal("Boost Strip Hit");
				}
				else if (!spawnedEffect.isBeneficial())
				{
					component4.Signal("Hazzard Hit");
				}
			}
		}
	}

	// RECUPERADO-AOT TerrainEffectTrigger::OnTriggerExit token 0x06000501 @0x0010ca18
	private void OnTriggerExit(Collider other)
	{
		if (removeOnExit && spawnedEffect != null)
		{
			EffectManager component = other.gameObject.GetComponent<EffectManager>();
			if (component != null)
			{
				component.RemoveEffect(spawnedEffect);
			}
		}
	}
}
