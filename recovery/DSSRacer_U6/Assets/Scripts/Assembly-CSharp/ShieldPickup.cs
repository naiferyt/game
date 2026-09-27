using UnityEngine;

// Shield box.
// Source listing: recovery/aot_listings/Assembly-CSharp/ShieldPickup.txt
// RECUPERADO-AOT ShieldPickup::.ctor token 0x06000452 @0x00100e28 (trivial constructor)
public class ShieldPickup : BasePickup
{
	private const float shieldDuration = 8f;

	// RECUPERADO-AOT ShieldPickup::GetTriggeredEffect token 0x06000453 @0x00100e5c
	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		ShieldEffect e = new ShieldEffect(obj);
		e.power = 3;
		e.time = 8f;
		e.IsMultiLevel = true;
		return e;
	}
}
