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
			return default(BaseEffect);
		}
	}

	public int numEffects
	{
		get
		{
			return default(int);
		}
	}

	public bool CanTakePowerup
	{
		get
		{
			return default(bool);
		}
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void AddEffect(BaseEffect newEffect)
	{
	}

	public bool HasEffect(BaseEffect.EffectTypes type)
	{
		return default(bool);
	}

	public bool ClearEffectsInReserve()
	{
		return default(bool);
	}

	public void ExecutePowerups()
	{
	}

	private bool PowerupComboCheck()
	{
		return default(bool);
	}
}
