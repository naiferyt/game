using UnityEngine;

public static class CharacterVOControllerGameObjectExtender
{
	public static CharacterVOController GetVOController(this GameObject go)
	{
		RecoveryPending.Hit("CharacterVOControllerGameObjectExtender.GetVOController");
		return default(CharacterVOController);
	}
}
