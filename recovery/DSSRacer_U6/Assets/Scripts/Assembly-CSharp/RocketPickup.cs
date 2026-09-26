using UnityEngine;

public class RocketPickup : BasePickup
{
	private const float rocketDuration = 6f;

	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		RecoveryPending.Hit("RocketPickup.GetTriggeredEffect");
		return default(BaseEffect);
	}
}
