using UnityEngine;

// Mine box.
// Source listing: recovery/aot_listings/Assembly-CSharp/MinePickup.txt
// RECUPERADO-AOT MinePickup::.ctor token 0x06000448 @0x00100688 (trivial constructor)
public class MinePickup : BasePickup
{
	private const float mineDuration = 1f;

	// RECUPERADO-AOT MinePickup::GetTriggeredEffect token 0x06000449 @0x001006bc
	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		MineEffect e = new MineEffect(obj);
		e.power = 1;
		e.time = 1f;
		e.IsMultiLevel = true;
		return e;
	}
}
