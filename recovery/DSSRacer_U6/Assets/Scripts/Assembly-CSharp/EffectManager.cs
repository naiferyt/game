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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public int GetEffectCount(Type effectType)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public int GetHighestPoweredEffect(Type effectType)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public BaseEffect GetStrongestEffect(Type effectType)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool HasEffectOfLevel(Type effectType, int level)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public BaseEffect GetEffect(int index)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public List<BaseEffect> GetEffectListCopy()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void SetEffectList(List<BaseEffect> list)
	{
	}
}
