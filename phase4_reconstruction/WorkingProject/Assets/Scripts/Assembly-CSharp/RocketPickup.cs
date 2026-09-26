using UnityEngine;

public class RocketPickup : BasePickup
{
	private const float rocketDuration = 6f;

	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		return default(BaseEffect);
	}
}
