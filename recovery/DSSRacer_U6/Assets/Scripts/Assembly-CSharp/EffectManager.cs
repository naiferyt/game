using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundSequencer))]
public class EffectManager : MonoBehaviour
{
	public GameObject rocketEffectPrefab;

	public GameObject mineEffectPrefab;

	public GameObject tripLinePrefab;

	public GameObject mineSpreaderPrefab;

	public GameObject randomShotPrefab;

	public GameObject anchorEffectPrefab;

	private List<BaseEffect> effectList;

	private bool updateLoop;

	private void Update()
	{
		RecoveryPending.Hit("EffectManager.Update");
	}

	private void Start()
	{
		RecoveryPending.Hit("EffectManager.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("EffectManager.FixedUpdate");
	}

	public void AddEffect(BaseEffect newEffect)
	{
		RecoveryPending.Hit("EffectManager.AddEffect");
	}

	public void RemoveEffect(BaseEffect e)
	{
		RecoveryPending.Hit("EffectManager.RemoveEffect");
	}

	public void RemoveAllEffects()
	{
		RecoveryPending.Hit("EffectManager.RemoveAllEffects");
	}

	public bool HasEffect(Type effectType)
	{
		RecoveryPending.Hit("EffectManager.HasEffect");
		return default(bool);
	}

	public int GetEffectCount(Type effectType)
	{
		RecoveryPending.Hit("EffectManager.GetEffectCount");
		return default(int);
	}

	public int GetHighestPoweredEffect(Type effectType)
	{
		RecoveryPending.Hit("EffectManager.GetHighestPoweredEffect");
		return default(int);
	}

	public BaseEffect GetStrongestEffect(Type effectType)
	{
		RecoveryPending.Hit("EffectManager.GetStrongestEffect");
		return default(BaseEffect);
	}

	public bool HasEffectOfLevel(Type effectType, int level)
	{
		RecoveryPending.Hit("EffectManager.HasEffectOfLevel");
		return default(bool);
	}

	public BaseEffect GetEffect(int index)
	{
		RecoveryPending.Hit("EffectManager.GetEffect");
		return default(BaseEffect);
	}

	public List<BaseEffect> GetEffectListCopy()
	{
		RecoveryPending.Hit("EffectManager.GetEffectListCopy");
		return default(List<BaseEffect>);
	}

	public void SetEffectList(List<BaseEffect> list)
	{
		RecoveryPending.Hit("EffectManager.SetEffectList");
	}
}
