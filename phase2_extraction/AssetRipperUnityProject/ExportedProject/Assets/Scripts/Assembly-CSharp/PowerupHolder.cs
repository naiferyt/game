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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public int numEffects
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool CanTakePowerup
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool ClearEffectsInReserve()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void ExecutePowerups()
	{
	}

	private bool PowerupComboCheck()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
