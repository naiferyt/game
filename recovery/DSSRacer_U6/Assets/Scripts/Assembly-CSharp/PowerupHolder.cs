using System.Collections.Generic;
using UnityEngine;

public class PowerupHolder : MonoBehaviour
{
	private const int maxPowerups = 2;

	public bool allowPowerups;

	public bool buttonDisabled;

	private EffectManager em;

	private CarMetrics metrics;

	private bool isCombo;

	private List<BaseEffect> effectsInReserve;

	public BaseEffect this[int index]
	{
		get
		{
			RecoveryPending.Hit("PowerupHolder.get_Item");
			return default(BaseEffect);
		}
	}

	public int numEffects
	{
		get
		{
			RecoveryPending.Hit("PowerupHolder.get_numEffects");
			return default(int);
		}
	}

	public bool CanTakePowerup
	{
		get
		{
			RecoveryPending.Hit("PowerupHolder.get_CanTakePowerup");
			return default(bool);
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("PowerupHolder.Awake");
	}

	private void Update()
	{
		RecoveryPending.Hit("PowerupHolder.Update");
	}

	public void AddEffect(BaseEffect newEffect)
	{
		RecoveryPending.Hit("PowerupHolder.AddEffect");
	}

	public bool HasEffect(BaseEffect.EffectTypes type)
	{
		RecoveryPending.Hit("PowerupHolder.HasEffect");
		return default(bool);
	}

	public bool ClearEffectsInReserve()
	{
		RecoveryPending.Hit("PowerupHolder.ClearEffectsInReserve");
		return default(bool);
	}

	public void ExecutePowerups()
	{
		RecoveryPending.Hit("PowerupHolder.ExecutePowerups");
	}

	private bool PowerupComboCheck()
	{
		RecoveryPending.Hit("PowerupHolder.PowerupComboCheck");
		return default(bool);
	}
}
