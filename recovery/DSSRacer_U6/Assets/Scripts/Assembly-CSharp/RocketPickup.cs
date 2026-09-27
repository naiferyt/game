using UnityEngine;

// Rocket box (the code uses 30 s, not the rocketDuration constant).
// Source listing: recovery/aot_listings/Assembly-CSharp/RocketPickup.txt
// RECUPERADO-AOT RocketPickup::.ctor token 0x06000450 @0x00100d70 (trivial constructor)
public class RocketPickup : BasePickup
{
	private const float rocketDuration = 6f;

	// RECUPERADO-AOT RocketPickup::GetTriggeredEffect token 0x06000451 @0x00100da4
	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		RocketEffect e = new RocketEffect(obj);
		e.power = 1;
		e.time = 30f;
		e.IsMultiLevel = true;
		return e;
	}
}
