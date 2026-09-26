using UnityEngine;

public class BoosterPickup : BasePickup
{
	private const int boosterPower = 50;

	private const float boosterDuration = 6f;

	public override BaseEffect GetTriggeredEffect(GameObject obj)
	{
		return default(BaseEffect);
	}
}
