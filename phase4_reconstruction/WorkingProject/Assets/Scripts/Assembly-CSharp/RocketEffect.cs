using System.Collections.Generic;
using UnityEngine;

public class RocketEffect : BaseEffect
{
	private const float BATTERY_LAUNCH_DELAY = 0.25f;

	private const float MAX_TARGET_DISTANCE = 150f;

	private GameObject parentObject;

	public bool isReflected;

	private List<GameObject> targetList;

	private float batteryTimer;

	private bool reverse;

	public RocketEffect(GameObject parent)
	{
	}

	public override void Init()
	{
	}

	public override void Shutdown()
	{
	}

	public override bool Stack(BaseEffect second)
	{
		return default(bool);
	}

	public override void Update()
	{
	}

	public override BaseEffect GetEffectSnapShot()
	{
		return default(BaseEffect);
	}

	protected void LaunchRocket(GameObject target)
	{
	}
}
