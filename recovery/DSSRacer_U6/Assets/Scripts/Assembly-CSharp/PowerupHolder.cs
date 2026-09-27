using System.Collections.Generic;
using UnityEngine;

// A kart's power-up reserve (up to 2). Firing it applies one power-up, two of the same multi-level kind as a
// level-2 power-up, or two different ones as their combo (BaseEffect.GetComboEffectType) when one exists.
// Source listing: recovery/aot_listings/Assembly-CSharp/PowerupHolder.txt
public class PowerupHolder : MonoBehaviour
{
	private const int maxPowerups = 2;

	// RECUPERADO-AOT PowerupHolder::.ctor token 0x06000467 @0x00101fd8 (field initializers)
	public bool allowPowerups = true;

	public bool buttonDisabled;

	private EffectManager em;

	private CarMetrics metrics;

	private bool isCombo;

	private List<BaseEffect> effectsInReserve = new List<BaseEffect>(2);

	public BaseEffect this[int index]
	{
		// RECUPERADO-AOT PowerupHolder::get_Item token 0x06000469 @0x001020ac
		get
		{
			if (index < 0 || index >= effectsInReserve.Count)
			{
				Debug.LogError("Tried to get a powerup at an illegal index!");
			}
			return effectsInReserve[index];
		}
	}

	public int numEffects
	{
		// RECUPERADO-AOT PowerupHolder::get_numEffects token 0x0600046a @0x0010212c
		get
		{
			return effectsInReserve.Count;
		}
	}

	public bool CanTakePowerup
	{
		// RECUPERADO-AOT PowerupHolder::get_CanTakePowerup token 0x0600046b @0x0010216c
		get
		{
			return effectsInReserve.Count < 2 && allowPowerups;
		}
	}

	// RECUPERADO-AOT PowerupHolder::Awake token 0x06000468 @0x0010203c
	private void Awake()
	{
		em = base.gameObject.GetComponent<EffectManager>();
		metrics = GetComponent<CarMetrics>();
	}

	// RECUPERADO-AOT PowerupHolder::Update token 0x0600046c @0x001021c8
	private void Update()
	{
		if (em == null)
		{
			em = base.gameObject.GetComponent<EffectManager>();
		}
		if (metrics == null)
		{
			metrics = base.gameObject.GetComponent<CarMetrics>();
		}
		if (em != null)
		{
			if (em.HasEffect(typeof(GuidedJumpEffect)))
			{
				buttonDisabled = true;
			}
			else
			{
				buttonDisabled = false;
			}
		}
	}

	// RECUPERADO-AOT PowerupHolder::AddEffect token 0x0600046d @0x001022bc
	public void AddEffect(BaseEffect newEffect)
	{
		if (!CanTakePowerup)
		{
			Debug.LogError("Trying to add an effect when CanTakePowerup is false!");
			return;
		}
		effectsInReserve.Add(newEffect);
		if (!RaceManager.IsPlayerCar(base.gameObject))
		{
			return;
		}
		if (HUDLogic.Instance != null)
		{
			HUDLogic.Instance.puNeedsUpdate = true;
			HUDLogic.Instance.SendMessage("UpdateHUD");
		}
		if (DataUtility.Instance.CurSettings.raceType != RaceSettings.RaceModes.Mission)
		{
			LifetimeMetrics.Signal("Lifetime Powerup Collection");
		}
		if (metrics != null)
		{
			metrics.Signal("Collected " + newEffect.effectType.ToString());
		}
	}

	// RECUPERADO-AOT PowerupHolder::HasEffect token 0x0600046e @0x0010243c
	public bool HasEffect(BaseEffect.EffectTypes type)
	{
		foreach (BaseEffect item in effectsInReserve)
		{
			if (item.effectType == type)
			{
				return true;
			}
		}
		return false;
	}

	// RECUPERADO-AOT PowerupHolder::ClearEffectsInReserve token 0x0600046f @0x001025a4
	public bool ClearEffectsInReserve()
	{
		effectsInReserve.Clear();
		return effectsInReserve.Count == 0;
	}

