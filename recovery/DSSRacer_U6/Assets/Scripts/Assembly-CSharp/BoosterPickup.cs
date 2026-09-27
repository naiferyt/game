using UnityEngine;

// Speed boost box (level-2 capable).
// Source listing: recovery/aot_listings/Assembly-CSharp/BoosterPickup.txt
// RECUPERADO-AOT BoosterPickup::.ctor token 0x06000446 @0x001005d0 (trivial constructor)
public class BoosterPickup : BasePickup
{
	private const int boosterPower = 50;

	private const float boosterDuration = 6f;

	// RECUPERADO-AOT BoosterPickup::GetTriggeredEffect token 0x06000447 @0x00100604
	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		BoosterEffect e = new BoosterEffect(obj);
		e.power = 50;
		e.time = 6f;
		e.IsMultiLevel = true;
		return e;
	}
}
