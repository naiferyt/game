using UnityEngine;

public class MinePickup : BasePickup
{
	private const float mineDuration = 1f;

	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		RecoveryPending.Hit("MinePickup.GetTriggeredEffect");
		return default(BaseEffect);
	}
}
