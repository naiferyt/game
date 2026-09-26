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
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	public void AddEffect(BaseEffect newEffect)
	{
	}

	public void RemoveEffect(BaseEffect e)
	{
	}

	public void RemoveAllEffects()
	{
	}

	public bool HasEffect(Type effectType)
	{
		return default(bool);
	}

	public int GetEffectCount(Type effectType)
	{
		return default(int);
	}

	public int GetHighestPoweredEffect(Type effectType)
	{
		return default(int);
	}

	public BaseEffect GetStrongestEffect(Type effectType)
	{
		return default(BaseEffect);
	}

	public bool HasEffectOfLevel(Type effectType, int level)
	{
		return default(bool);
	}

	public BaseEffect GetEffect(int index)
	{
		return default(BaseEffect);
	}

	public List<BaseEffect> GetEffectListCopy()
	{
		return default(List<BaseEffect>);
	}

	public void SetEffectList(List<BaseEffect> list)
	{
	}
}
