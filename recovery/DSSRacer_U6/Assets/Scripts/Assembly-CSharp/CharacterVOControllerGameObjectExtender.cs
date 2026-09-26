using UnityEngine;

// GameObject.GetVOController(): the character's voice controller, searched in its children.
// Source listing: recovery/aot_listings/Assembly-CSharp/CharacterVOControllerGameObjectExtender.txt
public static class CharacterVOControllerGameObjectExtender
{
	// RECUPERADO-AOT CharacterVOControllerGameObjectExtender::GetVOController token 0x060002eb @0x000ecc80
	public static CharacterVOController GetVOController(this GameObject go)
	{
		return go.GetComponentInChildren(typeof(CharacterVOController)) as CharacterVOController;
	}
}