	// RECUPERADO-AOT PowerupHolder::ExecutePowerups token 0x06000470 @0x00102604
	// (isCombo is never cleared, as in the original: after the first combo, pairs no longer log "Used <type>")
	public void ExecutePowerups()
	{
		if (RaceManager.IsPlayerCar(base.gameObject) && effectsInReserve.Count > 0 && base.gameObject.GetComponent<MissionManager>() != null)
		{
			base.gameObject.GetComponent<MissionManager>().Signal("Used Powerup");
		}
		if (em == null || em.HasEffect(typeof(GuidedJumpEffect)) || effectsInReserve.Count == 0)
		{
			return;
		}
		if (effectsInReserve.Count == 1)
		{
			em.AddEffect(effectsInReserve[0]);
		}
		else
		{
			if (effectsInReserve.Count != 2)
			{
				Debug.LogError("Unsupported number of effects in reserve!");
				return;
			}
			if (effectsInReserve[0].effectType == effectsInReserve[1].effectType && effectsInReserve[0].IsMultiLevel)
			{
				BaseEffect baseEffect = effectsInReserve[0];
				baseEffect.power = Mathf.Max(baseEffect.power, effectsInReserve[1].power);
				baseEffect.time = Mathf.Max(baseEffect.time, effectsInReserve[1].time);
				baseEffect.PowerLevel = 2;
				em.AddEffect(baseEffect);
			}
			else if (!PowerupComboCheck())
			{
				em.AddEffect(effectsInReserve[0]);
				em.AddEffect(effectsInReserve[1]);
			}
			if (base.gameObject.GetComponent<MissionManager>() != null)
			{
				base.gameObject.GetComponent<MissionManager>().Signal("Combined Powerup");
			}
		}
		if (metrics != null)
		{
			metrics.Signal("Powerup Used");
			if (effectsInReserve.Count == 2)
			{
				if (effectsInReserve[0].effectType == effectsInReserve[1].effectType && effectsInReserve[0].IsMultiLevel)
				{
					metrics.Signal("Used Double " + effectsInReserve[0].effectType.ToString());
					if (DataUtility.Instance.CurSettings.raceType != RaceSettings.RaceModes.Mission)
					{
						LifetimeMetrics.Signal("Used Double " + effectsInReserve[0].effectType.ToString());
					}
				}
				else if (!isCombo)
				{
					metrics.Signal("Used " + effectsInReserve[0].effectType.ToString());
					metrics.Signal("Used " + effectsInReserve[1].effectType.ToString());
				}
			}
			else if (effectsInReserve.Count == 1)
			{
				metrics.Signal("Used " + effectsInReserve[0].effectType.ToString());
			}
		}
		effectsInReserve.Clear();
		if (RaceManager.IsPlayerCar(base.gameObject))
		{
			HUDLogic instance = HUDLogic.Instance;
			if (instance != null)
			{
				instance.puNeedsUpdate = true;
				instance.SendMessage("UpdateHUD");
			}
		}
	}

	// RECUPERADO-AOT PowerupHolder::PowerupComboCheck token 0x06000471 @0x00102d74
	private bool PowerupComboCheck()
	{
		BaseEffect.EffectTypes comboType;
		bool comboEffectType = BaseEffect.GetComboEffectType(effectsInReserve[0].effectType, effectsInReserve[1].effectType, out comboType);
		if (!comboEffectType)
		{
			return comboEffectType;
		}
		BaseEffect baseEffect;
		switch (comboType)
		{
		case BaseEffect.EffectTypes.BoatAnchorEffect:
			baseEffect = em != null ? new BoatAnchorEffect(base.gameObject) : null;
			break;
		case BaseEffect.EffectTypes.RocketRideEffect:
			baseEffect = em != null ? new RocketRideEffect(base.gameObject) : null;
			break;
		case BaseEffect.EffectTypes.TripLineEffect:
			baseEffect = em != null ? new TripLineEffect(base.gameObject) : null;
			break;
		case BaseEffect.EffectTypes.PowerupMagnetEffect:
			baseEffect = em != null ? new PowerupMagnet(base.gameObject) : null;
			break;
		case BaseEffect.EffectTypes.SpreadMineEffect:
			baseEffect = em != null ? new SpreadMineEffect(base.gameObject) : null;
			break;
		case BaseEffect.EffectTypes.RandomShotEffect:
			baseEffect = em != null ? new RandomShotEffect(base.gameObject) : null;
			break;
		default:
			return comboEffectType;
		}
		if (baseEffect != null)
		{
			em.AddEffect(baseEffect);
			if (DataUtility.Instance.CurSettings.raceType != RaceSettings.RaceModes.Mission)
			{
				LifetimeMetrics.Signal("Used Double " + comboType.ToString());
			}
		}
		isCombo = true;
		return comboEffectType;
	}
}
