using UnityEngine;

public class ShieldPickup : BasePickup
{
	private const float shieldDuration = 8f;

	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		return default(BaseEffect);
	}
}
