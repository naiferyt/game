using System.Collections.Generic;
using UnityEngine;

// State of one kart at the start of the last lap (RaceManager.RecordSnapshot), restored by RaceRewind.
// Source listing: recovery/aot_listings/Assembly-CSharp/CarSnapShot.txt
public class CarSnapShot
{
	public string name;

	public Vector3 position;

	public Quaternion rotation;

	// RECUPERADO-AOT CarSnapShot::.ctor token 0x0600024c @0x000e5bf8 (field initializers)
	public int playerMoney = -1;

	public CarProgress prog;

	public List<BaseEffect> effectList = new List<BaseEffect>();

	public List<BaseEffect> powerupHolder = new List<BaseEffect>();

	public CarMetrics metrics;

	public int gimpedPathIndex = -1;

	public int gimpedPointIndex = -1;

	// RECUPERADO-AOT CarSnapShot::AddToEffectList token 0x0600024d @0x000e5ca4
	public void AddToEffectList(BaseEffect eff)
	{
		effectList.Add(eff);
	}

	// RECUPERADO-AOT CarSnapShot::AddEffectToPowerUpholder token 0x0600024e @0x000e5cec
	public void AddEffectToPowerUpholder(BaseEffect eff)
	{
		powerupHolder.Add(eff);
	}
}
