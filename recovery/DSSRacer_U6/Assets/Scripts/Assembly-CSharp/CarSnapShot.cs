using System.Collections.Generic;
using UnityEngine;

public class CarSnapShot
{
	public string name;

	public Vector3 position;

	public Quaternion rotation;

	public int playerMoney;

	public CarProgress prog;

	public List<BaseEffect> effectList;

	public List<BaseEffect> powerupHolder;

	public CarMetrics metrics;

	public int gimpedPathIndex;

	public int gimpedPointIndex;

	public void AddToEffectList(BaseEffect eff)
	{
	}

	public void AddEffectToPowerUpholder(BaseEffect eff)
	{
	}
}
