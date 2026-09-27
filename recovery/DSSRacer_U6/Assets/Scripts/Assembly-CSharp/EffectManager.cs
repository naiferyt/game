using System;
using System.Collections.Generic;
using UnityEngine;

// Per-kart list of active effects (boost, slowdown, wipeout, skid, power-ups...): updates and times them
// out, stacks same-type effects, and answers the queries CarCollider and the HUD make.
// Source listing: recovery/aot_listings/Assembly-CSharp/EffectManager.txt
// (Adelantado de la Etapa 4 en 3.9: las tiras de turbo, zonas de wipeout/frenado y los choques de la
// carrera pasan por aquí.)
[RequireComponent(typeof(SoundSequencer))]
public class EffectManager : MonoBehaviour
{
	public GameObject rocketEffectPrefab;

	public GameObject mineEffectPrefab;

	public GameObject tripLinePrefab;

	public GameObject mineSpreaderPrefab;

	public GameObject randomShotPrefab;

	public GameObject anchorEffectPrefab;

	// RECUPERADO-AOT EffectManager::.ctor token 0x06000369 @0x000f2508 (field initializer)
	private List<BaseEffect> effectList = new List<BaseEffect>();

	private bool updateLoop;

	// RECUPERADO-AOT EffectManager::Update token 0x0600036a @0x000f2570
	// Updates every effect; those whose time ran out (float.MinValue = no time limit) are removed and shut
	// down after the pass (RemoveEffect only zeroes their time while the pass runs).
	private void Update()
	{
		if (RaceManager.Exists && RaceManager.isPaused)
		{
			return;
		}
		List<BaseEffect> list = new List<BaseEffect>();
		updateLoop = true;
		foreach (BaseEffect effect in effectList)
		{
			effect.Update();
			if (!(effect.time > 0f) && effect.time != float.MinValue)
			{
				list.Add(effect);
			}
		}
		updateLoop = false;
		foreach (BaseEffect item in list)
		{
			effectList.Remove(item);
			item.Shutdown();
		}
	}

	// RECUPERADO-AOT EffectManager::Start token 0x0600036b @0x000f283c (empty)
	private void Start()
	{
	}

	// RECUPERADO-AOT EffectManager::FixedUpdate token 0x0600036c @0x000f2868
	private void FixedUpdate()
	{
		if (RaceManager.Exists && RaceManager.isPaused)
		{
			return;
		}
		foreach (BaseEffect effect in effectList)
		{
			effect.FixedUpdate();
			if (effect.time != float.MinValue)
			{
				effect.time -= Time.deltaTime;
			}
		}
	}

	// RECUPERADO-AOT EffectManager::AddEffect token 0x0600036d @0x000f29b8
	// A flip, jump, slowdown or wipeout knocks the kart off a rocket ride. An effect of a type already
	// present is offered to it (Stack) and only added when that returns true.
	public void AddEffect(BaseEffect newEffect)
	{
		bool flag = true;
		if (HasEffect(typeof(RocketRideEffect)) && (newEffect.effectType == BaseEffect.EffectTypes.FlipEffect || newEffect.effectType == BaseEffect.EffectTypes.GuidedJumpEffect || newEffect.effectType == BaseEffect.EffectTypes.SlowdownEffect || newEffect.effectType == BaseEffect.EffectTypes.WipeoutEffect))
		{
			RocketRideEffect rocketRideEffect = GetStrongestEffect(typeof(RocketRideEffect)) as RocketRideEffect;
			if (rocketRideEffect != null)
			{
				rocketRideEffect.DetachFromRocket();
				RemoveEffect(rocketRideEffect);
			}
		}
		foreach (BaseEffect effect in effectList)
		{
			if (effect.GetType() == newEffect.GetType())
			{
				flag = effect.Stack(newEffect);
				break;
			}
		}
		if (flag)
		{
			effectList.Add(newEffect);
			newEffect.Init();
		}
	}

	// RECUPERADO-AOT EffectManager::RemoveEffect token 0x0600036e @0x000f2c38
	public void RemoveEffect(BaseEffect e)
	{
		if (effectList.Contains(e))
		{
			if (!updateLoop)
			{
				effectList.Remove(e);
				e.Shutdown();
			}
			else
			{
				e.time = 0f;
			}
		}
	}

	// RECUPERADO-AOT EffectManager::RemoveAllEffects token 0x0600036f @0x000f2ccc
	// Expires everything on the next Update; rocket rides let go of their rocket now.
	public void RemoveAllEffects()
	{
		if (effectList.Count <= 0)
		{
			return;
		}
		foreach (BaseEffect effect in effectList)
		{
			effect.time = 0f;
			if (effect.effectType == BaseEffect.EffectTypes.RocketRideEffect)
			{
				(effect as RocketRideEffect).DetachFromRocket();
			}
		}
	}

	// RECUPERADO-AOT EffectManager::HasEffect token 0x06000370 @0x000f2e8c
	public bool HasEffect(Type effectType)
	{
		foreach (BaseEffect effect in effectList)
		{
			if (effect.GetType() == effectType)
			{
				return true;
			}
		}
		return false;
	}

	// RECUPERADO-AOT EffectManager::GetEffectCount token 0x06000371 @0x000f2ff0
	public int GetEffectCount(Type effectType)
	{
		int num = 0;
		foreach (BaseEffect effect in effectList)
		{
			if (effect.GetType() == effectType)
			{
				num++;
			}
		}
		return num;
	}

	// RECUPERADO-AOT EffectManager::GetHighestPoweredEffect token 0x06000372 @0x000f3144
	public int GetHighestPoweredEffect(Type effectType)
	{
		int num = 0;
		foreach (BaseEffect effect in effectList)
		{
			if (effect.GetType() == effectType && effect.power > num)
			{
				num = effect.power;
			}
		}
		return num;
	}

	// RECUPERADO-AOT EffectManager::GetStrongestEffect token 0x06000373 @0x000f32a4
	public BaseEffect GetStrongestEffect(Type effectType)
	{
		int num = 0;
		BaseEffect result = null;
		foreach (BaseEffect effect in effectList)
		{
			if (effect.GetType() == effectType && effect.power >= num)
			{
				num = effect.power;
				result = effect;
			}
		}
		return result;
	}

	// RECUPERADO-AOT EffectManager::HasEffectOfLevel token 0x06000374 @0x000f3410
	public bool HasEffectOfLevel(Type effectType, int level)
	{
		foreach (BaseEffect effect in effectList)
		{
			if (effect.GetType() == effectType && effect.PowerLevel == level)
			{
				return true;
			}
		}
		return false;
	}

	// RECUPERADO-AOT EffectManager::GetEffect token 0x06000375 @0x000f3588
	public BaseEffect GetEffect(int index)
	{
		if (effectList[index] != null)
		{
			return effectList[index];
		}
		return null;
	}

	// RECUPERADO-AOT EffectManager::GetEffectListCopy token 0x06000376 @0x000f35f8
	public List<BaseEffect> GetEffectListCopy()
	{
		BaseEffect[] array = new BaseEffect[effectList.Count];
		effectList.CopyTo(array);
		List<BaseEffect> list = new List<BaseEffect>();
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(array[i]);
		}
		return list;
	}

	// RECUPERADO-AOT EffectManager::SetEffectList token 0x06000377 @0x000f36f4
	public void SetEffectList(List<BaseEffect> list)
	{
		if (list != null)
		{
			effectList = list;
		}
	}
}
